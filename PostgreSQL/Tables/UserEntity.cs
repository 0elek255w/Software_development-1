namespace PostgreSQL.Tables
{
    public class UserEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
