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
    public class OfferController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OfferController> _logger;

        public OfferController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OfferController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddOffer([FromBody] OfferDTO center)
        {
            var result = _mapper.Map<Offer>(center);
            await _unitOfWork.Offer.Insert(result);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOffer()
        {

            var center = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x=>x.Center).Include(x=>x.ServiceCente).ThenInclude(x=>x.Service));
            var result = _mapper.Map<IList<GetOfferDTO>>(center);
            return Ok(result);
        }
        [HttpGet("TopOffer")]
        public async Task<IActionResult> GetTopOffer()
        {

            var center = await _unitOfWork.Offer.GetAll(orderBy:x=>x.OrderByDescending(q=>q.DateTime));
            var result = _mapper.Map<IList<GetOfferDTO>>(center);
            return Ok(result);
        }
    }
}
