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
    public class CenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CenterController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CenterController(IWebHostEnvironment environment, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CenterController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CenterImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter([FromForm] CenterFile center)
        {
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(center.Centers.Name);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + center.Centers.Name + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await center.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Center>(center.Centers);
                    result.ImageUrl = hosturl + "/Upload/CenterImage/" + center.Centers.Name + "/" + center.Centers.Name + ".png"; ;
                    await _unitOfWork.Center.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCenter()
        {

            var center = await _unitOfWork.Center.GetAll(include:x=>x.Include(p=>p.Specialists));
            var result = _mapper.Map<IList<GetCenterDTO>>(center);
            return Ok(result);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == id);


            if (center == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Center.Delete(id);
                await _unitOfWork.Save();


                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCenter(int id, [FromBody] CenterDTO centerDto)
        {
            var old = await _unitOfWork.Center.Get(q => q.Id == id);
            _mapper.Map(centerDto, old);
            _unitOfWork.Center.Update(old);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetCenter(String Name)
        {
            var center = await _unitOfWork.Center.Get(q => q.Name == Name);
            var result = _mapper.Map<GetCenterDTO>(center);
            return Ok(result);
        }
    }
}
