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
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompanyController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CompanyController(IUnitOfWork unitOfWork, ILogger<CompanyController> logger, IMapper mapper, IWebHostEnvironment environment)
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
        public async Task<IActionResult> AddCenter([FromForm] CompanyFile company)
        {
            string hosturl = $"{this.Request.Scheme}://11171443:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string FilePath = GetFilePath(company.Companies.Name);
                if (!System.IO.Directory.Exists(FilePath))
                {
                    System.IO.Directory.CreateDirectory(FilePath);
                }
                string url = FilePath + "\\" + company.Companies.Name + ".png";
                if (System.IO.File.Exists(url))
                {
                    System.IO.File.Delete(url);
                }
                using (FileStream stream = System.IO.File.Create(url))
                {
                    await company.Files.CopyToAsync(stream);
                    var result = _mapper.Map<Company>(company.Companies);
                    result.ImageUrl = hosturl + "/Upload/CompoanyImage/" + company.Companies.Name + "/" + company.Companies.Name + ".png"; ;
                    await _unitOfWork.Company.Insert(result);
                    await _unitOfWork.Save();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany()
        {

            var center = await _unitOfWork.Company.GetAll();
            var result = _mapper.Map<IList<GetCompanyDTO>>(center);
            return Ok(result);
        }


    }
}
