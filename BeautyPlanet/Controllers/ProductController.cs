using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Migrations;
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
        //[NonAction]
        //private string GetFilePath(string name)
        //{
        //    return this._environment.WebRootPath + "/Upload/ProductImage/" + name;
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddProduct([FromForm] ProductFile product)
        //{
        //    string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
        //    var result = _mapper.Map<Product>(product.Products);
        //    try
        //    {
        //        foreach (var f in product.Files)
        //        {


        //            string FilePath = GetFilePath(f.FileName);
        //            if (!System.IO.Directory.Exists(FilePath))
        //            {
        //                System.IO.Directory.CreateDirectory(FilePath);
        //            }
        //            string url = FilePath + "\\" + f.FileName;
        //            if (System.IO.File.Exists(url))
        //            {
        //                System.IO.File.Delete(url);
        //            }
        //            using (FileStream stream = System.IO.File.Create(url))
        //            {
        //                await f.CopyToAsync(stream);
                        
        //                result.ImageUrl.Add( hosturl + "/Upload/ProductImage/" + f.FileName + "/" + f.FileName);
                        
        //            }
        //        }
        //        await _unitOfWork.Product.Insert(result);
        //        await _unitOfWork.Save();
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound();
        //    }
        //}
        [HttpPut("EditeProduct/{productId}")]
        public async Task<IActionResult> EditeProduct(int productId, ProductDTO product)
        {
            var prod = await _unitOfWork.ProductCenterColorSize.Get(q=>q.Id==productId);
            if(prod!=null)
            {
                _mapper.Map(product, prod);
                _unitOfWork.ProductCenterColorSize.Update(prod);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet ("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var prod = await _unitOfWork.ProductCenterColorSize.GetAll(include:x=>x.Include(s=>s.Size).Include(c=>c.Color).Include(s=>s.Store).Include(c=>c.ShoppingCategory));
            var map = _mapper.Map<IList<GetProduct>>(prod);
            return Ok(map);
        }
        [HttpGet("GetAllDashPRoduct")]
        public async Task<IActionResult> GetAllDashProduct()
        {
            IList<HomeDashProduct> home = new List<HomeDashProduct>();
            //HomeDashProduct h1 = new HomeDashProduct();
            var prod = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Store).Include(p => p.Size).Include(p => p.Color)
            .Include(p => p.Reviews).ThenInclude(u => u.Userr).Include(s=>s.ShoppingCategory));
            var map = _mapper.Map<IList<GetProduct>>(prod);
            return Ok(map);
            return Ok(home);
        }

      

        [HttpGet("DashProductById")]
        public async Task<IActionResult> GetDashProduct(int id, int storeid)
        {
           
            var service = await _unitOfWork.ProductCenterColorSize.Get(q => q.SizeId == storeid && q.Id== id, include: x => x.Include(c => c.Store).Include(p => p.Size).Include(p => p.Color)
            .Include(p => p.Reviews).ThenInclude(u => u.Userr).Include(p=>p.ShoppingCategory));
            var result = _mapper.Map<HomeDashProduct>(service);

          return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProduct(int id,int storeId)
        {
            var prod = await _unitOfWork.ProductCenterColorSize.Get(q => q.StoreId == storeId && q.Id == id, include: x => x.Include(c => c.Store).Include(p => p.Size).Include(p => p.Color)
            .Include(p => p.Reviews).ThenInclude(u => u.Userr).Include(p => p.ShoppingCategory));
            var product = _mapper.Map<GetProduct>(prod);
           
            var result = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Store).Include(p => p.Size).Include(p => p.Color)
            .Include(p => p.Reviews).ThenInclude(u => u.Userr).Include(p => p.ShoppingCategory));
            var related = _mapper.Map<IList<GetProduct>>(result);
            return Ok(new { product, related });
        }
        [HttpPost("RatingProduct")]
        public async Task<IActionResult> Rating([FromBody]RatingProdDTO rating)
        {
            double rate = 0;
            var rett = _mapper.Map<Rating>(rating);
            await _unitOfWork.Reting.Insert(rett);
            await _unitOfWork.Save();
            var prod = await _unitOfWork.ProductCenterColorSize.Get(q=>q.Id==rating.ProductId);
            var ret = await _unitOfWork.Reting.GetAll(q => q.ProductId == rating.ProductId);
            var map= _mapper.Map<IList<RatingProdDTO>>(ret);
           rate= (rating.Rate + map.Sum(x => x.Rate)) / map.Count();
            prod.Rate =(int) Math.Floor(rate);
            prod.Conter = map.Count();
            _unitOfWork.ProductCenterColorSize.Update(prod);
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
           var old = await _unitOfWork.ProductCenterColorSize.Get(q => q.Id == id);
            if (old != null)
            {
                //old.Sizes = centerDto.Sizes;
                await _unitOfWork.ProductCenterColorSize.Delete(id);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
