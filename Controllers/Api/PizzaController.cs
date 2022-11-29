using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]", Order = 1)]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IDbPizzaRepository pizzaRepository;
        public PizzaController(IDbPizzaRepository _pizzaRepository)
        {
            pizzaRepository = _pizzaRepository;
        }
        public IActionResult Get()
        {
            List<Pizza> pizzas = pizzaRepository.GetAll(true, true);
            return Ok(pizzas);
        }
        public IActionResult FilterByName(string? name)
        {
            List<Pizza> filteredPizzas = pizzaRepository.GetByName(name);

            return Ok(filteredPizzas);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id, true, true);

            return Ok(pizza);
        }
    }
}