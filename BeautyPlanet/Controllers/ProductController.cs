using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ProductImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductFile product)
        {
            string hosturl = $"{this.Request.Scheme}://11171443:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
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
                        
                        result.ImageUrl.Add( hosturl + "/Upload/ProductImage/" + f.FileName + "/" + f.FileName);
                        
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
        [HttpGet("GetAllPRoduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            IList<HomeProduct> home = new List<HomeProduct>();
            HomeProduct h = new HomeProduct();
            var service = await _unitOfWork.ProductCenter.GetAll(include: x => x.Include(c=>c.Centerr).Include(p => p.Productt).ThenInclude(p => p.Sizes).Include(p => p.Productt).ThenInclude(p => p.Colors)
            .Include(p => p.Productt).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach (var p in result)
            {
                h.Id = p.Productt.Id;
                h.ImageUrl = p.Productt.ImageUrl;
                h.Name = p.Productt.Name;
                h.OfferPercent = p.Productt.OfferPercent;
                h.Price = p.Productt.Price;
                h.ProductAddTime = p.Productt.ProductAddTime;
                h.Rate = p.Productt.Rate;
                h.Reviews = p.Productt.Reviews;
                h.Sizes = p.Productt.Sizes;
                h.Description = p.Productt.Description;
                h.Colors = p.Productt.Colors;
                h.EarnPoint = p.Productt.EarnPoint;
                h.Centers = p.Centerr;
                home.Add(h);
            }
            return Ok(home);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int id,int centerid)
        {
            HomeProduct h = new HomeProduct();
            var service = await _unitOfWork.ProductCenter.Get(q=>q.CenterId==centerid&&q.ProductId==id,include: x => x.Include(c => c.Centerr).Include(p => p.Productt).ThenInclude(p => p.Sizes).Include(p => p.Productt).ThenInclude(p => p.Colors)
            .Include(p => p.Productt).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var result = _mapper.Map<ProductDetels>(service);
           
                h.Id = result.Productt.Id;
                h.ImageUrl = result.Productt.ImageUrl;
                h.Name = result.Productt.Name;
                h.OfferPercent = result.Productt.OfferPercent;
                h.Price = result.Productt.Price;
                h.ProductAddTime = result.Productt.ProductAddTime;
                h.Rate = result.Productt.Rate;
                h.Reviews = result.Productt.Reviews;
                h.Sizes = result.Productt.Sizes;
                h.Description = result.Productt.Description;
                h.Colors = result.Productt.Colors;
                h.EarnPoint = result.Productt.EarnPoint;
                h.Centers = result.Centerr;
                
            
            return Ok(h);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
           // var old = await _unitOfWork.Product.Get(q => q.Id == id);
            //old.Sizes = centerDto.Sizes;
           await _unitOfWork.Product.Delete(id);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}
