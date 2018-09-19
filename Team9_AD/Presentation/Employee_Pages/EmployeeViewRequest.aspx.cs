using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class EmployeeViewRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Code by Padma*/
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Employee")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                string depid = user.Department_ID;
                string empid = user.Employee_ID;
                using (Logic_University_Entity entities = new Logic_University_Entity())
                {
                    //var list = entities.Employee_Request.Where(x => x.Department_ID == depid && x.Employee_ID == empid && x.Status == "Pending").ToList();
                    var list = entities.Employee_Request.Where(x => x.Department_ID == depid && x.Employee_ID == empid).ToList();
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                }
            }

        }

        protected void Details(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow r = (GridViewRow)b.NamingContainer;

            string ID = GridView1.Rows[r.RowIndex].Cells[1].Text.ToString();

            Response.Redirect("EmployeeEditRequest.aspx?ID=" + ID);
        }


    }
}