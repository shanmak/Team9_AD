using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class ManagerVoucher : System.Web.UI.Page
    {
      
        static dynamic list;
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "Store-Manager")
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            Logic_University_Entity model = new Logic_University_Entity();

            List<Voucher_details> voucherslist = model.Voucher_details.Where(x => x.Status == "Pending" && x.Amount >= 250).ToList();

            var newlist = voucherslist.Select(x => new { Description = x.Item_Number, Quantity = x.Quantity, Amount = x.Amount, Status = x.Status }).ToList();


            GridView1.DataSource = newlist;
            GridView1.DataBind();


        }

        protected void Approve_Click(object sender, EventArgs e)
        {

            Employee user = (Employee)Session["user"];
            Logic_University_Entity model = new Logic_University_Entity();

            List<Voucher_details> voucherslist = model.Voucher_details.Where(x => x.Status == "Pending").ToList();

            var newlist = voucherslist.Select(x => new { Id = x.ID, Status = x.Status }).ToList();


            foreach (var v in newlist)
            {

                var first = model.Voucher_details.Where(x => x.ID == v.Id).FirstOrDefault();
                first.Approve_ID = "STR001"; // user.Employee_ID;

                first.Status = "APPROVED";

                model.SaveChanges();


            }

        }
    }
}