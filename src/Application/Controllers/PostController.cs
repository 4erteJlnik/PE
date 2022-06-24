using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Web1.Domain;
using Web1.Infrastructure;
using Web1.Services;

namespace Web1
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly PostService _postService;
        private readonly IFileService _fileService;
        private readonly UserManager<Peoplelogin> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public PostController(PostService service,
                              ILogger<PostController> logger,
                              FileService fileService,
                              UserManager<Peoplelogin> userManager,
                              RoleManager<IdentityRole<Guid>> roleManager)
        {
            _postService = service;
            _logger = logger;
            _fileService = fileService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Получить обьявления
        /// </summary>
        [HttpGet("GetByUserId")]
        public async Task<IEnumerable<Post>> GetByUserId()
        {
            Guid id = Guid.Parse(_userManager.GetUserId(HttpContext.User));
            return _postService.GetByUser(id);
        }
        /// <summary>
        /// Получить обьявления
        /// </summary>
        [HttpGet("GetNumber")]
        public async Task<IEnumerable<Post>> GetNumber(int number = int.MaxValue)
        {
            return _postService.GetNumber(number);
        }
        /// <summary>
        /// Получить объявление по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get without comments")]
        public async Task<Post> GePosttById(Guid id)
        {
            return _postService.GetNoComments(id);
        }
        /// <summary>
        /// Получить с комментариями
        /// </summary>
        /// <param name="id">id обьявления</param>
        /// <returns></returns>
        [HttpGet("Getwithcomments")]
        public async Task<Post> GetCommentsByPost(Guid id)
        {
            return _postService.GetWithComments(id);
        }
        /// <summary>
        /// Создать обьявление
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="UserId"></param>
        /// <param name="Description"></param>
        /// <param name="PictuteLink"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin, moderator, user")]
        [HttpPost("New")]
        public async Task<IActionResult> CreatePost(Post post)
        {
            try
            {
                //_PService.Add(new Post(Name, UserId, Description, PictuteLink, null));
                post.CreatorId = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                post.ID = Guid.NewGuid();
                _postService.Add(post);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }

        }
        /// <summary>
        /// Создать пустое обьявление
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin, moderator, user")]
        [HttpPost("NewEmpty")]
        public async Task<IActionResult> CreateEmptyPost()
        {
            try
            {
                Post post = new Post();
                post.CreatorId = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                _postService.Add(post);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }

        }
        [Authorize(Roles = "admin, moderator, user")]
        [HttpPost("AddPhoto")]
        public async Task<IActionResult> SetPhoto(Guid postid, IFormFile picture)
        {
            try
            {
                byte[] buffer = new byte[picture.Length];
                picture.OpenReadStream().Read(buffer, 0, (int)picture.Length);
                _fileService.SetPostFirstPicture(new Picture
                {
                    filename = postid,
                    file = buffer
                }, Guid.Parse(_userManager.GetUserId(HttpContext.User)));
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }

        }
        [HttpGet("GetPhoto")]
        public async Task<FileResult> GetPhoto(Guid postid)
        {
            try
            {
                return File(_fileService.GetFirstPostPicture(postid).file, "image/png");
            }
            catch (Exception e)
            {
                return null;
            }

        }
        /// <summary>
        /// Изменить обьявление
        /// </summary>
        /// <param name="Id">Id изменяемого</param>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="PictuteLink"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin, moderator, user")]
        [HttpPatch("Edit")]
        public async Task<IActionResult> Edit(Guid Id, string Name, string Description)
        {
            try
            {
                bool adm = false;
                Guid user = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                List<String> roles = new List<String>();
                roles.Add("admin");
                roles.Add("moderator");
                if (_userManager.GetRolesAsync(_userManager.FindByIdAsync(user.ToString()).Result).Result.Any(roles => roles.Contains("admin") | roles.Contains("moderator")))
                {
                    adm = true;
                }
                _postService.Edit(new Post { ID = Id, Name = Name, Description = Description, DateOfCreate = DateTime.Now, CreatorId = user }, adm);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin, moderator, user")]
        [HttpDelete("DeleteId")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            try
            {
                bool adm = false;
                Guid user = Guid.Parse(_userManager.GetUserId(HttpContext.User));
                List<String> roles = new List<String>();
                roles.Add("admin");
                roles.Add("moderator");
                if (_userManager.GetRolesAsync(_userManager.FindByIdAsync(user.ToString()).Result).Result.Any(roles => roles.Contains("admin") | roles.Contains("moderator")))
                {
                    adm = true;
                }
                _postService.Delete(Id,user,adm);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

    }
}
