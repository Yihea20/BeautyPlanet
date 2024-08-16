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
        private readonly IWebHostEnvironment _environment;

        public OfferController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OfferController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/OfferImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddOffer([FromForm] OfferFile offer)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            var servicecenter = await _unitOfWork.ServiceCenter.Get(q => q.ServiceId == offer.Offers.Serviced && q.CenterId == offer.Offers.CenterId);
            try
            {
                string FilePath = GetFilePath(offer.Offers.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + offer.Offers.Name.Replace(" ", "_") + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await offer.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Offer>(offer.Offers);
                    result.ServiceCenterId=servicecenter.Id;
                    result.ImageUrl = hosturl + "/Upload/OfferImage/" + offer.Offers.Name.Replace(" ", "_") + "/" + offer.Offers.Name.Replace(" ", "_") + ".png";
                    await _unitOfWork.Offer.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOffer()
        {
            IList<OfferHome> hf = new List<OfferHome>();
            var offer = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x=>x.Center).Include(x=>x.ServiceCente).ThenInclude(x=>x.Service),orderBy:x=>x.OrderByDescending(q=>q.DateTime));
           foreach(Offer f in offer)
            { 
            var service =_mapper.Map<GetServiceBesic>( await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
            var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == f.ServiceCente.CenterId));
            var result = _mapper.Map<GetOffersIdDTO>(f);
                hf.Add(new OfferHome { Offer = result, Service = service, Center = center });
            }
                return Ok(hf);
        }
        [HttpGet("GetOfferByCenter/{centerId}")]
        public async Task<IActionResult>GetOfferByCenter(int centerId)
        {
            IList<OfferHome> hf = new List<OfferHome>();
            var offer= await _unitOfWork.Offer.GetAll(q => q.ServiceCente.CenterId == centerId, include: c => c.Include(x => x.ServiceCente).ThenInclude(s=>s.Service).Include(se=>se.ServiceCente).ThenInclude(ce=>ce.Center));
            foreach (Offer f in offer)
            {
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
                var center = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == f.ServiceCente.CenterId));
                var result = _mapper.Map<GetOffersIdDTO>(f);
                hf.Add(new OfferHome { Offer = result, Service = service, Center = center });
            }
            return Ok(hf);
        }
       
        [HttpGet("TopOffer")]
        public async Task<IActionResult> GetTopOffer()
        {

            var center = await _unitOfWork.Offer.GetAll(orderBy:x=>x.OrderByDescending(q=>q.DateTime));
            var result = _mapper.Map<IList<GetOfferDTO>>(center);
            return Ok(result);
        }
        [HttpPut("EditOffer/{offerId}")]
        public async Task<IActionResult> EditOffer(int offerId,OfferDTO f)
        {
            var offer = await _unitOfWork.Offer.Get(q => q.Id == offerId);
            var servicecenter = await _unitOfWork.ServiceCenter.Get(q => q.ServiceId == f.Serviced && q.CenterId == f.CenterId);
            if (offer != null && servicecenter != null)
            {
                offer.ServiceCenterId = servicecenter.Id;
                _mapper.Map(f, offer);
                _unitOfWork.Offer.Update(offer);
                await _unitOfWork.Save();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
