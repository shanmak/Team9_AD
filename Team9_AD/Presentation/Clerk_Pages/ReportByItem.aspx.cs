using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class ReportByItem : System.Web.UI.Page
    {
        /*Code by Surendran*/
        Logic_University_Entity context = new Logic_University_Entity();
        public enum Month
        {
            January = 1,

            February = 2,

            March = 3,

            April = 4,

            May = 5,

            June = 6,

            July = 7,

            August = 8,

            September = 9,

            October = 10,

            November = 11,

            December = 12
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                descriptionDDL.Enabled = false;
                categoryDDL.DataBind();
                ListItem li = new ListItem("Select the Category", "-1");
                categoryDDL.Items.Insert(0, li);

                
            }
        }
        public void BindSalesChart(string desc)
        {

            var sales = context.GenerateReport1.Where(x => x.Description.Equals(desc)).ToList<GenerateReport1>();


            foreach (var sale in sales)
            {
                Chart1.Series["Series1"].Points.AddXY(Enum.Parse(typeof(Month), sale.Trans_Date.Value.Month.ToString()).ToString(), (double)sale.Retrived_Qunty);

            }

        }


        protected void categoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            descriptionDDL.Enabled = true;
            var q = context.Inventories.Where(p => p.Category == categoryDDL.SelectedValue).Select(p => p.Description).ToList();
            descriptionDDL.DataSource = q;
            descriptionDDL.DataBind();
            ListItem lis = new ListItem("Select the Description", "-1");
            descriptionDDL.Items.Insert(0, lis);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string description = descriptionDDL.SelectedValue;

            BindSalesChart(description);
        }
    }
}