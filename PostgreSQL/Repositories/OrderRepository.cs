using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;

namespace PostgreSQL.Repositories
{
    public class OrderRepository
    {
        private readonly DbContextFOS _DbContext;

        public OrderRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }

        /*
        public List<OrderEntity>? GetAllUserOrders(Guid userID, out string errorMessage)
        {
            bool exists = this._DbContext.Orders.Any(user => user.ID == userID);

            if (!exists)
            {
                errorMessage = $"user with ID {userID} has no orders";
                return null;
            }

            List<OrderEntity> orderPositions = this._DbContext.Orders
                .AsNoTracking()
                .Where(order => order.UserID == userID)
                .OrderByDescending(ID => ID)
                .ToList();

            errorMessage = String.Empty;
            return orderPositions;
        }
        */

        /*
        public List<Guid>? GetAllOrderIDsByUserID(Guid userID, out string errorMessage)
        {
            bool exists = this._DbContext.Orders.Any(user => user.ID == userID);

            if (!exists)
            {
                errorMessage = $"user with ID {userID} has no orders";
                return null;
            }

            List<Guid> orderIDs = this._DbContext.Orders
                .AsNoTracking()
                .Where(order => order.UserID == userID)
                .Select(order => order.OrderID)
                .Distinct()
                .ToList();

            errorMessage = String.Empty;
            return orderIDs;
        }

        public List<OrderEntity>? GetOrderByID(Guid orderID, out string errorMessage)
        {
            bool exists = this._DbContext.Orders.Any(order => order.OrderID == orderID);

            if (!exists)
            {
                errorMessage = $"no order with ID {orderID} exests";
                return null;
            }

            List<OrderEntity> orders = this._DbContext.Orders
                .AsNoTracking()
                .Where(order => order.OrderID == orderID)
                .ToList();

            errorMessage = String.Empty;
            return orders;
        }

        public bool Create(Guid userID, Dictionary<Guid, int> dishAmounts, out string errorMessage)
        {
            bool existsUser = this._DbContext.Users.Any(user => user.ID == userID);

            if (!existsUser)
            {
                errorMessage = $"no user with ID {userID} exests";
                return false;
            }

            Guid orderID = Guid.NewGuid();

            foreach (KeyValuePair<Guid, int> dishAmount in dishAmounts)
            {
                Guid dishID = dishAmount.Key;
                int amount = dishAmount.Value;
                bool existsDish = this._DbContext.Dishes.Any(dish => dish.ID == dishID);

                if (!existsDish)
                {
                    errorMessage = $"no dish with ID {dishID} exists";
                    return false;
                }

                OrderEntity order = new OrderEntity();
                order.ID = Guid.NewGuid();
                order.OrderID = orderID;
                order.UserID = userID;
                order.DishID = dishID;
                order.Amount = amount;
                order.User = null;
                order.Dish = null;

                this._DbContext.Orders.Add(order);
            }

            this._DbContext.SaveChanges();

            errorMessage = String.Empty;
            return true;
        }

        public bool Delete(Guid orderID, out string errorMessage)
        {
            bool exists = this._DbContext.Orders.Any(order => order.OrderID == orderID);

            if (!exists)
            {
                errorMessage = $"no order with ID {orderID} exists";
                return false;
            }

            errorMessage = String.Empty;
            this._DbContext.Orders
                .Where(order => order.ID == orderID)
                .ExecuteDelete();

            return true;
        }
        */
    }
}
