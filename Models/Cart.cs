using System.Collections.Generic;
using System.Linq;

namespace TheOuterWoldShopHome.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Home home, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Home.HomeId == home.HomeId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Home = home,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Home home)
        {
            lineCollection.RemoveAll(l => l.Home.HomeId == home.HomeId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Home.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Home Home { get; set; }
        public int Quantity { get; set; }
    }
}