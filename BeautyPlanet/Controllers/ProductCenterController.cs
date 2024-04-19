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
    public class ProductCenterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductCenterController> _logger;

        public ProductCenterController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductCenterController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductCenter([FromBody] ProductCenterDTO productCenter)
        {
            var m = _mapper.Map<ProductCenter>(productCenter);
            await _unitOfWork.ProductCenter.Insert(m);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductCenter()
        {
            var service = await _unitOfWork.ProductCenter.GetAll();
            var result = _mapper.Map<IList<GetProductCenter>>(service);
            return Ok(result);
        }
    }
}
