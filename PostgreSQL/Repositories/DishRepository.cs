using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;

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
    }
}
