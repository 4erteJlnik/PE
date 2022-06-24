using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Domain;
using Web1.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Web1.Services;
using Web1.PostForms;

namespace Web1
{
    [Authorize(Roles = "admin, moderator, user")]
    
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<Peoplelogin> _userManager;
        private readonly SignInManager<Peoplelogin> _signInManager;
        private readonly PeopleService _peopleService;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        /// <summary>
        /// Контроллер отвечающий за авторизацию / аунтитефикацю пользователей
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="peopleService"></param>
        /// <param name="roleManager"></param>
        public AccountController(UserManager<Peoplelogin> userManager, 
                                 SignInManager<Peoplelogin> signInManager, 
                                 PeopleService peopleService,
                                 RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _peopleService = peopleService;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("RegisterPost")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(String Email, String Password)
        {
            Peoplelogin user = new Peoplelogin
            {
                Id = Guid.NewGuid(),
                Email = Email,
                UserName = Email,
            };
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, Password);
            _peopleService.Add(user);
            await _userManager.AddToRoleAsync(user, "user");
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, true);
                return Ok();
            }
            else
            {
                String problem = "";
                foreach (var error in result.Errors)
                {
                    problem += error.Description;
                }
                return Problem(problem);
            }

            //return View(model);
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("LoginPost")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]SignInForm form)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(form.Email, form.Password, true, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return Problem("Неправильный логин и (или) пароль");
                }
            }
            else
            {
                return Problem("Неверный ввод");
            }
        }
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        [HttpPost("LogoutPost")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return Ok();
        }

        /// <summary>
        /// Сменить пароль
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Email"></param>
        /// <param name="OldPassword"></param>
        /// <param name="NewPassword"></param>
        /// <returns></returns>
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(Guid Id, string Email, string OldPassword, string NewPassword)
        {
            if (ModelState.IsValid)
            {
                Peoplelogin user = await _userManager.FindByIdAsync(Id.ToString());
                if (user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
                    if (result.Succeeded)
                    {
                        //return RedirectToAction("Index");
                        return Ok();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            //return View(model);
            return Ok();
        }

    }
}
