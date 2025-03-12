using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;
using PostgreSQL.Objects;

namespace PostgreSQL.Repositories
{
    public class DishRepository
    {
        private readonly DbContextFOS _DbContext;

        public DishRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }

        public List<DishEntity> GetAllDishes()
        {
            List<DishEntity> dishes = this._DbContext.Dishes
                .AsNoTracking()
                .ToList();

            return dishes;
        }

        public DishEntity? GetDishByID(Guid dishID, out string errorMessage)
        {
            DishEntity? dish = this._DbContext.Dishes
                .Find(dishID);

            if (dish == null)
            {
                errorMessage = $"no dish with ID {dishID} exists";
                return null;
            }

            errorMessage = string.Empty;
            return dish;
        }

        public void Create(DishEntity dish)
        {
            dish.ID = Guid.NewGuid();
            this._DbContext.Dishes.Add(dish);
            this._DbContext.SaveChanges();
        }

        public bool Delete(OrderObject dishToDelete, out string errorMessage)
        {
            UserEntity? staff = this._DbContext.Users.Find(dishToDelete.UserID);

            if (staff == null)
            {
                errorMessage = $"no user with ID {dishToDelete.UserID} exists";
                return false;
            }

            if (staff.Type != UserTypes.Staff)
            {
                errorMessage = $"user of type {staff.Type} can not delete dishes";
                return false;
            }

            if (staff.Password != dishToDelete.UserPassword)
            {
                errorMessage = "incorrect password";
                return false;
            }

            bool exists = this._DbContext.Dishes.Any(dish => dish.ID == dish.ID);

            if (!exists)
            {
                errorMessage = $"no dish with ID {dishToDelete.ID} exists";
                return false;
            }

            bool isContained = this._DbContext.OrderPositions.Any(orderPosition => orderPosition.DishID == dishToDelete.ID);

            if (isContained)
            {
                errorMessage = $"this dish is contained in orders";
                return false;
            }

            errorMessage = string.Empty;
            this._DbContext.Dishes
                .Where(dish => dish.ID == dishToDelete.ID)
                .ExecuteDelete();
            return true;
        }
    }
}
