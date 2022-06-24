using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PE.Infrastructure.DTO;
using PE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly UserManager<Peoplelogindto> _userManager;
        private readonly PeopleService _peopleService;

        public UserController(UserManager<Peoplelogindto> userManager, PeopleService peopleService)
        {
            _userManager = userManager;
            _peopleService = peopleService;
        }

        /// <summary>
        /// Admin: Добавить пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("AdminCreateUser")]
        public async Task<IActionResult> Create(String Email, String Password)
        {
            if (ModelState.IsValid)
            {
                Peoplelogindto user = new Peoplelogindto
                {
                    Id = Guid.NewGuid(),
                    Email = Email,
                    UserName = Email,
                };
                var result = await _userManager.CreateAsync(user, Password);
                _peopleService.Add(user);
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
            //return View();
            return Ok();
        }

        /// <summary>
        /// Admin: Изменить информацию о пользователе
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AdminEditUser")]
        public async Task<IActionResult> Edit(Peoplelogindto model)
        {
            if (ModelState.IsValid)
            {
                Peoplelogindto user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
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
            }
            //return View(model);
            return Ok();
        }

        /// <summary>
        /// Admin: Удалить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("AdminDeleteUser")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Peoplelogindto user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            //return RedirectToAction("Index");
            return Ok();
        }
    }
}
