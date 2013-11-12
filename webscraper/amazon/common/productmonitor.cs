using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webscraper.amazon.common
{
    public class productmonitor
    {
        public string url { get; set; }
        public string productname { get; set; }
        public string listprice { get; set; }
        public string ourprice { get; set; }
        public string agentname { get; set; }
        public int scraperesult { get; set; }
        public DateTime datecreated { get; set; }

        //start recording

        //stop recording
    }
}