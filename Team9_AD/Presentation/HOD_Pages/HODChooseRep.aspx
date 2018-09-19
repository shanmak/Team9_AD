<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HODChooseRep.aspx.cs" Inherits="Team9_AD.HODChooseRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .promohere {
    text-align: center;
    padding: 40px;
  
    background-size: cover;
    height: 500px;
}
        .auto-style1 {
            height: 27px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="promehere">
        <div class="table-responsive">
            <center><b>Choose Representative</b></center><br />
       <center>
            <table class="table-bordered"  >


            <tr> <td class="auto-style1"> Current Representative</td>
                <td class="auto-style1"><asp:Label ID="Label2" runat="server"></asp:Label></td>
            </tr>

            <tr>       <td>Select Representative</td>    
             <td> <asp:DropDownList ID="DropDownList1" runat="server" >
              </asp:DropDownList>     </td>     
            </tr>
            
        <tr><td colspan="2"><br /> <center><asp:Button ID="Button1" runat="server" Text="View Profile" CssClass="btn btn-info" OnClick="Button1_Click1" /></center></td></tr>
       <tr><td colspan="2"><asp:GridView ID="GridView1" runat="server" Width="276px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"  >
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
           </asp:GridView></td></tr> 
                </table>

             <br />
             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" class="btn btn-success" Text="Select Rep" />
                   <br />
            <br />
            <asp:Label ID="lbl_error" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                   </center>
           </center>
           </div>
        </div>
      

</asp:Content>
