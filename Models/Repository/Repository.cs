using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TheOuterWoldShopHome.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Home> Homes
        {
            get { return context.Homes; }
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Homes));
            }
        }

        public void SaveGame(Home home)
        {
            if (home.HomeId == 0)
            {
                home = context.Homes.Add(home);
            }
            else
            {
                Home dbGame = context.Homes.Find(home.HomeId);
                if (dbGame != null)
                {
                    dbGame.Name = home.Name;
                    dbGame.Description = home.Description;
                    dbGame.Price = home.Price;
                    dbGame.Category = home.Category;
                }
            }
            context.SaveChanges();
        }

        public void DeleteGame(Home game)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Homes))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Homes.HomeId == game.HomeId) > 0)
                .ToArray();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Homes.Remove(game);
            context.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Homes).State
                        = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }
    }
}