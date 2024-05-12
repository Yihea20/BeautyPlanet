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
        [HttpPost]
        public async Task<IActionResult> AddProductCenter([FromBody] ProductCenterDTO productCenter)
        {
            var m = _mapper.Map<ProductCenter>(productCenter);
            await _unitOfWork.ProductCenter.Insert(m);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpPost("AddProductSize")]
        public async Task<IActionResult> AddProductSize([FromBody] ProductSizeDTO productCenter)
        {
            var prod = await _unitOfWork.ProductColorSize.Get(q => q.ProductId == productCenter.ProductId);
            if (prod != null)
            {
                prod.SizeId = productCenter.SizeId;
                _unitOfWork.ProductColorSize.Update(prod);
                await _unitOfWork.Save();
                return Ok();

            }
            else 
            { 
            var m = _mapper.Map<ProductColorSize>(productCenter);
            await _unitOfWork.ProductColorSize.Insert(m);
            await _unitOfWork.Save();
            return Ok();
            }
        }
        [HttpPost("AddProductColor")]
        public async Task<IActionResult> AddProductColor([FromBody] ProductColorDTO productCenter)
        {
            var prod = await _unitOfWork.ProductColorSize.Get(q => q.ProductId == productCenter.ProductId);
            if (prod != null)
            {
                prod.ColorId = productCenter.ColorId;
                _unitOfWork.ProductColorSize.Update(prod);
                await _unitOfWork.Save();
                return Ok();

            }
            else
            {
                var m = _mapper.Map<ProductColorSize>(productCenter);
                await _unitOfWork.ProductColorSize.Insert(m);
                await _unitOfWork.Save();
                return Ok();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductCenter()
        {
            IList<HomeProduct> home = new List<HomeProduct>();
            HomeProduct h = new HomeProduct();
            var service = await _unitOfWork.ProductCenter.GetAll(include:x=>x.Include(c=>c.Centerr).ThenInclude(s=>s.Specialists).Include(p=>p.Productt).ThenInclude(p=>p.Sizes).Include(p=>p.Productt).ThenInclude(p=>p.Colors)
            .Include(p=>p.Productt).ThenInclude(p=>p.Reviews).ThenInclude(u=>u.Userr));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach(var p in result)
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
        [HttpGet("ProductSize")]
        public async Task<IActionResult> GetAllProductSize()
        {
            var service = await _unitOfWork.ProductColorSize.GetAll(include:x=>x.Include(q=>q.Size));
            var result = _mapper.Map<IList<GetProductSizeDTO>>(service);
            return Ok(result);
        }
        [HttpGet("GetProdoctColor")]
        public async Task<IActionResult> GetAllProductColor()
        {
            var service = await _unitOfWork.ProductColorSize.GetAll(include: x => x.Include(q => q.Color));
            var result = _mapper.Map<IList<GetProductColorDTO>>(service);
            return Ok(result);
        }
    }
}
