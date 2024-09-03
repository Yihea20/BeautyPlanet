using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;

using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CenterController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CenterController(IWebHostEnvironment environment, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CenterController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CenterImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter([FromForm] CenterFile center)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(center.Centers.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + center.Centers.Name.Replace(" ", "_") + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await center.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Center>(center.Centers);
                    result.ImageUrl = hosturl + "/Upload/CenterImage/" + center.Centers.Name.Replace(" ", "_") + "/" + center.Centers.Name.Replace(" ", "_") + ".png"; ;
                    await _unitOfWork.Center.Insert(result);
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
        public async Task<IActionResult> GetAllCenter()
        {

            var center = await _unitOfWork.Center.GetAll(include: x => x.Include(s=>s.Specialists) .Include(ca=>ca.Categories).Include(pp=>pp.Posts).ThenInclude(c=>c.Comments).ThenInclude(u=>u.Person));
          
           
            foreach (var item in center)
            {
                foreach(var s in item.Specialists)
                {
                    if (item.Id == s.CenterId)
                    {
                        s.Center = item;
                    }
                }
            }
            var result = _mapper.Map<IList<GetCenterDTO>>(center);
            return Ok(result);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == id);


            if (center == null)
            {
                return NotFound();
            }
            else
            {
                await _unitOfWork.Center.Delete(id);
                await _unitOfWork.Save();


                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCenter(int id, List<string>s)
        {
            var old = await _unitOfWork.Center.Get(q => q.Id == id);
            old.WorkingTime.Clear();
            old.WorkingTime.Add("Monday - Friday   , 08:00 am - 10:00 pm "
 
             );
            old.WorkingTime.Add("Saturday  - Sunday   , 10:00 am - 06:00 pm ");
            _unitOfWork.Center.Update(old);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("GetCenterById")]
        public async Task<IActionResult> GetCenter(int id)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == id,include:x=>x.Include(s=>s.Specialists).Include(s=>s.Services).Include(ca=>ca.Categories).ThenInclude(se=>se.Services));
           foreach(var s in center.Specialists)
            {
                if(center.Id==s.CenterId)
                {
                    s.Center = center;
                }
            }
           
            var result = _mapper.Map<GetCenterDTO>(center);
            foreach(var c in center.Categories)

            foreach (var item in result.Categories)
            {
                    if(c.Id==item.Id)
                item.ServiceCount=c.Services.Count;
            }
            result.SpecialistsCount = center.Specialists.Count;
            return Ok(result);
        }
        [HttpGet("GetCenterByIdDash/{id}")]
        public async Task<IActionResult> GetCenterDash(int id)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == id, include: x => x.Include(s => s.Specialists).Include(s => s.Services).Include(ca => ca.Categories));
            var result = _mapper.Map<GetCenterDTO>(center);
            result.SpecialistsCount = center.Specialists.Count;
            return Ok(result);
        }
        [HttpPost("AddCategoryToCenter")]
        public async Task<IActionResult> AddCategoryToCenter([FromBody]CenterCategoryDTO centerCategory)
        {
            var ceca = await _unitOfWork.CenterCategory.Get(q => q.CategoryId == centerCategory.CategoryId && q.CenterId == centerCategory.CenterId);
            if (ceca == null)
            {
                var map = _mapper.Map<CenterCategory>(centerCategory);
                await _unitOfWork.CenterCategory.Insert(map);
                await _unitOfWork.Save();
                return Ok();
            }
            else return BadRequest("The Center Allready Have THis Category ");
        }
        [HttpPut("EmptyGallery")]
        public async Task<IActionResult> DeleteImages(int centerid)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == centerid);
            center.GalleryImage.Clear();
            _unitOfWork.Center.Update(center);
            await _unitOfWork.Save();
            return Ok();
        }
        [NonAction]
        private string GetPath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CenterGalleryImage/" + name;
        }
        [HttpPut("ImageToGalery")]
        public async Task<IActionResult> AddImageToGallery([FromForm] CenterGallery image)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == image.CenterId);
            if (center != null)
            {
                string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {
                    foreach (var f in image.Files)
                    {


                        string FilePath = GetPath(f.FileName);
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
                           
                            center.GalleryImage.Add(hosturl + "/Upload/CenterGalleryImage/" + f.FileName + "/" + f.FileName);

                        }
                    }
                    _unitOfWork.Center.Update(center);
                    await _unitOfWork.Save();
                    return Ok();
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetCenterGallery")]
        public async Task<IActionResult> CenterGallery(int centerID)
        {
            var center = await _unitOfWork.Center.Get(q=>q.Id==centerID);
            var map = _mapper.Map<GetCenterGalleryDTO>(center);
            return Ok(map);
        }
       
        [HttpPut("EditCenter/{id}")]
        public async Task<IActionResult> EditCenter(int id, [FromBody]EditCenter? center)
        {
            var c = await _unitOfWork.Center.Get(q => q.Id == id);
            _mapper.Map(center, c);
            _unitOfWork.Center.Update(c);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("GetAllCenterAppointment/{centerId}")]
        public async Task<IActionResult> GetAllCenterAppointment(int centerId)
        {
            var center = await _unitOfWork.Center.Get(q => q.Id == centerId, include: x => x.Include(a => a.Appointments).ThenInclude(ca=>ca.Category).Include(a => a.Appointments).ThenInclude(s => s.Service).Include(a => a.Appointments).ThenInclude(ca => ca.User).Include(a => a.Appointments).ThenInclude(ca => ca.Specialist).Include(a => a.Appointments).ThenInclude(ca => ca.Status).Include(a => a.Appointments).ThenInclude(ca => ca.User));
            var map=_mapper.Map<GetCenterAppointment>(center);
            foreach (var item in map.Appointments)
            {
                foreach (var a in center.Appointments)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;

            }
            return Ok(map);
        }
        [HttpGet("GetAllUserAppointment/{userId}/{centerId}")]
        public async Task<IActionResult> GetAllUserAppointment(string userId,int centerId)
        {
            var appointment = await _unitOfWork.Appointment.GetAll(q => q.UserId.Equals(userId) && q.CenterId == centerId, include: x => x.Include(c => c.Center).Include(u => u.User).Include(x => x.Service).Include(p => p.Specialist).Include(s => s.Status));
            var map = _mapper.Map<IList<GetDashAppointment>>(appointment);
            foreach (var item in map)
            {
                foreach (var a in appointment)
                    if (item.Id == a.Id)
                        item.Status = a.Status.Name;
            }
            return Ok(map);
        }
        //[HttpGet("GetCategoryByCenter/{centerId}")]
        //public async Task<IActionResult>GetCategoryByCenter(int centerId)
        //{
        //    var center =
        //}
    }
}
