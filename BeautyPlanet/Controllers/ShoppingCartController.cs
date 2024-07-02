using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Migrations;
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

        [HttpPost("AddCart")]
        public async Task<IActionResult> AddCart([FromBody] ShoppingCart map)
        {
            await _unitOfWork.ShoppingCart.Insert(map);
            await _unitOfWork.Save();
            Task.Delay(2000);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpSertShoppingCart([FromBody] ShopCart shop)
        {
            var cart = await _unitOfWork.ShoppingCart.Get(q => q.UserId.Equals(shop.UserId) && q.CenterId == shop.CenterId);
            var prc = await _unitOfWork.ProductCenterColorSize.Get(q => q.ProductId == shop.ProductId && q.CenterId == shop.CenterId && q.ColorId == shop.ColorId && q.SizeId == shop.SizeId, include: q => q.Include(x => x.Product));

            Dictionary<string, string> pairs = new Dictionary<string, string>();
            if (prc.Count >= shop.Count)
            {
                if (cart != null && prc != null)
                {
                    var productCart = await _unitOfWork.ProductShopCart.Get(q => q.ProductCenterColorSizeId == prc.Id && q.ShoppingCartId == cart.Id);
                    if (productCart != null)
                    {
                        productCart.count += shop.Count;
                        cart.TotalPrice += prc.Product.Price * shop.Count;
                        _unitOfWork.ShoppingCart.Update(cart);
                        _unitOfWork.ProductShopCart.Update(productCart);
                        await _unitOfWork.Save();
                        pairs.Add("Message", "Add To Cart Done");
                        return Ok(pairs);
                    }
                    else
                    {
                        ProductShopDTO product = new ProductShopDTO();
                        product.ShoppingCartId = cart.Id;
                        product.ProductCenterColorSizeId = prc.Id;
                        product.count = shop.Count;
                        var map = _mapper.Map<ProductShopCart>(product);

                        await _unitOfWork.ProductShopCart.Insert(map);

                        cart.TotalPrice += shop.Count * prc.Product.Price;
                        _unitOfWork.ShoppingCart.Update(cart);
                        await _unitOfWork.Save();
                        pairs.Add("Message", "Add To Cart Done");
                        return Ok(pairs);
                    }
                }
                else if (prc != null && cart == null)
                {
                    ShoppingCartDTO shopping = new ShoppingCartDTO();
                    shopping.UserId = shop.UserId;
                    shopping.CenterId = shop.CenterId;
                    try
                    {

                        var map = _mapper.Map<ShoppingCart>(shopping);
                        await _unitOfWork.ShoppingCart.Insert(map);
                        await _unitOfWork.Save();
                        var newcart = await _unitOfWork.ShoppingCart.Get(q => q.CenterId == shop.CenterId && q.UserId.Equals(shop.UserId));
                        ProductShopDTO product = new ProductShopDTO();
                        product.ShoppingCartId = newcart.Id;
                        product.ProductCenterColorSizeId = prc.Id;
                        product.count = shop.Count;
                        var map1 = _mapper.Map<ProductShopCart>(product);
                        await _unitOfWork.ProductShopCart.Insert(map1);

                        newcart.TotalPrice += shop.Count * prc.Product.Price;
                        _unitOfWork.ShoppingCart.Update(newcart);
                        await _unitOfWork.Save();

                        pairs.Add("Message", "Add To Cart Done");
                        return Ok(pairs);

                    }
                    catch (Exception e)
                    {
                        var newcart = await _unitOfWork.ShoppingCart.Get(q => q.CenterId == shop.CenterId && q.UserId.Equals(shop.UserId));

                        ProductShopDTO product = new ProductShopDTO();
                        product.ShoppingCartId = newcart.Id;
                        product.ProductCenterColorSizeId = prc.Id;
                        product.count = shop.Count;
                        var map1 = _mapper.Map<ProductShopCart>(product);
                        await _unitOfWork.ProductShopCart.Insert(map1);

                        newcart.TotalPrice += shop.Count * prc.Product.Price;
                        _unitOfWork.ShoppingCart.Update(newcart);
                        await _unitOfWork.Save();

                        pairs.Add("Message", "Add To Cart Done");
                        return Ok(pairs);
                    }
                }
                else
                {
                    pairs.Add("Message", "Can Not Add To Cart");
                    return NotFound(pairs);
                }
            }
            else
            {
                pairs.Add("Message", "Can Not Add To Cart count not enouph in center");
                return NotFound(pairs);

            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingCart()
        {

            var shop = await _unitOfWork.ShoppingCart.GetAll(include: q => q.Include(c => c.Center).Include(u => u.User).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).Include(p => p.ProductCenterColorSize).ThenInclude(x => x.Color).Include(p => p.ProductCenterColorSize).ThenInclude(x => x.Size).Include(x=>x.Status));

            int c = 0;
            int p = 0;
            var map = _mapper.Map<IList<GetShoppingCart>>(shop);
            foreach (var item in map)
            {
                var cart = await _unitOfWork.ProductShopCart.GetAll(q=>q.ShoppingCartId==item.Id,include: x => x.Include(c => c.ShoppingCart).ThenInclude(p => p.Center).Include(c => c.ShoppingCart).ThenInclude(u => u.User).Include(s => s.ProductCenterColorSize).ThenInclude(p=>p.Product));

                c = 0;
                p = 0;
                foreach (var item1 in cart)
                {
                    item.ProductCenterColorSize.Where(x => x.Id == item1.ProductCenterColorSizeId).ToList().ForEach(w => w.Count = item1.count);
                    c += item1.count;
                    p += item1.count * item1.ProductCenterColorSize.Product.Price;
                }
                item.TotalCount = c;
                item.TotalPrice = p;
            }
            //map.Where(x => x.Id == cart.ToList().ForEach(a => a.ShoppingCartId)).ToList().ForEach(x=>x.ProductCenterColorSize.ToList().ForEach(z=>z.Id==cart.))
            //item.ProductCenterColorSize.Where(x => x.Id == item1.ProductCenterColorSizeId).ToList().ForEach(w => w.Count = item1.count);
            //Dictionary<int, IList<GetShoppingCart>> pairs = new Dictionary<int, IList<GetShoppingCart>>();
            //pairs.Add(StatusCodes.Status200OK,map) ;


            return Ok(map);
        }
        [HttpGet("pccs")]
        public async Task<IActionResult> GetAllProductCenterSizeColor()
        {
            var shop = await _unitOfWork.ProductShopCart.GetAll();
            //var map = _mapper.Map<IList<GetShoppingCart>>(shop);

            return Ok(shop);
        }
        [HttpGet("GetCartById")]
        public async Task<IActionResult> GetShoppingCart(int id)
        {
            GetCartDTO  cartDTO=new GetCartDTO();
            int c = 0;
           var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == id, include: q => q.Include(c => c.Center).Include(u => u.User).Include(p => p.ProductCenterColorSize).ThenInclude(p => p.Product).Include(p => p.ProductCenterColorSize).ThenInclude(x => x.Color).Include(p => p.ProductCenterColorSize).ThenInclude(x => x.Size));
            var cart = await _unitOfWork.ProductShopCart.GetAll(q => q.ShoppingCartId== id, include: x => x.Include(c => c.ShoppingCart).ThenInclude(p => p.Center).Include(c => c.ShoppingCart).ThenInclude(u => u.User).Include(s=>s.ProductCenterColorSize));
             var map = _mapper.Map<GetShoppingCart>(shop);
            foreach(var item in cart)
            {
                map.ProductCenterColorSize.Where(x => x.Id == item.ProductCenterColorSizeId).ToList().ForEach(w => w.Count = item.count);
                c+= item.count;
            }
            map.TotalCount = c;
            return Ok(new GetCartDTO { ShoppingCart=map});
        }
        [HttpPut("Incress")]
        public async Task<IActionResult>IncressProduct(int Cart,int Product,int count )
        {
            var cart = await _unitOfWork.ProductShopCart.Get(q => q.ProductCenterColorSizeId == Product && q.ShoppingCartId == Cart,include:x=>x.Include(q=>q.ProductCenterColorSize).ThenInclude(p=>p.Product));
           var prod= await _unitOfWork.ProductCenterColorSize.Get(q => q.Id == Product );
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            if (count <= prod.Count)
            {
                cart.count += count;
                _unitOfWork.ProductShopCart.Update(cart);
                var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == Cart);
                shop.TotalPrice = cart.count * cart.ProductCenterColorSize.Product.Price;
                _unitOfWork.ShoppingCart.Update(shop);
                await _unitOfWork.Save();

                pairs.Add("Message", "Add To Cart Done");
                return Ok(pairs);

            }
            else
            {
                pairs.Add("Message", "Can Not Add To Cart count not enouph in center");
                return NotFound(pairs);

            }
        }
        [HttpPut("Decress")]
        public async Task<IActionResult> DecressProduct(int Cart, int Product,int count )
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            var cart = await _unitOfWork.ProductShopCart.Get(q => q.ProductCenterColorSizeId == Product && q.ShoppingCartId == Cart, include: x => x.Include(q => q.ProductCenterColorSize).ThenInclude(p => p.Product));
            cart.count+=count;
            _unitOfWork.ProductShopCart.Update(cart);
            var shop = await _unitOfWork.ShoppingCart.Get(q => q.Id == Cart);
            shop.TotalPrice = cart.count * cart.ProductCenterColorSize.Product.Price;
            _unitOfWork.ShoppingCart.Update(shop);
            await _unitOfWork.Save();

            pairs.Add("Message", " Cart Done");
            return Ok(pairs);

        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int id, int status)
        {
            var app = await _unitOfWork.ShoppingCart.Get(q => q.Id == id);
            app.StatusId = status;
            _unitOfWork.ShoppingCart.Update(app);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete("DeleteCartById")]
        public async Task<IActionResult> DeleteCartById(int id)
        {

            var center = await _unitOfWork.ShoppingCart.Get(q => q.Id == id);

            Dictionary<string, string> d = new Dictionary<string, string>();


            if (center == null)
            {
                d.Add("message", "can not delete");

                return NotFound(d);
            }
            else
            {
                var prodcart = await _unitOfWork.ProductShopCart.GetAll(q=>q.ShoppingCartId==center.Id);
                _unitOfWork.ProductShopCart.DeleteRange(prodcart);
               
                await _unitOfWork.ShoppingCart.Delete(id);
                await _unitOfWork.Save();
                d.Add("message", "delete done");


                return Ok(d);
            }
        }
        [HttpDelete("DeleteCarts")]
        public async Task<IActionResult> DeleteCarts()
        {
            Dictionary<string ,string> d= new Dictionary<string ,string>();
            var center = await _unitOfWork.ShoppingCart.GetAll();


            if (center == null)
            {
                d.Add("message", "can not delete");
                return NotFound(d);
            }
            else
            {
                foreach (var item in center)
                {
                    var prodcart = await _unitOfWork.ProductShopCart.GetAll(q => q.ShoppingCartId == item.Id);
                    _unitOfWork.ProductShopCart.DeleteRange(prodcart);   
                }
                 _unitOfWork.ShoppingCart.DeleteRange(center);
                await _unitOfWork.Save();
                d.Add("message","delete done");
                return Ok(d);
            }
        }
    }
}
