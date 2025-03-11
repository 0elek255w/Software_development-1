namespace PostgreSQL.Objects
{
    public class OrderObject
    {
        public Guid? ID { get; set; }
        public Guid UserID { get; set; }
        public string? UserPassword { get; set; } = string.Empty;
        public Dictionary<Guid, int>? Dishes { get; set; } = new Dictionary<Guid, int>();
    }
}
