<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssuePromoCode.aspx.cs" Inherits="GUCera.IssuePromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 871px;
            left: 615px;
        }
    </style>
</head>
<body style="height: 990px">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" CssClass="auto-style1" style="z-index: 1" Text="Back to HomePage" OnClick="Back_Click" />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Enter Promo Code" style="position:absolute; top: 186px; left: 220px; height: 21px; font-size:30px; width: 290px;"></asp:Label>
                <asp:Label ID="LabelPromo" runat="server" Text="You Must Fill this !!" style="position:absolute; top: 226px; left: 259px; height: 21px; font-size:20px; width: 320px;" ForeColor="Red" Visible="False"></asp:Label>
        <asp:Label ID="LabelStudent" runat="server" Text="You Must Fill this !!" style="position:absolute; top: 578px; left: 244px; height: 38px; font-size:20px; width: 416px;" ForeColor="Red" Visible="False"></asp:Label>

        <asp:TextBox ID="Sid" runat="server" style="                position: absolute;
                top: 614px;
                left: 183px;
                height: 47px;
                width: 292px;
                font-size: 30px
        "></asp:TextBox>
        <asp:TextBox ID="Pid" runat="server" style="position:absolute; top: 257px; left: 200px; height: 47px; width: 292px; font-size:30px" MaxLength="6"></asp:TextBox>
        <asp:GridView ID="GridViewStudent" runat="server" style="position:absolute; top: 555px; left: 942px; width: 422px;" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
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
        <asp:GridView ID="GridViewPromo" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="position:absolute; top: 189px; left: 901px; bottom: 382px;" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
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
        <asp:Label ID="Label3" runat="server" Text="All Students" style="position:absolute; top: 485px; left: 1037px ; font-size:40px"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="All Promo Codes" style="position:absolute; top: 128px; left: 1035px ; font-size:40px"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="Issue Promo Code" style="position:absolute; top: 25px; left: 440px ; font-size:70px"></asp:Label>

        <asp:Label ID="Label7" runat="server" Text="Enter Student Id" style="position:absolute; top: 547px; left: 224px; font-size:30px"></asp:Label>

        <p>
            &nbsp;</p>
        <p>

        <asp:Button ID="Issue_Promo" runat="server" Text="Issue Promo To Student" style="position:absolute; top: 368px; left: 595px; height: 176px; width: 198px;" OnClick="Issue_Promo_Click"/>

        &nbsp;&nbsp;&nbsp;

        </p>

    </form>
</body>
</html>
