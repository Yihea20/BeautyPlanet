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
            var sp = await _unitOfWork.ServiceSpecialist.Get(q => q.Id == appointment.ServiceSpecialistId);
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

                return Ok();
            }
            else
                return NotFound();
        }
        [HttpGet("AppointmentByStatus")]
        public async Task<IActionResult> GetAllAppointment(int status)
        {
            IList<GetAppointment> app = new List<GetAppointment>();
            var appointment = await _unitOfWork.Appointment.GetAll(q=>q.StatusId==status, include:q=>q.Include(x=>x.ServiceSpecialistt).ThenInclude(x=>x.Servicee));
            foreach (Appointment a in appointment)
            {
                var center = _mapper.Map<AppCenter>(await _unitOfWork.Center.Get(q=>q.Id==a.ServiceSpecialistt.Specialistt.CenterId));
                var specialist = _mapper.Map<AppSpecialist>(await _unitOfWork.Specialist.Get(q => q.Id.Equals(a.ServiceSpecialistt.SpecialistId)));
                var category = _mapper.Map<AppCategory>(await _unitOfWork.Category.Get(q => q.Id == a.ServiceSpecialistt.Servicee.CategoryId));
                var service = _mapper.Map<AppService>(await _unitOfWork.Service.Get(q => q.Id == a.ServiceSpecialistt.ServiceId));
                app.Add(new GetAppointment { Center = center, Specialist = specialist, Category = category, Service = service });
            }

            return Ok(app);
        }
    }
}
