using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Domain;
using Web1.Services;
using Web1.Infrastructure;


namespace Web1
{
    /// <summary>
    /// Получение и отправка комментариев
    /// </summary>
    [Authorize(Roles = "admin, moderator, user")]
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly ILogger<PeopleDataController> _logger;
        private readonly CommentService _CService;
        
        /// <summary>
        /// DI
        /// </summary>
        /// <param name="logger">log</param>
        /// <param name="service">for test</param>
        public CommentsController(ILogger<PeopleDataController> logger, CommentService service)
        {
            _logger = logger;
            _CService = service;
        }
        /// <summary>
        /// Получить комментарии к обьявлению
        /// </summary>
        /// <returns></returns>
        [HttpGet("post")]
        public IEnumerable<PostComment> GetComments(Guid PostId)
        {
            return _CService.GetByPost(PostId);
        }
        /// <summary>
        /// Отправить комментарий
        /// </summary>
        /// <param name="PostId">Id обьявления</param>
        /// <param name="description">Текст комментария</param>
        /// <param name="user">id автора</param>
        /// <returns></returns>
        [HttpPost("Post")]
        public IActionResult Post(PostComment Postcomment)
        {
            try
            {
                //_CService.Add(new PostComment(PostId, user, description));
                _CService.Add(Postcomment);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
        /// <summary>
        /// Изменение комментария
        /// </summary>
        /// <param name="CommentId">Id изменяемого</param>
        /// <param name="Description">Текст комментария</param>
        /// <returns></returns>
        [HttpPatch("EditAndGet")]
        public async Task<PostComment> EditReturn([FromForm] Guid CommentId, String Description)
        {
            try
            {
                return _CService.Edit(CommentId, Description);
            }
            catch(Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }
        [HttpPatch("Edit")]
        public async Task<IActionResult> Edit([FromForm] Guid CommentId, String Description)
        {
            try
            {
                _CService.Edit(CommentId, Description);
                return Ok();
            }            
            catch(Exception e)
            {
                return Problem(e.ToString());
            }
        }
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="CommentId">Id удаляемого</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid CommentId)
        {
            try
            {
                _CService.Delete(CommentId);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem("Not deleted" + e);
            }
        }
        /// <summary>
        /// Получить все комментарии из бд(test)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetAll")]
        public List<PostComment> GetAll()
        {
            return _CService.GetAll();
        }
    }
}
