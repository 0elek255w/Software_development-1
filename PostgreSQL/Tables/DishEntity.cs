namespace PostgreSQL.Tables
{
    public class DishEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Composition { get; set; } = string.Empty;
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
