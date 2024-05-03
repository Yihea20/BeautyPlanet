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
            var product = _mapper.Map<IList<GetProduct>>(await _unitOfWork.Product.GetAll(orderBy:x=>x.OrderByDescending(p=>p.Conter)));
            var newproduct = _mapper.Map<IList<GetProduct>>(await _unitOfWork.Product.GetAll(orderBy: x => x.OrderBy(p => p.DateTime)));
            return Accepted(new ShopHome {GetShoppingCategory=category, GetProduct=product,NewProduct=newproduct} );
        }
    }
}
