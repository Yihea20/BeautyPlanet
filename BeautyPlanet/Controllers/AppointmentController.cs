using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;

using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromForm] AppointmentFile appointment)
        {
            var sp = await _unitOfWork.ServiceSpecialist.Get(q => q.SpecialistId.Equals(appointment.AppointmentDTO.SpecialistId) && q.ServiceId == appointment.AppointmentDTO.ServiceId, include: x => x.Include(q => q.Specialistt).Include(s => s.Servicee));
            if (appointment.Files != null)
            {
                string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {

                    if (!sp.Specialistt.Times.Contains(appointment.AppointmentDTO.DateTime))
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
                            var user = await _unitOfWork.User.Get(q => q.Id.Equals(appointment.AppointmentDTO.UserId));
                            user.Times.Add(appointment.AppointmentDTO.DateTime);
                            var spcialist = await _unitOfWork.Specialist.Get(q => q.Id.Equals(sp.SpecialistId));
                            spcialist.Times.Add(appointment.AppointmentDTO.DateTime);
                            _unitOfWork.Specialist.Update(spcialist);

                            _unitOfWork.User.Update(user);
                            var result = _mapper.Map<Appointment>(appointment.AppointmentDTO);
                            result.ImageUrl = hosturl + "/Upload/CostomServiceImage/" + appointment.Files.FileName.Replace(" ", "_") + "/" + appointment.Files.FileName;
                            result.StatusId = 1;
                            await _unitOfWork.Appointment.Insert(result);
                            await _unitOfWork.Save();
                            return Ok();
                        }
                    }
                    else { return NotFound(); }
                }
                catch (Exception e)
                {
                    return NotFound();
                }

            }
            else { 
            if (!sp.Specialistt.Times.Contains(appointment.AppointmentDTO.DateTime))
            {
                var user = await _unitOfWork.User.Get(q => q.Id.Equals(appointment.AppointmentDTO.UserId));
                user.Times.Add(appointment.AppointmentDTO.DateTime);
                var spcialist = await _unitOfWork.Specialist.Get(q => q.Id.Equals(sp.SpecialistId));
                spcialist.Times.Add(appointment.AppointmentDTO.DateTime);
                _unitOfWork.Specialist.Update(spcialist);

                _unitOfWork.User.Update(user);
                //await _unitOfWork.Save();
                var app = _mapper.Map<Appointment>(appointment);
                app.StatusId = 1;
                await _unitOfWork.Appointment.Insert(app);
                await _unitOfWork.Save();
                return Ok();
            }
            else
                return NotFound();
        }
        }

        [HttpGet("AllAppointment")]
        public async Task<IActionResult> GetAllAppointment()
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                app.Add(new GetAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllUserAppointment(String UserId)
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(UserId),include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                app.Add(new GetAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
        [HttpGet("DashAllAppointment")]
        public async Task<IActionResult> GetAllDashAppointment()
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                var user = _mapper.Map<GetUserDTO>(await _unitOfWork.User.Get(q => q.Id.Equals(a.UserId)));
                app.Add(new GetDashAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service, User = user });
            }

            return Ok(app);
        }
        [HttpGet("DashUserId/{DashUserId}")]
        public async Task<IActionResult> GetAllDashUserAppointment(String DashUserId)
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(DashUserId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                var user = _mapper.Map<GetUserDTO>(await _unitOfWork.User.Get(q => q.Id.Equals(a.UserId)));
                app.Add(new GetDashAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service ,User=user});
            }

            return Ok(app);
        }
        [HttpGet("DashAppointmentByStatus")]
        public async Task<IActionResult> GetAllDashAppointment(int status, string userId)
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StatusId == status && q.UserId.Equals(userId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                var user = _mapper.Map<GetUserDTO>(await _unitOfWork.User.Get(q => q.Id.Equals(a.UserId)));
                app.Add(new GetDashAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service, User = user });
            }

            return Ok(app);
        }

        [HttpGet("AppointmentByStatus")]
        public async Task<IActionResult> GetAllAppointment(int status,string userId)
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q=>q.StatusId==status&&q.UserId.Equals(userId), include: q => q.Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.Specialist.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.Service.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceId));
                app.Add(new GetAppointment {Id=a.Id,DateTime=a.DateTime,Status=a.Status.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int id,int status)
        {
            var app = await _unitOfWork.Appointment.Get(q => q.Id == id);
            app.StatusId = status;
            _unitOfWork.Appointment.Update(app);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("GetAllCategoryByCenter")]
        public async Task<IActionResult> GetAllCategoryByCenter(int centerId)
        {
            var category = await _unitOfWork.CenterCategory.GetAll(q=>q.CenterId==centerId,include:x=>x.Include(x=>x.Category));
            var Cat = _mapper.Map<IList<GetCenterCategoryDTO>>(category);
            return Ok(Cat);
        }
        [HttpGet("GetServiceByCategory")]
        public async Task<IActionResult>GetServiceByCategory(int centerId,int categoryId)
        {
            var cercat = await _unitOfWork.CenterCategory.Get(q=>q.CategoryId==categoryId&&q.CenterId==centerId,include:x=>x.Include(s=>s.Category));
            var service = await _unitOfWork.Service.GetAll(q=>q.CategoryId==cercat.CategoryId);
            var map =_mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(map);
        }
        [HttpGet("GetSpecealistbyService")]
        public async Task<IActionResult> GetSpecealistbyService(int serviceId,int centerId)
        {
            var sp = await _unitOfWork.ServiceSpecialist.GetAll(q=>q.ServiceId==serviceId&&q.Specialistt.CenterId==centerId,include:c=>c.Include(s=>s.Specialistt));
            var map = _mapper.Map<IList<GetSp>>(sp);
            return Ok(map);
        }

    }
}
