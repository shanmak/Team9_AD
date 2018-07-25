<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Master.Master" AutoEventWireup="true" CodeBehind="MakeRequest.aspx.cs" Inherits="Team9_AD.EmployeePages.MakeRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:GridView ID="Requestdetails" runat="server"  AutoGenerateColumns="False" CellPadding="3" GridLines="None"  >
    <Columns>
        
        <asp:TemplateField HeaderText="Category">
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="Category" AutoPostBack="True"> </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
             SelectCommand="SELECT DISTINCT [Category] FROM Inventory"></asp:SqlDataSource>
            </ItemTemplate>
           
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Description">
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList2" DataSourceID="SqlDataSource2"
                    DataTextField="Description" 
                    runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
            SelectCommand="SELECT DISTINCT [Description] FROM [Inventory] where Category = @Category">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" PropertyName ="SelectedValue" Name ="Category" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ItemTemplate>
            
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" >

                   </asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Unit Measure" >
            <ItemTemplate>
              
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource4" DataTextField="Unit_Measure" AutoPostBack="True"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
             SelectCommand="SELECT DISTINCT [Unit_Measure] FROM Inventory"></asp:SqlDataSource>
            </ItemTemplate>
            
        </asp:TemplateField>

    </Columns>
</asp:GridView>

        &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
         &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
         &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        
        <asp:Button ID="btn_Addrequest" runat="server" Text="Add New Request" OnClick="Button2_Click" />
&nbsp;&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        <asp:Button ID="btn_Submitrequest" runat="server" Text="Submit Request"  OnClick="Button1_Click"/>
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
            SelectCommand="SELECT [Category], [Description], [Unit_Measure] FROM [Inventory]"></asp:SqlDataSource>
</asp:Content>
