<%@ Page Title="" Language="C#" MasterPageFile="~/RepMasterPage.Master" AutoEventWireup="true" CodeBehind="RepEditRequest.aspx.cs" Inherits="Team9_AD.RepEditRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>

      <center><b>Edit Request</b></center><br />
               
               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                   OnRowUpdating="OnRowUpdating" 
                   OnRowDeleting="OnRowDeleting" 
                   OnRowEditing="OnRowEditing"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                   <AlternatingRowStyle BackColor="#DCDCDC" />
                   <Columns>
          

                       <asp:BoundField DataField="Description" HeaderText="Description"
                           SortExpression="Description" ReadOnly="True" />
                       <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                                 <asp:RegularExpressionValidator id="RegularExpressionValidator1" Text="*" ForeColor="Red" runat="server" 
         ErrorMessage="Enter Only Positive Numbers" 
             ValidationExpression="^[1-9]([0-9]*,?)*$" EnableClientScript="true"
        ControlToValidate="TextBox1" Display="Dynamic" /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" ForeColor="Red" runat="server" 
                    ErrorMessage="Quantity is null" 
                    ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Text="*" ForeColor="Red" Type="Integer" maximumvalue="50" minimumvalue="1" 
                    ErrorMessage="Invalid Quantity Range"  ControlToValidate="TextBox1" Display="Dynamic">
                </asp:RangeValidator>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="Unit_Measure" HeaderText="Unit_Measure" 
                           SortExpression="Unit_Measure" ReadOnly="True" />
                       <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />

                      

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
               </asp:GridView><br />

      <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Check the following errors" runat="server" />
   
        <br />
    <br />
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp

    <div><center>   <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" />
        </center></div>
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
                  
                   </UpdateParameters>
                 
                    <DeleteParameters>
                <asp:Parameter Type="String" 
                  Name="Request_ID"/>
                 
                  </DeleteParameters>
             </asp:SqlDataSource> 
              </div>
          
</asp:Content>
