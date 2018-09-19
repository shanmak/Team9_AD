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
    public partial class ClerkHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Mani & Prasanth*/

            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if(emp.Employee_Role!= "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                Logic_University_Entity model = new Logic_University_Entity();



                var store_Requests = model.Store_Request.Where(x => x.Status == "Done").ToList();

                var list = store_Requests.Select(x => new { x.StoreRequest_ID, x.Department.Department_Name, x.Employee.Employee_Name, x.Request_Date, x.Status }).ToList();

                List<ClerkViewRequest> cLerk_Request = list.Select(x => new ClerkViewRequest(x.StoreRequest_ID, x.Department_Name, x.Employee_Name, x.Request_Date, x.Status)).ToList<ClerkViewRequest>();

                List<ClerkViewRequest> listdes = cLerk_Request.OrderByDescending(x => x.StoreRequest_ID).ToList();


                GridView2.DataSource = listdes.ToList();

                GridView2.DataBind();
            }
        }






        protected void GridView(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            GridViewRow r = (GridViewRow)b.NamingContainer;
            string id = GridView2.Rows[r.RowIndex].Cells[1].Text.ToString();
            Response.Redirect("ClerkHistoryDetails.aspx?ID=" + id);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Logic_University_Entity model = new Logic_University_Entity();

            DateTime today = DateTime.Now;

            DateTime per = DateTime.Today.AddDays(-7);

            var store_Requests = model.Store_Request.Where(x => x.Status == "Done" && x.Request_Date <= today && x.Request_Date > per).ToList();

            var list = store_Requests.Select(x => new { x.StoreRequest_ID, x.Department.Department_Name, x.Employee.Employee_Name, x.Request_Date, x.Status }).ToList();

            List<ClerkViewRequest> cLerk_Request = list.Select(x => new ClerkViewRequest(x.StoreRequest_ID, x.Department_Name, x.Employee_Name, x.Request_Date, x.Status)).ToList<ClerkViewRequest>();

            List<ClerkViewRequest> listdes = cLerk_Request.OrderByDescending(x => x.StoreRequest_ID).ToList();


            GridView2.DataSource = listdes.ToList();

            GridView2.DataBind();
        }
    }
}