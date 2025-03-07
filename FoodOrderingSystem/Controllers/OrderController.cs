using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Tables;
using PostgreSQL.Repositories;
using FoodOrderingSystem.Cores;

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
        [FromForm] Guid userID,
        [FromForm] Dictionary<Guid, int> dishAmounts
        // [FromForm] OrderEntity order
    ) {
        bool isValid = this.DbOrder.Create(userID, dishAmounts, out string errorMessage);

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
