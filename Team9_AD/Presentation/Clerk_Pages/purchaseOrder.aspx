<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="purchaseOrder.aspx.cs" Inherits="Team9_AD.purchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>

            <asp:DropDownList ID="Suppliers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Suppliers_SelectedIndexChanged"></asp:DropDownList>

        </div>
        <div>
            <asp:Button ID="btn_GenPurchaseOrder" runat="server" Text="Generate Purchase Order" OnClick="btn_GenPurchaseOrder_Click" />
        </div>
        <div>
            <asp:GridView ID="PurchaseOrders" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Description" HeaderText="Item" />
                    <asp:BoundField DataField="Reorder_qty" HeaderText="OrderQuantity" />
                    <asp:BoundField DataField="Unit_Measure" HeaderText="Unit Measure" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
