<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerMaster.Master" AutoEventWireup="true" CodeBehind="Voucher_View.aspx.cs" Inherits="Team9_AD.Voucher_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="Vouchers" runat="server" AutoGenerateColumns="False" DataSourceID="Voucher_Details">
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Voucher_Date" HeaderText="Voucher_Date" SortExpression="Voucher_Date" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="Voucher_Details" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString2 %>" SelectCommand="SELECT Inventory.Description, Voucher_details.Voucher_Date, Voucher_details.Quantity, Voucher_details.Amount, Voucher_details.Status FROM Voucher_details INNER JOIN Inventory ON Voucher_details.Item_Number = Inventory.Item_Number"></asp:SqlDataSource>
</asp:Content>
