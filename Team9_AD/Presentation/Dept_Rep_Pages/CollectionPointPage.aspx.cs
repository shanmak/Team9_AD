using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;


namespace Team9_AD.RepPage
{
    public partial class CollectionPointPage : System.Web.UI.Page
    {

        RepBusinessLogic bl = new RepBusinessLogic();    
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Santhosh*/
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Employee-Rep")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                if (user == null)
                {
                   // Response.Redirect("LoginPage.aspx");
                }
            }
            using (Logic_University_Entity t = new Logic_University_Entity())
            {
                Label2.Text = bl.findPreviousCollectionPoint();
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string value = RadioButtonList1.SelectedValue;

            using (Logic_University_Entity t = new Logic_University_Entity())
            {
                Employee user = (Employee)Session["user"];

                Label2.Text = value;

                bl.sendNotificationByEmail(user, value);

                Label1.Text = "Collection Point has been Updated! Email sent to store clerk.";
            }
        }
    }
}