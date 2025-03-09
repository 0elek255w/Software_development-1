using Microsoft.EntityFrameworkCore;

namespace PostgreSQL.Tables
{
    [Keyless]
    public class OrderPositionEntity
    {
        public Guid OrderID { get; set; }
        public Guid DishID { get; set; }
        public int Amount { get; set; }
    }
}
