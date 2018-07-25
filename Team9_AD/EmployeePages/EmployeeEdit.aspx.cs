using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.Models;

namespace Team9_AD.EmployeePages
{
    public partial class EmployeeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bind();
            }

        }

        public  void bind()
        {
            using (Logic_University_Model entities = new Logic_University_Model())
            {
                var list = entities.Employee_Request.Where(x => x.Status == "Pending").Join(entities.Emp_Request_items, a => a.Request_ID, b => b.Request_ID, (a, b) => new { a, b }).Where(y => y.b.Status == "Pending").Select(x => new { x.b.Request_ID, x.b.Inventory.Description, x.b.Quantity, x.b.Inventory.Unit_Measure }).ToList();
                GridView1.DataSource = list;
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
            string requestid = row.Cells[0].Text.ToString();
            /*GridView1.DataKeys[e.RowIndex].Values[0].ToString()*/
            int quantity = Convert.ToInt32(e.NewValues["Quantity"]);
            //string quantity = (row.FindControl("TextBox1") as TextBox).Text;
            // BizLogic.UpdateReq(requestid, quantity);

            using ( Logic_University_Model entitie = new Logic_University_Model())
            {
                Emp_Request_items emp = entitie.Emp_Request_items.
                    Where(p => p.Request_ID == Convert.ToInt32(requestid)).FirstOrDefault<Emp_Request_items>();

                emp.Quantity = quantity;
                entitie.SaveChanges();
            }


        }
        public void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string requestid = row.Cells[0].Text.ToString();
            string descr = row.Cells[1].Text.ToString();
         //   string itemno = BizLogic.findItemID(descr);
            // BizLogic.DeleteReq(requestid, itemno);

            using (Logic_University_Model entities = new Logic_University_Model())
            {
                var xy = (from z in entities.Inventories where z.Description.Equals(descr) select z.Item_Number).SingleOrDefault();

                Emp_Request_items emp = entities.Emp_Request_items.Where
                    (x => x.Request_ID.Equals(requestid) && x.Item_Number.Equals(xy)).
                    FirstOrDefault();
                Employee_Request empreq = entities.Employee_Request.Where
                   (x => x.Request_ID.Equals(requestid)).
                   FirstOrDefault();
               // entities.Employee_Request.Remove(empreq);
                entities.Emp_Request_items.Remove(emp);
                entities.SaveChanges();
            }


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}