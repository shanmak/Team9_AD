using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class GoodsReceived : System.Web.UI.Page
    {
        Logic_University_Entity models = new Logic_University_Entity();
        Model m = new Model();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Priya*/

            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                ddl_Category.DataSource = models.Inventories.Select(x => x.Category).Distinct().ToList();
                ddl_Category.DataBind();
                ListItem li = new ListItem("Select the Category", "-1");
                ddl_Category.Items.Insert(0, li);
                ddl_Supplier.Enabled = false;
            }
        }
        protected void Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Description.SelectedIndex != 0)
            {
                txt_UnitMeasure.Enabled = true;
                string s = ddl_Description.SelectedValue;
                string desc = (from x in models.Inventories where x.Description == ddl_Description.SelectedValue select x.Unit_Measure).FirstOrDefault().ToString();
                txt_UnitMeasure.Text = desc;
                ddl_Supplier.Enabled = true;
                string supplier1 = models.Inventories.Where(x => x.Description == ddl_Description.SelectedValue).Select(x => x.Supplier_ID_1).FirstOrDefault();
                string supplier2 = models.Inventories.Where(x => x.Description == ddl_Description.SelectedValue).Select(x => x.Supplier_ID_2).FirstOrDefault();
                string supplier3 = models.Inventories.Where(x => x.Description == ddl_Description.SelectedValue).Select(x => x.Supplier_ID_3).FirstOrDefault();
                List<String> supplier = new List<string>();
                supplier.Add(supplier1);
                supplier.Add(supplier2);
                supplier.Add(supplier3);
                ddl_Supplier.DataSource = supplier;
                ddl_Supplier.DataBind();
                ListItem li = new ListItem("Select the Supplier", "-1");
                ddl_Supplier.Items.Insert(0, li);
            }
            else
            {
                txt_UnitMeasure.Text = " ";
                ddl_Supplier.Enabled = false;
            }

        }
        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddl_Category.SelectedIndex == 0)
            {
                txt_UnitMeasure.Text = " ";
            }
            ddl_Description.Enabled = true;
            ddl_Description.DataSource = models.Inventories.Where(x => x.Category == ddl_Category.SelectedValue).Select(x => x.Description).ToList();
            ddl_Description.DataBind();
            ListItem lis = new ListItem("Select the Description", "-1");
            ddl_Description.Items.Insert(0, lis);
        }

        protected void Btn_purchase_Click(object sender, EventArgs e)
        {
            
            Goods_Received newPurchaseItem = new Goods_Received();
            String Description = ddl_Description.SelectedValue;
            newPurchaseItem.Item_Number = ClerkMaintenanceBusinessLogic.getItemNumber(Description);
            newPurchaseItem.Quantity_Recevied = Convert.ToInt32(txt_Quantity.Text);
                ClerkMaintenanceBusinessLogic.IncreaseInventory(newPurchaseItem.Item_Number, newPurchaseItem.Quantity_Recevied);
            newPurchaseItem.Supplier_ID = ddl_Supplier.SelectedValue;
            newPurchaseItem.Received_Date = DateTime.Now;
            models.Goods_Received.Add(newPurchaseItem);
            m.SaveChanges();
            Response.Redirect("ClerkHome.aspx");
        }
    }
}