<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="MaintainInventory.aspx.cs" Inherits="Team9_AD.MaintainInventory"  EnableEventValidation="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#<%=GridView1.ClientID%>").footable();
    });
</script>


 <script src="scripts/jquery.responsivetable.min.js"></script>
  <script>  $(document).ready(function() {
    $('.myTable1').responsiveTable();
    
    $("#<%=GridView1.ClientID%>").responsiveTable({
        staticColumns= 2, 
        scrollRight= true, 
        scrollHintEnabled= true, 
        scrollHintDuration= 2000,
    });
});  </script>

           <style>
    .promohere {   
    padding: 40px;  
    background-size: cover;
    background-color:aliceblue;
    overflow:auto;
    height: 500px;
}
      </style>

      <Center><b>Maintain Inventory</b></Center>

    <div>
        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowDeleting="OnRowDeleting" 
            OnRowEditing="OnRowEditing" 
            OnRowCancelingEdit="OnRowCancelingEdit"
            OnRowUpdating="OnRowUpdating"  DataKeyNames="Item_Number" AllowPaging="True" OnPageIndexChanging="OnPageIndexChanging"   AlternatingRowStyle-CssClass="even" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="8" GridLines="Vertical" EnableViewState="True" >
            
        
                <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
               
                
                <asp:TemplateField HeaderText="ItemNumber" SortExpression="ItemNumber">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Item_Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Category" SortExpression="Category">
                    <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Quantity") %>' Width="50px"></asp:TextBox>
                        <br />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Of Measure" SortExpression="Unit Of Measure">
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Unit_Measure") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Supplier_1" SortExpression="Supplier_1">
                   <EditItemTemplate>
                          <asp:DropDownList ID="CategoryDropdown1" runat="server" Width="160px" DataSourceID="SqlDataSource3" DataTextField="Supplier_ID"  BackColor="#FFFFCC" DataValueField="Supplier_ID">
                          </asp:DropDownList>
                          <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT [Supplier_ID] FROM [Supplier]"></asp:SqlDataSource>
                  </EditItemTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Supplier_ID_1")%>' ReadOnly="true"></asp:TextBox>
                     </ItemTemplate>
                     </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier_2" SortExpression="Supplier_2">
                   <EditItemTemplate>
                          <asp:DropDownList ID="CategoryDropdown2" runat="server" Width="160px" DataSourceID="SqlDataSource4" DataTextField="Supplier_ID"  BackColor="#FFFFCC" DataValueField="Supplier_ID">
                          </asp:DropDownList>
                          <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT [Supplier_ID] FROM [Supplier]"></asp:SqlDataSource>
                  </EditItemTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Supplier_ID_2")%>' ReadOnly="true"></asp:TextBox>
                     </ItemTemplate>
                     </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier_3" SortExpression="Supplier_3">
                   <EditItemTemplate>
                          <asp:DropDownList ID="CategoryDropdown3" runat="server" Width="160px" DataSourceID="SqlDataSource5" DataTextField="Supplier_ID"  BackColor="#FFFFCC" DataValueField="Supplier_ID">
                          </asp:DropDownList>
                          <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT [Supplier_ID] FROM [Supplier]"></asp:SqlDataSource>
                  </EditItemTemplate>
                     <ItemTemplate>
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Supplier_ID_3")%>' ReadOnly="true"></asp:TextBox>
                     </ItemTemplate>
                     </asp:TemplateField>
                
                <%--<asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-secondary" ShowDeleteButton="True" ShowEditButton="True" ValidationGroup="Check" />--%>
                <asp:TemplateField >
                        <ItemTemplate >
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text = "Edit" CssClass="btn btn-secondary" />
                        </ItemTemplate>
                         <EditItemTemplate >
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update"  Text = "Update" CssClass="btn btn-secondary"  />
                         <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text = "Cancel" CssClass="btn btn-secondary"/>
                        </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <ItemTemplate >
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text = "Delete" CssClass="btn btn-secondary"/>
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
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" DeleteCommand="DELETE FROM [Inventory] WHERE [Item_Number] = @Item_Number" SelectCommand="SELECT * FROM [Inventory]" UpdateCommand="UPDATE [Inventory] SET [Quantity] = @Quantity, [Suppiler_ID_1] = @Suppiler_ID_1, [Suppiler_ID_2] = @Suppiler_ID_2, [Suppiler_ID_3] = @Suppiler_ID_3 WHERE [Item_Number] = @Item_Number">
                    <DeleteParameters>
                <asp:Parameter Name="Item_Number" Type="String" />
            </DeleteParameters>
                  <UpdateParameters>
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Supplier_ID_1" Type="String" />
                <asp:Parameter Name="Supplier_ID_2" Type="String" />
                <asp:Parameter Name="Supplier_ID_3" Type="String" />
                  </UpdateParameters>
            </asp:SqlDataSource>
    <br />
        
       
    </div>
   
</asp:Content>
