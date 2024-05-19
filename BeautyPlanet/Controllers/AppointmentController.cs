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

        public AppointmentController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AppointmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody]AppointmentDTO appointment)
        {
            var sp = await _unitOfWork.ServiceSpecialist.Get(q => q.Id == appointment.ServiceSpecialistId,include:x=>x.Include(q=>q.Specialistt));
            if (!sp.Specialistt.Times.Contains(appointment.DateTime))
            {
                var user = await _unitOfWork.User.Get(q => q.Id.Equals(appointment.UserId));
                user.Times.Add(appointment.DateTime);
                var spcialist = await _unitOfWork.Specialist.Get(q => q.Id.Equals(sp.SpecialistId));
                spcialist.Times.Add(appointment.DateTime);
                _unitOfWork.Specialist.Update(spcialist);

                _unitOfWork.User.Update(user);
                var app = _mapper.Map<Appointment>(appointment);
                app.StatusId = 1;
                await _unitOfWork.Appointment.Insert(app);
                await _unitOfWork.Save();
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet("AllAppointment")]
        public async Task<IActionResult> GetAllAppointment()
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(include: q => q.Include(x => x.ServiceSpecialistt).ThenInclude(x => x.Servicee).Include(q => q.ServiceSpecialistt).ThenInclude(p => p.Specialistt).Include(s => s.Statuss));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                app.Add(new GetAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Statuss.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAllUserAppointment(String UserId)
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(UserId), include: q => q.Include(x => x.ServiceSpecialistt).ThenInclude(x => x.Servicee).Include(q => q.ServiceSpecialistt).ThenInclude(p => p.Specialistt).Include(s => s.Statuss));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                app.Add(new GetAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Statuss.Name, Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
        [HttpGet("DashUserId/{DashUserId}")]
        public async Task<IActionResult> GetAllDashUserAppointment(String DashUserId)
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(DashUserId), include: q => q.Include(x => x.ServiceSpecialistt).ThenInclude(x => x.Servicee).Include(q => q.ServiceSpecialistt).ThenInclude(p => p.Specialistt).Include(s => s.Statuss));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                var user = _mapper.Map<GetUserDTO>(await _unitOfWork.User.Get(q => q.Id.Equals(a.UserId)));
                app.Add(new GetDashAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Statuss.Name, Center = center, Specialist = specialist, Category = category, Service = service ,User=user});
            }

            return Ok(app);
        }
        [HttpGet("DashAppointmentByStatus")]
        public async Task<IActionResult> GetAllDashAppointment(int status, string userId)
        {

            IList<GetDashAppointment> app = new List<GetDashAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.StatusId == status && q.UserId.Equals(userId), include: q => q.Include(x => x.ServiceSpecialistt).ThenInclude(x => x.Servicee).Include(q => q.ServiceSpecialistt).ThenInclude(p => p.Specialistt).Include(s => s.Statuss));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                var user = _mapper.Map<GetUserDTO>(await _unitOfWork.User.Get(q => q.Id.Equals(a.UserId)));
                app.Add(new GetDashAppointment { Id = a.Id, DateTime = a.DateTime, Status = a.Statuss.Name, Center = center, Specialist = specialist, Category = category, Service = service, User = user });
            }

            return Ok(app);
        }

        [HttpGet("AppointmentByStatus")]
        public async Task<IActionResult> GetAllAppointment(int status,string userId)
        {

            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q=>q.StatusId==status&&q.UserId.Equals(userId), include:q=>q.Include(x=>x.ServiceSpecialistt).ThenInclude(x=>x.Servicee).Include(q=>q.ServiceSpecialistt).ThenInclude(p=>p.Specialistt).Include(s=>s.Statuss));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q=>q.Id==a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<CategoryIdDTO>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                app.Add(new GetAppointment {Id=a.Id,DateTime=a.DateTime,Status=a.Statuss.Name, Center = center, Specialist = specialist, Category = category, Service = service });
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
    }
}
