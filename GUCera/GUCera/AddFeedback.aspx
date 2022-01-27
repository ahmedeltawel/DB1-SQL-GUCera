<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedback.aspx.cs" Inherits="GUCera.AddFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 550px;
            left: 600px;
        }
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="label1" runat="server" Text="Course ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="CourseID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Comment:"></asp:Label>
            <br />
            <asp:TextBox ID="Comment" runat="server" Height="124px" style="margin-top: 0px" Width="292px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Addfeed" runat="server" Text="Add Feedback"  style="margin-left: 105px" Width="285px" OnClick="Addfeed_Click" />
            <br />
            <br />
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </div>
    </form>
</body>
</html>
