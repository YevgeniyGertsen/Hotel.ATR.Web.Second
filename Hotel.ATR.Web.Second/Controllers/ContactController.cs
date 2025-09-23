using Hotel.ATR.Web.Second.Models;
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
        public IActionResult Index(ContactForm form)
        {
            //if (string.IsNullOrWhiteSpace(form.name))
            //{
            //    ModelState.AddModelError("name", "Необходимо укзать имя");
            //}

            if (ModelState.IsValid)
            {
                //1
                ViewBag.Result = "";
                //2
                TempData["Result"] = "Ваше сообщение отправлено!";
            }

            return View();
        }
    }
}