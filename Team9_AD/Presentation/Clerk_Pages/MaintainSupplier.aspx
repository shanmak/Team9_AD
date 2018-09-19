<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="MaintainSupplier.aspx.cs" Inherits="Team9_AD.MaintainSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--By Priya--%>
    <center><p><b>MAINTAIN SUPPLIER INFO</b></p></center>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Supplier_ID" HorizontalAlign="Center" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
               
                <asp:BoundField DataField="Supplier_Name" HeaderText="SupplierName" SortExpression="Supplier_Name" />
                <asp:BoundField DataField="Contact_Name" HeaderText="ContactName" SortExpression="Contact_Name" />
                <asp:BoundField DataField="Phone_Num" HeaderText="PhoneNum" SortExpression="Phone_Num" />
                <asp:BoundField DataField="Fax_Num" HeaderText="FaxNum" SortExpression="Fax_Num" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Supplier_ID" HeaderText="SupplierID" ReadOnly="True" SortExpression="Supplier_ID" />
                <asp:CommandField ShowDeleteButton="False"  HeaderText="Options"  ShowEditButton="True" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>"
            DeleteCommand="DELETE FROM [Supplier] WHERE [Supplier_ID] = @Supplier_ID"
            InsertCommand="INSERT INTO [Supplier] ([Supplier_Name], [Contact_Name], [Phone_Num], [Fax_Num], [Address], [Supplier_ID]) VALUES (@Supplier_Name, @Contact_Name, @Phone_Num, @Fax_Num, @Address, @Supplier_ID)" 
            SelectCommand="SELECT [Supplier_Name], [Contact_Name], [Phone_Num], [Fax_Num], [Address], [Supplier_ID] FROM [Supplier]" 
            UpdateCommand="UPDATE [Supplier] SET [Supplier_Name] = @Supplier_Name, [Contact_Name] = @Contact_Name, [Phone_Num] = @Phone_Num, [Fax_Num] = @Fax_Num, [Address] = @Address WHERE [Supplier_ID] = @Supplier_ID">
            <DeleteParameters>
                <asp:Parameter Name="Supplier_ID" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Supplier_Name" Type="String" />
                <asp:Parameter Name="Contact_Name" Type="String" />
                <asp:Parameter Name="Phone_Num" Type="Int32" />
                <asp:Parameter Name="Fax_Num" Type="Int32" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Supplier_ID" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Supplier_Name" Type="String" />
                <asp:Parameter Name="Contact_Name" Type="String" />
                <asp:Parameter Name="Phone_Num" Type="Int32" />
                <asp:Parameter Name="Fax_Num" Type="Int32" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Supplier_ID" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
</asp:Content>
