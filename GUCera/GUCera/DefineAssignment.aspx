<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineAssignment.aspx.cs" Inherits="GUCera.DefineAssignment" %>


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
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label2" runat="server" Text="Assignment Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label3" runat="server" Text="Type:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="type" runat="server">
                <asp:ListItem>Quiz</asp:ListItem>
                <asp:ListItem>Exam</asp:ListItem>
                <asp:ListItem>Project</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="label4" runat="server" Text="Full Grade:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label5" runat="server" Text="Weight:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Content:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Deadline:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Date"></asp:TextBox>
            &nbsp; <br />
            <br />
        </div>
        <asp:Button ID="Define" runat="server" Text="Define Assignment" OnClick="Define_Click" style="margin-left: 105px" Width="285px" />
        <p>
            &nbsp;</p>
            <asp:Button ID="Back" runat="server"  Text="Back to HomePage" OnClick="Back_Click" />
    </form>
</body>
</html>
