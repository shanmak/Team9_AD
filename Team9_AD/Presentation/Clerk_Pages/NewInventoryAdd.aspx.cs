using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class NewInventoryAdd : System.Web.UI.Page
    {
        /*Code by Mani*/
        static string supplier1 = "";
        static string supplier2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                DropDownList1.DataSource = ClerkMaintenanceBusinessLogic.GetSupplier();
                DropDownList1.DataBind();
                ListItem li = new ListItem("Select the First Supplier", "-1");
                DropDownList1.Items.Insert(0, li);

                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string host = Application["host"].ToString();

            Logic_University_Entity logic = new Logic_University_Entity();
            
            Inventory inventory = new Inventory();
            inventory.Item_Number = TextBox1.Text;
            inventory.Category = TextBox2.Text;
            inventory.Description = TextBox3.Text;
            inventory.Reorder_level = Convert.ToInt32(TextBox4.Text);
            inventory.Reorder_qty = Convert.ToInt32(TextBox5.Text);
            inventory.Price = Convert.ToDecimal(TextBox6.Text);
            inventory.Unit_Measure = TextBox7.Text;
            inventory.Quantity = Convert.ToInt32(TextBox8.Text);
            inventory.Bin_number = TextBox9.Text;

            inventory.Supplier_ID_1 = ClerkMaintenanceBusinessLogic.GetSupplierByName(DropDownList1.SelectedValue);
            inventory.Supplier_ID_2 = ClerkMaintenanceBusinessLogic.GetSupplierByName(DropDownList2.SelectedValue);
            inventory.Supplier_ID_3 = ClerkMaintenanceBusinessLogic.GetSupplierByName(DropDownList3.SelectedValue);

            string sus = ClerkMaintenanceBusinessLogic.AddnewInventory(inventory);


            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplier1 = DropDownList1.SelectedValue;

            List<string> list = ClerkMaintenanceBusinessLogic.GetSupplier();

            var newlist = list.Remove(supplier1);
            DropDownList2.Enabled = true;
            DropDownList2.DataSource = list;
            DropDownList2.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplier2 = DropDownList2.SelectedValue;

            List<string> list = ClerkMaintenanceBusinessLogic.GetSupplier();

            list.Remove(supplier1);
            list.Remove(supplier2);

            DropDownList3.Enabled = true;
            DropDownList3.DataSource = list;
            DropDownList3.DataBind();


        }

    }

}