using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;


namespace Team9_AD.RepPage
{
    public partial class CollectionPointPage : System.Web.UI.Page
    {

        BusinessLogic bl = new BusinessLogic();

        
        protected void Page_Load(object sender, EventArgs e)
        {

            using (Logic_University_Model t = new Logic_University_Model())
            {
                Label2.Text = bl.findPreviousCollectionPoint();
            }
        }

        //Update the place and send notification by email
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string value = RadioButtonList1.SelectedValue;

            using (Logic_University_Model t = new Logic_University_Model())
            {

                Label2.Text = value;

                bl.sendNotificationByEmail(value);

                Label1.Text = "Email Sent";
            }
        }
    }
}