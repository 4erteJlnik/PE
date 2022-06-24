using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Web1.Domain;
using Web1.Services;


namespace Web1
{
    [Authorize(Roles = "admin, moderator, user")]
    [ApiController]
    [Route("[controller]")]

    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService, ILogger<PeopleController> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }
        /// <summary>
        /// Получить информацию о пользователе
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNumber")]
        public IEnumerable<People> GetNumber(int number = int.MaxValue)
        {
            return _peopleService.GetAll(number);
        }
        [HttpGet("GetAll")]
        public IEnumerable<People> GetAll(int number = int.MaxValue)
        {
            return _peopleService.GetAll();
        }
        [HttpGet("ByID")]
        public People Get(Guid id)
        {
            return _peopleService.Get(id);
        }

        /// <summary>
        /// Обновление информации о пользователе
        /// </summary>
        /// <returns></returns>
    }
}
