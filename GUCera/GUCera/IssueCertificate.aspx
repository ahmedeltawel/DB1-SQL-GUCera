<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueCertificate.aspx.cs" Inherits="GUCera.IssueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            Course ID&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
            <br />
            Student ID&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            <br />
            <br />
            Issue Date&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" ></asp:TextBox>
            &nbsp;&nbsp; <br />
            <br />
            <asp:Button ID="Issue" runat="server" Text="Issue Certificate" OnClick="Issue_Click" />
        </div>
            <p>
            <asp:Button ID="Back" runat="server" Text="Back to HomePage" OnClick="Back_Click" />
        </p>
    </form>
</body>
</html>
