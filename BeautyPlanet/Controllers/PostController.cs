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
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/PostImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductFile product)
        {
            string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            var result = _mapper.Map<Product>(product.Products);
            try
            {
                foreach (var f in product.Files)
                {


                    string FilePath = GetFilePath(f.FileName);
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + f.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await f.CopyToAsync(stream);

                        result.ImageUrl.Add(hosturl + "/Upload/PostImage/" + f.FileName + "/" + f.FileName);

                    }
                }
                await _unitOfWork.Product.Insert(result);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}
