<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePromoCodes.aspx.cs" Inherits="GUCera.CreatePromoCodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 550px;
            left: 780px;
        }
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server" >
        <div>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </div>
        <p>
            &nbsp;</p>
        <p>
        <asp:Label ID="CodeLabel" runat="server" Text="AdminId" style="position:absolute; top: 510px; left: 466px;"></asp:Label>
        </p>


         <asp:Label ID="Label1" runat="server" Text="Discount" style="position:absolute; top: 418px; left: 471px; height: 22px;"></asp:Label>
       
        <asp:TextBox ID="DiscountInteger" runat="server"  style="position:absolute; top: 464px; left: 426px; width: 62px; right: 801px;" MaxLength="2" OnTextChanged="DiscountInteger_TextChanged"></asp:TextBox>
         <asp:Label ID="Label2" runat="server" Text="Code" style="position:absolute; top: 225px; left: 478px; height: 21px; width: 42px;"></asp:Label>
     
        <asp:TextBox ID="Code" runat="server"  style="position:absolute; top: 279px; left: 413px;" MaxLength="6"></asp:TextBox>
      
        <asp:TextBox ID="AdminId" runat="server"  style="position:absolute; top: 555px; left: 414px;"></asp:TextBox>
        <asp:DropDownList ID="exDay" runat="server" style="position:absolute; top: 366px; left: 546px; width: 43px; height: 19px;">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem Selected="True" Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
            <asp:ListItem Value="13"></asp:ListItem>
            <asp:ListItem Value="14"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="16"></asp:ListItem>
            <asp:ListItem Value="17"></asp:ListItem>
            <asp:ListItem Value="18"></asp:ListItem>
            <asp:ListItem Value="19"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
            <asp:ListItem Value="21"></asp:ListItem>
            <asp:ListItem Value="22"></asp:ListItem>
            <asp:ListItem Value="23"></asp:ListItem>
            <asp:ListItem Value="24"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="26"></asp:ListItem>
            <asp:ListItem Value="27"></asp:ListItem>
            <asp:ListItem Value="28"></asp:ListItem>
            <asp:ListItem Value="29"></asp:ListItem>
            <asp:ListItem Value="30"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="exMonth" runat="server" style="position:absolute; top: 366px; left: 484px;" OnSelectedIndexChanged="issueMonth_SelectedIndexChanged">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="ExpiryDate" style="position:absolute; top: 311px; left: 452px; height: 22px;"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Day"   style="position:absolute; height: 22px; top: 331px; left: 547px; width: 50px; bottom: 332px;"></asp:Label>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Month" style="position:absolute; top: 333px; left: 484px;"></asp:Label>
            <asp:TextBox ID="DiscountDecimal" runat="server" style="position:absolute; top: 464px; left: 521px; width: 63px;" OnTextChanged="TextBox1_TextChanged" MaxLength="2"></asp:TextBox>
        </p>
        <asp:DropDownList ID="exYear" runat="server" style="position:absolute; top: 365px; left: 404px; height: 19px;">
            <asp:ListItem Value="2021"></asp:ListItem>
            <asp:ListItem Value="2022"></asp:ListItem>
            <asp:ListItem Value="2023"></asp:ListItem>
            <asp:ListItem Value="2024"></asp:ListItem>
            <asp:ListItem Value="2025"></asp:ListItem>
            <asp:ListItem Value="2026"></asp:ListItem>
            <asp:ListItem Value="2027"></asp:ListItem>
            <asp:ListItem Value="2028"></asp:ListItem>
            <asp:ListItem Value="2029"></asp:ListItem>
            <asp:ListItem Value="2030"></asp:ListItem>
            <asp:ListItem Value="2031"></asp:ListItem>
            <asp:ListItem Value="2032"></asp:ListItem>
            <asp:ListItem Value="2033"></asp:ListItem>
            <asp:ListItem Value="2034"></asp:ListItem>
            <asp:ListItem Value="2035"></asp:ListItem>
            <asp:ListItem Value="2036"></asp:ListItem>
            <asp:ListItem Value="2037"></asp:ListItem>
            <asp:ListItem Value="2038"></asp:ListItem>
            <asp:ListItem Value="2039"></asp:ListItem>
            <asp:ListItem Value="2040"></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text="Year" style="position:absolute; top: 333px; left: 419px;"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add Promo Code" style="position:absolute; top: 638px; left: 404px; margin-top: 0px;" OnClick="Button1_Click"/>
        </p>
        <asp:Label ID="WrongeMsg1" runat="server" Text="You Can't chose this Day" style="position:absolute; top: 395px; left: 413px;" Visible="False" ForeColor="Red"></asp:Label>
        <asp:Label ID="WrongeMsg2" runat="server" Text="You Must Fill This!!" style="position:absolute; top: 255px; left: 426px;" ForeColor="Red" Visible="False"></asp:Label>
        <asp:Label ID="WrongeMsg3" runat="server" Text="You Must Fill This!!" style="position:absolute; height: 22px; top: 440px; left: 434px;" ForeColor="Red" Visible="False"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="." style="position:absolute; top: 477px; left: 499px;"></asp:Label>
        <asp:Label ID="WrongeMsg4" runat="server" Text="You Must Fill This !!" style="position:absolute; top: 530px; left: 425px;" ForeColor="Red" Visible="False"></asp:Label>
    </form>
</body>
</html>
