<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignmentGrades.aspx.cs" Inherits="GUCera.ViewAssignmentGrades" %>

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
      
            <asp:Button ID="Back0" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
            <asp:Label ID="label1" runat="server" Text="Course ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="CourseID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label2" runat="server" Text="Assignment Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="Number" runat="server"></asp:TextBox>
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
            &nbsp;
            <asp:Button ID="ViewGrade" runat="server" Text="View Grade" OnClick="ViewGrade_Click" style="margin-left: 105px" Width="285px" />
            <br />
        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />

        </div>
    </form>
</body>
</html>
