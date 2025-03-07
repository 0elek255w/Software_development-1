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

        public List<DishEntity> Get()
        {
            List<DishEntity> dishes = this._DbContext.Dishes
                .AsNoTracking()
                .ToList();

            return dishes;
        }

        public DishEntity? Get(Guid dishID, out string errorMessage)
        {
            bool exists = this._DbContext.Dishes.Any(dish => dish.ID == dishID);

            if (!exists)
            {
                errorMessage = $"no dish with ID {dishID} exists";
                return null;
            }

            DishEntity dish = this._DbContext.Dishes
                .AsNoTracking()
                .Where(dish => dish.ID == dishID)
                .First();

            errorMessage = String.Empty;
            return dish;
        }

        public void Create(DishEntity dish)
        {
            this._DbContext.Dishes.Add(dish);
            this._DbContext.SaveChanges();
        }
    }
}
