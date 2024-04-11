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
    public class GallaryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GallaryController> _logger;
        private readonly IWebHostEnvironment _environment;
        private int conter = 0;
        public GallaryController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GallaryController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> AddGallery([FromBody] GalleryDTO gallery)
        {
            var result = _mapper.Map<Gallery>(gallery);
            await _unitOfWork.Gallery.Insert(result);
            await _unitOfWork.Save();
            return Ok();
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/GalleryImage/" + name;
        }
        [HttpPost("AddImage")]
        public async Task<IActionResult> AddImage([FromForm] ImageFile image)
        {
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {

                var gallery = await _unitOfWork.Gallery.Get(q => q.Id==image.Create.GalleryId);
                string FilePath = GetFilePath(gallery.GallaryName);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + image.Files.FileName ;
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await image.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Image>(image.Create);
                  result.ImageUrl=  hosturl + "/Upload/GalleryImage/" + gallery.GallaryName + "/" + image.Files.FileName ;
                    
                     await _unitOfWork.Image.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("AllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var center = await _unitOfWork.Gallery.GetAll(include:x=>x.Include(p=>p.Images));
            var result = _mapper.Map<IList<GetGallery>>(center);
            return Ok(result);
        }
    }
}
