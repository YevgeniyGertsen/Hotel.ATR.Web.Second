using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Hotel.ATR.Web.Second.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            var test = _stringLocalizer["Home"];

            //AppUser user = new AppUser();
            //user.UserName = "admin2";
            //user.Email = "gersen.e.a@gmail.com";

            //var result = await  _userManager.CreateAsync(user, "Gg11011988@");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
