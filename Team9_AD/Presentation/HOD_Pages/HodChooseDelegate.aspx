<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HodChooseDelegate.aspx.cs" Inherits="Team9_AD.HodChooseDelegate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI Datepicker - Default functionality</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


   <script>var dateToday = new Date();
       $(function () {
           $('#<%=txt_StartDate.ClientID%>').datepicker({
               defaultDate: "+1w",
               changeMonth: true,
               dateFormat: 'yy/mm/dd',
               numberOfMonths: 1,
               minDate: dateToday,
               onClose: function (selectedDate) {
                   $('#<%=txt_EndDate.ClientID%>').datepicker("option", "minDate", selectedDate);
            }
           });
           $('#<%=txt_EndDate.ClientID%>').datepicker({
               defaultDate: "+1w",
               changeMonth: true,
               dateFormat: 'yy/mm/dd',
               numberOfMonths: 1,
               onClose: function (selectedDate) {
                   $( '#<%=txt_StartDate.ClientID%>').datepicker("option", "maxDate", selectedDate);
            }
           });
       });
        </script> 

   

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <div class="table-responsive">
            <center><b>Choose Delegate</b></center><br />
       <center>
            <table class="table-bordered"  >
            
                <tr><td> Current Delegate</td>
                    <td> <asp:Label ID="Label2" runat="server" Text="Label" AutoPostBack="True"></asp:Label></td></tr>
                <tr><td colspan="2"><center><br /><asp:Button ID="Revoke_btn" runat="server" Text="Revoke" OnClick="Revoke_Btn_Click" causesvalidation="false"></asp:Button></center></td></tr>
                   <tr><td>Choose Employee</td>
                    <td>   <asp:DropDownList ID="DropDownList1" runat="server" >
        </asp:DropDownList> </td>
                                    </tr>
                
                <tr>
                    <td colspan="2"><br /><center>
                        &nbsp;<asp:Button ID="Btn_ViewEmployee" runat="server" CssClass="btn btn-info" OnClick="ViewEmployee_Clicked" Text="View Employee" causesvalidation="false"/>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><center>
                         <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                             <AlternatingRowStyle BackColor="#DCDCDC" />
                             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                             <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                             <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                             <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                             <SortedAscendingCellStyle BackColor="#F1F1F1" />
                             <SortedAscendingHeaderStyle BackColor="#0000A9" />
                             <SortedDescendingCellStyle BackColor="#CAC9C9" />
                             <SortedDescendingHeaderStyle BackColor="#000065" />
                         </asp:GridView></center>
                    </td>
                </tr>
                <tr>
                    <td>
                       Start Date
                    </td>
                    <td>
                        <asp:TextBox ID="txt_StartDate" runat="server"  ></asp:TextBox>
<asp:RequiredFieldValidator ID="Validator_StartDate" runat="server" Text="*"  ErrorMessage="Start Date to be entered" ControlToValidate="txt_StartDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        End Date
                    </td>
                    <td>
                        <asp:TextBox ID="txt_EndDate" runat="server" ></asp:TextBox>
<asp:RequiredFieldValidator ID="Validator_EndDate" runat="server" Text="*" ErrorMessage="End Date to be entered" ControlToValidate="txt_EndDate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><center>
                         <asp:Button ID="Btn_SelectDelegate" runat="server" class="btn btn-success" OnClick="Select_Delegate_Click" Text="Select Delegate" />
                         <br />
                         <br />
                         <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                        </center>                       
                    </td>
                </tr>
                </table>
           </center>
            <div id="container" class="container" >
                 <div id="top" class="top">
        <div id="topLeft" class="topLeft">
            &nbsp;
        </div>
        <div id="topMiddle" class="topMiddle">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Check the following errors"  ForeColor="Red" DisplayMode="BulletList" />
        </div>
        <div id="topRight" class="topRight">
            &nbsp;
        </div>
    </div>  
            </div>     
</asp:Content>
