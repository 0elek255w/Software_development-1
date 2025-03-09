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
        bool isValid = this.DbOrder.Create(order.UserID, order.Dishes, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Created();
    }

    [HttpPost("GetOrderByID")]
    public ActionResult<OrderObject> Get(
        [FromBody] Guid orderID
    ) {
        OrderObject? order = this.DbOrder.Get(orderID, out string errorMessage);

        if (order == null)
            return BadRequest(errorMessage);

        return Ok(order);
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

    //[HttpDelete]
    //public ActionResult Delete(
    //    [FromForm] Guid orderID
    //) {
    //    bool isValid = this.DbOrder.Delete(orderID, out string errorMessage);

    //    if (!isValid)
    //        return BadRequest(errorMessage);

    //    return Ok();
    //}
}
