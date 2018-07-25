<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HodViewPage.aspx.cs" Inherits="Team9_AD.HodPage.HodViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Request_ID" >
                <Columns>
                    <asp:BoundField DataField="Request_ID" HeaderText="Request_ID" SortExpression="Request_ID" ReadOnly="True" />
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" SortExpression="Employee_Name" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField><ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="Details" OnClick="btn_Click" /></ItemTemplate></asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" SelectCommand="SELECT DISTINCT Employee_Request.Request_ID, Employee.Employee_Name, Emp_Request_items.Status FROM Employee INNER JOIN Employee_Request ON Employee.Employee_ID = Employee_Request.Employee_ID INNER JOIN Emp_Request_items ON Employee_Request.Request_ID = Emp_Request_items.Request_ID AND Emp_Request_items.Status='pending'"></asp:SqlDataSource>
        </div>
</asp:Content>
