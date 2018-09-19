using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class RepAcknowledge : System.Web.UI.Page
    {
        Logic_University_Entity m = new Logic_University_Entity();
        static List<Disbursement_List> singlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Surendhar*/
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Employee-Rep")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                string departid = user.Department_ID;
                singlist = m.Disbursement_List.Where(x => x.Department_ID == departid && x.Status == "Pending").ToList();

                List<Disbursement_List_dtl> list = new List<Disbursement_List_dtl>();

                foreach (var v in singlist)
                {

                    list.AddRange(m.Disbursement_List_dtl.Where(x => x.Disburse_ID == v.Disburse_ID).ToList());
                }

                var list2 = list.GroupBy(x => new { x.Item_number, x.Discription, x.Inventory }).Select(x => new { Category = x.Key.Inventory.Category, Discription = x.Key.Discription, RequestQuantity = x.Sum(y => y.req_qunty), DeliveredQuantity = x.Sum(y => y.Quantity) }).ToList();
                if (list2.Count != 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = list2.ToList();
                    GridView1.DataBind();                   

                }
                else
                {
                    
                    GridView1.Visible = false;
                    img_NoRecord.Visible = true;
                    Button1.Visible = false;
                    CheckBox1.Visible = false;
                    Label1.Visible = false;      
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {

                Employee user = (Employee)Session["user"];
                string departid = user.Department_ID;
                singlist = m.Disbursement_List.Where(x => x.Department_ID == departid && x.Status == "Pending").ToList();

                if (singlist.Count()!=0)
                {
                        foreach (Disbursement_List item in singlist)
                        {
                        
                            item.Status = "Acknowledged";
                            
                            m.SaveChanges();
                        }
                }
            }
        }
    }
}