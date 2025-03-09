namespace PostgreSQL.Tables
{
    public class DishEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Composition { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
