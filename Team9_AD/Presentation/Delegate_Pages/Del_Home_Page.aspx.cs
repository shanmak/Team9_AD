using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class Del_Home_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Delegate")
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }
    }
}