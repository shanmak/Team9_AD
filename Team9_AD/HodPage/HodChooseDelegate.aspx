<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HodChooseDelegate.aspx.cs" Inherits="Team9_AD.HodPage.HodChooseDelegate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>jQuery UI Datepicker - Default functionality</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script type="text/javascript">
  $( function() {
    $("#<%= textbox1.ClientID %>" ).datepicker();
  } );
  </script>
    <script type="text/javascript">
  $( function() {
    $("#<%= textbox2.ClientID %>" ).datepicker();
  } );
  </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="promo">
        <div>
            <table>
                 <tr>
                    <td>
                        <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Resume Work" />

                    </td>
                </tr>
                <tr><td>Choose Employee</td>
                    <td>   <asp:TextBox ID="txtName" runat="server"></asp:TextBox> <asp:DropDownList ID="DropDownList1" runat="server" >
        </asp:DropDownList> </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Select Employee" />

                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:GridView ID="GridView1" runat="server">
                         </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        Start Date
                    </td>
                    <td>
                        <asp:TextBox ID="textbox1" runat="server" CssClass="datepicker" placeholder="Select date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        End Date
                    </td>
                    <td>
                        <asp:TextBox ID="textbox2" runat="server" CssClass="datepicker" placeholder="Select date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Select Delegate" />
                    </td>
                </tr>
                </table>
            </div>

        <p> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </p>
        <p><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> </p>
  </div>

</asp:Content>
