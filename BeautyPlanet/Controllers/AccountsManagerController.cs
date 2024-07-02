using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
using BeautyPlanet.Migrations;
using BeautyPlanet.Models;
using BeautyPlanet.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;

namespace BeautyPlanet.Controllers
{

    [Route("api/[controller]")]
    
    [ApiController]
   
    public class AccountsManagerController : ControllerBase
    {

        private readonly UserManager<Person> _userManager;
        private readonly ILogger<AccountsManagerController> _logger;
        private readonly IAuthoManger _authoManger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly IEmailService _emailService;

        public AccountsManagerController(UserManager<Person> userManager, ILogger<AccountsManagerController> logger, IAuthoManger authoManger, IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment environment, IEmailService emailService)
        {
            _userManager = userManager;
            _logger = logger;
            _authoManger = authoManger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _environment = environment;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("Regis")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserRegistDTO personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var user = _mapper.Map<User>(personDTO);
                user.UserName = personDTO.FirstName + personDTO.LastName;
                user.Email = personDTO.Email;
                var result = await _userManager.CreateAsync(user, personDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);

                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, personDTO.RoleName);
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                var person = await _userManager.FindByEmailAsync(personDTO.Email) as Person;
                person.Code = myRandomNo.ToString();
                await _userManager.UpdateAsync(person);
                EmailDTO emailDTO = new EmailDTO();
                emailDTO.To= personDTO.Email;
                emailDTO.Subject = "veryfiyEmail";
                emailDTO.Body = $"your code is{myRandomNo} ";
                 _emailService.SendEmail(emailDTO);
                //result = await _userManager.AddPasswordAsync(user,);

                return Ok($"StatusCode:{StatusCodes.Status202Accepted}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Register)}");
                return Problem($"somthging went wrong in the {nameof(Register)}");
            }
        }

        [HttpPost]
        [Route("RegisSpecialist")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisSpecialist([FromBody] SpecialisRegistDTO personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var user = _mapper.Map<Specialist>(personDTO);
                user.UserName = personDTO.FirstName + personDTO.LastName;
                user.Email = personDTO.Email;
                var result = await _userManager.CreateAsync(user, personDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);

                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, personDTO.RoleName);


                //result = await _userManager.AddPasswordAsync(user,);

                return Ok($"StatusCode:{StatusCodes.Status202Accepted}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Register)}");
                return Problem($"somthging went wrong in the {nameof(Register)}");
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authoManger.ValidateUser(personDTO))
                {
                    return Unauthorized();
                }
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                var person = await _userManager.FindByEmailAsync(personDTO.Email) as Person;
                person.Code = myRandomNo.ToString();
                await _userManager.UpdateAsync(person);
                return Accepted(new TokenRequest { Token = await _authoManger.CreatToken(), RefreshToken = await _authoManger.CreateRefreshToken(), rand = myRandomNo.ToString(), Id = await _userManager.GetUserIdAsync(person) });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Login)}");
                return Problem($"somthging went wrong in the {nameof(Login)}");
            }
        }
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest = await _authoManger.VerifyRefreshToken(request);
            if (tokenRequest is null)
            {
                return Unauthorized();
            }

            return Ok(tokenRequest);
        }

        [HttpGet("GetUser")]

        public async Task<IActionResult> GetAllUser()
        {
            var specialist = await _unitOfWork.User.GetAll();
            var result = _mapper.Map<IList<GetUserDTO>>(specialist);


            return Ok(result);

        }
        [Authorize]
        [HttpGet]
        [Route("GetSpecialist")]
        public async Task<IActionResult> GetAllSpecialist()
        {
            var specialist = await _unitOfWork.Specialist.GetAll();
            var result = _mapper.Map<IList<GetSpecialistDTO>>(specialist);
            return Ok(result);

        }
        [HttpPut]
        [Route("RefreshLocation/{Id}")]
        public async Task<IActionResult> RefreshLocation(String Id, [FromBody]location location )
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                user.Lat = location.lat;
                user.Lng = location.lng;
                await _userManager.UpdateAsync(user);
                return Ok(new {StatusCode=StatusCodes.Status200OK,StatusBody="Update Done",Status=true});
            }
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "faield", Status = false });
        }
        [HttpPut]
        [Route("UpdatePhoto")]
        public async Task<IActionResult>UpdatePhoto([FromForm]photo photo)
        {
            var user = await _userManager.FindByIdAsync(photo.Id);
            if (user != null)
            {

                string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {
                    string FilePath = GetFilePath(user.Email.Replace(" ", "_"));
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + photo.File.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await photo.File.CopyToAsync(stream);
                        user.ImageURL = hosturl + "/Upload/UserImage/" + user.Email.Replace(" ", "_") + "/" + photo.File.FileName;
                        await _userManager.UpdateAsync(user);
                        return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Update Done", Status = true });
                    }
                }
                catch (Exception e)
                {
                    return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "faield", Status = false });
                }
                }
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "faield", Status = false });

        }
        [HttpPut]
        [Route("UpdateProfilePhoto")]
        public async Task<IActionResult> UpdateProfilePhoto([FromForm] photo photo)
        {
            var user = await _userManager.FindByIdAsync(photo.Id);
            if (user != null)
            {

                string hosturl = $"{this.Request.Scheme}://11181198:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";

                try
                {
                    string FilePath = GetProfileFilePath(user.Email.Replace(" ", "_"));
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }
                    string url = FilePath + "\\" + photo.File.FileName;
                    if (System.IO.File.Exists(url))
                    {
                        System.IO.File.Delete(url);
                    }
                    using (FileStream stream = System.IO.File.Create(url))
                    {
                        await photo.File.CopyToAsync(stream);
                        user.ProfileImageURL = hosturl + "/Upload/ProfileImage/" + user.Email.Replace(" ", "_") + "/" + photo.File.FileName;
                        await _userManager.UpdateAsync(user);
                        return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Update Done", Status = true });
                    }
                }
                catch (Exception e)
                {
                    return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "faield", Status = false });
                }
            }
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "faield", Status = false });

        }
        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/UserImage/" + name;
        }
         [NonAction]
        private string GetProfileFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/ProfileImage/" + name;
        }
        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] EmailDTO email)
        {
            _emailService.SendEmail(email);
            return Ok();

        }
    }
}
