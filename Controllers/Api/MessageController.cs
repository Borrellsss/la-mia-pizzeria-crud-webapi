using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]", Order = 1)]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private PizzeriaDbContext db;
        public MessageController(PizzeriaDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Message messageToCreate)
        {
            db.Add(messageToCreate);
            db.SaveChanges();

            return Ok();
        }
    }
}
