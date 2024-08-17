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
        private readonly IWebHostEnvironment _environment;
        public CategoryController(IWebHostEnvironment environment, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CategoryImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] CategoryFile category)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(category.Categories.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + category.Files.FileName;
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await category.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Category>(category.Categories);
                    result.ImageUrl = hosturl + "/Upload/CategoryImage/" + category.Categories.Name.Replace(" ", "_") + "/" + category.Files.FileName ; 
                    await _unitOfWork.Category.Insert(result);
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
            var result = _mapper.Map<IList<GetCategoryWithIdDTO>>(category);
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
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _unitOfWork.Category.Get(q => q.Id == id, include: x => x.Include(p => p.Services).ThenInclude(c=>c.Centers));
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
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var center = await _unitOfWork.Category.Get(q => q.Id == id);


            if (center == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Category.Delete(id);
                await _unitOfWork.Save();


                return Ok();
            }
        }
        [HttpGet("AllById")]
        public async Task<IActionResult> GetAllCategoriesById(int id)
        {
            var service = await _unitOfWork.Service.GetAll(q => q.CategoryId == id, include: q => q.Include(x => x.Centers));
            var result = _mapper.Map<IList<GetServiceDTO>>(service);
            return Ok(result);
        }
        [HttpGet("GetCategoryByCenter/{centerId}")]
        public async Task<IActionResult> GetCategoriesByCenter(int centerId)
        {
            var category = await _unitOfWork.CenterCategory.GetAll(q => q.CenterId == centerId, include: x => x.Include(ca => ca.Category).ThenInclude(s=>s.Services));
            var map = _mapper.Map<IList<CategoryByCenter>>(category);
            return Ok(map);
        }
    }
}
