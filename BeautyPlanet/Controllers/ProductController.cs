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


        [HttpGet("GetAllDashPRoduct")]
        public async Task<IActionResult> GetAllDashProduct()
        {
            IList<HomeDashProduct> home = new List<HomeDashProduct>();
            HomeDashProduct h1 = new HomeDashProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Center).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr).Include(c=>c.Product.ShoppingCategoryy));
            var result = _mapper.Map<IList<ProductDashDetels>>(service);
            foreach (var p in result)
            {
                h1.Id = p.Product.Id;
                h1.ImageUrl = p.Product.ImageUrl;
                h1.Name = p.Product.Name;
                h1.OfferPercent = p.Product.OfferPercent;
                h1.Price = p.Product.Price;
                h1.ProductAddTime = p.Product.ProductAddTime;
                h1.Rate = p.Product.Rate;
                h1.Reviews = p.Product.Reviews;
                h1.Sizes = p.Product.Sizes;
                h1.Description = p.Product.Description;
                h1.Colors = p.Product.Colors;
                h1.EarnPoint = p.Product.EarnPoint;
                h1.Centers = p.Center;
                h1.ShoppingCategoryy=p.Product.ShoppingCategoryy;
                h1.Count=p.Count;
                home.Add(h1);
            }
            return Ok(home);
        }

        [HttpGet("GetAllPRoduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            IList<HomeProduct> home = new List<HomeProduct>();
            HomeProduct h1 = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c=>c.Center).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach (var p in result)
            {
                h1.Id = p.Product.Id;
                h1.ImageUrl = p.Product.ImageUrl;
                h1.Name = p.Product.Name;
                h1.OfferPercent = p.Product.OfferPercent;
                h1.Price = p.Product.Price;
                h1.ProductAddTime = p.Product.ProductAddTime;
                h1.Rate = p.Product.Rate;
                h1.Reviews = p.Product.Reviews;
                h1.Sizes = p.Product.Sizes;
                h1.Description = p.Product.Description;
                h1.Colors = p.Product.Colors;
                h1.EarnPoint = p.Product.EarnPoint;
                h1.Centers = p.Center;
                home.Add(h1);
            }
            return Ok(home);
        }


        [HttpGet("DashProductById")]
        public async Task<IActionResult> GetDashProduct(int id, int centerid)
        {
            HomeDashProduct h = new HomeDashProduct();
            var service = await _unitOfWork.ProductCenterColorSize.Get(q => q.CenterId == centerid && q.ProductId == id, include: x => x.Include(c => c.Center).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr).Include(p=>p.Product.ShoppingCategoryy));
            var result = _mapper.Map<ProductDashDetels>(service);

            h.Id = result.Product.Id;
            h.ImageUrl = result.Product.ImageUrl;
            h.Name = result.Product.Name;
            h.OfferPercent = result.Product.OfferPercent;
            h.Price = result.Product.Price;
            h.ProductAddTime = result.Product.ProductAddTime;
            h.Rate = result.Product.Rate;
            h.Reviews = result.Product.Reviews;
            h.Sizes = result.Product.Sizes;
            h.Description = result.Product.Description;
            h.Colors = result.Product.Colors;
            h.EarnPoint = result.Product.EarnPoint;
            h.Centers = result.Center;
            h.ShoppingCategoryy=result.Product.ShoppingCategoryy;
            h.Count = result.Count;

            return Ok(h);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int id,int centerid)
        {
            HomeProduct h = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.Get(q=>q.CenterId==centerid&&q.ProductId==id,include: x => x.Include(c => c.Center).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var result = _mapper.Map<ProductDetels>(service);
           
                h.Id = result.Product.Id;
                h.ImageUrl = result.Product.ImageUrl;
                h.Name = result.Product.Name;
                h.OfferPercent = result.Product.OfferPercent;
                h.Price = result.Product.Price;
                h.ProductAddTime = result.Product.ProductAddTime;
                h.Rate = result.Product.Rate;
                h.Reviews = result.Product.Reviews;
                h.Sizes = result.Product.Sizes;
                h.Description = result.Product.Description;
                h.Colors = result.Product.Colors;
                h.EarnPoint = result.Product.EarnPoint;
                h.Centers = result.Center;
                
            
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
