<%@ Page Title="" Language="C#" MasterPageFile="~/RepMasterPage.Master" AutoEventWireup="true" CodeBehind="CollectionPointPage.aspx.cs" Inherits="Team9_AD.RepPage.CollectionPointPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Collection_Point" DataValueField="Collection_Point">
        </asp:RadioButtonList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" SelectCommand="SELECT distinct [Collection_Point] FROM [Department]"></asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
   
</asp:Content>
