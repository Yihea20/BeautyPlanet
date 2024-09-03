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
    public class StoreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StoreController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public StoreController(IUnitOfWork unitOfWork, ILogger<StoreController> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CompanyImage/" + name;
        }
        [HttpPost]
        public async Task<IActionResult> AddCenter([FromForm] StoreFile company)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(company.Store.Name.Replace(" ", "_"));
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + company.Store.Name.Replace(" ", "_") + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await company.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Store>(company.Store);
                    result.ImageUrl = hosturl + "/Upload/CompoanyImage/" + company.Store.Name.Replace(" ", "_") + "/" + company.Store.Name.Replace(" ", "_") + ".png"; ;
                    await _unitOfWork.Store.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("GetAllStore")]
        public async Task<IActionResult> GetAllCompany()
        {

            var center = await _unitOfWork.Store.GetAll(include: x => x.Include(c => c.Products).ThenInclude(s => s.Size).Include(co => co.Products).ThenInclude(cc=>cc.Color));
            var result = _mapper.Map<IList<GetStorDTO>>(center);
            return Ok(result);
        }
        [HttpDelete("DeleteStore")]
        public async Task<IActionResult> DeleteStore(int storeID)
        {
            var store = await _unitOfWork.Store.Get(q => q.Id == storeID);
            if (store != null)
            {
                await _unitOfWork.Store.Delete(storeID);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
