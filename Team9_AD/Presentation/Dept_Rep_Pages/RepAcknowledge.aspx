<%@ Page Title="" Language="C#" MasterPageFile="~/RepMasterPage.Master" AutoEventWireup="true" CodeBehind="RepAcknowledge.aspx.cs" Inherits="Team9_AD.RepAcknowledge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><center><b>Goods Acknowledgement</b></center></div>
    <br />
    <center><asp:Image ID="img_NoRecord" runat="server" ImageUrl ="assets/img/NoRecordFound.jpg" Visible="false"/></center>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center" GridLines="Vertical">
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
    <div><center><asp:CheckBox ID="CheckBox1" runat="server" /><asp:Label ID="Label1" runat="server" Text=" I have received the goods" Visible="true"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Acknowledge" OnClick="Button1_Click" class="btn btn-success"/></center></div>

</asp:Content>
