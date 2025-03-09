namespace PostgreSQL.Tables
{
    public class OrderPositionEntity
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid DishID { get; set; }
        public int Amount { get; set; }
    }
}
