using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.AddClass;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class Del_View_Page : System.Web.UI.Page
    {
        Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Padma*/
            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Delegate")
                {
                    Response.Redirect("LoginPage.aspx");
                }

                var list2 = model.Employee_Request.Where(x => x.Department_ID == user.Department_ID && x.Status == "Pending").ToList();

                var newlist = list2.Select(x => new HodViewlist(x.Request_ID, x.Employee.Employee_Name, x.Date_of_Request, x.Status)).ToList();

                if (newlist.Count != 0)
                {
                    GridView1.DataSource = newlist;
                    GridView1.DataBind();
                }
                else
                {
                    Img_NoRecord.Visible = true;
                }
            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            GridViewRow r = (GridViewRow)b.NamingContainer;
            string ID = GridView1.DataKeys[r.RowIndex].Values[0].ToString();
      
        Response.Redirect("Del_View_Details.aspx?ID=" + ID);
        }
    }
}