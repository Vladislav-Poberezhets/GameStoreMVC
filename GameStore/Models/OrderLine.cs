namespace GameStore.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public Game Game { get; set; }
        public Order Order { get; set; }
    }
}
