using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyPlanet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreShoppCategory : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StoreShoppCategory> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public StoreShoppCategory(IUnitOfWork unitOfWork, ILogger<StoreShoppCategory> logger, IMapper mapper, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }
        [HttpPost("AddCategoryToCStore")]
        public async Task<IActionResult> AddCategoryToCenter([FromBody] StoreShoppingCategoryDTO centerCategory)
        {
            var map = _mapper.Map<StoreShopCategory>(centerCategory);
            await _unitOfWork.StoreShoppCategory.Insert(map);
            await _unitOfWork.Save();
            return Ok();
        }
    }
}
