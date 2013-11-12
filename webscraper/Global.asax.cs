using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using webscraper.amazon.common;

namespace webscraper
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            dataaccess.CurrentUser.LoadedAgents = dataaccess.GetUserAgents();
            dataaccess.CurrentUser.ActiveProductMonitors = dataaccess.GetActiveProductMonitors();
            dataaccess.CurrentUser.UserAgent = dataaccess.CurrentUser.LoadedAgents.Where(a => a.AgentName.ToLower().Contains("asp")).Single(); //default to asp
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
