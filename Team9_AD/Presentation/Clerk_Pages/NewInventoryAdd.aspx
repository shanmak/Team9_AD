<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="NewInventoryAdd.aspx.cs" Inherits="Team9_AD.NewInventoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
   <center> <b>ADD NEW INVENTORY</b>
       <table>
             <tr>
                 <td>
                     <asp:Label ID="lbl_Itemnumber" runat="server" Text="Item_Number"></asp:Label>
                 </td>
                 <td>  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
             </tr>
             <br />
             <tr>
                 <td><asp:Label ID="lbl_Category" runat="server" Text="Category"></asp:Label></td>
                 <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
             </tr>
             <br />
             <tr>
              <td><asp:Label ID="lbl_Description" runat="server" Text="Description"></asp:Label></td>
              <td> <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
              </tr>
                <br />
             <tr>
                 <td> <asp:Label ID="lbl_Reorder_level" runat="server" Text="Reorder_level"></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
             </tr>         
            <br />
             <tr>
                 <td>   <asp:Label ID="lbl_Reorderqty" runat="server" Text="Reorder_qty"></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
             </tr>
            <br />
             <tr>
                 <td><asp:Label ID="lbl_Price" runat="server" Text="Price"></asp:Label></td>
                 <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
             </tr>
            <br />
             <tr>
                 <td><asp:Label ID="lbl_UnitMeasure" runat="server" Text="Unit_Measure"></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
             </tr>
            
            <br />

             <tr>
                 <td><asp:Label ID="lbl_Quantity" runat="server" Text="Quantity"></asp:Label></td>
                 <td> <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
             </tr>          
            <br />
             <tr>
                 <td>  <asp:Label ID="lbl_Binnumber" runat="server" Text="Bin_number"></asp:Label></td>
                 <td><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
             </tr>           
            <br />
             <tr>
                  <td>  <asp:Label ID="lbl_Supplier1" runat="server" Text="Supplier 1"></asp:Label></td>
                 <td><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
             </tr>
            <br />
             <tr>
                 <td>  <asp:Label ID="lbl_Supplier2" runat="server" Text="Supplier 2"></asp:Label></td>
                 <td> <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
             </tr>         
            <br />
             <tr>
                 <td><asp:Label ID="lbl_Supplier3" runat="server" Text="Supplier 3"></asp:Label></td>
                 <td><asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
             </tr>
            <br />
             </table>
           <br />
           <br />
            <asp:Button ID="btn_AddInventory" runat="server" Text="Add Inventory" class="btn btn-success" OnClick="Button1_Click" />
        </div>     
    </center>
</asp:Content>
