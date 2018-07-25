<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="WarehouseRetrievelList.aspx.cs" Inherits="Team9_AD.WarehouseRetrievelList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Item_Number" HeaderText="Item_Number" SortExpression="Item_Number" />
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Bin_number" HeaderText="Bin_number" SortExpression="Bin_number" />
            <asp:BoundField DataField="Req_Qunty" HeaderText="Req_Qunty" ReadOnly="True" SortExpression="Req_Qunty" />
            <asp:BoundField DataField="Available" HeaderText="Available" ReadOnly="true" SortExpression="Available" />
            <asp:TemplateField >
                <ItemTemplate >
                    <asp:TextBox runat="server" ID="CollectedQuntity" Text="0"  ></asp:TextBox> 

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField >
                <ItemTemplate >
                 
                 <asp:TextBox runat="server" ID="DamagedQuantity" Text="0" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <asp:GridView ID="GridView2" runat="server">

    </asp:GridView>
    
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT Store_Request_items.Item_Number, Inventory.Category, Inventory.Description, Inventory.Bin_number, SUM(Store_Request_items.Req_Quantity) AS Req_Qunty ,Inventory.Quantity as Available FROM Store_Request INNER JOIN Store_Request_items ON Store_Request.StoreRequest_ID = Store_Request_items.StoreRequest_ID INNER JOIN Inventory ON Store_Request_items.Item_Number = Inventory.Item_Number GROUP BY Store_Request_items.Item_Number, Inventory.Category, Inventory.Description, Inventory.Bin_number,Inventory.Quantity"></asp:SqlDataSource>--%>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
</asp:Content>
