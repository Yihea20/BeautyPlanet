using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceSpecialistController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceSpecialistController> _logger;

        public ServiceSpecialistController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ServiceSpecialistController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddServiceSpecialist([FromBody] ServiceSpecialistDTO serviceSpecialist)
        {
            var m = _mapper.Map<ServiceSpecialist>(serviceSpecialist);
            await _unitOfWork.ServiceSpecialist.Insert(m);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllServiceSpecialist()
        {
            var service = await _unitOfWork.ServiceSpecialist.GetAll();
            var result = _mapper.Map<IList<GetServiceSpecialist>>(service);
            return Ok(result);
        }
    }
}
