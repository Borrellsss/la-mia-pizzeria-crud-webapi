using la_mia_pizzeria_static.Models.FormModels;
using la_mia_pizzeria_static.Models.Repositories;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Data;

namespace la_mia_pizzeria_static.Controllers
{
    public class ReviewController : Controller
    {
        private PizzeriaDbContext db;
        public ReviewController(PizzeriaDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            Review reviewToUpdate = db.Reviews.Find(id);

            if (reviewToUpdate == null)
            {
                return NotFound();
            }

            return View(reviewToUpdate);
        }
    }
}
