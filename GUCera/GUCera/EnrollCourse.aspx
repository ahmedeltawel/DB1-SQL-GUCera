<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrollCourse.aspx.cs" Inherits="GUCera.EnrollCourse" %>

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
            <h2>Enroll Page</h2>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Course ID: "></asp:Label>
        <asp:TextBox ID="cid" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Instructor ID: "></asp:Label>
        <asp:TextBox ID="InsID" runat="server"></asp:TextBox>
        <asp:Button ID="Submit" runat="server" Height="36px" style="margin-left: 34px" Text="Enroll" Width="140px" OnClick="Submit_Click" />
    </form>
</body>
</html>
