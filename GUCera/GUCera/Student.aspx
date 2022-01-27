<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="GUCera.Student" %>

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
            left: 200px;
        }
        .auto-style3 {
            position: absolute;
            top: 55px;
            left: 400px;
        }
        .auto-style4 {
            position: absolute;
            top: 55px;
            left: 580px;
            
        }
        .auto-style5 {
            position: absolute;
            top: 55px;
            left: 760px;
        }
        .auto-style6 {
            position: absolute;
            top: 130px;
            left: 40px;
        }
        .auto-style7 {
            position: absolute;
            top: 130px;
            left: 220px;
        }
        .auto-style8 {
            position: absolute;
            top: 130px;
            left: 400px;
        }
        .auto-style9 {
            position: absolute;
            top: 130px;
            left: 615px;
        }
        .auto-style10 {
            position: absolute;
            top: 130px;
            left: 760px;
        }
        .auto-style11 {
            position: absolute;
            top: 200px;
            left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <h3>Student Home</h3> <br />
            <br />
            <br />
            <asp:Button ID="ViewAssignments" runat="server" CssClass="auto-style6" style="z-index: 1" Text="View Assignments" OnClick="ViewAssignments_Click" />
            <asp:Button ID="SubmitAssignment" runat="server" CssClass="auto-style7" style="z-index: 1" Text="Submit Assignment" OnClick="SubmitAssignment_Click" />
            <asp:Button ID="ViewAssignmentGrades" runat="server" CssClass="auto-style8" style="z-index: 1" Text="View Assignment Grades" OnClick="ViewAssignmentGrades_Click" />
            <asp:Button ID="AddFeedback" runat="server" CssClass="auto-style9" style="z-index: 1" Text="Add Feedback" OnClick="AddFeedback_Click" />
            <asp:Button ID="ListCertificates" runat="server" CssClass="auto-style10" style="z-index: 1" Text="List Certificates" OnClick="ListCertificates_Click" />
            <br />
            <br />
            <asp:Button ID="AddMobile" runat="server" CssClass="auto-style11" style="z-index: 1" Text="Add Mobile Number" OnClick="AddMobile_Click" />
            <br />
            <asp:Button ID="ViewProfile" runat="server" CssClass="auto-style1" style="z-index: 1" Text="View Profile" OnClick="ViewProfile_Click" />
            <asp:Button ID="ListCourses" runat="server" CssClass="auto-style2" style="z-index: 1" Text="List Courses" OnClick="ListCourses_Click"  />
            <asp:Button ID="EnrollCourse" runat="server" CssClass="auto-style3" style="z-index: 1" Text="Enroll Course" OnClick="EnrollCourse_Click" />
            <asp:Button ID="ViewPromo" runat="server" CssClass="auto-style5" style="z-index: 1" Text="View Promo" OnClick="ViewPromo_Click" />
            <asp:Button ID="AddCreditCard" runat="server" CssClass="auto-style4" style="z-index: 1" Text="Add Credit Card" OnClick="AddCreditCard_Click" />
            <br />
        </div>
    </form>
</body>
</html>
