using Hotel.Atr.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Atr.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext db;
        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Position()
        {
            List<Position> positions = db.Positions.ToList();

            return View(positions);
        }

        public IActionResult EditPosition(int id=0)
        {
            Position data = db.Positions.Find(id);
            if(data==null)
            {
                data = new Position();
            }
           
            return View(data);
        }

        /// <summary>
        /// метод добавления и редактирования таблицы Position
        /// </summary>
        /// <param name="">Класс Position</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditPosition(Position position)
        {
            if(position.Id>0)
            {
                var data = db.Positions.Find(position.Id);
                if(data!=null)
                {
                    data.Name = position.Name;
                }
            }
            else
            {
                db.Positions.Add(position);
            }

            db.SaveChanges();

            return RedirectToAction("Position");
        }

        public IActionResult DeletePosition(int id)
        {
            var data = db.Positions.Find(id);
            if (data != null)
            {
                db.Positions.Remove(data);
                db.SaveChanges();
            }

            return RedirectToAction("Position");
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
    }
}
