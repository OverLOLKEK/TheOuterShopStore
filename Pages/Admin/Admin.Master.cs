using System;
using System.Web.Routing;

namespace TheOuterWoldShopHome.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string OrdersUrl
        {
            get
            {
                return generateURL("admin_orders");
            }
        }

        public string HomesUrl
        {
            get
            {
                return generateURL("admin_homes");
            }
        }

        private string generateURL(string routeName)
        {
            return RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;
        }
    }
}