<%@ Page Title="" Language="C#" MasterPageFile="~/amazon/amazon.master" AutoEventWireup="true" CodeBehind="newproductmonitor.aspx.cs" Inherits="webscraper.amazon.newproductmonitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="amazoncontent" runat="server">
<p>
<asp:Label ID="lblMessage" runat="server" Text="Note: list price may differ from actual price in cart. Data is retrieved with a virtual browser using the selected user agent."></asp:Label>
<div class="form">
<div class="row">
<span class="label">Product URL:</span><asp:TextBox ID="tbProductURL" runat="server"></asp:TextBox>
</div>
<div class="marginSmall">&nbsp;</div>
<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Clicked" Text="Retrieve Data" />
</div>
<div class="marginLarge">&nbsp;</div>
<asp:Panel ID="pnlResults" runat="server">
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
</ItemTemplate>
<SeparatorTemplate>
<div class="marginLarge">&nbsp;</div>
</SeparatorTemplate>
</asp:Repeater>
</asp:Panel>
</p>
</asp:Content>
