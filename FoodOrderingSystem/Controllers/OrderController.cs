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

    [HttpPost("GetAllOrderIDs")]
    public ActionResult<List<Guid>> GetAllOrders(
        [FromBody] OrderObject order
    ) {
        if (order.UserPassword == null)
            return BadRequest("password ID is null");

        List<Guid>? allOrderIDs = this.DbOrder.GetAllOrderIDsStaff(order.UserID, order.UserPassword, out string errorMessage);

        if (allOrderIDs == null)
            return BadRequest(errorMessage);

        return Ok(allOrderIDs);
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

        order.UserPassword = null;
        return Ok(orderToReturn);
    }

    [HttpPost("GetOrderIDsByUserID")]
    public ActionResult<List<Guid>> GetAllOrderIDsByUserID(
        [FromBody] OrderObject order
    ) {
        if (order.UserPassword == null)
            return BadRequest("password is null");

        List<Guid>? orderIDs = this.DbOrder.GetOrderIDs(order.UserID, order.UserPassword, out string errorMessage);

        if (orderIDs == null)
            return BadRequest(errorMessage);

        return orderIDs;
    }

    [HttpDelete("DeleteOrderByID")]
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

        order.UserPassword = null;
        return Ok();
    }
}
