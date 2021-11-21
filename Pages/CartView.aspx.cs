using System;
using System.Collections.Generic;
using System.Linq;
using TheOuterWoldShopHome.Models;
using TheOuterWoldShopHome.Models.Repository;
using TheOuterWoldShopHome.Pages.Helpers;
using System.Web.Routing;

namespace TheOuterWoldShopHome.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository repository = new Repository();
                int homeId;
                if (int.TryParse(Request.Form["remove"], out homeId))
                {
                    Home homeToRemove = repository.Homes
                        .Where(g => g.HomeId == homeId).FirstOrDefault();
                    if (homeToRemove != null)
                    {
                        SessionHelper.GetCart(Session).RemoveLine(homeToRemove);
                    }
                }
            }
        }

        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }

        public decimal CartTotal
        {
            get
            {
                return SessionHelper.GetCart(Session).ComputeTotalValue();
            }
        }

        public string ReturnUrl
        {
            get
            {
                return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL);
            }
        }

        public string CheckoutUrl
        {
            get
            {
                return RouteTable.Routes.GetVirtualPath(null, "checkout",
                    null).VirtualPath;
            }
        }
    }
}