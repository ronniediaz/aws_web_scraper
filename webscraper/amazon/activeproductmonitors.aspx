<%@ Page Title="" Language="C#" MasterPageFile="~/amazon/amazon.master" AutoEventWireup="true" CodeBehind="activeproductmonitors.aspx.cs" Inherits="webscraper.amazon.activeproductmonitors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="amazoncontent" runat="server">
<!--also amazon buyer and buyer rating-->
<asp:Repeater ID="rptResults" runat="server">
<ItemTemplate>
<div class="productmonitor">
<div><span>URL:</span> <%# Eval("url") %></div>
<div><span>Product Name:</span> <%# Eval("productname") %></div>
<div><span>List Price:</span> <%# Eval("listprice") %></div>
<div><span>Our Price:</span> <%# Eval("ourprice") %></div>
<div><span>User Agent:</span> <%# Eval("agentname") %></div>
<div><span>Scrape Result:</span> <%# int.Parse(Eval("scraperesult").ToString())==1 ? "Success" : "Failed" %></div>
<div><span>Date Created:</span> <%# DateTime.Parse(Eval("datecreated").ToString()).ToShortDateString() %></div>
</div>

<a href=""><%# Eval("pricenotifications") %></a>
<a href="" target="_blank"><%# Eval("url") %></a>

<!--button item command --><%# Eval("graph") %>
</ItemTemplate>
</asp:Repeater>
</asp:Content>
