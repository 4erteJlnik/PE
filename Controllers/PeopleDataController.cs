using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE.Entity;
using PE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Controllers
{
    [Authorize(Roles = "admin, moderator, user")]
    [ApiController]
    [Route("[controller]")]

    public class PeopleDataController : Controller
    {
        private readonly ILogger<PeopleDataController> _logger;
        private readonly PeopleService _peopleService;

        public PeopleDataController(PeopleService peopleService, ILogger<PeopleDataController> logger)
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
