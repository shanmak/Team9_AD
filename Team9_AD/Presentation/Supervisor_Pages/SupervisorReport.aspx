<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorReport.aspx.cs" Inherits="Team9_AD.SupervisorReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <center><b>Report</b></center>
    <div class="bodychart"> 

    <div>
        <asp:Label ID="Label1" runat="server" Text="Select Department Or Supplier"></asp:Label>
        <asp:RadioButton ID="DeptRadioBtn" GroupName="Group1" Text="Department"  runat="server" OnCheckedChanged="Group1_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="SupplierRadioBtn" GroupName="Group1" Text="Supplier" runat="server" OnCheckedChanged="Group1_CheckedChanged" AutoPostBack="true" />
       </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="categoryDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" AutoPostBack="True" OnSelectedIndexChanged="categoryDDL_SelectedIndexChanged"><asp:ListItem Value="0">-- Select Category--</asp:ListItem></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Entity %>" SelectCommand="SELECT Distinct [Category] FROM [Inventory]"></asp:SqlDataSource>
            <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
            <asp:DropDownList ID="descriptionDDL" runat="server" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <asp:DropDownList ID="DeptOrSupp1" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="DeptOrSupp2" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="DeptOrSupp3" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Select Months"></asp:Label>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lstMonths]').multiselect({
                includeSelectAllOption: true
            });
            
        });
    </script>
            <asp:ListBox ID="lstMonths" runat="server" SelectionMode="Multiple">
                <asp:ListItem Text="January" Value="1" />
                <asp:ListItem Text="February" Value="2" />
                <asp:ListItem Text="March" Value="3" />
                <asp:ListItem Text="April" Value="4" />
                <asp:ListItem Text="May" Value="5" />
                <asp:ListItem Text="June" Value="6" />
                <asp:ListItem Text="July" Value="7" />
                <asp:ListItem Text="August" Value="8" />
                <asp:ListItem Text="September" Value="9" />
                <asp:ListItem Text="October" Value="10" />
                 <asp:ListItem Text="November" Value="11" />
                <asp:ListItem Text="December" Value="12" />
            </asp:ListBox>
        
        </div>
        <div>
             <asp:Chart ID="Chart1" runat="server" Width="842px" EnableViewState="False" Height="361px" CssClass="auto-style1">
            <series>
                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="Series1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="Series2">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="Series3">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid Enabled="False" />
                    </AxisY>
                    <AxisX>
                        <MajorGrid Enabled="False" />
                    </AxisX>
                </asp:ChartArea>
            </chartareas>
            <Legends>
                <asp:Legend Name="Legend1" Alignment="Far">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 18pt" Name="Top Title" Text="Compare By Department">
                </asp:Title>
                <asp:Title Docking="Left" Name="Left Title" Text="Quantity">
                </asp:Title>
                <asp:Title Docking="Bottom" Name="Bottom Title" Text="Months">
                </asp:Title>
            </Titles>
        </asp:Chart>
       
        </div>
        <div class="auto-style1">
            <asp:Button ID="Button1" runat="server" Text="Generate Chart" OnClick="Button1_Click" />
        </div>
        </div>
</asp:Content>
