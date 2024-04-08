using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using BeautyPlanet.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO category)
        {
            var result = _mapper.Map<Category>(category);
            await _unitOfWork.Category.Insert(result);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("NameForAll")]
        public async Task<IActionResult> GetAllCategoryByName(string Name)
        {
            var category = await _unitOfWork.Category.GetAll(q => q.Name.Contains(Name), include: x => x.Include(p => p.Services));
            var result = _mapper.Map<IList<GetCategoryDTO>>(category);
            return Ok(result);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _unitOfWork.Category.GetAll(include: x => x.Include(p => p.Services));
            var result = _mapper.Map<IList<GetCategoryDTO>>(category);
            return Ok(result);
        }
        [HttpGet("Name")]
        public async Task<IActionResult> GetCategoryByName(string Name)
        {
            var center = await _unitOfWork.Category.Get(q => q.Name.Contains( Name),include:x=>x.Include(p=>p.Services));
            var result = _mapper.Map<GetCategoryDTO>(center);
            return Ok(result);
        }
        [HttpGet("ID")]
        public async Task<IActionResult> GetCenterById(int id)
        {
            var category = await _unitOfWork.Category.Get(q => q.Id == id, include: x => x.Include(p => p.Services));
            var result = _mapper.Map<GetCategoryDTO>(category);
            return Ok(result);
        }
        [HttpGet("Paging")]
        public async Task<IActionResult> GetCategoryPaging(string name, [FromQuery]RequestParams request)
        {
            var category = await _unitOfWork.Category.GetPagingAll( q=>q.Name.Contains(name),include: x => x.Include(p => p.Services),request:request);
            var result = _mapper.Map<IList<GetCategoryDTO>>(category);
            return Ok(result);
        }
    }
}
