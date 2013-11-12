using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db4objects.Db4o;

namespace webscraper.amazon.common
{
    public static class dataaccess
    {
        //TODO: load from db
        public static List<UserAgent> GetUserAgents() {
            List<UserAgent> results = new List<UserAgent>();

            UserAgent aspnet = new UserAgent();
            aspnet.AgentName = "ASP.Net 4.0";
            aspnet.AgentValue = ""; //scrape checks if null and skips and defaults to asp.net
            //default values OK for scrape rules

            UserAgent iPhoneiOS4 = new UserAgent();
            iPhoneiOS4.AgentName = "iPhoneiOS4";
            iPhoneiOS4.AgentValue = "Mozilla/5.0 (iPhone; U; CPU like Mac OS X; en) AppleWebKit/420+ (KHTML, like Gecko) Version/3.0 Mobile/1A543a Safari/419.3";
            iPhoneiOS4.Rules.AmazonProductName = "<div.*class=\"dpProductTitle\".*?>(.*?)</div>";
            iPhoneiOS4.Rules.AmazonProductOurPrice = "<span.*class=\"dpOurPrice\".*?>(.*?)</span>";
            iPhoneiOS4.Rules.AmazonProductListPrice = "<span.*class=\"dpListPrice\".*?>(.*?)</span>";
            
            UserAgent iPhoneLegacy = new UserAgent();
            iPhoneLegacy.AgentName = "iPhoneLegacy";
            iPhoneLegacy.AgentValue="Mozilla/5.0 (iPhone; U; CPU like Mac OS X; en) AppleWebKit/420+ (KHTML, like Gecko) Version/3.0 Mobile/1A543a Safari/419.3";
            iPhoneLegacy.Rules.AmazonProductName = "<div.*class=\"dpProductTitle\".*?>(.*?)</div>";
            iPhoneLegacy.Rules.AmazonProductOurPrice = "<span.*class=\"dpOurPrice\".*?>(.*?)</span>";
            iPhoneLegacy.Rules.AmazonProductListPrice = "<span.*class=\"dpListPrice\".*?>(.*?)</span>";

            results.Add(aspnet);
            results.Add(iPhoneiOS4);
            results.Add(iPhoneLegacy);

            return results;
        }

        // ?
        public static List<productmonitor> GetActiveProductMonitors()
        {
            List<productmonitor> results = new List<productmonitor>();

            return results;

            // accessDb4o
            using (IObjectContainer db = Db4oEmbedded.OpenFile("data/"))
            {
                // do something with db4o
            }
        }

        //todo: db insert
        public static void AddProductMonitor(productmonitor pm)
        {
            if (CurrentUser.ActiveProductMonitors.Find(p => p.productname == pm.productname) == null)
            {
                CurrentUser.ActiveProductMonitors.Add(pm);
            }
        }

        public static class CurrentUser
        {
            public static List<UserAgent> LoadedAgents { get { return (List<UserAgent>)HttpContext.Current.Session["CurrentUserLoadedAgents"]; } set { HttpContext.Current.Session["CurrentUserLoadedAgents"] = value; } }
            public static UserAgent UserAgent { get { return (UserAgent)HttpContext.Current.Session["CurrentUserAgent"]; } set { HttpContext.Current.Session["CurrentUserAgent"] = value; } }
            public static List<productmonitor> ActiveProductMonitors { get { return (List<productmonitor>)HttpContext.Current.Session["CurrentUserActiveProductMonitors"]; } set { HttpContext.Current.Session["CurrentUserActiveProductMonitors"] = value; } }
        }
    }
}