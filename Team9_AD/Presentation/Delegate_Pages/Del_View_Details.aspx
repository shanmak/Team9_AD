<%@ Page Title="" Language="C#" MasterPageFile="~/Delegate.Master" AutoEventWireup="true" CodeBehind="Del_View_Details.aspx.cs" Inherits="Team9_AD.Del_View_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div><center><b>Request Details</b></center><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                     <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                <asp:CheckBox ID="SelectCheckBox" runat="server"  />
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
        <p><center> <asp:Label ID="Label1" runat="server" Text="Comment (Optional)"></asp:Label>&nbsp&nbsp<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox></center></p>
      <div><center> <asp:Button class="btn btn-success" ID="APPROVE" runat="server" Text="APPROVE" OnClick="Button2_Click" />&nbsp&nbsp

            
         <asp:Button class="btn btn-secondary" ID="Button1" runat="server" Text="CANCEL" OnClick="Button1_Click"  />
        </center></div>
        </div>
</asp:Content>
