<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeSubmissions.aspx.cs" Inherits="GUCera.GradeSubmissions" %>

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
            <asp:Label ID="label1" runat="server" Text="Student ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label2" runat="server" Text="Course ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label8" runat="server" Text="Assignment Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
            <asp:Label ID="label4" runat="server" Text="Grade:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Button ID="Grade" runat="server" Text="Grade Assignment"  style="margin-left: 105px" Width="285px" OnClick="Grade_Click" />
        <p>
            &nbsp;</p>
            <asp:Button ID="Back" runat="server" Text="Back to HomePage" OnClick="Back_Click" />
    </form>
</body>
</html>
