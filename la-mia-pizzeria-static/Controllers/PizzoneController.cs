using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using la_mia_pizzeria_static.Database;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzoneController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizze = db.Pizze.ToList<Pizza>();

                return Ok(pizze);
            }
        }
    }
}
