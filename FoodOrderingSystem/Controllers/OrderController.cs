using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Tables;
using PostgreSQL.Repositories;
using FoodOrderingSystem.Cores;
using System.Collections.Frozen;

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

    /*
    [HttpGet("GetOrderByID")]
    public ActionResult<OrderCore> GetOrderByID(
        [FromForm] Guid orderID
    ) {
        List<OrderEntity>? orderPositions = this.DbOrder.GetOrderByID(orderID, out string errorMessage);

        if (orderPositions  == null)
            return BadRequest(errorMessage);

        OrderCore order = new OrderCore(orderID, orderPositions);
        return Ok(order);
    }
    */

    [HttpGet("GetOrderIDsByUserID")]
    public ActionResult<List<Guid>> GetAllOrderIDsByUserID(
        [FromForm] Guid userID
    ) {
        List<Guid>? orderIDs = this.DbOrder.GetAllOrderIDsByUserID(userID, out string errorMessage);

        if (orderIDs == null)
            return BadRequest(errorMessage);

        return Ok(orderIDs);
    }

    [HttpPost]
    public ActionResult Create(
        [FromBody] OrderCore order
    ) {
        bool isValid = this.DbOrder.Create(order.UserID, order.Dishes, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(
        [FromForm] Guid orderID
    ) {
        bool isValid = this.DbOrder.Delete(orderID, out string errorMessage);

        if (!isValid)
            return BadRequest(errorMessage);

        return Ok();
    }
}
