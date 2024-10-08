﻿
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
        private readonly IWebHostEnvironment _environment;
        public ServiceController(IWebHostEnvironment environment, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ServiceController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ServiceImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddService([FromForm] ServiceFile service)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(service.Services.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + service.Services.Name.Replace(" ", "_") + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await service.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Service>(service.Services);
                    result.ImageURL = hosturl + "/Upload/ServiceImage/" + service.Services.Name.Replace(" ", "_") + "/" + service.Services.Name.Replace(" ", "_") + ".png"; ;
                    await _unitOfWork.Service.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
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
            var service = await _unitOfWork.Service.GetAll(include: q => q.Include(x => x.Centers));
            var result = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(result);
        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetServiceByName(string Name)
        {
            var service = await _unitOfWork.Service.Get(q => q.Name.Contains(Name),include:q=>q.Include(x=>x.Centers));
            var result = _mapper.Map<GetServiceDTO>(service);
            return Ok(result);
        }
        [HttpGet("ID")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var service = await _unitOfWork.Service.Get(q => q.Id == id,include:x=>x.Include(c=>c.Centers).Include(ca=>ca.Category));
            var result = _mapper.Map<GetServiceDTO>(service);
            return Ok(result);
        }
        [HttpGet("TopServices")]
        public async Task<IActionResult> GetTopServices()
        {
            var service = await _unitOfWork.Service.GetAll(orderBy: q => q.OrderByDescending(x => x.Rate));
            var result = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCenter(int id, [FromBody] ServiceDTO centerDto)
        {
            var old = await _unitOfWork.Service.Get(q => q.Id == id );
            _mapper.Map(centerDto, old);
            _unitOfWork.Service.Update(old);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("DeleteService/{id}")]
        public async Task<IActionResult>DeleteService(int id)
        {
            var service=await _unitOfWork.Service.Get(q=>q.Id==id);
            if(service==null)
            {
                return BadRequest();
            }
            else
            {
                await _unitOfWork.Service.Delete(id);
                await _unitOfWork.Save();
                return Ok();
            }
        }
        [HttpGet("GetServiceByCenterId/{centerId}")]
        public async Task<IActionResult> GetServiceByCenterId(int centerId)
        {
            var servicecenter=await _unitOfWork.ServiceCenter.GetAll(q=>q.CenterId==centerId,include:x=>x.Include(s=>s.Service));
            var map = _mapper.Map<IList<GetSearch>>(servicecenter);
            return Ok(map);
        }
        [HttpGet("ServiceById")]
        public async Task<IActionResult> ServiceById(int serviceid)
        {
            var service = await _unitOfWork.Service.Get(q => q.Id == serviceid, include: x => x.Include(c => c.Centers).Include(ca => ca.Category).Include(sp => sp.Specialists));
            var services = await _unitOfWork.Service.GetAll(q => q.Type.Equals(service.Type), include: x => x.Include(c => c.Centers));
            var result = _mapper.Map<GetServiceByIDDTO>(service);
            var results= _mapper.Map<IList<GetServiceByIDDTO>>(services);
            var TopSpecialist = result.Specialists.OrderBy(r => r.Rate);
            return Ok(new { Service = result, SimilarServices = results, TopSpecialist =TopSpecialist});
        }
    }
}
