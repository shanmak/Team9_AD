using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class purchaseGoods : System.Web.UI.Page
    {
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
                Purchasegoods.DataSource = ClerkMaintenanceBusinessLogic.PurchaseGoods();
                Purchasegoods.DataBind();
            }
        }

        protected void btn_purchase_Click(object sender, EventArgs e)
        {
             
        }
        protected void onRowEditing(object sender, GridViewEditEventArgs e)
        {

            this.Purchasegoods.EditIndex = e.NewEditIndex;
            Purchasegoods.DataSource = ClerkMaintenanceBusinessLogic.PurchaseGoods();
            Purchasegoods.DataBind();

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = Purchasegoods.Rows[e.RowIndex];
            Label l = (Label)row.FindControl("label2");
            string desc = l.Text;
            ClerkMaintenanceBusinessLogic.Deleteitem(desc);
            Purchasegoods.DataSource = ClerkMaintenanceBusinessLogic.PurchaseGoods();
            Purchasegoods.DataBind();

        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            Purchasegoods.EditIndex = -1;
            //BindGrid();
            Purchasegoods.DataSource = ClerkMaintenanceBusinessLogic.PurchaseGoods();
            Purchasegoods.DataBind();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = Purchasegoods.Rows[e.RowIndex];
            Label l = (Label)row.FindControl("label2");
            string Description = l.Text;
            int quantity = Convert.ToInt32((row.FindControl("TextBox1") as TextBox).Text);
            ClerkMaintenanceBusinessLogic.Edititem(Description, quantity);
            Purchasegoods.EditIndex = -1;
            Purchasegoods.DataBind();
            Response.Redirect("purchaseGoods.aspx");

        }

        

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPurchase.aspx");
        }

        protected void btn_CreatePO_Click(object sender, EventArgs e)
        {
            List<PurchaseGood> Purchasegoods = ClerkMaintenanceBusinessLogic.PurchaseGoods();
            foreach (PurchaseGood item in Purchasegoods)
            {
                item.Status = "PO Generated";
                Inventory_purchase newInvPur = new Inventory_purchase();
                newInvPur.Supplier_ID = item.Supplier_ID;
                newInvPur.Date_Order = DateTime.Today;
            }
        }
    }
}