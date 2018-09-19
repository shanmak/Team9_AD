<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk_Master.Master" AutoEventWireup="true" CodeBehind="WarehouseRetrievelList.aspx.cs" Inherits="Team9_AD.WarehouseRetrievelList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <script type="text/javascript">
     function positive() {
         document.getElementById("Lable1").innerHTML =
             document.getElementById("CollectedQuntity").nodeValue.length + "character(s)";
     }
 </script>

    <script type="text/javascript">
        function checkCollectedQuntity(lnk) {
            //Reference the GridView Row.
            var row = lnk.parentNode.parentNode;          

            var cqunty = row.cells[5].innerHTML;
            var aqunty = row.cells[6].innerHTML;
            var colqunty = row.cells[7].getElementsByTagName("input")[0].value;

            var tedqunty = parseInt(cqunty);
            var availblequnty = parseInt(aqunty);
            var collectedqunty = parseInt(colqunty);

            if (tedqunty < collectedqunty) {
                alert("Sorry you can't get more than required Quantity");
            }

            if (collectedqunty <= availblequnty)
            {

                
            } else {
               
                alert("Sorry you can't get more than availble Quantity");
            }
            return false;
        }
    </script>
    <script type="text/javascript">

        function checkDamagedQuantity(lnk) {

             var row = lnk.parentNode.parentNode;          

            var requnty = row.cells[5].innerHTML;
            var requnty = row.cells[6].innerHTML;
            var colqunty = row.cells[7].getElementsByTagName("input")[0].value;
             var damagequnty = row.cells[8].getElementsByTagName("input")[0].value;

            var tedqunty = parseInt(requnty);
            var availblequnty = parseInt(requnty);
            var collectedqunty = parseInt(colqunty);
            var dmgqnty = parseInt(damagequnty);

            var check = availblequnty - collectedqunty;

            if (damagequnty <= check) {
               
            } else {
                alert(" dmg Sorry you can't get more than availble Quantity ");
            }

            return false;
        }
    </script>
       <center><b>WAREHOUSE RETRIEVAL LIST</b></center>
    <br />

     <center><asp:Image ID="Img_NoRecord" runat="server" ImageUrl ="assets/img/NoRecordFound.jpg" width="500" Height ="500" ImageAlign="AbsMiddle" Visible="false" /></center>
  <center>  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
                 <asp:TemplateField HeaderText="SERIAL N0">
                     <ItemTemplate>
                      <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                     </asp:TemplateField>
                 <asp:BoundField DataField="itemnumber" HeaderText="ITEM NUMBER" />
                 <asp:BoundField DataField="category" HeaderText="CATEGORY" />
            <asp:BoundField DataField="description" HeaderText="DESCRIPTION" SortExpression="Description" />
            <asp:BoundField DataField="location" HeaderText="BIN NUMBER" SortExpression="Bin_number" />
            <asp:BoundField DataField="Quty" HeaderText="REQUIRED QUANTITY" ReadOnly="True" SortExpression="Req_Qunty" />
            <asp:BoundField DataField="ava" HeaderText="AVAILABLE QUANTITY" ReadOnly="true" SortExpression="Available" />
            <asp:TemplateField HeaderText="COLLECTED QUANTITY" >
                <ItemTemplate >
                    <asp:TextBox runat="server" ID="CollectedQuntity" Text="0" onfocusout="return checkCollectedQuntity(this);" AutoPostBack="false" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>                    
               </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="DAMAGED QUANTITY" >
                <ItemTemplate >
                 
                 <asp:TextBox runat="server" ID="DamagedQuantity" Text="0"  onfocusout="return checkDamagedQuantity(this)" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
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
    <br />

 <center>   <asp:Button ID="btn_Update" runat="server" Text="Create Disbursement List" class="btn btn-success"  OnClick ="Button1_Click" />
  
    <asp:Button ID="btn_cancel" runat="server" OnClick="Button2_Click" CssClass="btn btn-danger" Text="Cancel" /></center>
</asp:Content>
