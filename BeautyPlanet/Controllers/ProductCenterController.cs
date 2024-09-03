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
    public class ProductCenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductCenterController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ProductCenterController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductCenterController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            this._environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ProductImage/" + name;
        }
        [HttpPost("AddProductColorOrSize")]
        public async Task<IActionResult> AddProductSize([FromForm] ProductFile productCenter)
        {

         
                string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
                var result = _mapper.Map<ProductCenterColorSize>(productCenter.Products);
                try
                {
                    foreach (var f in productCenter.Files)
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

                            result.ImageUrl.Add(hosturl + "/Upload/ProductImage/" + f.FileName + "/" + f.FileName);

                        }
                    }
                    await _unitOfWork.ProductCenterColorSize.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
     
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = await _unitOfWork.ProductCenterColorSize.GetAll(include:x=>x.Include(c=>c.Color).Include(s=>s.Size).Include(sh=>sh.ShoppingCategory).Include(st=>st.Store));
            var map = _mapper.Map<HomeProduct>(product);
            return Ok(map);
        }
        [HttpGet("ProductSize")]
        public async Task<IActionResult> GetAllProductSize()
        {
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include:x=>x.Include(q=>q.Size));
            var result = _mapper.Map<IList<GetProductSizeDTO>>(service);
            return Ok(result);
        }
        [HttpGet("GetProdoctColor")]
        public async Task<IActionResult> GetAllProductColor()
        {
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(q => q.Color));
            var result = _mapper.Map<IList<GetProductColorDTO>>(service);
            return Ok(result);
        }
    }
}
