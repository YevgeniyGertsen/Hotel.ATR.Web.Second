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

            ContactFormValidation rules = new ContactFormValidation();
            var result = rules.Validate(form);

            if(result.IsValid)
            //if (ModelState.IsValid)
            {
                //1
                ViewBag.Result = "";
                //2
                TempData["Result"] = "Ваше сообщение отправлено!";
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}