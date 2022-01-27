<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptPendingCourses.aspx.cs" Inherits="GUCera.AcceptPendingCourses" %>

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
<body style="height: 990px" onload="window.history.forward();">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </div>


          <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged4" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="319px" Width="509px" style="position:absolute; top: 48px; left: 65px;" OnRowDeleting="GridView1_RowDeleting">
             <Columns>
               
                 <asp:CommandField ButtonType="Button" DeleteText="Accept" HeaderText="Accept Course" ShowDeleteButton="True" />
              
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
             <RowStyle BackColor="White" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
    </form>
</body>
   
</html>
