using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.Second.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Userlogin userlogin)
        {
            AppUser user = await _userManager.FindByEmailAsync(userlogin.UserName);
            if (user != null)
            {
                await _signInManager.SignOutAsync();

                //делаем авторизацию пользователя
                var result = await _signInManager.PasswordSignInAsync(user, userlogin.Password, false, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("UserName", "Логин или пароль указаны не верно!");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
