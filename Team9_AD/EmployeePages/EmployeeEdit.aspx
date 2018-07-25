<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Master.Master" AutoEventWireup="true" CodeBehind="EmployeeEdit.aspx.cs" Inherits="Team9_AD.EmployeePages.EmployeeEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                   OnRowUpdating="OnRowUpdating" 
                   OnRowDeleting="OnRowDeleting" 
                   OnRowEditing="OnRowEditing"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit">
                   <Columns>
                       <asp:BoundField DataField="Request_ID" HeaderText="Request_ID" 
                           SortExpression="Request_ID" ReadOnly="True" />
                       <asp:BoundField DataField="Description" HeaderText="Description"
                           SortExpression="Description" ReadOnly="True" />
                       <asp:BoundField DataField="Quantity" HeaderText="Quantity"
                           SortExpression="Quantity" />
                       <asp:BoundField DataField="Unit_Measure" HeaderText="Unit_Measure" 
                           SortExpression="Unit_Measure" ReadOnly="True" />
                       <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                   </Columns>
               </asp:GridView>
               <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                   ConnectionString="<%$ ConnectionStrings:Logic_University_Model%>" 
                   SelectCommand="SELECT Emp_Request_items.Request_ID, Inventory.Description,
                   Emp_Request_items.Quantity, 
                   Inventory.Unit_Measure FROM Emp_Request_items INNER JOIN 
                   Inventory ON Emp_Request_items.Item_Number = Inventory.Item_Number" 
                    UpdateCommand="Update Emp_Request_items SET [Quantity]=@Quantity 
                   WHERE [Request_ID] = @Request_ID"
                   DeleteCommand="Delete from Emp_Request_items where [Request_ID]=@Request_ID ">
                  
                   <UpdateParameters>
                       <asp:Parameter Name="Quantity" Type="Int32" />
                    <asp:Parameter Name="Request_ID" Type="String" />
                   </UpdateParameters>
                 
                    <DeleteParameters>
                <asp:Parameter Type="String" 
                  Name="Request_ID"/>
                 
                  </DeleteParameters>
             </asp:SqlDataSource> 
              </div>
          
</asp:Content>
