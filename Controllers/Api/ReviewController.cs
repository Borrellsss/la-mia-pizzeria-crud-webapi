using la_mia_pizzeria_static.Models.Repositories;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private PizzeriaDbContext db;
        public ReviewController(PizzeriaDbContext _db)
        {
            db = _db;
        }
        public IActionResult Get()
        {
            List<Review> reviews = db.Reviews.Include("Pizza").ToList<Review>();
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Review reviewToCreate)
        {
            reviewToCreate.CheckName();

            db.Add(reviewToCreate);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Review newReview)
        {
            Review reviewToUpdate = db.Reviews.Find(id);
            reviewToUpdate.UserName = newReview.UserName;
            reviewToUpdate.Message = newReview.Message;
            reviewToUpdate.CheckName();
            db.SaveChanges();
            return Ok(newReview);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Review reviewToDelete = db.Reviews.Find(id);
            db.Reviews.Remove(reviewToDelete);
            db.SaveChanges();
            return Ok();
        }
        public IActionResult FilterByText(string? text)
        {
            if (text == null)
            {
                List<Review> reviews = db.Reviews.Include("Pizza").ToList<Review>();
                return Ok(reviews);
            }

            List<Review> filteredReviews = db.Reviews.Where(r => r.Message.ToLower().Contains(text.ToLower())).Include("Pizza").ToList<Review>();
            return Ok(filteredReviews);
        }

    }
}
