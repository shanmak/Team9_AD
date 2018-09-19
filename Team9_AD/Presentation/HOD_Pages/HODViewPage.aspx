<%@ Page Title="" Language="C#" MasterPageFile="~/HodMasterPage.Master" AutoEventWireup="true" CodeBehind="HODViewPage.aspx.cs" Inherits="Team9_AD.HODViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div><center><b>View Request</b></center><br />
        <center><asp:Image ID="Img_NoRecord" runat="server" ImageUrl ="assets/img/NoRecordFound.jpg" width="500" Height ="500" ImageAlign="AbsMiddle" Visible="false" /></center>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Request_ID" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>

                    <asp:TemplateField HeaderText="Serial No" >
                     <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField DataField="Request_ID" HeaderText="Request ID" SortExpression="Request_ID" ReadOnly="True" />
                    <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" SortExpression="Employee_Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Date_of_Request" HeaderText="Date of Request" ItemStyle-HorizontalAlign="Center"  />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Details"><ItemTemplate >
                        <asp:Button ID="Button1" runat="server" Text="Details" class="btn btn-info" OnClick="btn_Click" Font-Bold="true"/></ItemTemplate></asp:TemplateField>
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" SelectCommand="SELECT DISTINCT Employee_Request.Request_ID, Employee.Employee_Name, Emp_Request_items.Status FROM Employee INNER JOIN Employee_Request ON Employee.Employee_ID = Employee_Request.Employee_ID INNER JOIN Emp_Request_items ON Employee_Request.Request_ID = Emp_Request_items.Request_ID AND Emp_Request_items.Status='pending'"></asp:SqlDataSource>
        </div>
</asp:Content>
