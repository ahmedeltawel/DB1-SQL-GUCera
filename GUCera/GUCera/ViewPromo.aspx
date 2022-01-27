<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPromo.aspx.cs" Inherits="GUCera.ViewPromo" %>

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
        
        
       
        <p>

            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />

        </p>
        
        
       
    </form>
</body>
</html>
