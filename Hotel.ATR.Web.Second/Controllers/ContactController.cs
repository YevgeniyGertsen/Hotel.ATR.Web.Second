using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.Second.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ContactForm contact = new ContactForm();
            contact.name = "Yevgeniy";
            contact.email = "gersen.e.a@gmail.com";

            return View(contact);
        }

        //string name, string email, string message
        [HttpPost]
        public IActionResult SaveContactForm(ContactForm form)
        {
            //1
            ViewBag.Result = "";
            //2
            TempData["Result"] = "Ваше сообщение отправлено!";

            return RedirectToAction("Index"); 
            //return RedirectToAction("Index", "Home");
            //return View();
        }
    }
}