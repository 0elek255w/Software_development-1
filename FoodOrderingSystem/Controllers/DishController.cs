using PostgreSQL.Objects;
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

    [HttpPost("CreateDish")]
    public ActionResult Create(
        [FromBody] DishObject dishObject
    ) {
        DishEntity dish = new DishEntity();

        if (dishObject.Name == null)
            return BadRequest("name is null");

        if (dishObject.Price == null)
            return BadRequest("price is null");

        if (dishObject.Image == null)
            dish.Image = string.Empty;
        else
            dish.Image = dishObject.Image;

        if (dishObject.Composition == null)
            dish.Composition = string.Empty;
        else
            dish.Composition = dishObject.Composition ;

        dish.Name = dishObject.Name;
        dish.Price = (decimal)dishObject.Price;
        this.DbDish.Create(dish);

        return Created();
    }

    [HttpDelete("DeleteDish")]
    public ActionResult Delete(
        [FromBody] OrderObject dishObject
    ) {
        if (dishObject.ID == null)
            return BadRequest("ID is null");

        if (dishObject.UserPassword == null)
            return BadRequest("password is null");

        bool isValid = this.DbDish.Delete(dishObject, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok(isValid);
    }
}
