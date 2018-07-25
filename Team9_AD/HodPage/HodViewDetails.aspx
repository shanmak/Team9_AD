<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HodViewDetails.aspx.cs" Inherits="Team9_AD.HodPage.HodViewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>

            </asp:GridView>
            <asp:Button ID="Button1" runat="server" Text="Approve" OnClick="Approve_Click" />
            <asp:Button ID="Button2" runat="server" Text="Reject" OnClick="Reject_Click"/>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Hint="Comment"></asp:TextBox>
            
        </div>
</asp:Content>
