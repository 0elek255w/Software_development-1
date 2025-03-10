using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Repositories;
using PostgreSQL.Objects;

namespace FoodOrderingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly OrderRepository DbOrder;

    public OrderController(OrderRepository order)
    {
        this.DbOrder = order;
    }

    [HttpPost("Create")]
    public ActionResult Create(
        [FromBody] OrderObject order
    ) {
        Dictionary<Guid, int>? orderPositions = order.Dishes;

        if (orderPositions == null)
            return BadRequest("Dishes is null");

        if (orderPositions.Count < 1)
            return BadRequest("Dishes is empty");

        if (order.UserPassword == null)
            return BadRequest("user password is null");

        bool isValid = this.DbOrder.Create(order.UserID, order.UserPassword, orderPositions, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Created();
    }

    [HttpPost("GetOrderByID")]
    public ActionResult<OrderObject> Get(
        [FromBody] OrderObject order
    ) {
        if (order.ID == null)
            return BadRequest("order ID is null");

        OrderObject? orderToReturn = this.DbOrder.Get(order, out string errorMessage);

        if (orderToReturn == null)
            return BadRequest(errorMessage);

        return Ok(orderToReturn);
    }

    //[HttpGet("GetOrderIDsByUserID")]
    //public ActionResult<List<Guid>> GetAllOrderIDsByUserID(
    //    [FromForm] Guid userID
    //) {
    //    List<Guid>? orderIDs = this.DbOrder.GetAllOrderIDsByUserID(userID, out string errorMessage);

    //    if (orderIDs == null)
    //        return BadRequest(errorMessage);

    //    return Ok(orderIDs);
    //}

    [HttpDelete]
    public ActionResult Delete(
        [FromBody] OrderObject order
    ) {
        if (order.ID == null)
            return BadRequest("order ID is null");

        if (order.UserPassword == null)
            return BadRequest("user password is null");

        bool isValid = this.DbOrder.Delete(order, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok();
    }
}
