<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Master.Master" AutoEventWireup="true" CodeBehind="EmployeeViewRequest.aspx.cs" Inherits="Team9_AD.EmployeeViewRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div>
            <center><b>View Request</b></center><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center" >
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                     <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Request_ID" HeaderText="Request ID" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                     </asp:BoundField>
                    <asp:BoundField DataField="Date_of_Request" HeaderText="Date Of Request" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                     </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                   
<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                     </asp:BoundField>
                   
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                   <ItemTemplate>                     
                    <asp:Button ID="Button1" runat="server" Text="Details"  class="btn btn-info" OnClick="Details" />
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" ></ItemStyle>
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
               
        </div>
</asp:Content>
