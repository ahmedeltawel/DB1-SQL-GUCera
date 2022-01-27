<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMobile.aspx.cs" Inherits="GUCera.AddMobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <br />
        <asp:Label ID="mobile" runat="server" Text="Mobile number"></asp:Label>
        <asp:TextBox ID="mobileNumber" runat="server" Width="213px" style="margin-left: 36px"></asp:TextBox>
        <br />
            <asp:Button ID="Button1" runat="server" Text="Add mobile" OnClick="Button1_Click" />
            <br />
  <br />
        </div>
        <asp:Button ID="Back" runat="server" Text="Back to HomePage" Width="213px" OnClick="Back_Click" />
    </form>
</body>
</html>
