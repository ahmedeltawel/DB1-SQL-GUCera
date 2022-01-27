<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCourses.aspx.cs" Inherits="GUCera.ListCourses" %>

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
        .vertical-center {
            position: absolute;
            top: 50%;
            left: 55%;
            bottom:7%;
           -ms-transform: translateY(-50%);
            transform: translateY(-50%);
            width: 215px;
        }

    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
            
           <h2>Accepted courses which you can enroll in.</h2>
               <asp:Button ID="Enroll" runat="server" Text="Enroll" height ="30px" CssClass="vertical-center" OnClick="Enroll_Click" />
               </div>
        <asp:Label ID="Label1" runat="server" Text="To view the information of a course please enter its ID. "></asp:Label>
        <br />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Course ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Button ID="View" runat="server" style="margin-left: 31px" Text="View" Width="103px" OnClick="View_Click" />
    </form>
</body>
</html>
