﻿using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;

using BeautyPlanet.Models;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AppointmentController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CostomServiceImage/" + name;
        }
        [HttpPost("send-notification-to-user")]
        public async Task<IActionResult> SendNotificationUser([FromBody] NotificationDTO request)
        {
            var message = new Message
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = request.Title,
                    Body = request.Body,
                },
                Token = request.DeviceToken,
            };

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                var notifi = _mapper.Map<Models.Notification>(request);
                await _unitOfWork.Notification.Insert(notifi);
                await _unitOfWork.Save();
                return Ok(new { Message = "Notification sent successfully.", Response = response });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to send notification: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromForm] AppointmentFile appointment)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            var user = await _unitOfWork.User.Get(q => q.Id.Equals(appointment.AppointmentDTO.UserId));
            if (appointment.AppointmentDTO.SpecialistId != null && appointment.AppointmentDTO.ServiceId != null)
            {
                var sp = await _unitOfWork.ServiceSpecialist.Get(q => q.SpecialistId.Equals(appointment.AppointmentDTO.SpecialistId) && q.ServiceId == appointment.AppointmentDTO.ServiceId, include: x => x.Include(q => q.Specialist).Include(s => s.Service));

                var service = await _unitOfWork.Service.Get(q => q.Id == appointment.AppointmentDTO.ServiceId);
                var center = await _unitOfWork.Center.Get(q => q.Id == appointment.AppointmentDTO.CenterId);

                var app = _mapper.Map<Appointment>(appointment.AppointmentDTO);
                app.EndTime = app.StartTime.Add(service.Duration).AddMinutes(10);
                app.StatusId = 1;
                await _unitOfWork.Appointment.Insert(app);
                await _unitOfWork.Save();

                d.Add("Message", "Appointment succeded");
                NotificationDTO notification1 = new NotificationDTO();
                notification1.Title = "Appintment Details";
                notification1.Body = $"appointment Time: {app.StartTime}\n for user : {user.FirstName + " " + user.LastName}\n Service Nmae:{service.Name}";
                notification1.DeviceToken =sp.Specialist.DeviceTokken ;
                notification1.CenterImage = center.ImageUrl;
                notification1.CenterName=center.Name;
                //notification1.ServiceId = 1;
                await SendNotificationUser(notification1);
                NotificationDTO notification=new NotificationDTO();
                notification.Title = "Appintment Details";
                notification.Body = $"appointment Time: {app.StartTime}\n Center Name:{center.Name}\n specialist Name :{sp.Specialist.FirstName + " " + sp.Specialist.LastName}\n service name :{service.Name}";
                notification.DeviceToken = user.DeviceTokken;
                notification.CenterImage = center.ImageUrl;
                notification.CenterName = center.Name;
                //notification.ServiceId = 1;
                await SendNotificationUser(notification);
                return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Appointment succeded", Status = true });
            }

            else if (appointment.AppointmentDTO.ServiceId == null && appointment.Files != null && appointment.AppointmentDTO.SpecialistId == null)
            {
                var spp = await _unitOfWork.Specialist.GetAll(q => q.CenterId == appointment.AppointmentDTO.CenterId && q.CategoryId == appointment.AppointmentDTO.CategoryId);
                var m = _mapper.Map<List<GetSpecialistDTO>>(spp);

                while (appointment.AppointmentDTO.SpecialistId == null)
                {
                    if (!m.Any())
                    {
                        break;
                    }
                    var rand = GetRandomValue(m);

                    appointment.AppointmentDTO.SpecialistId = await IsFree(rand.Id, appointment.AppointmentDTO.StartTime);
                    var remove = m.Single(q => q.Id.Equals(rand.Id));
                    m.Remove(remove);


                }
                string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {

                    string FilePath = GetFilePath(appointment.AppointmentDTO.CostomServiceName.Replace(" ", "_"));
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + appointment.Files.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await appointment.Files.CopyToAsync(stream);
                        // var spcialist = await _unitOfWork.Specialist.Get(q => q.Id.Equals(sp.SpecialistId));
                       var center = await _unitOfWork.Center.Get(q => q.Id == appointment.AppointmentDTO.CenterId);
                        var s = await _unitOfWork.Specialist.Get(q => q.Equals(appointment.AppointmentDTO.SpecialistId));
                        //var service = await _unitOfWork.Service.Get(q => q.Id == appointment.AppointmentDTO.ServiceId);
                        var result = _mapper.Map<Appointment>(appointment.AppointmentDTO);
                        result.ImageUrl = hosturl + "/Upload/CostomServiceImage/" + appointment.Files.FileName.Replace(" ", "_") + "/" + appointment.Files.FileName;
                        result.StatusId = 1;
                        result.EndTime = result.StartTime.AddHours(1).AddMinutes(10);
                        result.SpecialistId = appointment.AppointmentDTO.SpecialistId;
                        await _unitOfWork.Appointment.Insert(result);
                        await _unitOfWork.Save();
                        d.Add("Message", "Appointment succeded");
                        NotificationDTO notification1 = new NotificationDTO();
                        notification1.Title = "Appintment Details";
                        notification1.Body = $"appointment Time: {result.StartTime}\n for user : {user.FirstName + " " + user.LastName}\n With CostomService Name: {result.CostomServiceName}\n and details is:{result.description}";
                        notification1.DeviceToken = s.DeviceTokken;
                        notification1.CenterImage = center.ImageUrl;
                        notification1.CenterName = center.Name;
                        //      notification1.ServiceId = 1;
                        await SendNotificationUser(notification1);
                        NotificationDTO notification = new NotificationDTO();
                        notification.Title = "Appintment Details";
                        notification.Body = $"appointment Time: {result.StartTime}\n Center Name:{center.Name}\n specialist Name :{s.FirstName + " " + s.LastName}\n With CostomService name :{appointment.AppointmentDTO.CostomServiceName}";
                        notification.DeviceToken = user.DeviceTokken;
                        notification.CenterImage = center.ImageUrl;
                        notification.CenterName = center.Name;
                        //notification.ServiceId = 1;
                        await SendNotificationUser(notification);

                        return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Appointment succeded", Status = true });
                    }

                }
                catch (Exception e)
                {
                    d.Add("Message", "Appointment Faild");
                    return NotFound(d);
                }

            }
            else if (appointment.AppointmentDTO.ServiceId == null && appointment.Files != null && appointment.AppointmentDTO.SpecialistId != null)
            {

                string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {

                    string FilePath = GetFilePath(appointment.AppointmentDTO.CostomServiceName.Replace(" ", "_"));
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + appointment.Files.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await appointment.Files.CopyToAsync(stream);
                        // var spcialist = await _unitOfWork.Specialist.Get(q => q.Id.Equals(sp.SpecialistId));
                        var center = await _unitOfWork.Center.Get(q=>q.Id==appointment.AppointmentDTO.CenterId);
                        
                        var s = await _unitOfWork.Specialist.Get(q => q.Equals(appointment.AppointmentDTO.SpecialistId));
                        var result = _mapper.Map<Appointment>(appointment.AppointmentDTO);
                        result.ImageUrl = hosturl + "/Upload/CostomServiceImage/" + appointment.Files.FileName.Replace(" ", "_") + "/" + appointment.Files.FileName;
                        result.StatusId = 1;
                        result.EndTime = result.StartTime.AddHours(1).AddMinutes(10);
                        // result.SpecialistId = appointment.AppointmentDTO.SpecialistId;
                        await _unitOfWork.Appointment.Insert(result);
                        await _unitOfWork.Save();
                        d.Add("Message", "Appointment succeded");
                        NotificationDTO notification1 = new NotificationDTO();
                        notification1.Title = "Appintment Details";
                        notification1.Body = $"appointment Time: {result.StartTime}\n for user : {user.FirstName + " " + user.LastName}\n With CostomService Name: {result.CostomServiceName}\n and details is:{result.description}";
                        notification1.DeviceToken = s.DeviceTokken;
                        notification1.CenterImage = center.ImageUrl;
                        notification1.CenterName = center.Name;
                        await SendNotificationUser(notification1);
                        NotificationDTO notification = new NotificationDTO();
                        notification.Title = "Appintment Details";
                        notification.Body = $"appointment Time: {result.StartTime}\n Center Name:{center.Name}\n specialist Name :{s.FirstName + " " + s.LastName}\n With CostomService name :{appointment.AppointmentDTO.CostomServiceName}";
                        notification.DeviceToken = user.DeviceTokken;
                        notification.CenterImage = center.ImageUrl;
                            notification.CenterName = center.Name;
                        //notification.ServiceId = 1;
                        await SendNotificationUser(notification);

                        return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Appointment succeded", Status = true });
                    }

                }
                catch (Exception e)
                {
                    d.Add("Message", "Appointment Faild");
                    return NotFound(e);
                }

            }

            else
            {

                var sp = await _unitOfWork.ServiceSpecialist.GetAll(q => q.Specialist.CenterId == appointment.AppointmentDTO.CenterId && q.Specialist.CategoryId == appointment.AppointmentDTO.CategoryId && q.ServiceId == appointment.AppointmentDTO.ServiceId, include: x => x.Include(q => q.Specialist).Include(s => s.Service));

                var m = _mapper.Map<List<GetSp>>(sp);

                while (appointment.AppointmentDTO.SpecialistId == null)
                {
                    if (!m.Any())
                    {
                        break;
                    }
                    var rand = GetRandomValue(m);

                    appointment.AppointmentDTO.SpecialistId = await IsFree(rand.Specialist.Id, appointment.AppointmentDTO.StartTime);
                    var remove = m.Single(q => q.Specialist.Id.Equals(rand.Specialist.Id));
                    m.Remove(remove);


                }
                var service = await _unitOfWork.Service.Get(q => q.Id == appointment.AppointmentDTO.ServiceId);

                if (appointment.AppointmentDTO.SpecialistId != null)
                {
                    var s = await _unitOfWork.Specialist.Get(q => q.Equals(appointment.AppointmentDTO.SpecialistId));
                    var center = await _unitOfWork.Center.Get(q => q.Id == appointment.AppointmentDTO.CenterId);
                  //  var user = await _unitOfWork.User.Get(q => q.Id.Equals(appointment.AppointmentDTO.UserId));
                    var app = _mapper.Map<Appointment>(appointment.AppointmentDTO);
                    app.SpecialistId = appointment.AppointmentDTO.SpecialistId;
                    app.EndTime = app.StartTime.Add(service.Duration).AddMinutes(10);
                    app.StatusId = 1;
                    await _unitOfWork.Appointment.Insert(app);
                    await _unitOfWork.Save();
                    d.Add("Message", "Appointment succeded");
                    NotificationDTO notification1 = new NotificationDTO();
                    notification1.Title = "Appintment Details";
                    notification1.Body = $"appointment Time: {app.StartTime}\n for user : {user.FirstName+" "+user.LastName}";
                    notification1.DeviceToken = s.DeviceTokken;
                    notification1.CenterImage = center.ImageUrl;
                    notification1.CenterName = center.Name;
                    await SendNotificationUser(notification1);
                    NotificationDTO notification = new NotificationDTO();
                    notification.Title = "Appintment Details";
                    notification.Body = $"appointment Time: {app.StartTime}\n Center Name:{center.Name}\n specialist Name :{s.FirstName + " " + s.LastName}\n service name :{service.Name}";
                    notification.DeviceToken = user.DeviceTokken;
                    notification.CenterImage = center.ImageUrl;
                    notification.CenterName = center.Name;
                    // notification.ServiceId = 1;
                    await SendNotificationUser(notification);

                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Appointment succeded", Status = true });
                }

                else {
                    d.Add("Message", "No Specialist free ");
                    return NotFound(d); }
            }
        }
        [NonAction]
        private async Task<string> IsFree(string spId, DateTime dt)
        {
            var times = new List<DateTime>();
            //DateTime dt = DateTime.Now;
            var sp = await _unitOfWork.Specialist.Get(q => q.Id.Equals(spId), include: x => x.Include(a => a.Appointments).Include(c => c.Center));
            int f = 0;
            foreach (var s in sp.Center.WorkingTime)
            {
                var work = ParseWorkingHours(s);
                var time = GenerateTimeSlots(DateTime.Now, DateTime.Now.AddMonths(2), work.Item2, work.Item3, work.Item1, 15);
                foreach (var t in time)
                {
                    f = 0;
                    foreach (var st in sp.Appointments)
                    {
                        if (t >= st.StartTime && t < st.EndTime)
                        {
                            f = 1;
                            break;
                        }

                    }
                    if (f == 0)
                    {
                        times.Add(t);

                    }

                }

            }
            times.Sort();
            foreach (var g in times)
            {
                if (g.Date == dt.Date)
                {
                    if (g.TimeOfDay == dt.TimeOfDay)
                        return sp.Id;
                }
            }

            return null;


        }
        [NonAction]
        static T GetRandomValue<T>(List<T> list)
        {
            Random random = new Random();
            int index = random.Next(0, list.Count - 1);
            return list[index];
        }
        [HttpGet("MyTest")]
        public async Task<IActionResult> GetAppointmentsTest()
        {
            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(c => c.Center).Include(cc => cc.Category).Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var map = _mapper.Map<IList<GetAppointment>>(appointment);
            return Ok(map);
        }

        [HttpGet("AllAppointment")]
        public async Task<IActionResult> GetAllAppointment()
        {

            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status).Include(c => c.Center).Include(ca => ca.Category));

            //foreach (Appointment a in appointment)
            //{
            //    var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
            //    var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
            //    var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
            //    var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
            //      app.Add(new GetAppointment {Id=a.Id,StartTime=a.StartTime,EndTime=a.EndTime,Status=a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            //}
            var map = _mapper.Map<IList<GetAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;

            }
            return Ok(map);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllUserAppointment(String UserId)
        {

            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(UserId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status).Include(c => c.Center).Include(ca => ca.Category));

            //foreach (Appointment a in appointment)
            //{
            //    var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
            //    var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
            //    var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
            //    var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
            //      app.Add(new GetAppointment {Id=a.Id,StartTime=a.StartTime,EndTime=a.EndTime,Status=a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            //}
            var map = _mapper.Map<IList<GetAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;

            }
            return Ok(map);
        }
        [HttpGet("DashAllAppointment")]
        public async Task<IActionResult> GetAllDashAppointment()
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var map = _mapper.Map<IList<GetDashAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;
            }

            return Ok(map);
        }
        [HttpGet("DashUserId/{DashUserId}")]
        public async Task<IActionResult> GetAllDashUserAppointment(String DashUserId)
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            // var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(DashUserId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(DashUserId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var map = _mapper.Map<IList<GetDashAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;
            }

            return Ok(map);
        }
        [HttpGet("DashAppointmentByStatus")]
        public async Task<IActionResult> GetAllDashAppointment(int status, string userId)
        {

            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StatusId == status && q.UserId.Equals(userId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var map = _mapper.Map<IList<GetDashAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;
            }

            return Ok(map);
        }

        [HttpGet("AppointmentByStatus")]
        public async Task<IActionResult> GetAllAppointment(int status, string userId)
        {


            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StatusId == status && q.UserId.Equals(userId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status).Include(c => c.Center).Include(ca => ca.Category), orderBy: o => o.OrderBy(a => a.StartTime));

            //foreach (Appointment a in appointment)
            //{
            //    var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
            //    var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
            //    var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
            //    var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
            //      app.Add(new GetAppointment {Id=a.Id,StartTime=a.StartTime,EndTime=a.EndTime,Status=a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            //}
            var map = _mapper.Map<IList<GetAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;

            }
            return Ok(map);
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int id, int status)
        {
            try
            {

                var app = await _unitOfWork.Appointment.Get(q => q.Id == id, include: x => x.Include(s => s.Status));
                if (app.EndTime.Date < DateTime.Now.Date)
                {
                    app.Status.Id = 2;
                    _unitOfWork.Appointment.Update(app);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Change", Status = true, appointment = true });
                }
                var user = await _unitOfWork.User.Get(q => q.Id.Equals(app.UserId), include: a => a.Include(x => x.Appointments).ThenInclude(s => s.Status));
                var ap = user.Appointments.OrderBy(a => a.StartTime).ToList().LastOrDefault();
                TimeSpan timeDifference = app.StartTime - DateTime.Now;
                TimeSpan t = new TimeSpan(1, 0, 0);
                if (status == 3)
                {
                    if (timeDifference >= t)
                    {
                        app.StatusId = status;
                        if (ap.Status.Id == 3)
                        {
                            user.CancelDate.Add(DateTime.Now);

                            _unitOfWork.Appointment.Update(app);
                            await _unitOfWork.Save();
                            return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Change", Status = true, appointment = true });
                        }
                        else
                        {
                            user.CancelDate.Clear();
                            _unitOfWork.Appointment.Update(app);
                            await _unitOfWork.Save();
                            return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Change", Status = true,appointment = true });
                        }
                    }
                    else
                    {
                        return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Can not cancel appointment in this time pleas Contact the manager ", Status = true, appointment = false });
                    }
                } else
                {
                    app.Status.Id = status;
                    _unitOfWork.Appointment.Update(app);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Change", Status = true ,appointment=true});
                }
            }



            catch (Exception e)
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("Message", "some thing erroe in change");
                return BadRequest(pairs);
            }
        }
   
        [HttpPut("ChangeEndTime")]
        public async Task<IActionResult> ChangeEndTime(int id, DateTime t)
        {
            var app = await _unitOfWork.Appointment.Get(q => q.Id == id);
            app.EndTime = t;
            _unitOfWork.Appointment.Update(app);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("GetAllCategoryByCenter")]
        public async Task<IActionResult> GetAllCategoryByCenter(int centerId)
        {
            var category = await _unitOfWork.CenterCategory.GetAll(q => q.CenterId == centerId, include: x => x.Include(x => x.Category).ThenInclude(s => s.Services));
            var Cat = _mapper.Map<IList<GetCenterCategoryDTO>>(category);
            foreach (var c in category)
            {
                var s = c.Category.Services.Count;
                Cat.Where(x => x.Category.Id == c.CategoryId).ToList().ForEach(x => x.Category.ServiceCount = s);


            }
            return Ok(Cat);
        }
        [HttpGet("GetServiceByCategory")]
        public async Task<IActionResult> GetServiceByCategory(int centerId, int categoryId)
        {
            var cercat = await _unitOfWork.CenterCategory.Get(q => q.CategoryId == categoryId && q.CenterId == centerId, include: x => x.Include(s => s.Category));
            var service = await _unitOfWork.Service.GetAll(q => q.CategoryId == cercat.CategoryId,include:x=>x.Include(ce=>ce.Centers));
            var map = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(map);
        }
        [HttpGet("GetSpecealistbyService")]
        public async Task<IActionResult> GetSpecealistbyService(int serviceId, int centerId)
        {
            var sp = await _unitOfWork.ServiceSpecialist.GetAll(q => q.ServiceId == serviceId && q.Specialist.CenterId == centerId, include: c => c.Include(s => s.Specialist).ThenInclude(c => c.Center));
           
            var map = _mapper.Map<IList<GetSp>>(sp);
            
            return Ok(map);
        }
        [HttpGet("GetSpecealistbyCategory")]
        public async Task<IActionResult> GetSpecealistbyCategory(int caegoryId, int centerId)
        {
            var sp = await _unitOfWork.Specialist.GetAll(q => q.CategoryId == caegoryId && q.CenterId == centerId,include:x=>x.Include(c=>c.Center));
            var map = _mapper.Map<IList<GetSpecialistDTO>>(sp);
            IList<GetSp>GetSp=new List<GetSp>();
            foreach (var item in map)
            {
                GetSp.Add(new GetSp { Specialist = item });
            }
            return Ok(GetSp);
        }

        [HttpGet("GetFreeDaySpecealist")]
        public async Task<IActionResult> GetSpecealistFreeDay(string spId)
        {
            //var all = new List<List<DateTime>>();
            var times = new List<DateTime>();
            var sp = await _unitOfWork.Specialist.Get(q => q.Id.Equals(spId), include: x => x.Include(a => a.Appointments.Where(s=>s.StatusId!=3)).Include(c => c.Center));
            int f = 0;
            foreach (var s in sp.Center.WorkingTime)
            {
                var work = ParseWorkingHours(s);
                var time = GenerateTimeSlots(DateTime.Now, DateTime.Now.AddMonths(2), work.Item2, work.Item3, work.Item1, 15);
                foreach (var t in time)
                {
                    f = 0;
                    foreach (var st in sp.Appointments)
                    {
                        if (t >= st.StartTime && t < st.EndTime)
                        {
                            f = 1;
                            break;
                        }

                    }
                    if (f == 0)
                    {
                        times.Add(t.Date.Date);

                    }

                }

            }
           var list= times.Distinct().ToList();
            list.Sort();
           // List<TimeSpan> ss = new List<TimeSpan>();
           //foreach(var r in times)
           // {
               
           //     if (r.Date==d.Date)
           //     {
           //         ss.Add(r.TimeOfDay);
           //     }
           // }
            Dictionary<string,List<DateTime>>map = new Dictionary<string,List<DateTime>>();
            map.Add("Times:", list);

            return Ok(map);
        }
        [HttpGet("GetFreeHoursSpecealist")]
        public async Task<IActionResult> GetSpecealistFreeHour(string spId, DateTime d)
        {
            //var all = new List<List<DateTime>>();
            var times = new List<DateTime>();
            DateTime dt = DateTime.Now;
            var sp = await _unitOfWork.Specialist.Get(q => q.Id.Equals(spId), include: x => x.Include(a => a.Appointments.Where(s=>s.StatusId!=3)).Include(c => c.Center));
            int f = 0;
            foreach (var s in sp.Center.WorkingTime)
            {
                var work = ParseWorkingHours(s);
                var time = GenerateTimeSlots(DateTime.Now, DateTime.Now.AddMonths(2), work.Item2, work.Item3, work.Item1, 15);
                foreach (var t in time)
                {
                    f = 0;
                    foreach (var st in sp.Appointments)
                    {
                        if (t >= st.StartTime && t < st.EndTime)
                        {
                            f = 1;
                            break;
                        }

                    }
                    if (f == 0)
                    {
                        times.Add(t);

                    }

                }

            }
             times.Sort();
            List<TimeSpan> ss = new List<TimeSpan>();
            foreach (var r in times)
            {

                if (r.Date == d.Date)
                {
                    ss.Add(r.TimeOfDay);
                }
            }
            Dictionary<string, List<TimeSpan>> map = new Dictionary<string, List<TimeSpan>>();
            map.Add("Times:", ss);

            return Ok(map);
        }
        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var center = await _unitOfWork.Appointment.Get(q => q.Id == id);


            if (center == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Appointment.Delete(id);
                await _unitOfWork.Save();


                return Ok();
            }
        }
        [NonAction]
        private (List<DayOfWeek>, TimeSpan, TimeSpan) ParseWorkingHours(string workingHours)
        {
            var parts = workingHours.Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 4)
            {
                throw new ArgumentException("Invalid working hours format. Expected format: 'monday - friday : 08:00 am - 10:00 pm'");
            }

            var startDay = parts[0].Trim();
            var endDay = parts[1].Trim();
            var startTimeString = parts[2].Trim();
            var endTimeString = parts[3].Trim();

            var startDayOfWeek = Enum.Parse<DayOfWeek>(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(startDay.ToLower()));
            var endDayOfWeek = Enum.Parse<DayOfWeek>(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(endDay.ToLower()));

            var workingDays = new List<DayOfWeek>();
            if (startDayOfWeek <= endDayOfWeek)
            {
                workingDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
                                  .Where(d => d >= startDayOfWeek && d <= endDayOfWeek)
                                  .ToList();
            }
            else
            {
                workingDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>()
                                  .Where(d => d >= startDayOfWeek || d <= endDayOfWeek)
                                  .ToList();
            }

            var startTime = DateTime.Parse(startTimeString).TimeOfDay;
            var endTime = DateTime.Parse(endTimeString).TimeOfDay;

            return (workingDays, startTime, endTime);
        }
        [NonAction]
        private TimeSpan ParseTime(string timeString)
        {
            try
            {
                var formats = new[] { "h:mm tt", "hh:mm tt" };
                var time = DateTime.ParseExact(timeString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
                return time.TimeOfDay;
            }
            catch (Exception ex)
            {
                throw new FormatException($"Invalid time format: {timeString}. Expected format: 'hh:mm tt' or 'h:mm tt'.", ex);
            }
        }

        [NonAction]
        private List<DateTime> GenerateTimeSlots(DateTime startTime, DateTime endTime, TimeSpan startT, TimeSpan endT, List<DayOfWeek> d, int durationInMinutes)
        {
            var timeSlots = new List<DateTime>();

            var holidays = GetHolidays();

            for (var date = startTime.Date; date <= endTime.Date; date = date.AddDays(1))
            {
                if (d.Contains(date.DayOfWeek) && !holidays.Contains(date))
                {
                    var currentDateTime = date.Add(startT);
                    var endOfDay = date.Add(endT);

                    while (currentDateTime < endOfDay)
                    {
                        timeSlots.Add(currentDateTime);
                        currentDateTime = currentDateTime.AddMinutes(durationInMinutes);
                    }
                }
            }
            return timeSlots;
        }
        [HttpPost("GetTimeOnly")]
        public ActionResult<TimeSpan> IsWeekend([FromForm] TimeSpan date)
        {

            return date;
        }
        [NonAction]
        private List<DateTime> GetHolidays()
        {
            return new List<DateTime>
        {
            new DateTime(2024, 1, 1),  // New Year's Day
            new DateTime(2024, 12, 25), // Christmas Day
            // Add other holidays here
        };
        }
        [HttpGet("GetAllFreeDaySpecealist")]
        public async Task<IActionResult> GetAllSpecealistFreeDay(int centerID,int categoryId)
        {
            //var all = new List<List<DateTime>>();
            var times = new List<DateTime>();
            var timesostime=new List<DateTime>();
            var sp = await _unitOfWork.Specialist.GetAll( q=>q.CenterId==centerID&&q.CategoryId==categoryId,include: x => x.Include(a => a.Appointments).Include(c => c.Center));
            int f = 0;
            foreach (var sss in sp)
            {
                foreach (var s in sss.Center.WorkingTime)
                {
                    var work = ParseWorkingHours(s);
                    var time = GenerateTimeSlots(DateTime.Now, DateTime.Now.AddMonths(2), work.Item2, work.Item3, work.Item1, 15);
                    foreach (var t in time)
                    {
                        f = 0;
                        foreach (var st in sss.Appointments)
                        {
                            if (t >= st.StartTime && t < st.EndTime)
                            {
                                f = 1;
                                break;
                            }

                        }
                        if (f == 0&& !times.Contains(t.Date.Date))
                        {
                            times.Add(t.Date.Date);

                        }

                    }

                }
                
            }
            var list = times.Distinct().ToList();
            list.Sort();
            // List<TimeSpan> ss = new List<TimeSpan>();
            //foreach(var r in times)
            // {

            //     if (r.Date==d.Date)
            //     {
            //         ss.Add(r.TimeOfDay);
            //     }
            // }
            Dictionary<string, List<DateTime>> map = new Dictionary<string, List<DateTime>>();
            map.Add("Times:", list);

            return Ok(map);
        }
        [HttpGet("GetAllFreeHoursSpecealist")]
        public async Task<IActionResult> GetAllSpecealistFreeHour(int centerId,int categoryId, DateTime d)
        {
            //var all = new List<List<DateTime>>();
            var times = new List<DateTime>();
            DateTime dt = DateTime.Now;
            var sp = await _unitOfWork.Specialist.GetAll(q=>q.CenterId==centerId&&q.CategoryId == categoryId, include: x => x.Include(a => a.Appointments).Include(c => c.Center));
            int f = 0;
            foreach (var sss in sp)
            {
                foreach (var s in sss.Center.WorkingTime)
                {
                    var work = ParseWorkingHours(s);
                    var time = GenerateTimeSlots(DateTime.Now, DateTime.Now.AddMonths(2), work.Item2, work.Item3, work.Item1, 15);
                    foreach (var t in time)
                    {
                        f = 0;
                        foreach (var st in sss.Appointments)
                        {
                            if (t >= st.StartTime && t < st.EndTime)
                            {
                                f = 1;
                                break;
                            }

                        }
                        if (f == 0)
                        {
                            times.Add(t);

                        }

                    }

                }
            }
            var list = times.Distinct().ToList();
            times.Sort();
            List<TimeSpan> ss = new List<TimeSpan>();
            foreach (var r in times)
            {

                if (r.Date == d.Date&&r.TimeOfDay>dt.TimeOfDay)
                {
                    ss.Add(r.TimeOfDay);
                }
            }
            Dictionary<string, List<TimeSpan>> map = new Dictionary<string, List<TimeSpan>>();
            map.Add("Times:", ss);

            return Ok(map);
        }
        [HttpGet("GetUserBand")]
        public  async Task<IActionResult> GetUserBand(string userId,DateTime starttime ,DateTime endtime)
        {
            var user = await _unitOfWork.User.Get(q => q.Id.Equals(userId), include: x => x.Include(a => a.Appointments));
            if (user.CancelDate.Count >= 3)
            {
                return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "You Are Baned For AMonth", Status = false });
            }
            else return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "You Can Booked Appointment", Status = true });
        }
        [HttpGet("ServicePerDay/{serviceid}/{startDayOfMonth}/{endDayOfMonth}")]
        public async Task<IActionResult> ServicePerDay(int serviceid, DateTime startDayOfMonth, DateTime endDayOfMonth)
        {
            Dictionary<DateTime,int >pairs=new Dictionary<DateTime,int>();
            var service = await _unitOfWork.Appointment.GetAll(q => q.StartTime.Date >= startDayOfMonth.Date && q.StartTime.Date <= endDayOfMonth.Date &&q.ServiceId == serviceid, include: s => s.Include(c => c.Service));
            for (var date = startDayOfMonth; date <= endDayOfMonth; date = date.AddDays(1))
            {
                pairs.Add(date.Date, service.Where(s => s.StartTime.Date == date.Date).ToList().Count());
            }
            return Ok(pairs);
        }
        [HttpGet("ServiceUpcomming/{serviceid}/{startDayOfMonth}/{endDayOfMonth}")]
        public async Task<IActionResult> ServiceUpcomming(int serviceid, DateTime startDayOfMonth, DateTime endDayOfMonth)
        {
            Dictionary<DateTime, int> pairs = new Dictionary<DateTime, int>();
            var service = await _unitOfWork.Appointment.GetAll(q => q.StartTime.Date >= startDayOfMonth.Date && q.StartTime.Date <= endDayOfMonth.Date && q.ServiceId == serviceid&&q.StatusId==1, include: s => s.Include(c => c.Service));
            for (var date = startDayOfMonth; date <= endDayOfMonth; date = date.AddDays(1))
            {
                pairs.Add(date.Date, service.Where(s => s.StartTime.Date == date.Date).ToList().Count());
            }
            return Ok(pairs);
        }
        [HttpGet("AppointmentCancelOrUpcomming/{statusId}/{startDayOfMonth}/{endDayOfMonth}")]
        public async Task<IActionResult> AppointmentCancelOrUpcomming(int statusId, DateTime startDayOfMonth, DateTime endDayOfMonth)
        {
            Dictionary<DateTime, int> pairs = new Dictionary<DateTime, int>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StartTime.Date >= startDayOfMonth.Date && q.StartTime.Date <= endDayOfMonth.Date && q.StatusId == statusId);
            for (var date = startDayOfMonth; date <= endDayOfMonth; date = date.AddDays(1))
            {
                pairs.Add(date.Date, appointment.Where(s => s.StartTime.Date == date.Date).ToList().Count());
            }
            return Ok(pairs);
        }
        [HttpGet("SpecialistOrderPerDay/{spId}/{startDayOfMonth}/{endDayOfMonth}")]
        public async Task<IActionResult> SpecialistOrderPerDay(string spId, DateTime startDayOfMonth, DateTime endDayOfMonth)
        {
            Dictionary<DateTime, int> pairs = new Dictionary<DateTime, int>();
          
            var spcialist = await _unitOfWork.Appointment.GetAll(q => q.StartTime.Date >= startDayOfMonth.Date && q.StartTime.Date <= endDayOfMonth.Date && q.SpecialistId.Equals(spId), include: s => s.Include(c => c.Specialist));
            for (var date = startDayOfMonth; date <= endDayOfMonth; date = date.AddDays(1))
            {
                pairs.Add(date.Date, spcialist.Where(s => s.StartTime.Date == date.Date).ToList().Count());
            }
            return Ok(pairs);
        }
        [HttpGet("AppointmentErned/{startDayOfMonth}/{endDayOfMonth}")]
        public async Task<IActionResult> AppointmentCancelOrUpcomming( DateTime startDayOfMonth, DateTime endDayOfMonth)
        {
            Dictionary<DateTime, int> pairs = new Dictionary<DateTime, int>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StartTime.Date >= startDayOfMonth.Date && q.StartTime.Date <= endDayOfMonth.Date && q.StatusId == 2,include:x=>x.Include(s=>s.Service));
            for (var date = startDayOfMonth; date <= endDayOfMonth; date = date.AddDays(1))
            {
                pairs.Add(date.Date, appointment.Where(s => s.StartTime.Date == date.Date).Sum(s=>s.Service.Price));
            }
            return Ok(pairs);
        }
        //[HttpGet("TestFilter")]
        //public async Task<IActionResult> TestFilter(FilterApplay f)
        //{
        //    var Category = await _unitOfWork.Category.GetAll(q=>q.Services.Where(s=>s.Id==1).ToList() );
        //}
    }
}
