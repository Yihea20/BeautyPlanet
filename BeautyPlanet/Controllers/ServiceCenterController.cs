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
    public class ServiceCenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceCenterController> _logger;

        public ServiceCenterController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ServiceCenterController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddServiceCenter([FromBody]ServiceCenterDTO serviceCenter)
        {
            var m = _mapper.Map<ServiceCenter>(serviceCenter);
             await _unitOfWork.ServiceCenter.Insert(m);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult>GetAllServiceCenter()
        {
            var service = await _unitOfWork.ServiceCenter.GetAll();
            var result = _mapper.Map<IList<GetServiceCenter>>(service);
            return Ok(result);
        }
    }
}
