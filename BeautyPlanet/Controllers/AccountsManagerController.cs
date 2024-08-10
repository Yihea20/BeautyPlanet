using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.IRepository;
//using BeautyPlanet.Migrations;
using BeautyPlanet.Models;
using BeautyPlanet.Services;
using Google.Apis.Util;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Register(int code)
        {
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                var email = await _unitOfWork.Code.Get(q => q.MyCode == code);
                if (email == null)
                {
                    pairs.Add("message", "WrongCode");
                    return NotFound(pairs);
                }
                UserRegistDTO personDTO =new UserRegistDTO();
                personDTO.Email = email.Email;
                personDTO.Password=email.Password;
                personDTO.RoleName = new List<string>();
                personDTO.RoleName.Add("USER");
                var user = _mapper.Map<User>(personDTO);
                user.UserName = "New User";
                user.ProfileImageURL = "http://11181198:60-dayfreetrial@yiheamasa-001-site1.jtempurl.com/Upload/CenterImage/yihea/yihea.png";
                user.ImageURL = "http://11181198:60-dayfreetrial@yiheamasa-001-site1.jtempurl.com/Upload/CenterImage/yihea/yihea.png";
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
                pairs.Add("message", "RegistDone");
                return Ok(pairs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Register)}");
                return Problem($"somthging went wrong in the {nameof(Register)}");
            }
        }

        [HttpPost("SendCode")]
        public async Task<IActionResult> SendCode([FromBody]CodeDTO code)
        {

            Random rnd = new Random();
            int myRandomNo = rnd.Next(100000, 999999);
            var map =_mapper.Map<Code>(code);
            var c = await _unitOfWork.Code.Get(q => q.MyCode == myRandomNo);
            while (c != null)
            {
                myRandomNo = rnd.Next(100000, 999999);
                c = await _unitOfWork.Code.Get(q => q.MyCode == myRandomNo);
            }
            map.MyCode = myRandomNo;
            EmailDTO email =new EmailDTO();
            email.To=code.Email;
            email.Subject = "Verification Code";
            email.Body = $"Your Code Is : {myRandomNo}";
            if (_emailService.SendEmail(email))
            {
                await _unitOfWork.Code.Insert(map);
                await _unitOfWork.Save();
                return Ok(map);
            }
            else return NotFound();
           
        }
        [HttpPost]  
        [Route("RegisSpecialist")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisSpecialist(int code)
        {
            try
            {

                var email = await _unitOfWork.Code.Get(q => q.MyCode == code);
                UserRegistDTO personDTO = new UserRegistDTO();
                var user = _mapper.Map<Specialist>(personDTO);
                user.Email = personDTO.Email;
                personDTO.RoleName.Add("EMPLOYEE");
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
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            _logger.LogInformation($"Registerstion Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authoManger.ValidateUser(personDTO))
                {
                    pairs.Add("message", "EmailOrPasswordNotValid");
                    return NotFound(pairs);
                }
               
                var person = await _userManager.FindByEmailAsync(personDTO.Email) as Person;
                
                return Accepted(new TokenRequest { Token = await _authoManger.CreatToken(), RefreshToken = await _authoManger.CreateRefreshToken(), Id = await _userManager.GetUserIdAsync(person) });
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
        //[Authorize]
        [HttpGet]
        [Route("GetSpecialist")]
        public async Task<IActionResult> GetAllSpecialist()
        {
            var specialist = await _unitOfWork.Specialist.GetAll(include:x=>x.Include(a=>a.Appointments));
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
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "failed", Status = false });
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
                    return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "failed", Status = false });
                }
                }
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "failed", Status = false });

        }
        [HttpPut("AddUserInfo")]
        public async Task<IActionResult> AddUserInfo(string id, [FromBody] EditUsetProfile? edit)
        {
            Dictionary<string ,string>pairs = new Dictionary<string ,string>();
            var useer = await _unitOfWork.User.Get(q => q.Id.Equals(id));
            if (User != null) {
                if (!edit.FirstName.IsNullOrEmpty() && !edit.LastName.IsNullOrEmpty())
                {
                    useer.UserName = edit.FirstName + " " + edit.LastName;
                    _mapper.Map(edit, useer);
                }
                else if (edit.FirstName.IsNullOrEmpty()&& !edit.LastName.IsNullOrEmpty())
                {
                    edit.FirstName = useer.FirstName;
                    useer.UserName = edit.FirstName + " " + edit.LastName;
                    _mapper.Map(edit, useer);

                }
                else if (!edit.FirstName.IsNullOrEmpty()&& edit.LastName.IsNullOrEmpty())
                {
                    edit.LastName = useer.LastName;
                    useer.UserName = edit.FirstName + " " + edit.LastName;
                    _mapper.Map(edit, useer);

                }
                else
                {
                    edit.LastName = useer.LastName;
                    edit.FirstName = useer.FirstName;
                    useer.UserName = edit.FirstName + " " + edit.LastName;
                    _mapper.Map(edit, useer);
                }
                _unitOfWork.User.Update(useer);
            await _unitOfWork.Save();
            return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Update Done", Status = true });
        
        }
            else {
                pairs.Add("Message", "UserNotFound"); 
                return NotFound(pairs); }
        }
        [HttpPut("AddSpecialistInfo/{id}")]
        public async Task<IActionResult> AddSpecialistInfo(string id, [FromBody] EditSpecialistProfile edit)
        {
            var useer = await _unitOfWork.Specialist.Get(q => q.Id.Equals(id));

            useer.UserName = edit.FirstName + " " + edit.LastName;
            _mapper.Map(edit, useer);
            var category = await _unitOfWork.Category.Get(q => q.Id == edit.CategoryId, include: x => x.Include(s => s.Services));
            var specialist = await _unitOfWork.Specialist.Get(q => q.Equals(id));
            foreach (var s in category.Services)
            {
                ServiceSpecialistDTO serviceSpecialistDTO = new ServiceSpecialistDTO();
                serviceSpecialistDTO.SpecialistId = id;
                serviceSpecialistDTO.ServiceId = s.Id;
                var map = _mapper.Map<ServiceSpecialist>(serviceSpecialistDTO);
                await _unitOfWork.ServiceSpecialist.Insert(map);

            }
           
            _unitOfWork.Specialist.Update(useer);
            await _unitOfWork.Save();
            return Ok();
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
                    return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "failed", Status = false });
                }
            }
            else return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "failed", Status = false });

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
        [HttpPut("AddDeviceTokken")]
        public async Task<IActionResult> RefreshDeviceTokken(string Id,string deviceTokken)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null) 
            {
                return NotFound();
            }
            else
            {
                user.DeviceTokken = deviceTokken;
                await _userManager.UpdateAsync(user);
                return Ok();
            }
        }
        [HttpPut("AddSpecialistToCategory")]
        public async Task<IActionResult> AddSpecialistToCategory(string specialistId,int categoryId)
        {
            var category = await _unitOfWork.Category.Get(q => q.Id == categoryId, include: x => x.Include(s => s.Services));
            var specialist = await _unitOfWork.Specialist.Get(q => q.Equals(specialistId));
            foreach(var s in category.Services)
            {
                ServiceSpecialistDTO serviceSpecialistDTO = new ServiceSpecialistDTO();
                serviceSpecialistDTO.SpecialistId = specialistId;
                serviceSpecialistDTO.ServiceId = s.Id;
                var map = _mapper.Map<ServiceSpecialist>(serviceSpecialistDTO);
                await _unitOfWork.ServiceSpecialist.Insert(map);
                
            }
            await _unitOfWork.Save();
            return Ok();
        }
        [HttpPost]
        [Route("RegisterAdmin")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistAdmin personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var user = _mapper.Map<Admin>(personDTO);
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
                List <string >RoleName = new List<string>();
               RoleName.Add("MANAGER");
                await _userManager.AddToRolesAsync(user, RoleName);
                //result = await _userManager.AddPasswordAsync(user,);

                return Ok($"StatusCode:{StatusCodes.Status202Accepted}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Register)}");
                return Problem($"somthging went wrong in the {nameof(Register)}");
            }
        }

        [HttpGet("AdminInfo/{id}")]
        public async Task<IActionResult>GetAdminInfo(String id)
        {
            var admin = await _unitOfWork.Admin.Get(q => q.Id.Equals(id), include: x => x.Include(c => c.Center).ThenInclude(s=>s.Specialists).Include(c=>c.Center).ThenInclude(ca=>ca.Categories));
            var map = _mapper.Map<AdminLogIn>(admin);
            return Ok(map);
        }


    }
}
