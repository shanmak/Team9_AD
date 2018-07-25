<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Master.Master" AutoEventWireup="true" CodeBehind="EmployeeView.aspx.cs" Inherits="Team9_AD.EmployeePages.EmployeeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div>
       
            
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1"  DataKeyNames="Request_ID">
                
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="Request_IDLabel" runat="server" Text='<%# Eval("Request_ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Date_of_RequestLabel" runat="server" Text='<%# Eval("Date_of_Request") %>' />
                        </td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="Request_IDLabel1" runat="server" Text='<%# Eval("Request_ID") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Date_of_RequestTextBox" runat="server" Text='<%# Bind("Date_of_Request") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:TextBox ID="Request_IDTextBox" runat="server" Text='<%# Bind("Request_ID") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Date_of_RequestTextBox" runat="server" Text='<%# Bind("Date_of_Request") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="StatusTextBox" runat="server" Text='<%# Bind("Status") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="Request_IDLabel" runat="server" Text='<%# Eval("Request_ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Date_of_RequestLabel" runat="server" Text='<%# Eval("Date_of_Request") %>' />
                        </td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                        </td>
                        <td>

                            <a href="EmployeeEdit.aspx">Details</a>

                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server">Request_ID</th>
                                        <th runat="server">Date_of_Request</th>
                                        <th runat="server">Status</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="Request_IDLabel" runat="server" Text='<%# Eval("Request_ID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Date_of_RequestLabel" runat="server" Text='<%# Eval("Date_of_Request") %>' />
                        </td>
                        <td>
                            <asp:Label ID="StatusLabel" runat="server" Text='<%# Eval("Status") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>

         
            </asp:ListView>

          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
                SelectCommand="SELECT  [Request_ID], [Date_of_Request], [Status]FROM [Employee_Request] "></asp:SqlDataSource>
               
               
        </div>
</asp:Content>
