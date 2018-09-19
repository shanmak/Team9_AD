<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorVoucher.aspx.cs" Inherits="Team9_AD.SupervisorVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <center><b>Adjustment Voucher Details</b></center>
    <br />
    <br />
    <asp:GridView ID="GridView1" HorizontalAlign="Center"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />

    </asp:GridView>
    <br />
    <br />
    <div><center> <asp:Button ID="Button1" runat="server" Text="Approve" Font-Bold="true" OnClick="Approve_Click" /></center></div>
</asp:Content>
