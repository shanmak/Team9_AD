using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class purchaseOrder : System.Web.UI.Page
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Subash*/
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                Suppliers.DataSource = (from o in model.Inventories where o.Quantity < o.Reorder_level select o.Supplier_ID_1).ToList().Distinct();
                //(from o in model.Inventories select o.Supplier_ID_1).ToList().Distinct();
                Suppliers.DataBind();
                ListItem li = new ListItem("Select the supplier", "-1");
                Suppliers.Items.Insert(0, li);
                btn_GenPurchaseOrder.Enabled = false;
            }

        }

        protected void btn_GenPurchaseOrder_Click(object sender, EventArgs e)
        {
            List<Inventory> m = ClerkMaintenanceBusinessLogic.purchaseOrder(Suppliers.SelectedValue);
            PurchaseOrders.DataSource = m;
            PurchaseOrders.DataBind();
        }

        protected void Suppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Suppliers.SelectedIndex == 0)
            {
                btn_GenPurchaseOrder.Enabled = false;
                PurchaseOrders.Visible = false;
            }
            else
            {
                PurchaseOrders.Visible = true;
                PurchaseOrders.DataBind();
                btn_GenPurchaseOrder.Enabled = true;
            }
        }
    }
}