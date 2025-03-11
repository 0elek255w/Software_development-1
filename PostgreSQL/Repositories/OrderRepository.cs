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

        public List<Guid>? GetAllOrderIDsStaff(Guid userID, string userPassword, out string errorMessage)
        {
            UserEntity? user = this._DbContext.Users.Find(userID);

            if (user == null)
            {
                errorMessage = $"no user with ID {userID} exists";
                return null;
            }

            if (user.Type != UserTypes.Staff)
            {
                errorMessage = $"user of type {user.Type} can not access all orders";
                return null;
            }

            if (user.Password != userPassword)
            {
                errorMessage = "incorrect password";
                return null;
            }

            List<Guid> orderIDs = this._DbContext.Orders
                .AsNoTracking()
                .Select(order => order.ID)
                .ToList();
            errorMessage = string.Empty;
            return orderIDs;
        }

        public List<Guid>? GetOrderIDs(Guid userID, string userPassword, out string errorMessage)
        {
            UserEntity? user = this._DbContext.Users.Find(userID);

            if (user == null)
            {
                errorMessage = $"no user with ID {userID} exists";
                return null;
            }

            if (user.Password != userPassword)
            {
                errorMessage = "incorrect password";
                return null;
            }

            List<Guid> orderIDs = this._DbContext.Orders
                .AsNoTracking()
                .Where(order => order.UserID == userID)
                .Select(order => order.ID)
                .ToList();
            errorMessage = string.Empty;
            return orderIDs;
        }

        public OrderObject? GetOrderStaff(OrderObject order, out string errorMessage)
        {
            UserEntity? staff = this._DbContext.Users.Find(order.UserID);

            if (staff == null)
            {
                errorMessage = $"no user with ID {order.UserID} exists";
                return null;
            }

            if (staff.Type != UserTypes.Staff)
            {
                errorMessage = $"user of type {staff.Type} can not access this order";
                return null;
            }

            if (staff.Password == order.UserPassword)
            {
                errorMessage = "incorrect password";
                return null;
            }

            OrderObject orderToReturn = new OrderObject()
            {
                ID = order.ID,
                UserID = staff.ID,
                UserPassword = null,
                Dishes = new Dictionary<Guid, int>()
            };

            List<OrderPositionEntity> positions = this._DbContext.OrderPositions
                .AsNoTracking()
                .Where(position => position.OrderID == order.ID)
                .ToList();

            foreach (OrderPositionEntity positionToConvert in positions)
            {
                orderToReturn.Dishes.Add(positionToConvert.DishID, positionToConvert.Amount);
            }

            errorMessage = string.Empty;
            return orderToReturn;
        }

        public OrderObject? Get(OrderObject order, out string errorMessage)
        {
            OrderEntity? orderEntity = this._DbContext.Orders.Find(order.ID);

            if (orderEntity == null)
            {
                errorMessage = $"no order with ID {order.ID} exists";
                return null;
            }

            UserEntity? user = this._DbContext.Users.Find(order.UserID);

            if (user == null)
            {
                errorMessage = $"no user with ID {order.UserID} exists";
                return null;
            }

            if (user.Password != order.UserPassword)
            {
                errorMessage = $"incorrect password";
                return null;
            }

            OrderObject orderToReturn = new OrderObject()
            {
                ID = order.ID,
                UserID = orderEntity.UserID,
                UserPassword = null,
                Dishes = new Dictionary<Guid, int>()
            };

            List<OrderPositionEntity> positions = this._DbContext.OrderPositions
                .AsNoTracking()
                .Where(position => position.OrderID == order.ID)
                .ToList();

            foreach (OrderPositionEntity positionToConvert in positions)
            {
                orderToReturn.Dishes.Add(positionToConvert.DishID, positionToConvert.Amount);
            }

            errorMessage = string.Empty;
            return orderToReturn;
        }

        public bool Create(Guid userID, string userPassword, Dictionary<Guid, int> Dishes, out string errorMessage)
        {
            UserEntity? user = this._DbContext.Users.Find(userID);

            if (user == null)
            {
                errorMessage = $"no user with ID {userID} exists";
                return false;
            }

            if (user.Password != userPassword)
            {
                errorMessage = $"incorrect password";
                return false;
            }

            foreach (KeyValuePair<Guid, int> position in Dishes)
            {
                Guid dishID = position.Key;
                bool existsDish = this._DbContext.Dishes.Any(dish => dish.ID == dishID);

                if (!existsDish)
                {
                    errorMessage = $"no dish with ID {dishID} exists";
                    return false;
                }
            }

            Guid orderID = Guid.NewGuid();
            OrderEntity order = new OrderEntity();
            order.ID = orderID;
            order.UserID = userID;

            this._DbContext.Orders
                .Add(order);

            foreach (KeyValuePair<Guid, int> position in Dishes)
            {
                Guid dishID = position.Key;
                OrderPositionEntity positionToAdd = new OrderPositionEntity
                {
                    ID = Guid.NewGuid(),
                    OrderID = orderID,
                    DishID = dishID,
                    Amount = position.Value
                };

                this._DbContext.OrderPositions.Add(positionToAdd);
                this._DbContext.SaveChanges();
            }

            this._DbContext.SaveChanges();
            errorMessage = string.Empty;
            return true;
        }

        public bool Delete(OrderObject orderObject, out string errorMessaage)
        {
            OrderEntity? orderToDelete = this._DbContext.Orders.Find(orderObject.ID);

            if (orderToDelete == null)
            {
                errorMessaage = $"no order with ID {orderObject.ID} exists";
                return false;
            }

            UserEntity? user = this._DbContext.Users.Find(orderObject.UserID);

            if (user == null)
            {
                errorMessaage = $"no user with ID {orderObject.UserID} exists";
                return false;
            }

            if (user.Type != UserTypes.Staff)
            {
                errorMessaage = $"user of type {user.Type} can not delete orders";
                return false;
            }

            if (user.Password != orderObject.UserPassword)
            {
                errorMessaage = "incorrect password";
                return false;
            }

            errorMessaage = string.Empty;
            this._DbContext.Orders.Where(order => order.ID == orderToDelete.ID).ExecuteDelete();
            this._DbContext.OrderPositions.Where(orderPosition => orderPosition.OrderID == orderToDelete.ID).ExecuteDelete();
            return true;
        }
    }
}
