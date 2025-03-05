namespace PostgreSQL.Repositories
{
    public class OrderRepository
    {
        private readonly DbContextFOS _DbContext;

        public OrderRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
