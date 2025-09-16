using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.Second.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveContactForm(string name, string email, string message)
        {

            return View();
        }
    }
}