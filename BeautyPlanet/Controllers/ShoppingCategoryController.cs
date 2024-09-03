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
    public class ShoppingCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ShoppingCategoryController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ShoppingCategoryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ShoppingCategoryController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ShoppingCategoryImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddShoppingCategory([FromForm] ShoppingCategoryFile category)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(category.Categories.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + category.Categories.Name.Replace(" ", "_") + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await category.Files.CopyToAsync(stream);
                    var result = _mapper.Map<ShoppingCategory>(category.Categories);
                    result.ImageUrl = hosturl + "/Upload/ShoppingCategoryImage/" + category.Categories.Name.Replace(" ", "_") + "/" + category.Categories.Name.Replace(" ", "_") + ".png";
                    await _unitOfWork.ShoppingCategory.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllShoppingCategory()
        {
            var category = await _unitOfWork.ShoppingCategory.GetAll(include: x => x.Include(p => p.ProductCenterColorSizes));
            var result = _mapper.Map<IList<GetShoppingCategory>>(category);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetShoppingCategoryById(int id)
        {
            var category = await _unitOfWork.ShoppingCategory.Get(q => q.Id == id, include: x => x.Include(p => p.ProductCenterColorSizes).Include(s=>s.Stores));
            var result=_mapper.Map<GetShoppingCategory>(category);
            return Ok(result);
        }
        
    }
}
