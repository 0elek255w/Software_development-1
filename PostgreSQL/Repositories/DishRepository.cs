using PostgreSQL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL.Repositories
{
    public class DishRepository
    {
        private readonly DbContextFOS _DbContext;

        public DishRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }

        public List<DishEntity> AllDishReturn()
        {
            List<DishEntity> dishEntities = this._DbContext.DishEntity.ToList();
            return dishEntities;
        }

        public void AddDish(DishEntity dish)
        {
            this._DbContext.DishEntity.Add(dish);
            this._DbContext.SaveChanges();
        }
    }
}
