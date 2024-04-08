
using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ServiceController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] ServiceDTO category)
        {
            var result = _mapper.Map<Service>(category);
            await _unitOfWork.Service.Insert(result);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("NameForAll")]
        public async Task<IActionResult> GetAllServicesByName(string Name)
        {
            var service = await _unitOfWork.Service.GetAll(q => q.Name.Contains(Name));
            var result = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(result);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllServices()
        {
            var service = await _unitOfWork.Service.GetAll();
            var result = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(result);
        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetServiceByName(string Name)
        {
            var service = await _unitOfWork.Service.Get(q => q.Name.Contains(Name));
            var result = _mapper.Map<GetServiceDTO>(service);
            return Ok(result);
        }
        [HttpGet("ID")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _unitOfWork.Service.Get(q => q.Id == id);
            var result = _mapper.Map<GetServiceDTO>(service);
            return Ok(result);
        }
    }
}
