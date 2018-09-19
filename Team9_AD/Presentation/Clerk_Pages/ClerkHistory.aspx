<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ClerkHistory.aspx.cs" Inherits="Team9_AD.ClerkHistory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <center>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">

        <AlternatingRowStyle BackColor="#DCDCDC" />

        <Columns>
             <asp:TemplateField HeaderText="SERIAL N0">
          <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
          </ItemTemplate>


          </asp:TemplateField>
           <asp:BoundField DataField="StoreRequest_ID" HeaderText="StoreRequest ID" >

             </asp:BoundField>
            <asp:BoundField DataField="Department_Name" HeaderText="Department Name" >

             </asp:BoundField>
            <asp:BoundField DataField="Employee_Name" HeaderText="Approved By"  >

             </asp:BoundField>
            <asp:BoundField DataField="Request_Date" HeaderText="Request Date"   >       

             </asp:BoundField>
             <asp:BoundField DataField="Status" HeaderText="Status"   >

             </asp:BoundField>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:Button CommandName="select" ID="Button" Text="Details" CssClass="btn btn-info" OnClick="GridView" runat="server" />
                </ItemTemplate>

            </asp:TemplateField>
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
    </asp:GridView></center>
</asp:Content>
