using PostgreSQL.Tables;

namespace FoodOrderingSystem.Cores
{
    public class OrderCore
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Dictionary<Guid, int> Dishes { get; set; } = new Dictionary<Guid, int>();

        public OrderCore(Guid iD, List<OrderEntity> orderPositions)
        {
            ID = iD;
            UserID = orderPositions.First().UserID;

            foreach (OrderEntity orderPosition in orderPositions)
            {
                Guid dishID = orderPosition.DishID;
                int amount = orderPosition.Amount;

                this.Dishes.Add(dishID, amount);
            }
        }
    }
}
