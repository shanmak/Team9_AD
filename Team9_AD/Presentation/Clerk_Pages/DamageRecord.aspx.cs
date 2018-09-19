using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
using Team9_AD.AddClass;
using Newtonsoft.Json;
using System.Net;

namespace Team9_AD
{
    public partial class DamageRecord : System.Web.UI.Page
    {

        static Logic_University_Entity models = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Subash*/
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                txt_UnitMeasure.Enabled = false;
                ddl_Category.DataBind();
                ListItem li = new ListItem("Select the Category", "-1");
                ddl_Category.Items.Insert(0, li);
            }
        }
        protected void Description_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_UnitMeasure.Enabled = true;
            txt_UnitMeasure.Text = (from x in models.Inventories where x.Description == ddl_Description.SelectedValue select x.Unit_Measure).FirstOrDefault().ToString();

        }

        protected void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Description.Enabled = true;
            ddl_Description.DataBind();
            ListItem lis = new ListItem("Select the Description", "-1");
            ddl_Description.Items.Insert(0, lis);
        }

        protected void record_Damage_Click(object sender, EventArgs e)
        {
            Employee em = (Employee)Session["user"];
            string itemnumber = (from o in models.Inventories where o.Description == ddl_Description.SelectedValue select o.Item_Number).FirstOrDefault().ToString();
            int qty = Convert.ToInt32(txt_Quantity.Text);
            string loc = txt_Loc.Text.ToString();
           ClerkMaintenanceBusinessLogic.recordDamageDetails(itemnumber, qty, loc,em);


            DamageUpdate damage = new DamageUpdate();

            damage.Location = txt_Loc.Text.ToString();
            damage.Category = ddl_Category.SelectedValue;
            damage.Description = ddl_Description.SelectedValue;
            damage.Quantity= Convert.ToInt32(txt_Quantity.Text);            
            damage.Employee_ID = em.Employee_ID;


            string joutput = JsonConvert.SerializeObject(damage);

            using (WebClient webclient = new WebClient())
            {
                webclient.Headers.Add("Content-type", "application/json");
                //  string result = webclient.UploadString("http://"+Application["host"]+"/AD_Service/WCF/Service1.svc/DamageUpdate", "POST", joutput);


            }
        }
    }
}