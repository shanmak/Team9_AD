<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HodChooseRep.aspx.cs" Inherits="Team9_AD.HodPage.HodChooseRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div>
            <asp:DropDownList ID="DropDownList1" runat="server" >
            </asp:DropDownList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="View Profile" OnClick="Button1_Click1" />
        <asp:GridView ID="GridView1" runat="server" >
        </asp:GridView>
           
                   
                     <p>    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Select Rep" />
                    </p>
              
        <p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
</asp:Content>
