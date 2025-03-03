using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL.Tables
{
    public class OrderEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid DishID { get; set; }
        public int Amount { get; set; }
        public UserEntity User { get; set; } = new UserEntity();
        public DishEntity Dish { get; set; } = new DishEntity();
    }
}
