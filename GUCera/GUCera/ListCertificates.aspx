<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCertificates.aspx.cs" Inherits="GUCera.ListCertificates" %>

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
            
            <asp:Label ID="CourseID" runat="server" Text="Course ID:"></asp:Label>
            &nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="16px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ViewCert" runat="server" Text="View Certificates" OnClick="Viewassign_Click" />
        <div>

            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />

        </div>
        </div>
    </form>
</body>
</html>
