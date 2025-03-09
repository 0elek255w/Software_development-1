using Microsoft.EntityFrameworkCore;
using PostgreSQL.Objects;
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

        public OrderObject? Get(Guid orderID, out string errorMessage)
        {
            OrderEntity? orderEntity = this._DbContext.Orders.Find(orderID);

            if (orderEntity == null)
            {
                errorMessage = $"no order with ID {orderID} exists";
                return null;
            }

            OrderObject orderToReturn = new OrderObject();
            orderToReturn.ID = orderID;
            orderToReturn.UserID = orderEntity.UserID;

            List<OrderPositionEntity> positions = this._DbContext.OrderPositions
                .AsNoTracking()
                .Where(position => position.OrderID == orderID)
                .ToList();

            foreach (OrderPositionEntity positionToConvert in positions)
            {
                orderToReturn.Dishes.Add(positionToConvert.DishID, positionToConvert.Amount);
            }

            errorMessage = string.Empty;
            return orderToReturn;
        }

        public bool Create(Guid userID, Dictionary<Guid, int> Dishes, out string errorMessage)
        {
            bool existsUser = this._DbContext.Users.Any(user => user.ID == userID);

            if (!existsUser)
            {
                errorMessage = $"no user with ID {userID} exists";
                return false;
            }

            // TODO: check for user password

            Guid orderID = Guid.NewGuid();
            OrderEntity order = new OrderEntity();
            order.ID = orderID;
            order.UserID = userID;

            this._DbContext.Orders
                .Add(order);

            OrderPositionEntity positionToAdd = new OrderPositionEntity();

            foreach (KeyValuePair<Guid, int> position in Dishes)
            {
                Guid dishID = position.Key;

                bool existsDish = this._DbContext.Dishes.Any(dish => dish.ID == dishID);

                if (!existsDish)
                {
                    errorMessage = $"no dish with ID {dishID} exists";
                    return false;
                }

                positionToAdd.ID = Guid.NewGuid();
                positionToAdd.OrderID = orderID;
                positionToAdd.DishID = dishID;
                positionToAdd.Amount = position.Value;

                this._DbContext.OrderPositions
                    .Add(positionToAdd);
                this._DbContext.SaveChanges(); // TODO: orderPosition can get saved even tho order is not: move dish checking out of loop scope
            }

            this._DbContext.SaveChanges();
            errorMessage = string.Empty;
            return true;
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
