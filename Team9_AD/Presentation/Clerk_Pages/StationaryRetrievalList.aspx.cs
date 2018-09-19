using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Team9_AD.AddClass;

namespace Team9_AD
{
    public partial class Stationary_Retrieval__List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Mani & Prasanth*/
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                Logic_University_Entity model = new Logic_University_Entity();

                    List<ClerkViewRequest> result = ClerkBusinessLogic.collectedlist();

                    if (!result.Count().Equals(0))
                    {

                        GridView1.DataSource = result;
                        GridView1.DataBind();
                    }
                    else
                    {
                       
                        Img_NoRecordFound.Visible = true;
                    }
                }             
                else
                {
                    lbl_no.Visible = true;
                }          
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            List<ClerkViewRequest> result = ClerkBusinessLogic.collectedlist();
            if (!result.Count().Equals(0))
            {
                GridView1.DataSource = result;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("no record ");
            }
        }
    }
}