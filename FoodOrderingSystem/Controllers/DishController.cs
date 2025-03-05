using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Repositories;
using PostgreSQL.Tables;

namespace FoodOrderingSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        public readonly DishRepository DbDish;

        public DishController(DishRepository dish)
        {
            this.DbDish = dish;
        }

        [HttpGet]
        public IActionResult<List<DishEntity>> Get()
        {
            List<DishEntity> dishes = this.DbDish.Get(dishID);

            return Ok(dishes)
        }
    }
}
