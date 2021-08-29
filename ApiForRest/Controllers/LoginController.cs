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
    public class LoginController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<ActionResult<UserData>> Post(UserData user)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = null;
            if (ModelState.IsValid)
            {
                
                result =
                    await _signInManager.PasswordSignInAsync(user.Login, user.Password, false, false);
                if (result == null)
                    return BadRequest();
                
            }
            return user;
        }
    }
}
