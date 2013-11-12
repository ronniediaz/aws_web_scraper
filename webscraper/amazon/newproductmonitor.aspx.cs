using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
//using System.Xml;
//using System.Data;

namespace webscraper.amazon
{
    public partial class newproductmonitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["newproductmonitor_rptResults"] != null)
                {
                    Session.Remove("newproductmonitor_rptResults");
                }
            }
        }

        protected void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                List<common.productmonitor> productmonitors = new List<common.productmonitor>();

                if (Session["newproductmonitor_rptResults"] != null)
                {
                    productmonitors = (List<common.productmonitor>)Session["newproductmonitor_rptResults"];
                }

                string url = tbProductURL.Text.Trim();
                
                //1.0
                //LoadXml(url);

                //2.0
                //XDocument page = XDocument.Load(url);
                //IEnumerable<XElement> productnames = page.Root.Elements("body").Where(p => (string)p.Attribute("id") == "btAsinTitle");

                //3.0
                //st<string> results = WebScrape(url);
                common.productmonitor pm = new common.productmonitor();
                common.webscraper ws = new common.webscraper();

                pm.url = url;
                pm.productname = ws.Scrape(url, common.dataaccess.CurrentUser.UserAgent.Rules.AmazonProductName, common.dataaccess.CurrentUser.UserAgent.AgentValue);
                pm.listprice = ws.Scrape(url, common.dataaccess.CurrentUser.UserAgent.Rules.AmazonProductListPrice, common.dataaccess.CurrentUser.UserAgent.AgentValue);
                pm.ourprice = ws.Scrape(url, common.dataaccess.CurrentUser.UserAgent.Rules.AmazonProductOurPrice, common.dataaccess.CurrentUser.UserAgent.AgentValue);
                pm.agentname = common.dataaccess.CurrentUser.UserAgent.AgentName;
                pm.datecreated = DateTime.Now;

                if ((!string.IsNullOrEmpty(pm.productname)) && (!string.IsNullOrEmpty(pm.listprice)))
                {
                    pm.scraperesult = 1;
                }

                productmonitors.Add(pm);
                common.dataaccess.AddProductMonitor(pm); //db insert

                Session["newproductmonitor_rptResults"] = productmonitors;
                rptResults.DataSource = productmonitors;
                rptResults.DataBind();

                lblMessage.Text = "Data Retrieved successfully. Product is now monitored for price changes.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

    }
}