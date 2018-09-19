using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
namespace Team9_AD
{
    public partial class StockAdjustment : System.Web.UI.Page
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Dhanya*/
            Employee emp = (Employee)Session["user"];
            if (emp.Employee_Role != "Store-Clerk")
            {
                Response.Redirect("LoginPage.aspx");
            }
            Voucher_Gridview.DataSource = model.Voucher_details.ToList();
            Voucher_Gridview.DataBind();
        }

    }
}