using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
