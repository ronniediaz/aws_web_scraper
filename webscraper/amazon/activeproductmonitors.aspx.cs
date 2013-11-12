using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webscraper.amazon
{
    public partial class activeproductmonitors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCurrentUserActiveProductMonitors();
        }

        private void LoadCurrentUserActiveProductMonitors() {
            rptResults.DataSource = common.dataaccess.CurrentUser.ActiveProductMonitors;
                rptResults.DataBind();
        }
    }
}