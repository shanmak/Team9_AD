using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class LocationDamage : System.Web.UI.Page
    {
        /*Code by Mani & Prasanth*/
        Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string departname = TextBox1.Text;
            string itemnumber = TextBox2.Text;
            int qunty =Convert.ToInt32(TextBox3.Text);

            using (model)
            {
                string departid = model.Departments.Where(x => x.Department_Name == departname).Select(y => y.Department_Name).FirstOrDefault();

                var depart = model.Disbursement_List.Where(x => x.Department_ID == departid && x.Status == "Pending").FirstOrDefault();

                var list = model.Disbursement_List_dtl.Where(x => x.Disburse_ID == depart.Disburse_ID).ToList();


                Disbursement_List_dtl list_Dtl = list.Where(x => x.Item_number == itemnumber).FirstOrDefault();

                list_Dtl.Quantity -= qunty;

                model.SaveChanges();

                rollbackrequest(itemnumber, departid,qunty);

            }

        }

        public string rollbackrequest(string itemnumber,string departid,int qunty)
        {

            using (model)
            {
                Employee user =(Employee) Session["user"];
                Dmg_Goods_Dtl dmg_Goods = new Dmg_Goods_Dtl();

                dmg_Goods.Item_number = itemnumber;
                dmg_Goods.Damage_Qnty = qunty;
                dmg_Goods.Location = departid;
                dmg_Goods.Dmg_Date = DateTime.Now;
                dmg_Goods.Employee_ID = user.Employee_ID;
                dmg_Goods.Details = "Pending";

                model.Dmg_Goods_Dtl.Add(dmg_Goods);
                model.SaveChanges();
            }


            return null;
        }


    }
}