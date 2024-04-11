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
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(offer.Offers.Name);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + offer.Offers.Name + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await offer.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Offer>(offer.Offers);
                    result.ImageUrl = hosturl + "/Upload/OfferImage/" + offer.Offers.Name + "/" + offer.Offers.Name + ".png";
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
        public async Task<IActionResult> GetAllOffer(int id)
        {
            IList<OfferHome> hf = new List<OfferHome>();
            var offer = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x=>x.Center).Include(x=>x.ServiceCente).ThenInclude(x=>x.Service));
           foreach(Offer f in offer)
            { 
            var service =_mapper.Map<GetServiceBesic>( await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
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
    }
}
