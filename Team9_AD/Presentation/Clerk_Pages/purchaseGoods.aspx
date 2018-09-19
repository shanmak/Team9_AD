<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="purchaseGoods.aspx.cs" Inherits="Team9_AD.purchaseGoods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><b>PURCHASE GOODS<br />
      </b></center>
    <center>
    <asp:GridView ID="Purchasegoods" OnRowDeleting="OnRowDeleting" 
            OnRowEditing="onRowEditing" 
            OnRowCancelingEdit="OnRowCancelingEdit"
            OnRowUpdating="OnRowUpdating" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">

        <AlternatingRowStyle BackColor="#DCDCDC" />

       <Columns>
           <asp:TemplateField HeaderText="Description">
               
               <ItemTemplate>
                   <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Available Quantity">
             
               <ItemTemplate>
                   <asp:Label ID="Label3" runat="server" Text='<%# Bind("Available_Quantity") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Order Quantity">
               <EditItemTemplate>
                   <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Order_Quantity") %>'></asp:TextBox>
               </EditItemTemplate>
               <ItemTemplate>
                   <asp:Label ID="Label1" runat="server" Text='<%# Bind("Order_Quantity") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Supplier">
               
               <ItemTemplate>
                   <asp:Label ID="Label4" runat="server" Text='<%# Bind("Supplier_ID") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Phone Number">
              
               <ItemTemplate>
                   <asp:Label ID="Label5" runat="server" Text='<%# Bind("Phonenumber") %>'></asp:Label>
               </ItemTemplate>
           </asp:TemplateField>
        <asp:TemplateField >
                        <ItemTemplate >
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text = "Edit"  />
                        </ItemTemplate>
                         <EditItemTemplate >
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update"  Text = "Update" />
                         <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text = "Cancel" />
                        </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <ItemTemplate >
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text = "Delete" />
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
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" DeleteCommand="DELETE FROM [PurchaseGoods] WHERE [Description] = @Description" SelectCommand="SELECT * FROM [PurchaseGoods]"  UpdateCommand="UPDATE [PurchaseGoods] SET [Order_Quantity] = @Quantity WHERE [Description] = @Description " >
                    <DeleteParameters>
                <asp:Parameter Name="Description" Type="String" />
            </DeleteParameters>
         <UpdateParameters>
                <asp:Parameter Name="Order_Quantity" Type="Int32" />
             </UpdateParameters>
           
         </asp:SqlDataSource>

    <br /><center>
    <asp:Button ID="btn_Add" runat="server" Text="Add goods" OnClick="btn_Add_Click" /> &nbsp &nbsp &nbsp &nbsp&nbsp&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Button ID="btn_CreatePO" runat="server" Text="Create Purchase Order" OnClick="btn_CreatePO_Click" />
 
     </center>

</asp:Content>
