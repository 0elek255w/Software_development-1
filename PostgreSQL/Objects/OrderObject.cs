namespace PostgreSQL.Objects
{
    public class OrderObject
    {
        public Guid? ID { get; set; }
        public Guid UserID { get; set; }
        public Dictionary<Guid, int> Dishes { get; set; } = new Dictionary<Guid, int>();
    }
}

