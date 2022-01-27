<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="GUCera.Instructor" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            position: absolute;
            top: 55px;
            left: 40px;
        }
        .auto-style3 {
            position: absolute;
            top: 55px;
            left: 220px;
        }
        .auto-style4 {
            position: absolute;
            top: 55px;
            left: 400px;
        }
        .auto-style7 {
            position: absolute;
            top: 130px;
            left: 40px;
        }
        .auto-style8 {
            position: absolute;
            top: 130px;
            left: 220px;
        }
        .auto-style9 {
            position: absolute;
            top: 130px;
            left: 400px;
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
           <h3> Instructor Home</h3><br />
            <br />
            <br />
            <asp:Button ID="ViewFeedback" runat="server" CssClass="auto-style7" style="z-index: 1" Text="View Feedback" OnClick="ViewFeedback_Click" />
            <asp:Button ID="IssueCertificate" runat="server" CssClass="auto-style8" style="z-index: 1" Text="IssueCertificate" OnClick="IssueCertificate_Click" />
            <asp:Button ID="GradeSubmissions" runat="server" CssClass="auto-style9" style="z-index: 1" Text="Grade Submissions" OnClick="GradeSubmissions_Click" />
            <br />
            <asp:Button ID="AddMobileNumber" runat="server" CssClass="auto-style11" style="z-index: 1" Text="Add Mobile Number" OnClick="AddMobileNumber_Click" />
            <br />
            <asp:Button ID="AddCourse" runat="server" CssClass="auto-style2" style="z-index: 1" Text="Add Course" OnClick="AddCourse_Click" />
            <asp:Button ID="DefineAssignment" runat="server" CssClass="auto-style3" style="z-index: 1" Text="Define Assignment" OnClick="DefineAssignment_Click" />
            <asp:Button ID="ViewSubmissions" runat="server" CssClass="auto-style4" style="z-index: 1" Text="View Submissions" OnClick="ViewSubmissions_Click" />
            <br />
        </div>
    </form>
</body>
</html>

