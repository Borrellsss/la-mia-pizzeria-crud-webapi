using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("[controller]/[action]", Order = 0)]
    public class MessageController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
