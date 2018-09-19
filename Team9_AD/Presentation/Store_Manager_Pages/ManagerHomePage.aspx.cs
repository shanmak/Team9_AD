using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class ManagerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "Store-Manager")
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }
    }
}