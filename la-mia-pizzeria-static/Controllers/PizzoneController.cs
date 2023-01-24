using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using la_mia_pizzeria_static.Database;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzoneController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizze = db.Pizze.ToList<Pizza>();
                if (search is null || search == "")
                {
                    pizze = db.Pizze.Include(pizza => pizza.Toppings).ToList<Pizza>();
                }
                else
                {
                    search = search.ToLower();

                    pizze = db.Pizze.Where(pizza => pizza.Nome.ToLower().Contains(search)).Include(pizza => pizza.Toppings).ToList<Pizza>();
                }

                return Ok(pizze);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizza is null)
                {
                    return NotFound("La pizza con questo id non è stata trovata!");
                }

                return Ok(pizza);
            }
        }
    }
}
