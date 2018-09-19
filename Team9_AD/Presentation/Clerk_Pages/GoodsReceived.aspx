<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="GoodsReceived.aspx.cs" Inherits="Team9_AD.GoodsReceived" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
             <center><b>Goods Received</b></center>
        <br />
        <br />
         <center> <table style="width:40%" border="0">
               <tr>
    <td><asp:Label ID="lbl_Category" runat="server" Text="Select Category:" Font-Bold="true"></asp:Label>&nbsp &nbsp &nbsp</td>
    <td><asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Category_SelectedIndexChanged"/>
        <asp:RequiredFieldValidator ID="Validator_Category" runat="server" InitialValue="-1" ErrorMessage="Category" Text="*" ControlToValidate="ddl_Category" Display="Dynamic"></asp:RequiredFieldValidator>
    </td>       
  </tr>
               <tr>
                   <td> <asp:Label ID="lbl_description" runat="server" Text="Select Description:" Font-Bold="true"></asp:Label></td>
                   <td><asp:DropDownList ID="ddl_Description" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Description_SelectedIndexChanged">
            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="Validator_Description" runat="server" InitialValue="-1" ErrorMessage="Description" Text="*" ControlToValidate="ddl_Description" Display="Dynamic"></asp:RequiredFieldValidator>
                   </td>
                  
               </tr>        
               <tr>
                   <td><asp:Label ID="lbl_quantity" runat="server" Text="Quantity:" Font-Bold="true"></asp:Label></td>
                   <td><asp:TextBox ID="txt_Quantity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Validator_Quantity" runat="server" ErrorMessage="Quantity" Text="*" ControlToValidate="txt_Quantity" Display="Dynamic"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td> <asp:Label ID="lbl_Unit" runat="server" Text="Unit Measure:" Font-Bold="true"></asp:Label></td>
                   <td><asp:TextBox ID="txt_UnitMeasure" runat="server" AutoPostBack="True"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td><asp:Label ID="lbl_Supplier" runat="server" Text="Supplier:" Font-Bold="true"></asp:Label></td>
                   <td><asp:DropDownList ID="ddl_Supplier" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="Validator_Supplier" runat="server" InitialValue="-1" ErrorMessage="Supplier" Text="*" ControlToValidate="ddl_Supplier" Display="Dynamic"></asp:RequiredFieldValidator>
                   </td>
               </tr>               
               </table> </center>        
        <br />
        <center><asp:Button ID="Btn_purchase" runat="server" Font-Bold="true" Text="Record Goods" OnClick="Btn_purchase_Click"/></center>

        </div>
     <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList" HeaderText="Check the following Fields" runat="server"></asp:ValidationSummary>
</asp:Content>
