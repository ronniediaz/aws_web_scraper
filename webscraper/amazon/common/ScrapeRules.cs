using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace webscraper.amazon.common
{
    public class ScrapeRules
    {
        [Description()]
        public string AmazonProductName = "<span.*id=\"btAsinTitle\".*?>(.*?)</span>";

        [Description()]
        public string AmazonProductListPrice = "<td><span.*?>(.*?)</span></td>"; 
        //<td.*class=\"priceBlockLabel\".*?>List Price:</td>.*?<td><span.*?>(.*?)</span></td>
        //<span.*class=\"listprice\".*?>(.*?)</span>
        
        [Description()]
        public string AmazonProductOurPrice = "";
    }
}