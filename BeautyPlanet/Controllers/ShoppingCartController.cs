using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ShoppingCartController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> UpSertShoppingCart([FromBody] ShopCart shop)
        {
            var prc = await _unitOfWork.ProductCenter.Get(q => q.ProductId == shop.ProductId && q.CenterId == shop.CenterId);
            //var prs = await _unitOfWork.ProductSize.Get(q => q.ProductId == shop.ProductId && q.SizeId == shop.SizeId);
            //var pc = await _unitOfWork.ProductColor.Get(q => q.ProductId == shop.ProductId && q.ColorId == shop.ColorId);
            
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingCart()
        {
            //IList<GetCart> shopCarts = new List<GetCart>();
            //var sh = await _unitOfWork.ShoppingCart.GetAll(include:x=>x.Include(p=>p.ProductCenterr).ThenInclude(q=>q.Productt));
            //foreach(ShoppingCart s in sh)
            //{
            //    var prod = _mapper.Map<AppProduct>(s.ProductCenterr.Productt);
            //    shopCarts.Add(new GetCart { Id=s.Id,AppProduct=prod,Count=s.Count});
            //}
            return Ok();
        }
    }
}
