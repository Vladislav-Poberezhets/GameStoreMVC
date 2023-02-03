namespace GameStore.Models
{
    public class Cart
    {
        private List<OrderLine> selections = new List<OrderLine>();

        public IEnumerable<OrderLine> Selections { get => selections; }

        public Cart AddItem(Game g, int quantity)
        {
            OrderLine orderLine = selections.Where(e => e.GameId == g.GameId).FirstOrDefault();
            if (orderLine != null)
            {
                orderLine.Quantity += quantity;
            }
            else
            {
                selections.Add(new OrderLine
                {
                    GameId = g.GameId,
                    Game = g,
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
