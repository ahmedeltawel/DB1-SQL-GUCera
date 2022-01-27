<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Register {
            width: 100px;
        }
        #Button1 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <asp:Label ID="lbl_username" runat="server" Text="ID:"></asp:Label>
    
        <asp:TextBox ID="txt_username" runat="server" style="margin-left: 131px" Width="300px" MaxLength="9"></asp:TextBox>
    
  <br />
    
        <br />
        <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password" style="margin-left: 73px" Width="300px"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Button ID="btn_login" runat="server" Text="Login" onclick="login" Width="106px"/>
    


        <asp:Button ID="RegisterStudent1" runat="server" style="margin-left: 47px" Text="Register as Student" onclick="RegisterStudent" Width="157px" />
        <asp:Button ID="RegisterInstructor1" runat="server" style="margin-left: 52px" Text="Register as Instructor" OnClick="RegisterInstructor" Width="174px" />
    


    &nbsp;
    


    </div>
    </form>
</body>
</html>
