using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<Peoplelogindto> _userManager;

        public RolesController(RoleManager<IdentityRole<Guid>> roleManager, UserManager<Peoplelogindto> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Создать роль
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("CreateRole")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole<Guid>(name));
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
            return View(name);
        }

        /// <summary>
        /// Удалить роль
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteRole")]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole<Guid> role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            //return RedirectToAction("Index");
            return Ok();
        }

        /// <summary>
        /// Изменение ролей
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost("EditRole")]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // получаем пользователя
            Peoplelogindto user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                //return RedirectToAction("UserList");
                return Ok();
            }

            return NotFound();
        }
    }
}
