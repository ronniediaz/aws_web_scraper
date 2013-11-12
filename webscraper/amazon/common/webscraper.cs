using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace webscraper.amazon.common
{
    public class webscraper
    {

        public virtual string Scrape(string url, string ScrapeRule, string UserAgent) //List<string>
        {
            //System.Reflection.MemberInfo info = typeof(ScrapeRule);
            //string regex = info.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),true)[0].ToString();

            if (!string.IsNullOrEmpty(ScrapeRule)) {
            string regex = ScrapeRule;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                //client.Headers.Add(HttpRequestHeader.UserAgent, UserAgents.iPhone);
                if (!string.IsNullOrEmpty(UserAgent)) client.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
                string result = client.DownloadString(url);
                Match m = Regex.Match(result, regex);
                return m.Groups[1].Value;
            }
            }
            else 
                return "";
        }

        //TODO: compare performance
        //public string WebScrape(string url) //List<string>?
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    string line;

        //    string regex = "<span.*id=\"btAsinTitle\".*?>(.*?)</span>";

        //    using (Stream responseStream = response.GetResponseStream())
        //    using (StreamReader htmlStream = new StreamReader(responseStream, Encoding.UTF8))
        //        while ((line = htmlStream.ReadLine()) != null)
        //            if (Regex.IsMatch(line, regex)) //, RegexOptions.IgnoreCase?
        //                return line;

        //            return "";
        //}

        //public static string WebScrape(string url)
        //{
        //    using (System.Net.WebClient client = new System.Net.WebClient())
        //    {
        //        // set properties of the client
        //        return client.DownloadString(url);
        //    }
        //}

        //public static string WebScrape(string url)
        //{
        //    System.Net.WebRequest request = System.Net.WebRequest.Create(url);
        //    // set properties of the request
        //    using (System.Net.WebResponse response = request.GetResponse())
        //    {
        //        using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        //private void LoadXml(string url)
        //{
        //    XmlTextReader xr = new XmlTextReader(url);

        //    DataSet ds = new DataSet();

        //    ds.ReadXml(xr);

        //    DataTable dt = ds.Tables["playlist_items"];
        //}
    }
}