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
        [HttpGet]
        public async Task<IActionResult>HomeApi(string userId)
        {
                var user = _mapper.Map<GetUserHome>(await _unitOfWork.User.Get(q => q.Id.Equals(userId)));
            var category = _mapper.Map<IList<CategoryIdDTO>>(await _unitOfWork.Category.GetAll());
            var center = _mapper.Map<IList<GetCenterwithIdDTO>>(await _unitOfWork.Center.GetAll(orderBy:x=>x.OrderByDescending(p=>p.Rate)));
            var offers = _mapper.Map<IList<GetOffersIdDTO>>(await _unitOfWork.Offer.GetAll(orderBy:x=>x.OrderByDescending(q=>q.DateTime)));
            return Accepted(new Home { User=user,Categories=category,Centers=center,Offers=offers});
        }
        [HttpGet("GlopalSearch")]
        public async Task<IActionResult> GlopalSearch(string search)
        {
            var center = _mapper.Map<IList<GetCenterDTO>>(await _unitOfWork.Center.GetAll(q => q.Name.Contains(search),orderBy:x=>x.OrderByDescending(p=>p.Rate)));
            var specialist = _mapper.Map<IList<GetSpecialistDTO>>(await _unitOfWork.Specialist.GetAll(q => q.UserName.Contains(search), orderBy: x => x.OrderByDescending(p => p.Rate)));
            var service = _mapper.Map<IList<GetSearch>>(await _unitOfWork.ServiceCenter.GetAll(q=>q.Center.Name.Contains(search),orderBy: x => x.OrderByDescending(p => p.Service.Rate),include:x=>x.Include(q=>q.Service)));

            return Accepted(new HomeSearch { Centers=center,Specialist=specialist,Services=service});

        }
    }
}
