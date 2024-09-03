using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IWebHostEnvironment _environment;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> HomeApi(String Id)
        {
            var u = await _unitOfWork.User.Get(q => q.Id.Equals(Id));
            var user = _mapper.Map<UserProfile>(u);
            var banner = await _unitOfWork.HomeImage.Get(q => q.Id == 1);
            var category = _mapper.Map<IList<CategoryIdDTO>>(await _unitOfWork.Category.GetAll());

            var center = _mapper.Map<IList<GetCenterwithIdDTO>>(await _unitOfWork.Center.GetAll(include: x => x.Include(p => p.Specialists), orderBy: x => x.OrderByDescending(p => p.Rate)));
            IList<OfferHome> hf = new List<OfferHome>();
            var offer = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x => x.Center).Include(x => x.ServiceCente).ThenInclude(x => x.Service));
            foreach (var f in offer)
            {
                var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
                var cente = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == f.ServiceCente.CenterId));
                var result = _mapper.Map<GetOffersIdDTO>(f);
                hf.Add(new OfferHome { Offer = result, Service = service, Center = cente });
            }
            var Specialist = await _unitOfWork.Specialist.GetAll(orderBy: o => o.OrderBy(r => r.Rate));
            var spMap = _mapper.Map<IList<GetSpecialistDTO>>(Specialist);
            return Accepted(new Home { User = user, Banner = banner.ImageUrl, Categories = category, Centers = center, Offers = hf ,Specialist=spMap});


        }
        [HttpGet("HomeWithFilter/{Id}")]
        public async Task<IActionResult> HomeWithFilter(String Id, int? categoryId,int? distanceId,int? MinPraice,int? MaxPraice)
        {
            var u = await _unitOfWork.User.Get(q => q.Id.Equals(Id));

            var user = _mapper.Map<UserProfile>(u);
            var des = await _unitOfWork.Distance.Get(q => q.Id == distanceId);
            var categoryfilter = await _unitOfWork.Category.GetAll(q => q.Id == categoryId);

           var centerfilter = await _unitOfWork.Center.GetAll(q=>Math.Sqrt((Math.Pow(q.Lat-u.Lat,2))+(Math.Pow(q.Lng - u.Lng, 2) ))>=des.To&& Math.Sqrt((Math.Pow(q.Lat - u.Lat, 2)) + (Math.Pow(q.Lng - u.Lng, 2))) <= des.From);
            // var servicefilter = await _unitOfWork.Service.GetAll(q=>q.Price>=MinPraice&&q.Price<=MaxPraice);
            var catgor = await _unitOfWork.Category.GetAll();
            
            var center = _mapper.Map<IList<GetCenterwithIdDTO>>(await _unitOfWork.Center.GetAll(include: x => x.Include(p => p.Specialists), orderBy: x => x.OrderByDescending(p => p.Rate)));
            IList<OfferHome> hf = new List<OfferHome>();
            var offer = await _unitOfWork.Offer.GetAll(include: q => q.Include(x => x.ServiceCente).ThenInclude(x => x.Center).Include(x => x.ServiceCente).ThenInclude(x => x.Service));
            var Specialist = await _unitOfWork.Specialist.GetAll(orderBy: o => o.OrderBy(r => r.Rate));
            var spMap = _mapper.Map<IList<GetSpecialistDTO>>(Specialist);
            var catego = catgor.Where(c => categoryfilter.Any(cf => cf.Id == c.Id)||c.Centers.Any(ce=>centerfilter.Any(cn=>ce.Id==cn.Id))).ToList();
                var category = _mapper.Map<IList<CategoryIdDTO>>(catgor);
                    foreach (var f in offer)
                    {
                        var service = _mapper.Map<GetServiceBesic>(await _unitOfWork.Service.Get(q => q.Id == f.ServiceCente.ServiceId));
                        var cente = _mapper.Map<GetCenterwithIdDTO>(await _unitOfWork.Center.Get(q => q.Id == f.ServiceCente.CenterId));
                        var result = _mapper.Map<GetOffersIdDTO>(f);
                        hf.Add(new OfferHome { Offer = result, Service = service, Center = cente });
                    }
                
            return Accepted(new Home { User = user, Categories = category, Centers = center, Offers = hf });


        }
        [HttpGet("GetFilter")]
        public async Task<IActionResult> GetFilters()
        {
            var category = _mapper.Map<IList<CategoryIdDTO>>(await _unitOfWork.Category.GetAll());
            var distance = _mapper.Map<IList<DistanceDTO>>(await _unitOfWork.Distance.GetAll());
            var rate = await _unitOfWork.Rate.GetAll();
            return Accepted(new Filter { Categories = category, Distances = distance, Rates = rate });
        }
        [HttpGet("GlopalSearch")]
        public async Task<IActionResult> GlopalSearch(string search)
        {
            var center = _mapper.Map<IList<GetCenterDTO>>(await _unitOfWork.Center.GetAll(q => q.Name.Contains(search), orderBy: x => x.OrderByDescending(p => p.Rate)));
            var specialist = _mapper.Map<IList<GetSpecialistDTO>>(await _unitOfWork.Specialist.GetAll(q => q.UserName.Contains(search), orderBy: x => x.OrderByDescending(p => p.Rate)));
            var service = _mapper.Map<IList<GetSearch>>(await _unitOfWork.ServiceCenter.GetAll(q => q.Center.Name.Contains(search), orderBy: x => x.OrderByDescending(p => p.Service.Rate), include: x => x.Include(q => q.Service)));
            IList<GetServiceDTO> ser = new List<GetServiceDTO>();
            foreach (GetSearch s in service)
            {
                ser.Add(s.Service);
            }
            return Accepted(new HomeSearch { Centers = center, Specialist = specialist, Services = ser });

        }
        [HttpGet("ShopHome")]
        public async Task<IActionResult> ShopHome()
        {
            var banner = await _unitOfWork.HomeImage.Get(q => q.Id == 1);

            var category = _mapper.Map<IList<GetShoppingCategory>>(await _unitOfWork.ShoppingCategory.GetAll());
            var prod = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(s => s.Size).Include(c => c.Color).Include(s => s.Store).Include(c => c.ShoppingCategory));
            var home1 = _mapper.Map<IList<GetProduct>>(prod);
            var prod1 = await _unitOfWork.ProductCenterColorSize.GetAll(include: x => x.Include(s => s.Size).Include(c => c.Color).Include(s => s.Store).Include(c => c.ShoppingCategory));
            var home = _mapper.Map<IList<GetProduct>>(prod1);
            return Accepted(new ShopHome { GetShoppingCategory = category, GetProduct = home1, NewProduct = home ,Banner=banner.ImageUrl});
        }
        [HttpDelete("ClearBanner")]
        public async Task<IActionResult> ClearBanner()
        {
            var banner = await _unitOfWork.HomeImage.Get(q=>q.Id==1);
            if(banner == null)
                return NotFound();
            else
            {
                banner.ImageUrl.Clear();
                _unitOfWork.HomeImage.Update(banner);
                await _unitOfWork.Save();
                return Ok();
            }
        }
        [NonAction]
        private string GetBannerFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/HomeImage/" + name;
        }
        [HttpPost("AddToBanner")]
        public async Task<IActionResult> AddToBanner([FromForm]IList<IFormFile>files)
        {
            var home = await _unitOfWork.HomeImage.Get(q => q.Id == 1);
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                foreach (var f in files)
                {
                    string FilePath = GetBannerFilePath(f.FileName);
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + f.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await f.CopyToAsync(stream);
                       home.ImageUrl.Add(hosturl + "/Upload/HomeImage/" + f.FileName + "/" + f.FileName);
                    }
                }

             _unitOfWork.HomeImage.Update(home);
             
                
                await _unitOfWork.Save();
                return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Image Add To Banner", Status = true });
            }
            catch (Exception e)
            {
                return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "Not Add", Status = false });
            }
        }
    }
}
