<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Registration.aspx.cs" Inherits="GUCera.Student_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello Student please register</div>
     <asp:Label ID="Label1" runat="server" Text="First name:"></asp:Label>
            <asp:TextBox ID="fname" runat="server" Width="655px" style="margin-left: 39px"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="Last name:"></asp:Label>
            <asp:TextBox ID="lname" runat="server" Width="656px" style="margin-left: 42px"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            &nbsp;<asp:TextBox ID="Password1" runat="server" style="margin-left: 61px" Width="644px" type="password"></asp:TextBox>
        <br />
        <br />
        
            <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="email" runat="server" Width="652px" style="margin-left: 76px"></asp:TextBox>
        <br />
        <br />
&nbsp;<asp:Label ID="Label5" runat="server" Text="Gender:"></asp:Label>
            <asp:DropDownList ID="SelectGender" runat="server" style="margin-left: 65px">
                <asp:ListItem Value="false">Male</asp:ListItem>
                <asp:ListItem Value="true">Female</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
&nbsp;<asp:Label ID="Label6" runat="server" Text="Address:"></asp:Label>
            &nbsp;<asp:TextBox ID="address" runat="server" Width="639px" style="margin-left: 60px"></asp:TextBox>

        <br />

        <br />
        <asp:Button ID="RegisterButton" runat="server" Height="49px" Text="Register" Width="204px" BackColor="WhiteSmoke" OnClick="register"/>
    </form>
     
</body>
</html>
