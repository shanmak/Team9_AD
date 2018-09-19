<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Clerk_Pages/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="Disbursemtlist.aspx.cs" Inherits="Team9_AD.Disbursemtlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><div>
    <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Please select the Department:"></asp:Label> 
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBAck="true"></asp:DropDownList>
   </div>
<br />
    <asp:Button ID="btn_ViewDisbmt" runat="server" Text="View" CssClass="btn btn-info" OnClick="btn_ViewDisbmt_Click"></asp:Button>
        <br />
        <br />
        <center><asp:Image ID="Img_NoRecord" runat="server" ImageUrl ="assets/img/NoRecordFound.jpg" width="500" Height ="500" ImageAlign="AbsMiddle" Visible="false" /></center>
        <br />
        <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" CellPadding="4" GridLines="Both" ForeColor="#333333">
       <AlternatingRowStyle BackColor="White" />
      <EditRowStyle BackColor="#2461BF" />
      <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#EFF3FB" />
      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      <SortedAscendingCellStyle BackColor="#F5F7FB" />
      <SortedAscendingHeaderStyle BackColor="#6D95E1" />
      <SortedDescendingCellStyle BackColor="#E9EBEF" />
      <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
        <br />
        <br />

    <asp:Button ID="Button3" runat="server" Text="SEND MAIL TO Department Rep" CssClass="btn btn-success" OnClick="Button3_Click" />

    </center>
</asp:Content>
