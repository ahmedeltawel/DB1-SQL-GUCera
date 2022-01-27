<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingCourses.aspx.cs" Inherits="GUCera.PendingCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 453px;
            left: 684px;
        }
        #form1 {
              position: absolute;
            width: 1184px;
            top: 15px;
            left: 10px;
            height: 444px;
        }
        #Panel1 {
            position: absolute;
          
        }
    </style>
</head>
<body style="height: 990px" onload="window.history.forward();">
    <form id="form1" runat="server">
        <div>
            <br />
        </div>
       <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged4" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="319px" Width="509px" style="position:absolute; top: -9px; left: 34px;">
             <Columns>
                 <asp:HyperLinkField />
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



        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>



        <p>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </p>



    </form>

     </body>
</html>
