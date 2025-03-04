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
        public IActionResult Get(Guid dishID)
        {
            DishEntity? dish = this.DbDish.Get(dishID);

            if (dish != null)
                return Ok(dish);
            else
                return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Post(
            // [FromForm] DishEntity dish
            [FromForm] string name,
            [FromForm] string imagePath,
            [FromForm] string composition
        )
        {
            // DishEntity dish = new DishEntity { Name = name, ImagePath = imagePath, Composition = composition };
            /*DishEntity dish = new DishEntity();
            dish.ID = Guid.NewGuid();
            dish.Name = "name0";
            dish.ImagePath = "/images/image0";
            dish.Composition = "item{0, 1, 2}";
            dish.Orders = new List<OrderEntity>();*/
            DishEntity dish = new DishEntity
            {
                ID = Guid.NewGuid(),
                Name = name,
                ImagePath = imagePath,
                Composition = composition,
                Orders = new List<OrderEntity>()
            };

            this.DbDish.Add(dish);
            return Ok();
        }
    }
}
