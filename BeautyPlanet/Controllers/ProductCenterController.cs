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

        public ProductCenterController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductCenterController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpPost("AddProductColorOrSize")]
        public async Task<IActionResult> AddProductSize([FromBody] ProductSizeColorDTO productCenter)
        {
            if (productCenter.ProductId != 0&&productCenter.CenterId!=0)
            {
                if (productCenter.ColorId != 0 && productCenter.SizeId != 0)
                {

                    var prod = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == productCenter.ProductId &&q.CenterId==productCenter.CenterId &&q.SizeId == productCenter.SizeId&&q.ColorId==productCenter.ColorId);
                    if (prod != null)
                    {
                        prod.Count += productCenter.Count;
                        return Ok("color and size exist before");
                    }
                    else {
                      var  prod1 = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == productCenter.ProductId && q.CenterId == productCenter.CenterId && q.SizeId == productCenter.SizeId && q.ColorId == 10000);
                        var prod2= await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == productCenter.ProductId && q.CenterId == productCenter.CenterId && q.ColorId == productCenter.ColorId && q.SizeId == 10000);
                        if (prod1!=null)
                            {
                            prod1.ColorId = productCenter.ColorId;
                            _unitOfWork.ProductCenterColorSize.Update(prod1);
                            await _unitOfWork.Save();
                            return Ok();
                            }
                        if(prod2!=null)
                        {
                            prod2.SizeId = productCenter.SizeId;
                            _unitOfWork.ProductCenterColorSize.Update(prod2);
                            await _unitOfWork.Save();
                            return Ok();

                        }
                        var m = _mapper.Map<ProductCenterColorSize>(productCenter);
                        await _unitOfWork.ProductCenterColorSize.Insert(m);
                        await _unitOfWork.Save();
                        return Ok();
                    }
                }
                else if (productCenter.ColorId == 0 && productCenter.SizeId != 0) 
                {
                    productCenter.ColorId = 10000;
                    var prod = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == productCenter.ProductId && q.CenterId == productCenter.CenterId && q.SizeId == productCenter.SizeId);
                    if(prod!=null)
                    {
                        prod.Count += productCenter.Count;
                        return Ok("size exist before");
                    }
                    else
                    {

                        var m = _mapper.Map<ProductCenterColorSize>(productCenter);
                        await _unitOfWork.ProductCenterColorSize.Insert(m);
                        await _unitOfWork.Save();
                        return Ok();
                    }

                }

                else if (productCenter.SizeId == 0 && productCenter.ColorId != 0)
                {
                    productCenter.SizeId = 10000;
                    var prod = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == productCenter.ProductId && q.CenterId == productCenter.CenterId && q.ColorId == productCenter.ColorId);
                    if (prod != null)
                    {
                        prod.Count += productCenter.Count;
                        return Ok("color exist before");
                    }
                    else
                    {

                        var m = _mapper.Map<ProductCenterColorSize>(productCenter);
                        await _unitOfWork.ProductCenterColorSize.Insert(m);
                        await _unitOfWork.Save();
                        return Ok();
                    }

                }
                else { return NotFound(); }
            }
            
            else return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductCenter()
        {
            IList<HomeProduct> home = new List<HomeProduct>();
            HomeProduct h1 = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include:x=>x.Include(c=>c.Center).ThenInclude(s=>s.Specialists).Include(p=>p.Product).ThenInclude(p=>p.Sizes).Include(p=>p.Product).ThenInclude(p=>p.Colors)
            .Include(p=>p.Product).ThenInclude(p=>p.Reviews).ThenInclude(u=>u.Userr));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach(var p in result)
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
                h1.Center = p.Center;
                home.Add(h1);
            }
            return Ok(home);
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
