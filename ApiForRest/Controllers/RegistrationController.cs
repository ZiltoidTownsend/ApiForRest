using ApiForRest.Models;
using LibraryMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserData>> Post(UserData user)
        {
            User newUser = new User { UserName = user.Login, Role = user.Role};
            if (ModelState.IsValid)
            {
                    // добавляем пользователя
                    var result = await _userManager.CreateAsync(newUser, user.Password);
                    if (result.Succeeded)
                    {
                        // установка куки
                        await _signInManager.SignInAsync(newUser, false);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return BadRequest(ModelState);
                    }
            }
            return user;
        }
    }
}
