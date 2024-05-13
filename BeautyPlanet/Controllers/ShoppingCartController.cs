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
            var cart = await _unitOfWork.ShoppingCart.Get(q => q.UserId.Equals(shop.UserId) && q.CenterId == shop.CenterId);
            var prc = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == shop.ProductId && q.CenterId == shop.CenterId && q.ColorId == shop.ColorId && q.SizeId == shop.SizeId, include: q => q.Include(x => x.Product));

            if (cart != null && prc != null)
            {
                ProductShopDTO product = new ProductShopDTO();
                product.ShoppingCartId = cart.Id;
                product.ProductCenterColorSizeId = prc.Id;
                product.count = shop.Count;
                var map = _mapper.Map<ProductShopCart>(product);

                await _unitOfWork.ProductShopCart.Insert(map);
                await _unitOfWork.Save();
                cart.TotalPrice += shop.Count * prc.Product.Price;
                _unitOfWork.ShoppingCart.Update(cart);
                await _unitOfWork.Save();
                return Ok();
            }
            else if (prc != null && cart == null)
            {
                ShoppingCartDTO shopping = new ShoppingCartDTO();
                shopping.UserId = shop.UserId;
                shopping.CenterId = shop.CenterId;
                var map = _mapper.Map<ShoppingCart>(shopping);
                await _unitOfWork.ShoppingCart.Insert(map);
                await _unitOfWork.Save();
                var newcart = await _unitOfWork.ShoppingCart.Get(q => q.CenterId == shop.CenterId && q.UserId == shop.UserId);
                ProductShopDTO product = new ProductShopDTO();
                product.ShoppingCartId = newcart.Id;
                product.ProductCenterColorSizeId = prc.Id;
                product.count = shop.Count;
                var map1 = _mapper.Map<ProductShopCart>(product);
                await _unitOfWork.ProductShopCart.Insert(map1);
                await _unitOfWork.Save();
                newcart.TotalPrice += shop.Count * prc.Product.Price;
                _unitOfWork.ShoppingCart.Update(newcart);
                await _unitOfWork.Save();

                return Ok();
            }
            else
                return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingCart()
        {
            var shop = await _unitOfWork.ShoppingCart.GetAll(include: q => q.Include(c => c.Center).Include(u => u.User).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Colors).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Sizes).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Reviews));
            var map = _mapper.Map<IList<GetShoppingCart>>(shop);

            return Ok(map);
        }
        [HttpGet("pccs")]
        public async Task<IActionResult> GetAllProductCenterSizeColor()
        {
            var shop = await _unitOfWork.ProductCenterColorSize.GetAll();
            //var map = _mapper.Map<IList<GetShoppingCart>>(shop);

            return Ok(shop);
        }
        [HttpGet("GetCartById")]
        public async Task<IActionResult> GetShoppingCart(int id)
        {
            var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == id, include: q => q.Include(c => c.Center).Include(u => u.User).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Colors).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Sizes).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).ThenInclude(x => x.Reviews));
           
            var map = _mapper.Map<GetShoppingCart>(shop);
            return Ok(map);
        }
        [HttpPut("Incress")]
        public async Task<IActionResult>IncressProduct(int Cart,int Product)
        {
            var cart = await _unitOfWork.ProductShopCart.Get(q => q.ProductCenterColorSizeId == Product && q.ShoppingCartId == Cart,include:x=>x.Include(q=>q.ProductCenterColorSize).ThenInclude(p=>p.Product));
            cart.count++;
            _unitOfWork.ProductShopCart.Update(cart);
            var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == Cart);
            shop.TotalPrice = cart.count * cart.ProductCenterColorSize.Product.Price;
            _unitOfWork.ShoppingCart.Update(shop);
            await _unitOfWork.Save();
            
            return Ok();
        }
        [HttpPut("Decress")]
        public async Task<IActionResult> DecressProduct(int Cart, int Product)
        {
            var cart = await _unitOfWork.ProductShopCart.Get(q => q.ProductCenterColorSizeId == Product && q.ShoppingCartId == Cart, include: x => x.Include(q => q.ProductCenterColorSize).ThenInclude(p => p.Product));
            cart.count++;
            _unitOfWork.ProductShopCart.Update(cart);
            var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == Cart);
            shop.TotalPrice = cart.count * cart.ProductCenterColorSize.Product.Price;
            _unitOfWork.ShoppingCart.Update(shop);
            await _unitOfWork.Save();

            return Ok();
        }
    }
}
