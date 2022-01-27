<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="GUCera.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 237px;
            left: 413px;
            z-index: 1;
            width: 203px;
        }
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            Course Name&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
            <br />
            Credit Hours
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            <br />
            <br />
            Course Price&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
            <br />
            <br />
            Instructor ID&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
            &nbsp; 
            <asp:Label ID="InstrID" runat="server"  Text="Current Id =  "></asp:Label>
&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="Add" runat="server" Text="Add Course" OnClick="Add_Click" />
        </div>
            <p>
            <asp:Button ID="Back" runat="server" Text="Back to HomePage" OnClick="Back_Click" />
        </p>
    </form>
</body>
</html>
