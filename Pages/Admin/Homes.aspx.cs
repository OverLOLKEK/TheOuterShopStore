using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheOuterWoldShopHome.Models;
using TheOuterWoldShopHome.Models.Repository;
using System.Web.ModelBinding;

namespace TheOuterWoldShopHome.Pages.Admin
{
    public partial class Homes : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Home> GetHomes()
        {
            return repository.Homes;
        }

        public void UpdateHome(int HomeID)
        {
            Home myHome = repository.Homes
                .Where(p => p.HomeId == HomeID).FirstOrDefault();
            if (myHome != null && TryUpdateModel(myHome,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myHome);
            }
        }

        public void DeleteGame(int HomeID)
        {
            Home myHome = repository.Homes
                .Where(p => p.HomeId == HomeID).FirstOrDefault();
            if (myHome != null)
            {
                repository.DeleteGame(myHome);
            }
        }

        public void InsertGame()
        {
            Home myHome = new Home();
            if (TryUpdateModel(myHome,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myHome);
            }
        }
    }
}