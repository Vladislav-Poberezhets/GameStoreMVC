namespace GameStore.Models
{
    public class Cart
    {
        
        private List<OrderLine> selections = new List<OrderLine>();

        public IEnumerable<OrderLine> Selections { get => selections; }

        public Cart AddItem(Game p, int quantity)
        {
            OrderLine orderLine = selections.FirstOrDefault(e => e.GameId == p.GameId);
            if (orderLine != null)
            {
                orderLine.Quantity += quantity;
            }
            else
            {
                selections.Add(new OrderLine
                {
                    GameId = p.GameId,
                    Game = p,
                    Quantity = quantity
                });
            }
            return this;
        }
        public Cart RemoveItem(int gameId)
        {
            selections.RemoveAll(e => e.GameId == gameId);
            return this;
        }
        public void Clear() => selections.Clear();
    }
}
