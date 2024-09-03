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
    public class FavorateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<FavorateController> _logger;
        private readonly IWebHostEnvironment _environment;

        public FavorateController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FavorateController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }
        [HttpPost]
        public async Task<IActionResult> AddFavorate([FromBody]FavorateDTO favorateDTO)
        {
            var map = _mapper.Map<Favorate>(favorateDTO);
            var user = await _unitOfWork.User.Get(q => q.Id.Equals(favorateDTO.UserId));
            user.FavoriteCount++;
            _unitOfWork.User.Update(user);
            await _unitOfWork.Favorate.Insert(map);
            await _unitOfWork.Save();
            return Ok(new {StatusCode= StatusCodes.Status200OK,StatusBody ="AddDone",Status= true });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFavorates()
        {
            var f=await _unitOfWork.Favorate.GetAll(include: x => x.Include(u => u.User).Include(c => c.Center));
            var map=_mapper.Map<IList<GetFavorate>>(f);
            return Ok(map);
        }
        [HttpGet("GetUserFavorate")]
        public async Task<IActionResult>GetUserFavorate(string id)
        {
            var f = await _unitOfWork.Favorate.GetAll(q=>q.UserId.Equals(id),include:x=>x.Include(u=>u.User).Include(c=>c.Center));
        var map=_mapper.Map<IList<GetFavorate>>(f);
            return Ok(map);
        }
    }
}
