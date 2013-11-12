using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webscraper.amazon.common
{
    public class UserAgent
    {
        public string AgentName { get; set; }
        public string AgentValue { get; set; }

        public ScrapeRules Rules { get; set; }
        public UserAgent()
        {
            Rules = new ScrapeRules();
        }
    }
}