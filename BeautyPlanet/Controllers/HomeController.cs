using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult>HomeApi(String Id)
        {
                var user = _mapper.Map<GetUserHome>(await _unitOfWork.User.Get(q => q.Id.Equals(Id)));
            var category = _mapper.Map<IList<CategoryIdDTO>>(await _unitOfWork.Category.GetAll());
            var center = _mapper.Map<IList<GetCenterwithIdDTO>>(await _unitOfWork.Center.GetAll(include:x=>x.Include(p=>p.Specialists) ,orderBy:x=>x.OrderByDescending(p=>p.Rate)));
            IList<OfferHome> hf = new List<OfferHome>();
            var offer = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x => x.Center).Include(x => x.ServiceCente).ThenInclude(x => x.Service));
            foreach (Offer f in offer)
            {
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
                var cente = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == f.ServiceCente.CenterId));
                var result = _mapper.Map<GetOffersIdDTO>(f);
                hf.Add(new OfferHome { Offer = result, Service = service, Center = cente });
            }
            return Accepted(new Home { User=user,Categories=category,Centers=center,Offers=hf});
        }
        [HttpGet("GlopalSearch")]
        public async Task<IActionResult> GlopalSearch(string search)
        {
            var center = _mapper.Map<IList<GetCenterDTO>>(await _unitOfWork.Center.GetAll(q => q.Name.Contains(search),orderBy:x=>x.OrderByDescending(p=>p.Rate)));
            var specialist = _mapper.Map<IList<GetSpecialistDTO>>(await _unitOfWork.Specialist.GetAll(q => q.UserName.Contains(search), orderBy: x => x.OrderByDescending(p => p.Rate)));
            var service = _mapper.Map<IList<GetSearch>>(await _unitOfWork.ServiceCenter.GetAll(q=>q.Center.Name.Contains(search),orderBy: x => x.OrderByDescending(p => p.Service.Rate),include:x=>x.Include(q=>q.Service)));
            IList<GetServiceDTO> ser = new List<GetServiceDTO>();
            foreach(GetSearch s in service)
            {
                ser.Add(s.Service);
            }
            return Accepted(new HomeSearch { Centers=center,Specialist=specialist,Services=ser});

        }
        [HttpGet("ShopHome")]
        public async Task<IActionResult> ShopHome()
        {

            var category = _mapper.Map<IList<GetShoppingCategory>>(await _unitOfWork.ShoppingCategory.GetAll());
            IList<HomeProduct> home1 = new List<HomeProduct>();
            HomeProduct h1=new HomeProduct();
            var service1 = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Center).ThenInclude(s => s.Specialists).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr), orderBy: x => x.OrderByDescending(p => p.Product.Conter));
            var result1 = _mapper.Map<IList<ProductDetels>>(service1);
            foreach (var p in result1)
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
                home1.Add(h1);
            }

            IList<HomeProduct> home = new List<HomeProduct>();
            HomeProduct h = new HomeProduct();
            var service = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(c => c.Center).ThenInclude(s => s.Specialists).Include(p => p.Product).ThenInclude(p => p.Sizes).Include(p => p.Product).ThenInclude(p => p.Colors)
            .Include(p => p.Product).ThenInclude(p => p.Reviews).ThenInclude(u => u.Userr),orderBy:x=>x.OrderByDescending(p=>p.Product.ProductAddTime));
            var result = _mapper.Map<IList<ProductDetels>>(service);
            foreach (var p in result)
            {
                h.Id = p.Product.Id;
                h.ImageUrl = p.Product.ImageUrl;
                h.Name = p.Product.Name;
                h.OfferPercent = p.Product.OfferPercent;
                h.Price = p.Product.Price;
                h.ProductAddTime = p.Product.ProductAddTime;
                h.Rate = p.Product.Rate;
                h.Reviews = p.Product.Reviews;
                h.Sizes = p.Product.Sizes;
                h.Description = p.Product.Description;
                h.Colors = p.Product.Colors;
                h.EarnPoint = p.Product.EarnPoint;
                h.Centers = p.Center;
                home.Add(h);
            }
            return Accepted(new ShopHome {GetShoppingCategory=category, GetProduct=home1,NewProduct=home} );
        }
    }
}
