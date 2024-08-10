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
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostController> _logger;
        private readonly IWebHostEnvironment _environment;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostController> logger, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _environment = environment;
        }

        [NonAction]
        private string GetFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/SpPostImage/" + name;
        }
        [HttpPost("AddSpPost")]
        public async Task<IActionResult> AddSpPost([FromForm] PostSpFile product)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            var result = _mapper.Map<Post>(product.SpPost);
            try
            {
                foreach (var f in product.Files)
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
                        result.ImageUrl.Add(hosturl + "/Upload/SpPostImage/" + f.FileName + "/" + f.FileName);
                    }
                }

                await _unitOfWork.Post.Insert(result);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [NonAction]
        private string GetCenterFilePath(string name)
        {
            return this._environment.WebRootPath + "/Upload/CenterPostImage/" + name;
        }
        [HttpPost("AddCenterPost")]
        public async Task<IActionResult> AddCenterPost([FromForm] PostCenterPost product)
        {
            string hosturl = $"{this.Request.Scheme}://11189934:60-dayfreetrial@{this.Request.Host}{this.Request.PathBase}";
            var result = _mapper.Map<Post>(product.CenterPost);
            try
            {
                foreach (var f in product.Files)
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
                        result.ImageUrl.Add(hosturl + "/Upload/CenterPostImage/" + f.FileName + "/" + f.FileName);
                    }
                }

                await _unitOfWork.Post.Insert(result);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        [HttpPut("PostLike")]
        public async Task<IActionResult> Like([FromBody]UserPostDTO userPost)
        {
            var post = await _unitOfWork.Post.Get(q => q.Id == userPost.PostId);
            var user =await _unitOfWork.User.Get(q => q.Id.Equals(userPost.UserId));
            if (post == null || user == null)
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("message", "some thing not true");
                return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "false", Status = false});
            }
            else
            {
                var userpost = await _unitOfWork.UserPost.Get(q => q.UserId.Equals(userPost.UserId) && q.PostId == userPost.PostId,include:x=>x.Include(u=>u.User).Include(p=>p.Post));

                if (userpost == null)
                {
                    post.likes++;
                    user.Like++;
                    var map = _mapper.Map<UserPost>(userPost);
                    await _unitOfWork.UserPost.Insert(map);
                    _unitOfWork.Post.Update(post);
                    _unitOfWork.User.Update(user);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Like", Status = true,IsLike=true,Liks=post.likes });
                }
                else
                {
                    post.likes--;
                    user.Like--;
                    await _unitOfWork.UserPost.Delete(userpost.Id);
                    _unitOfWork.Post.Update(post);
                    _unitOfWork.User.Update(user);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "DisLike", Status = true, IsLike = false, Liks = post.likes });
                }
            }
      }
        [HttpGet("GetAllPost")]
        public async Task<IActionResult> GetAllPost(string userId)
        {
            var post = await _unitOfWork.Post.GetAll(include: x => x.Include(s=>s.Specialist).Include(c=>c.Comments));
            var userpos = await _unitOfWork.UserPost.GetAll(q => q.UserId.Equals(userId));
            var usersave = await _unitOfWork.UserSavedPost.GetAll(q => q.UserId.Equals(userId));
            var map =_mapper.Map<IList<GetCenterPost>>(post);
            foreach(var u in userpos)
                foreach(var v in map)
                    if(v.Id==u.PostId)
                    {
                        v.IsLiked = true;
                    }
            foreach (var u in usersave)
                foreach (var v in map)
                    if (v.Id == u.PostId)
                    {
                        v.IsSaved = true;
                    }

            return Ok(map);
        }
        [HttpGet("GetPostById")]
        public async Task<IActionResult> GetPostById(int postid)
        {
            var post = await _unitOfWork.Post.Get(q=>q.Id==postid,include: x => x.Include(s=>s.Specialist).Include(c => c.Comments));
            var map = _mapper.Map<GetCenterPost>(post);
            return Ok(map);
        }
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody]CommentDTO comment)
        {
            var map=_mapper.Map<Comment>(comment);
            await _unitOfWork.Comment.Insert(map);
            await _unitOfWork.Save();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("message", "Add Done");
            return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "AddDone", Status = true });
        }
        [HttpGet("GetAllComments")]
        public async Task<IActionResult>GetAllComments(string userId,int postId)
        {
            var comments = await _unitOfWork.Comment.GetAll(q=>q.PostId==postId,include:x=>x.Include(c=>c.User).Include(p=>p.Post));
            var usercomment=await _unitOfWork.UserComment.GetAll(q=>q.UserId.Equals(userId),include:x=>x.Include(u=>u.UserLike));
            var map=_mapper.Map<IList<GetComment>>(comments);
            foreach (var u in usercomment)
                foreach (var v in map)
                    if (v.Id == u.CommentId)
                    {
                        v.IsLiked = true;
                    }
            return Ok(map);
        }
        [HttpGet("GetComment")]
        public async Task<IActionResult>GetComment(int commintId)
        {
            var comments = await _unitOfWork.Comment.Get(q=>q.Id==commintId,include: x => x.Include(c => c.User));
            var map = _mapper.Map<GetComment>(comments);
            return Ok(map);

        }
        [HttpPut("CommentLike")]
        public async Task<IActionResult> CommentLike([FromBody] UserCommentDTO userComment)
        {
            var comments = await _unitOfWork.Comment.Get(q => q.Id == userComment.CommentId);
            var user = await _unitOfWork.User.Get(q => q.Id.Equals(userComment.UserId));
            if (comments == null || user == null)
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("message", "some thing not true");
                return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "false", Status = false });
            }
            else
            {
                var usercomment = await _unitOfWork.UserComment.Get(q => q.UserId.Equals(userComment.UserId) && q.CommentId == userComment.CommentId, include: x => x.Include(u => u.UserLike).Include(p => p.Comment));

                if (usercomment == null)
                {
                    comments.Like++;

                    var map = _mapper.Map<UserComment>(userComment);
                    await _unitOfWork.UserComment.Insert(map);
                    _unitOfWork.Comment.Update(comments);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Like", Status = true, IsLike = true,Liks=comments.Like });
                }
                else
                {
                    comments.Like--;
                    await _unitOfWork.UserComment.Delete(usercomment.Id);
                    _unitOfWork.Comment.Update(comments);
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "DisLike", Status = true, IsLike = false, Liks = comments.Like });
                }
            }
        }
        
        [HttpPut("SavePost")]
        public async Task<IActionResult> Save([FromBody] UserSavedPostDTO userPost)
        {
            var post = await _unitOfWork.Post.Get(q => q.Id == userPost.PostId);
            var user = await _unitOfWork.User.Get(q => q.Id.Equals(userPost.UserId));
            if (post == null || user == null)
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                pairs.Add("message", "some thing not true");
                return NotFound(new { StatusCode = StatusCodes.Status404NotFound, StatusBody = "false", Status = false });
            }
            else
            {
                var userpost = await _unitOfWork.UserSavedPost.Get(q => q.UserId.Equals(userPost.UserId) && q.PostId == userPost.PostId, include: x => x.Include(u => u.User).Include(p => p.Post));

                if (userpost == null)
                {
                   
                    var map = _mapper.Map<UserSavedPost>(userPost);
                    await _unitOfWork.UserSavedPost.Insert(map);
                  
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "Save", Status = true, IsSave = true });
                }
                else
                {
                   
                    await _unitOfWork.UserSavedPost.Delete(userpost.Id);
                   
                    await _unitOfWork.Save();
                    return Ok(new { StatusCode = StatusCodes.Status200OK, StatusBody = "UnSave", Status = true, IsSave = false });
                }
            }
        }
        [HttpGet("GetSavedPost")]
        public async Task<IActionResult> GetSavedPost(string usserID)
        {
            var userpost = await _unitOfWork.UserSavedPost.GetAll(q => q.UserId.Equals(usserID) , include: x => x.Include(p => p.Post));
            var map = _mapper.Map<IList<GetSavedPost>>(userpost);
            return Ok(map);
        }
    }
    
}
