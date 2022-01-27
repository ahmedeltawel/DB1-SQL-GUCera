<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitAssignment.aspx.cs" Inherits="GUCera.SubmitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 548px;
            left: 599px;
        }
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
    
            <asp:Label ID="label5" runat="server" Text="Course ID:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="CourseID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label2" runat="server" Text="Assignment Number:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="Number" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label4" runat="server" Text="Type:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="type0" runat="server">
                <asp:ListItem>Quiz</asp:ListItem>
                <asp:ListItem>Exam</asp:ListItem>
                <asp:ListItem>Project</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        <asp:Button ID="Sumbit" runat="server" Text="Sumbit Assignment" OnClick="Submit_Click" style="margin-left: 105px" Width="285px" />
       <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />

        </div>
    </form>
</body>
</html>
