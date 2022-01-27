<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCreditCard.aspx.cs" Inherits="GUCera.AddCreditCard" %>

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
        h4 {
            color:black;
            text-align: center;
        } 
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
            <h2>
                Please add your credit card information
            </h2>
            <asp:Label ID="Label2" runat="server" Text="Card Number: "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" MaxLength="15"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Card Holder Name: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Expiry Date: "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="CVV: "></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" MaxLength="3"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="39px" style="margin-left: 334px" Text="Add Credit Card" Width="203px" OnClick="Button1_Click" />
        </div>
   
    </form>
</body>
</html>
