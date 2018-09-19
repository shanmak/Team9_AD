<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="ReceviedRequestClerk.aspx.cs" Inherits="Team9_AD.Recevied_request_clerk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    
    <link rel="stylesheet" href="/resources/demos/style.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


  <script type="text/javascript">
      $(function () {

          $("#<%= textbox1.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' })

        
  } );
  </script>
     <center><p><b>STORE REQUESTS</b></p></center><br />
     <center><asp:DropDownList ID="DropDownList1" runat="server"  ></asp:DropDownList>
    
      <asp:TextBox ID="textbox1" runat="server" CssClass="datepicker" placeholder="Select date"></asp:TextBox>
<asp:RequiredFieldValidator ID="Validator_Date" runat="server" ControlToValidate="textbox1" Text="*" ErrorMessage="Select any Date" Display="Dynamic" ></asp:RequiredFieldValidator>
     <asp:Button ID="Button1" runat="server" Text="View" class="btn btn-info" OnClick="Button1_Click"/>
         &nbsp &nbsp
    <asp:Button ID="Button2" runat="server" Text="VIEW ALL" CausesValidation="false" CssClass="btn btn-info" OnClick="Button2_Click" />
    <br />
    <asp:Image ID="Img_NoRecord" runat="server" ImageUrl ="assets/img/NoRequests.jpg" CssClass="img" width="500" Height ="500" ImageAlign="AbsMiddle" Visible="false" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StoreRequest_ID" OnPageIndexChanging="OnPageIndexChanging" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
             <asp:TemplateField HeaderText="SERIAL NO" >
          <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
          </ItemTemplate>
          </asp:TemplateField>
           <asp:BoundField DataField="StoreRequest_ID" HeaderText="StoreRequest ID" />
            <asp:BoundField DataField="Department_Name" HeaderText="Department Name" />
            <asp:BoundField DataField="Employee_Name" HeaderText="Approved By"   />
            <asp:BoundField DataField="Request_Date" HeaderText="Request Date"  />       
             <asp:BoundField DataField="Status" HeaderText="Status"   />
            <asp:TemplateField  >
                <ItemTemplate>
                    <asp:Button CommandName="select" ID="Button" Text="Details" CausesValidation="false" CssClass="btn btn-info" OnClick="GridView" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
         </center>
  <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" Font-Bold="true" runat="server" />
    </asp:Content>
