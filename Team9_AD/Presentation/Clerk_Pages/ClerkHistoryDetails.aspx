<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ClerkHistoryDetails.aspx.cs" Inherits="Team9_AD.ClerkHistoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StoreRequest_ID" HeaderText="REQUEST ID" />
            <asp:BoundField DataField="Item_Number" HeaderText="ITEM NUMBER" />
            <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" />
            <asp:BoundField DataField="Req_Quantity" HeaderText="REQUIRED QUANTITY" />
            <asp:BoundField DataField="Delv_Quantity" HeaderText="DELIVERED QUANTITY " />
            <asp:BoundField DataField="Pend_Quantity" HeaderText="PENDING QUANTITY" />
            <asp:BoundField DataField="Status" HeaderText="STATUS" />
        </Columns>

    </asp:GridView>
</asp:Content>
