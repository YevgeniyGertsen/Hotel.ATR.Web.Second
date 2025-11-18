using Hotel.ATR.Web.Second.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.Second.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private AppDbContext db;
        public ContactController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactForm form)
        {
            ContactFormValidation rules = new ContactFormValidation();
            var result = rules.Validate(form);

            if(result.IsValid)
            //if (ModelState.IsValid)
            {
                //1
                ViewBag.Result = "";
                //2
                TempData["Result"] = "Ваше сообщение отправлено!";

                db.ContactForms.Add(form);
                db.SaveChanges();
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