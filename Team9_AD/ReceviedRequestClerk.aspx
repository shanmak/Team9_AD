<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ReceviedRequestClerk.aspx.cs" Inherits="Team9_AD.Recevied_request_clerk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
     

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
    
   
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StoreRequest_ID" >
        <Columns>

            <asp:BoundField DataField="StoreRequest_ID" HeaderText="StoreRequest_ID" />
            <asp:BoundField DataField="Department_ID" HeaderText="Department_ID" />
            <asp:BoundField DataField="Employee_ID" HeaderText="Employee_ID" />
            <asp:BoundField DataField="Request_Date" HeaderText="Request_Date" />           
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button CommandName="select" ID="Button" Text="Details" OnClick="GridView" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>
