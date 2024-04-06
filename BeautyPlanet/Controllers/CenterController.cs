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
    public class CenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CenterController> _logger;
        private readonly IMapper _mapper;


        public CenterController(IUnitOfWork unitOfWork, ILogger<CenterController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter([FromBody] CenterDTO center)
        {
            var result = _mapper.Map<Center>(center);
            await _unitOfWork.Center.Insert(result);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCenter()
        {

            var center = await _unitOfWork.Center.GetAll();
            var result = _mapper.Map<IList<GetCenterDTO>>(center);
            return Ok(result);
        }

        [HttpDelete("{id}")]
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
