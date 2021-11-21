using System;

namespace TheOuterWoldShopHome.Models
{
    public class Home
    {
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}