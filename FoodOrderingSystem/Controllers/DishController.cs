using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Repositories;
using PostgreSQL.Tables;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class DishController : ControllerBase
{
    public readonly DishRepository DbDish;

    public DishController(DishRepository dish)
    {
        this.DbDish = dish;
    }

    [HttpGet("GetAllDishes")]
    public ActionResult<List<DishEntity>> Get()
    {
        List<DishEntity> dishes = this.DbDish.GetAllDishes();

        return Ok(dishes);
    }

    [HttpGet("GetDishByID")]
    public ActionResult<DishEntity> Get(
        Guid dishID
    ) {
        DishEntity? dish = this.DbDish.GetDishByID(dishID, out string errorMessage);

        if (dish == null)
            return BadRequest(errorMessage);

        return Ok(dish);
    }

    [HttpPost]
    public ActionResult Create(
        [FromForm] string name,
        [FromForm] string image,
        [FromForm] string composition
    ) {
        DishEntity dish = new DishEntity();
        dish.Name = name;
        dish.Image = image;
        dish.Composition = composition;
        this.DbDish.Create(dish);

        return Created();
    }
}
