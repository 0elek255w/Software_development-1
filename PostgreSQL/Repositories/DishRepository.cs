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

        /*
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
        */

        public List<DishEntity> Get()
        {
            return _DbContext.Dishes.ToList();
        }
        public DishEntity? Get(Guid ID)
        {
            return _DbContext.Dishes.FirstOrDefault(dish => dish.ID == ID);
        }

        public void Add(Guid ID, string name, string imagePath, string composition)
        {
            DishEntity dish = new DishEntity
            {
                ID = ID,
                Name = name,
                ImagePath = imagePath,
                Composition = composition
            };

            this._DbContext.Add(dish);
            this._DbContext.SaveChanges();
        }
        public void Add(DishEntity dish)
        {
            this._DbContext.Dishes.Add(dish);
            this._DbContext.SaveChanges();
        }

        public void Edit(Guid ID, string name, string imagePath, string composition)
        {
            DishEntity? dish = this._DbContext.Dishes.FirstOrDefault(dish => dish.ID == ID);

            if (dish == null)
            {
                // dish is null
                return;
            }

            dish.Name = name;
            dish.ImagePath = imagePath;
            dish.Composition = composition;

            this._DbContext.SaveChanges();
        }
    }
}
