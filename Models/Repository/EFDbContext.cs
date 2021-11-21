using System.Web;
using System.Data.Entity;

namespace TheOuterWoldShopHome.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + HttpContext.Current.Server.MapPath("~/App_Data/GameStore.mdf")
                    + ";Integrated Security=True")
        {  }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}