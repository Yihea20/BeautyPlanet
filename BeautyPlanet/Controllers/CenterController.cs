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

            var center = await _unitOfWork.Center.GetAll(include: x => x.Include(p => p.Specialists).Include(pp=>pp.Posts).ThenInclude(c=>c.Comments).ThenInclude(u=>u.User));
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

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetCenter(String Name)
        {
            var center = await _unitOfWork.Center.Get(q => q.Name == Name);
            var result = _mapper.Map<GetCenterDTO>(center);
            return Ok(result);
        }
        [HttpPost("AddCategoryToCenter")]
        public async Task<IActionResult> AddCategoryToCenter([FromBody]CenterCategoryDTO centerCategory)
        {
            var map=_mapper.Map<CenterCategory>(centerCategory);
            await _unitOfWork.CenterCategory.Insert(map);
            await _unitOfWork.Save();
            return Ok();
        }
        //[HttpPut("ImageToGalery")]
        //public async Task<IActionResult>AddImageToGallery([FromForm] CenterGallery image)
        //{
        //    var center = await _unitOfWork.Center.Get(q => q.Id == image.CenterId);
        //    if(center!=null)
        //    {
        //        string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
               
        //        try
        //        {
        //            foreach (var f in image.Files)
        //            {


        //                string FilePath = GetFilePath(f.FileName);
        //                if (!System.IO.Directory.Exists(FilePath))
        //                {
        //                    System.IO.Directory.CreateDirectory(FilePath);
        //                }
        //                string url = FilePath + "\\" + f.FileName;
        //                if (System.IO.File.Exists(url))
        //                {
        //                    System.IO.File.Delete(url);
        //                }
        //                using (FileStream stream = System.IO.File.Create(url))
        //                {
        //                    await f.CopyToAsync(stream);

        //                    center.GalleryImage.Add(hosturl + "/Upload/CenterGalleryImage/" + f.FileName + "/" + f.FileName);

        //                }
        //            }
        //             _unitOfWork.Center.Update(center);
        //            await _unitOfWork.Save();
        //            return Ok();
        //        }
        //        catch (Exception e)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        [HttpGet("GetCenterGallery")]
        public async Task<IActionResult> CenterGallery(int centerID)
        {
            var center = await _unitOfWork.Center.Get(q=>q.Id==centerID);
            var map = _mapper.Map<GetCenterGalleryDTO>(center);
            return Ok(map);
        }
        [NonAction]
        private string GetPath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CenterGalleryImage/" + name;
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
    }
}
