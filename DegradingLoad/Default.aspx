<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DegradingLoad._Default" Async="true"%>
<%@ Register TagPrefix="template" Src="Templates/ProductTemplate.ascx" TagName="ProductListing" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Some LOAD related POC or something</title>
    <link rel="Stylesheet" type="text/css" href="Styles/main.css" />
</head>
<body>

<form runat="server">

    <div class="ProductDescription">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ut nunc risus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Quisque aliquet eleifend arcu. Praesent commodo bibendum ipsum in porta. Sed ullamcorper eros ac dolor tincidunt ultricies. Morbi facilisis arcu nec sem congue congue. Curabitur commodo, leo vel lacinia facilisis, neque lectus egestas quam, quis pulvinar nisl justo eu nulla. Donec venenatis auctor elementum. Curabitur in nisi vitae enim aliquam pharetra. Praesent vitae massa sed ipsum tempor ornare. Etiam bibendum metus in arcu accumsan scelerisque. Aliquam tristique, felis eget pharetra dignissim, libero nunc interdum urna, ut facilisis lorem neque id massa. Phasellus viverra purus ut odio facilisis semper. Integer id dui odio, ut congue ipsum. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Suspendisse potenti. Nam lacinia hendrerit massa, sed mollis arcu consequat eget. Nunc tincidunt turpis nec augue lacinia tempor.
        <br /><br />
        <select>
            <option>Just a select box to show</option>
            <option>that the main content is</option>
            <option>functional even though the</option>
            <option>full page may not be fully</option>
            <option>rendered quite yet.</option>
        </select>
        <br /><br />
        In metus lectus, semper et venenatis vitae, sollicitudin in elit. Morbi elementum lectus sed sapien pulvinar ut semper neque sodales. Praesent varius facilisis velit, non hendrerit sem adipiscing sit amet. Cras placerat porttitor varius. Suspendisse lacinia enim vitae nisl tincidunt dapibus vel eu ante. Etiam vulputate condimentum semper. Morbi at leo vel libero malesuada egestas. Suspendisse potenti. In vestibulum ultricies odio, ac iaculis lacus auctor ut. Vestibulum pretium suscipit dolor, sed ullamcorper ante mattis non. Vestibulum elit dui, gravida sed hendrerit ac, semper blandit nibh. Donec cursus, odio id fermentum euismod, tortor nulla bibendum ipsum, ut suscipit mi felis sit amet nisl. Nam at orci nec mi pharetra luctus at ac turpis. Curabitur venenatis imperdiet nulla, ut mattis felis vulputate in. Fusce at quam massa, ac aliquet lorem.
    </div>

    <div class="ProductListing">
        <asp:Panel ID="LocalContent" runat="server">
        Local: Async Completed<br />
        <template:ProductListing runat="server" ID="ctlProductListing" />
        </asp:Panel>

        <asp:Panel ID="RemoteContent" runat="server" Visible="false">
        Remote: Async Timed Out<br />
        <script type="text/javascript" language="javascript" src="/Scripts/jquery-1.4.1.js"></script>
        <script language="javascript" type="text/javascript">
            $(document).ready(function() {
                $.ajax({
                    type: "POST",
                    url: "/Services/ProductProcessService.asmx/GetProductListingHtml",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(data) {
                        $("#RemoteContentDisplay").html(data.d);
                    }
                });
            });
        </script>
        <div id="RemoteContentDisplay" style="background-color:#deffff;" />
        </asp:Panel>
    </div>

</form>
</body>
</html>