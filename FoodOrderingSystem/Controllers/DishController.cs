using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Repositories;
using PostgreSQL.Tables;

namespace FoodOrderingSystem.Controllers
{
    [ApiController]
    [Route("dish")]
    public class DishController : ControllerBase
    {
        public readonly DishRepository DbDish;

        public DishController(DishRepository dish)
        {
            this.DbDish = dish;
        }

        [HttpGet("get")]
        public IEnumerable<DishEntity> Get()
        {
            // return this.DbDish.AllDishReturn();
            DishEntity dish = new DishEntity();
            dish.ID = Guid.NewGuid();
            dish.Name = "name0";
            dish.ImagePath = "/images/image0";
            dish.Composition = "item{0, 1, 2}";
            dish.Orders = new List<OrderEntity>();
            return new List<DishEntity>{ dish };
        }

        [HttpPost("add")]
        public IActionResult Post(
            // [FromForm] DishEntity dish
        ) {
            // DishEntity dish = new DishEntity { Name = name, ImagePath = imagePath, Composition = composition };
            DishEntity dish = new DishEntity();
            dish.ID = Guid.NewGuid();
            dish.Name = "name0";
            dish.ImagePath = "/images/image0";
            dish.Composition = "item{0, 1, 2}";
            dish.Orders = new List<OrderEntity>();
            this.DbDish.AddDish(dish);
            return Ok();
        }
    }
}
