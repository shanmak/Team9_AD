using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team9_AD
{
    public partial class ManagerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            string host = Application["host"].ToString();
            Response.Redirect("http://" + host + "/AD_Demo/LoginPage.aspx");
        }
    }
}