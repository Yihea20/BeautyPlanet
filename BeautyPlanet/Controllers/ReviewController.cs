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
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ReviewController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody]ReviewDTO reviewDTO)
        {
            var add = _mapper.Map<Review>(reviewDTO);
            await _unitOfWork.Review.Insert(add);
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var rev = await _unitOfWork.Review.GetAll(include:x=>x.Include(p=>p.Productt));
            var map = _mapper.Map<GetReviewDTO>(rev);
            return Ok(map);
        }
    }
}
