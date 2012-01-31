<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductTemplate.ascx.cs" Inherits="DegradingLoad.Templates.ProductTemplate" %>
<asp:Repeater ID="rptProductList" runat="server">
<ItemTemplate>
<span class="ProductItem">
    <asp:Image ID="ProductImage" runat="server" /><br />
    <asp:HyperLink ID="ProductTitle" runat="server" /><br />
    <asp:Literal ID="ProductPrice" runat="server" /><br />
</span>
</ItemTemplate>
</asp:Repeater>