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
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
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

        [HttpGet ("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var prod = await _unitOfWork.Product.GetAll();
            var map = _mapper.Map<IList<GetProduct>>(prod);
            return Ok(map);
        }
        [HttpGet("GetAllDashPRoduct")]
        public async Task<IActionResult> GetAllDashProduct()
        {
            IList<HomeDashProduct> home = new List<HomeDashProduct>();
            //HomeDashProduct h1 = new HomeDashProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Store).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr).Include(c=>c.Product).ThenInclude(s=>s.ShoppingCategoryy));
            var result = _mapper.Map<IList<ProductDashDetels>>(service);
            foreach (var p in result)
            {
                home.Add(new HomeDashProduct {
                    Id = p.Product.Id,
                ImageUrl = p.Product.ImageUrl,
                Name = p.Product.Name,
                OfferPercent = p.Product.OfferPercent,
                Price = p.Product.Price,
                ProductAddTime = p.Product.ProductAddTime,
                Rate = p.Product.Rate,
                Reviews = p.Product.Reviews,
                Sizes = p.Product.Sizes,
                Description = p.Product.Description,
                Colors = p.Product.Colors,
                EarnPoint = p.Product.EarnPoint,
                Store = p.Store,
                ShoppingCategoryy = p.Product.ShoppingCategoryy,
                Count = p.Count,
            });
            }
            return Ok(home);
        }

        [HttpGet("GetAllPRoduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            IList<HomeProduct> home = new List<HomeProduct>();
          //  HomeProduct h1 = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c=>c.Store).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach (var p in result)
            {
                home.Add(new HomeProduct { Id = p.Product.Id,
                ImageUrl = p.Product.ImageUrl,
                Name = p.Product.Name,
                OfferPercent = p.Product.OfferPercent,
                Price = p.Product.Price,
                ProductAddTime = p.Product.ProductAddTime,
                Rate = p.Product.Rate,
                Reviews = p.Product.Reviews,
                Sizes = p.Product.Sizes,
                Description = p.Product.Description,
                Colors = p.Product.Colors,
                EarnPoint = p.Product.EarnPoint,
                Store = p.Store,
                Count = result.Count, });
                
            }
            return Ok(home);
        }


        [HttpGet("DashProductById")]
        public async Task<IActionResult> GetDashProduct(int id, int storeid)
        {
            HomeDashProduct h = new HomeDashProduct();
            var service = await _unitOfWork.ProductCenterColorSize.Get(q => q.SizeId == storeid && q.ProductId == id, include: x => x.Include(c => c.Store).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
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
            h.Store = result.Store;
            h.ShoppingCategoryy=result.Product.ShoppingCategoryy;
            h.Count = result.Count;

            return Ok(h);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int id,int storeId)
        {
            HomeProduct product = new HomeProduct();
            IList<HomeProduct> related = new List<HomeProduct>();
            //HomeProduct re = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.Get(q=>q.StoreId==storeId&&q.ProductId==id,include: x => x.Include(c => c.Store).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var prod = await _unitOfWork.ProductCenterColorSize.GetAll(q =>q.Product.Type.Equals(service.Product.Type), include: x => x.Include(c => c.Store).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr));
            var lated = _mapper.Map<IList<ProductDetels>>(prod);
            var result = _mapper.Map<ProductDetels>(service);
            foreach (ProductDetels r in lated)
            {
                related.Add(new HomeProduct { Id = r.Product.Id,
                ImageUrl = r.Product.ImageUrl,
                Name = r.Product.Name,
                OfferPercent = r.Product.OfferPercent,
                Price = r.Product.Price,
                ProductAddTime = r.Product.ProductAddTime,
                Rate = r.Product.Rate,
                Reviews = r.Product.Reviews,
                Sizes = r.Product.Sizes,
                Description = r.Product.Description,
                Colors = r.Product.Colors,
                EarnPoint = r.Product.EarnPoint,
                Store = r.Store,
                Count = r.Count,
                Counter = r.Product.Conter,
            });
            }
                product.Id = result.Product.Id;
                product.ImageUrl = result.Product.ImageUrl;
                product.Name = result.Product.Name;
                product.OfferPercent = result.Product.OfferPercent;
                product.Price = result.Product.Price;
                product.ProductAddTime = result.Product.ProductAddTime;
                product.Rate = result.Product.Rate;
                product.Reviews = result.Product.Reviews;
                product.Sizes = result.Product.Sizes;
                product.Description = result.Product.Description;
                product.Colors = result.Product.Colors;
                product.EarnPoint = result.Product.EarnPoint;
                product.Store = result.Store;
                product.Count = result.Count;
                product.Counter = result.Product.Conter;

            return Ok(new { product, related });
        }
        [HttpPost("RatingProduct")]
        public async Task<IActionResult> Rating([FromBody]RatingProdDTO rating)
        {
            double rate = 0;
            var rett = _mapper.Map<Rating>(rating);
            await _unitOfWork.Reting.Insert(rett);
            await _unitOfWork.Save();
            var prod = await _unitOfWork.Product.Get(q=>q.Id==rating.ProductId);
            var ret = await _unitOfWork.Reting.GetAll(q => q.ProductId == rating.ProductId);
            var map= _mapper.Map<IList<RatingProdDTO>>(ret);
           rate= (rating.Rate + map.Sum(x => x.Rate)) / map.Count();
            prod.Rate =(int) Math.Floor(rate);
            prod.Conter = map.Count();
            _unitOfWork.Product.Update(prod);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("RatingCount")]
        public async Task<IActionResult> RatingCount(int prodId)
        {
            var ret = await _unitOfWork.Reting.GetAll(q=>q.ProductId==prodId);
            var map = _mapper.Map<IList<RatingProdDTO>>(ret);
            
            return Ok(map.Count());
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
