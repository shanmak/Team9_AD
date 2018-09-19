<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_Master.Master" AutoEventWireup="true" CodeBehind="EmployeeMakeRequest.aspx.cs" Inherits="Team9_AD.EmployeeMakeRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style>
   .hover {
    color: blueviolet;
}
    </style> 
    <div>
    <center><b>Make Request</b></center><br />

        </div>
  
    <asp:GridView ID="Requestdetails" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
    <Columns>
        
        <asp:TemplateField HeaderText="Category" HeaderStyle-HorizontalAlign="Center"   >
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3"
                    DataTextField="Category" AutoPostBack="True" OnSelectedIndexChanged ="Unit_Measure">

                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 

             SelectCommand="SELECT DISTINCT [Category] FROM Inventory"></asp:SqlDataSource>
            </ItemTemplate>
           
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>


           
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Center"   >
            <ItemTemplate>
                <asp:DropDownList ID="DropDownList2" DataSourceID="SqlDataSource2"
                    DataTextField="Description" 
                    runat="server" AutoPostBack="True" OnSelectedIndexChanged ="Unit_Measure">
                    </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
            SelectCommand="SELECT DISTINCT [Description] FROM [Inventory] where Category = @Category">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" 
                            PropertyName ="SelectedValue" Name ="Category" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ItemTemplate>
            
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>


            
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center" >
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" CausesValidation="True">                    
                   </asp:TextBox>
                     </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>


        </asp:TemplateField>      
               
        <asp:TemplateField HeaderText="Unit Measure" HeaderStyle-HorizontalAlign="Center"   >
            <ItemTemplate>
               <asp:TextBox ID="TextBox2" runat="server" DataSourceID="SqlDataSource4"  
                   ReadOnly="True" AutoPostBack="True">
                   </asp:TextBox>
            </ItemTemplate>
            
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            
        </asp:TemplateField>
        <asp:TemplateField>   <ItemTemplate> 
             <asp:Button ID="Button" Text="Reset" Font-Bold="true" runat="server" OnClick="btn_delete" CausesValidation="false"/>
                              </ItemTemplate>   </asp:TemplateField>
       

       <asp:TemplateField>
            <ItemTemplate>
         <asp:RegularExpressionValidator id="RegularExpressionValidator1" Text="*" ForeColor="Red" runat="server" 
         ErrorMessage="Enter Only Positive Numbers" 
             ValidationExpression="^[1-9]([0-9]*,?)*$" EnableClientScript="true"
        ControlToValidate="TextBox1" Display="Dynamic" /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" ForeColor="Red" runat="server" 
                    ErrorMessage="Quantity is null" 
                    ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Text="*" ForeColor="Red" Type="Integer" maximumvalue="50" minimumvalue="1" 
                    ErrorMessage="Invalid Quantity Range"  ControlToValidate="TextBox1" Display="Dynamic">
                </asp:RangeValidator>
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
    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Check the following errors" runat="server" />
   
        <br />
    <br />
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        &nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        <asp:Button ID="btn_Addrequest" runat="server" Text="Add New Request" class="btn btn-warning" Font-Bold="true" OnClick="btn_Addrequest_Click" />
&nbsp;&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp
        <asp:Button ID="btn_Submitrequest" runat="server" Text="Submit Request" Font-Bold="true" class="btn btn-success" OnClick="btn_Submitrequest_Click"/>
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Logic_University_Model %>" 
            SelectCommand="SELECT [Category], [Description], [Unit_Measure] FROM [Inventory]"></asp:SqlDataSource>
</asp:Content>
