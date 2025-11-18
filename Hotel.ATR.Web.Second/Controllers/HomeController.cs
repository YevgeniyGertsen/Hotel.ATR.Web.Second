using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Hotel.ATR.Web.Second.Controllers
{
    [TimeElapsed]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        public HomeController(ILogger<HomeController> logger,
            UserManager<AppUser> userManager,
            IStringLocalizer<HomeController> stringLocalizer)
        {
            _logger = logger;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
        }

       
        //->> Resource Filter (OnResourceExecuting)
        public async Task<IActionResult> Index()
        {
            //->>ActionResult (OnActionExecuting)

            //throw new Exception("Test ERROR!!!");

            var test = _stringLocalizer["Home"];

            //AppUser user = new AppUser();
            //user.UserName = "admin2";
            //user.Email = "gersen.e.a@gmail.com";

            //var result = await  _userManager.CreateAsync(user, "Gg11011988@");

            //->>ActionResult (OnActionExecuted)

            //-->
            return View();
            //-->
        }
        //->> Resource Filter (OnResourceExecuted)

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(string ErrorMessage)
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = ErrorMessage
            });
        }

        public JsonResult Cookie(string culture)
        {
            Response.Cookies
                .Append(

                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddHours(1) }
                );

            return Json(culture);
        }
    }
}
