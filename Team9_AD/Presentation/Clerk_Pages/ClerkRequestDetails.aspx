<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ClerkRequestDetails.aspx.cs" Inherits="Team9_AD.CLerk_request_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><p><b>STORE REQUEST DETAILS</b></p></center><br />
   <center> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="StoreRequest_ID" HeaderText="REQUEST ID" />
            <asp:BoundField DataField="Item_Number" HeaderText="ITEM NUMBER" />
            <asp:BoundField DataField="Description" HeaderText="DESCRIPTION" />
            <asp:BoundField DataField="Req_Quantity" HeaderText="REQUIRED QUANTITY" />
            <asp:BoundField DataField="Delv_Quantity" HeaderText="DELIVERED QUANTITY " />
            <asp:BoundField DataField="Pend_Quantity" HeaderText="PENDING QUANTITY" />
            <asp:BoundField DataField="Status" HeaderText="STATUS" />
        </Columns>

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
       <asp:Button ID="btn_back" runat="server" Font-Bold="true" Text="Back" CssClass="btn btn-sm" OnClick="btn_back_Click"></asp:Button>
   </center>

</asp:Content>
