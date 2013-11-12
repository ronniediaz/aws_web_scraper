using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webscraper
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    ddlUserAgents.Items.Clear();
                    ddlUserAgents.DataSource = amazon.common.dataaccess.CurrentUser.LoadedAgents;
                    ddlUserAgents.DataTextField = "AgentName";
                    ddlUserAgents.DataValueField = "AgentName";
                    ddlUserAgents.DataBind();
                    

                    if (Session["ddlUserAgents_SelectedIndex"] != null)
                    {
                        ddlUserAgents.SelectedIndex = (int)Session["ddlUserAgents_SelectedIndex"];
                        lblSelectedAgent.Text = ddlUserAgents.Items[ddlUserAgents.SelectedIndex].Value;
                    }
                    else
                    {
                        lblSelectedAgent.Text = ddlUserAgents.Items[0].Value;
                    }
            }
        }

        protected void ddlUserAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddlUserAgents_SelectedIndex"] = ddlUserAgents.SelectedIndex;
            lblSelectedAgent.Text = ddlUserAgents.SelectedValue;
            amazon.common.dataaccess.CurrentUser.UserAgent = amazon.common.dataaccess.CurrentUser.LoadedAgents.Where(a => a.AgentName == ddlUserAgents.SelectedValue).Single();
        }
    }
}
