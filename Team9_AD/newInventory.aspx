<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newInventory.aspx.cs" Inherits="Team9_AD.newInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Item_Number"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label4" runat="server" Text="Reorder_level"></asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label5" runat="server" Text="Reorder_qty"></asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label6" runat="server" Text="Price"></asp:Label><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label7" runat="server" Text="Unit_Measure"></asp:Label><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label8" runat="server" Text="Quantity"></asp:Label><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label9" runat="server" Text="Bin_number"></asp:Label><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label10" runat="server" Text="Suppiler_ID_1"></asp:Label><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label11" runat="server" Text="Suppiler_ID_2"></asp:Label><asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            <br />
             <asp:Label ID="Label12" runat="server" Text="Suppiler_ID_3"></asp:Label><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
