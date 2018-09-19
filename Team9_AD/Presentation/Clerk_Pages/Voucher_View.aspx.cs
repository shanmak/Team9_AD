using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class Voucher_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*code by Dhanya*/
            Employee emp = (Employee)Session["user"];
            if (emp.Employee_Role != "Store-Clerk")
            {
                Response.Redirect("LoginPage.aspx");
            }

        }
    }
}