<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="GUCera.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 55px;
            left: 40px;
        }
        .auto-style2 {
            position: absolute;
            top: 55px;
            left: 220px;
        }
        .auto-style3 {
            position: absolute;
            top: 55px;
            left: 400px;
        }
        .auto-style4 {
            position: absolute;
            top: 55px;
            left: 600px;
        }
        .auto-style5 {
            position: absolute;
            top: 55px;
            left: 780px;
        }
        .auto-style11 {
            position: absolute;
            top: 140px;
            left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h3> Admin Home </h3><br />
            <br />          
            <asp:Button ID="AddMobileNumber" runat="server" CssClass="auto-style11" style="z-index: 1" Text="Add Mobile Number" OnClick="AddMobileNumber_Click" />
            <br />
            <asp:Button ID="ListAllCourses" runat="server" CssClass="auto-style1" style="z-index: 1" Text="List All Courses" OnClick="ListAllCourses_Click" />
            <asp:Button ID="PendingCourses" runat="server" CssClass="auto-style2" style="z-index: 1" Text="Pending Courses" OnClick="PendingCourses_Click" />
            <asp:Button ID="AcceptPendingCourses" runat="server" CssClass="auto-style3" style="z-index: 1" Text="Accept Pending Courses" OnClick="AcceptPendingCourses_Click" />
            <asp:Button ID="IssuePromoCode" runat="server" CssClass="auto-style5" style="z-index: 1" Text="Issue Promocode" OnClick="IssuePromoCode_Click" />
            <asp:Button ID="CreatePromoCodes" runat="server" CssClass="auto-style4" style="z-index: 1" Text="Create Promocodes" OnClick="CreatePromoCodes_Click" />
            <br />
        </div>
    </form>
</body>
</html>
