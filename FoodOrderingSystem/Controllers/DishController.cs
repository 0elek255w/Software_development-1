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
        List<DishEntity> dishes = this.DbDish.Get();

        return Ok(dishes);
    }

    [HttpGet("GetDishByID")]
    public ActionResult<DishEntity> Get(
        Guid dishID
    ) {
        DishEntity? dish = this.DbDish.Get(dishID, out string errorMessage);

        if (dish == null)
            return BadRequest(errorMessage);

        return Ok(dish);
    }

    [HttpPost]
    public ActionResult Create(
        [FromForm] string name,
        [FromForm] string imagePath,
        [FromForm] string composition
    ) {
        DishEntity dish = new DishEntity();
        dish.Name = name;
        dish.ImagePath = imagePath;
        dish.Composition = composition;
        this.DbDish.Create(dish);

        return Ok();
    }
}
