<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ReportByItem.aspx.cs" Inherits="Team9_AD.ReportByItem" Debug="true"%>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .chart{
             padding: 40px;  
    background-size: cover;
    background-color:aliceblue;
    height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div>
            <asp:DropDownList ID="categoryDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" AutoPostBack="True" OnSelectedIndexChanged="categoryDDL_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model1 %>" SelectCommand="SELECT distinct [Category] FROM [Inventory]"></asp:SqlDataSource>
            <asp:DropDownList ID="descriptionDDL" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        
        
            <div>
            <asp:Chart ID="Chart1" runat="server" Width="828px" Height="350px">
                <Series>
                    <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
                </Series>
                <ChartAreas >
                    <asp:ChartArea Name="ChartArea1">
                     
                    </asp:ChartArea>
                </ChartAreas>
                <Titles>
                    <asp:Title Font="Microsoft Sans Serif, 18pt" Name="Title1" Text="Chart By Item">
                    </asp:Title>
                    <asp:Title Docking="Left" Name="Title2" Text="Quantity">
                    </asp:Title>
                    <asp:Title Docking="Bottom" Name="Title3" Text="Item Description">
                    </asp:Title>
                </Titles>
            </asp:Chart>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Generate Chart" OnClick="Button1_Click" />
        </div>
    
</asp:Content>
