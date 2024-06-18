using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListImageController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListImageController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ListImageController(IUnitOfWork unitOfWork, ILogger<ListImageController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ListImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter([FromForm] Files center)
        {
            string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            ListImageDTO list = new ListImageDTO();
            list.ImageUrl = new List<string>();
            try
            {
                foreach (var f in center.File) 
                { 
                string FilePath = GetFilePath(f.FileName);
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
                    
                    list.ImageUrl.Add( hosturl + "/Upload/ListImage/" + f.FileName + "/" + f.FileName)  ;
                    }
            }

                var map = _mapper.Map<ListImage>(list);
                await _unitOfWork.ListImage.Insert(map);
                await _unitOfWork.Save();
                return Ok();
            }

            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult>GetList()
        {
            var list = await _unitOfWork.ListImage.GetAll();
            return Ok(list);
        }
    }
}
