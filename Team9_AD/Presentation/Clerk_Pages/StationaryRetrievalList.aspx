<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Clerk_Pages/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="StationaryRetrievalList.aspx.cs" Inherits="Team9_AD.Stationary_Retrieval__List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <center>
       <p><b>STATIONERY RETRIEVAL LIST</b></p>
<asp:Label ID="lbl_no" runat="server" Text="Stationery request list for the week is not generated. Please come back on Wednesday" ForeColor="OrangeRed" Visible="false"></asp:Label>
    <asp:Image ID="Img_NoRecordFound" runat="server" Visible="false" ImageUrl ="assets/img/NoRecordFound.jpg" width="500" Height ="500" ImageAlign="AbsMiddle" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="OnPageIndexChanging" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
             <asp:TemplateField HeaderText="SERIAL NO">
          <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
          </ItemTemplate>
          </asp:TemplateField>
            <asp:BoundField DataField="itemnumber" HeaderText="ITEM NUMBER" />
            <asp:BoundField DataField="description" HeaderText="DESCRIPTION" />
            <asp:BoundField DataField="Quty" HeaderText="REQUIRED QUANTITY" />
            <asp:BoundField DataField="ava" HeaderText="AVAILABLE QUANTITY" />
            <asp:BoundField DataField="location" HeaderText="LOCATION" />
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
    </asp:Content>
