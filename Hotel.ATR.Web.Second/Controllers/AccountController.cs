using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.Second.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager; 
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Userlogin userlogin)
        {
            _logger.LogInformation("User {UserName} attempted to log in to the system {AuthDate}",
                userlogin.UserName, DateTime.Now);

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
                else
                {
                    _logger.LogError("While attempting to log in, user: {UserName} encountered an error: {ErrorMessage}",
                         userlogin.UserName, result.ToString());
                }
            }
            else
            {
                _logger.LogWarning("User {UserName} not found in the database", 
                    userlogin.UserName);
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
