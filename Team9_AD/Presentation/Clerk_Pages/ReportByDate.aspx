<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ReportByDate.aspx.cs" Inherits="Team9_AD.ReportByDate" Debug="true"%>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
       <script>  
        
        $(function () {
            $("#<%=fromdatepicker.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" });
        });
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("#<%=todatepicker.ClientID%>").datepicker({ dateFormat: "yy-mm-dd" , 
                maxDate: new Date(currentYear, currentMonth, currentDate)
            });
        });

  </script>
    <style>
    .chart
    {
        }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      

            <asp:Label ID="Label1" runat="server" Text="FROM:"></asp:Label>
            <asp:TextBox ID="fromdatepicker" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
            <asp:TextBox ID="todatepicker" runat="server"></asp:TextBox>
           <p><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Chart" />
            </p>  
  <div>     
    <ContentTemplate>
        <asp:Chart ID="Chart1" runat="server" Height="490px" Width="721px" >
            <Series>
                <asp:Series Name="Series1" IsValueShownAsLabel="True"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>                
            </ChartAreas>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 18pt" Name="Title1" Text="Chart By Date Range">
                </asp:Title>
                <asp:Title Docking="Left" Name="Title2" Text="Quantity">
                </asp:Title>
                <asp:Title Docking="Bottom" Name="Title3" Text="Description">
                </asp:Title>
            </Titles>
        </asp:Chart>
     </ContentTemplate>
 <div>   
</asp:Content>
