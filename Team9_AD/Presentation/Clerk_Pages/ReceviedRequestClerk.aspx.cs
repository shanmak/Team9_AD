using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using Team9_AD.Entity;
using Team9_AD.AddClass;

using System.Configuration;

namespace Team9_AD
{
    public partial class Recevied_request_clerk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Mani & Prasanth*/
            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }

                string date = DateTime.Now.ToString("yyy-MM-dd");
                    List<string> departmentList = ClerkBusinessLogic.GetDepartment();
                   if (departmentList != null)
                   {
                    departmentList.Insert(0, "ALL");
                    DropDownList1.DataSource = departmentList;
                    DropDownList1.DataBind();
                    }

                string namae = DropDownList1.SelectedValue;

                List<ClerkViewRequest> store_Requests = ClerkBusinessLogic.GetAllPendingRequest("ALL", "");
                    
                    if (!store_Requests.Count().Equals(0))
                    {
                    Img_NoRecord.Visible = false;
                    GridView1.DataSource = store_Requests;
                        GridView1.DataBind();
                    }
                    else
                    {
                    Img_NoRecord.Visible = true;
                    }
            }
        }
        
        protected void GridView(object sender, EventArgs e)
        {
            Button b = (Button)sender;
             GridViewRow r = (GridViewRow)b.NamingContainer;
            string ID = GridView1.DataKeys[r.RowIndex].Values[0].ToString();                      
            Response.Redirect("ClerkRequestDetails.aspx?ID="+ID);
        }
  
        protected void Button1_Click(object sender, EventArgs e)
        {
            string department_name = DropDownList1.SelectedValue;
            string date = textbox1.Text;
             BindGrid(department_name, date);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindGrid("ALL", "");
        }

        public void BindGrid(string depart,string date)
        {

            List<ClerkViewRequest> store_Requests = ClerkBusinessLogic.GetAllPendingRequest(depart, date);


            if (!store_Requests.Count().Equals(0))
            {
                Img_NoRecord.Visible = false;
                GridView1.Visible = true;
                GridView1.DataSource = store_Requests;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
                Img_NoRecord.Visible = true;
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string department_name = DropDownList1.SelectedValue;
            string date = textbox1.Text;
            this.BindGrid(department_name, date);
        }

    }

}

