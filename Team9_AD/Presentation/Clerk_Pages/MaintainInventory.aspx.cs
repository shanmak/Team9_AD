using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
using Team9_AD.Clerk_Goods_Maintenance;
using System.Data;
using System.Configuration;

namespace Team9_AD
{
    public partial class MaintainInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Prasanth*/
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                BindGridData();
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = Businesslogic.list();
            GridView1.DataBind();
           
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            BindGridData();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string itemnumber = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            Businesslogic.Deleteitem(itemnumber);
            GridView1.DataSource = Businesslogic.list();
            GridView1.DataBind();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            
            GridView1.DataSource = Businesslogic.list();
            GridView1.DataBind();
        }


        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string itemnumber = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            string category = (row.FindControl("Label5") as Label).Text;
            string description = (row.FindControl("Label3") as Label).Text;
            decimal price = Convert.ToDecimal((row.FindControl("Label4") as Label).Text);
            int quantity = Convert.ToInt32((row.FindControl("TextBox1") as TextBox).Text);
            string unit_measure = (row.FindControl("Label5") as Label).Text;
            string suppiler_ID_1 = (row.FindControl("CategoryDropdown1") as DropDownList).SelectedValue;
            string suppiler_ID_2 = (row.FindControl("CategoryDropdown2") as DropDownList).SelectedValue;
            string suppiler_ID_3 = (row.FindControl("CategoryDropdown3") as DropDownList).SelectedValue;
            Businesslogic.Edititem(itemnumber, quantity, suppiler_ID_1, suppiler_ID_2, suppiler_ID_3);
          
            GridView1.EditIndex = -1;
            BindGridData();
            Response.Redirect("MaintainInventory.aspx");

        }

        protected void BindGridData()
        {
            GridView1.DataSource = Businesslogic.list();
            GridView1.DataBind();
        }



    }
}
