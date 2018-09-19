using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class RepEditRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bind();
            }

        }

        public void bind()
        {
            using (Logic_University_Entity entities = new Logic_University_Entity())
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Employee-Rep")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                string userid = user.Department_ID;

                int requestid = Convert.ToInt32(Request.QueryString["ID"]);

                var list = entities.Employee_Request.Where(x => x.Status == "Pending" && x.Department_ID == userid).
                    Join(entities.Emp_Request_items, a => a.Request_ID, b => b.Request_ID, (a, b)
                    => new { a, b }).Where(y => y.b.Status == "Pending").
                    Select(x => new {
                        x.b.Request_ID,
                        x.b.Inventory.Description,
                        x.b.Quantity,
                        x.b.Inventory.Unit_Measure
                    }).ToList();


                var list2 = entities.Emp_Request_items.Where(x => x.Request_ID == requestid && x.Status == "Pending").Select(y => new { DESCRIPTION = y.Inventory.Description, QUANTITY = y.Quantity, UNIT_MEASURE = y.Inventory.Unit_Measure, STATUS = y.Status }).ToList();

                GridView1.DataSource = list2;
                GridView1.DataBind();
            }

        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        public void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int quantity = Convert.ToInt32(e.NewValues["Quantity"]);
           

            using (Logic_University_Entity entitie = new Logic_University_Entity())
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                string description = row.Cells[0].Text.ToString();
                string item_number = entitie.Inventories.Where(x => x.Description == description).Select(x => x.Item_Number).FirstOrDefault();
                var emp = entitie.Emp_Request_items.Where(p => p.Request_ID == id && p.Item_Number == item_number).FirstOrDefault();
                emp.Quantity = quantity;
                entitie.SaveChanges();
                GridView1.EditIndex = -1;
                bind();
            }


        }
        public void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            
            string descr = row.Cells[0].Text.ToString();
           

            using (Logic_University_Entity entities = new Logic_University_Entity())
            {
                
                var xy1 = entities.Inventories.Where(x => x.Description == descr).FirstOrDefault();
                string id = xy1.Item_Number;
                int req_id = Convert.ToInt32(Request.QueryString["ID"]);
                var emp = entities.Emp_Request_items.Where
                    (x => x.Request_ID.Equals(req_id) && x.Item_Number.Equals(id)).
                    FirstOrDefault();
               
                entities.Emp_Request_items.Remove(emp);
                entities.SaveChanges();

                bind();
            }
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepViewRequest.aspx");
        }
    }
}
