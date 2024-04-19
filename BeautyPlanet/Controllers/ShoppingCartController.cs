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
        public async Task<IActionResult> AddShoppingCart([FromBody] ShopCart shop)
        {
            var prc = await _unitOfWork.ProductCenter.Get(q => q.ProductId == shop.ProductId && q.CenterId == shop.CenterId);
            ShoppingCartDTO shp = new ShoppingCartDTO();
            shp.ProductCenterId = prc.Id;
            shp.UserId = shop.UserId;
            shp.Count = shop.Count;
            var sh = _mapper.Map<ShoppingCart>(shp);
             await _unitOfWork.ShoppingCart.Insert(sh);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingCart()
        {
            IList<GetCart> shopCarts = new List<GetCart>();
            var sh = await _unitOfWork.ShoppingCart.GetAll(include:x=>x.Include(p=>p.ProductCenterr).ThenInclude(q=>q.Productt));
            foreach(ShoppingCart s in sh)
            {
                var prod = _mapper.Map<AppProduct>(s.ProductCenterr.Productt);
                shopCarts.Add(new GetCart { Id=s.Id,AppProduct=prod,Count=s.Count});
            }
            return Ok(shopCarts);
        }
    }
}
