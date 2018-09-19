<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="DamageRecord.aspx.cs" Inherits="Team9_AD.DamageRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center><b>RECORD DAMAGE</b></center>
        <center>
<table>
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Select Category" ></asp:Label></td>
        <td><asp:DropDownList ID="ddl_Category" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category"></asp:DropDownList></td>
    </tr>
<tr>
    <td><asp:Label ID="Label2" runat="server" Text="Select Description"></asp:Label> </td>
    <td> <asp:DropDownList ID="ddl_Description" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Description_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="Description" DataValueField="Description">
            </asp:DropDownList></td>
</tr>
   <tr>
       <td class="auto-style1"><asp:Label ID="lbl_quantity" runat="server" Text="Quantity"> </asp:Label></td>
       <td class="auto-style1"><asp:TextBox ID="txt_Quantity" runat="server"></asp:TextBox></td>
   </tr>     
     
    <tr>
          <td> <asp:Label ID="lbl_measure" runat="server" Text="Unit Measure"></asp:Label></td> 
            <td><asp:TextBox ID="txt_UnitMeasure" runat="server" AutoPostBack="True"></asp:TextBox></td>
    </tr>
         <tr>
            <td><asp:Label ID="lbl_loc" runat="server" Text="Location:"></asp:Label></td>
             <td>  <asp:TextBox ID="txt_Loc" runat="server" AutoPostBack="True"></asp:TextBox></td>
         </tr>   
        
    <tr>
        <td></td>
    </tr>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT distinct[Category] FROM [Inventory]">

            </asp:SqlDataSource>
            <br />
            
           <br />

    </table>
            <br />
              <asp:Button ID="record_Damage" runat="server" Text="Record damage" CssClass="btn btn-success" OnClick="record_Damage_Click"/>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Team_9_AD_DBConnectionString %>" SelectCommand="SELECT Description FROM [Inventory] where Category =@Category">
            <SelectParameters>
                        <asp:ControlParameter ControlID="ddl_Category" PropertyName ="SelectedValue" Name ="Category" />
            </SelectParameters>    
        </asp:SqlDataSource>
           <br />     
    </div>
    </center>
</asp:Content>
