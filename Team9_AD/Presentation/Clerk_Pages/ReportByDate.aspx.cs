using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class ReportByDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Surendran*/
            Employee emp = (Employee)Session["user"];
            if (emp.Employee_Role != "Store-Clerk")
            {
                Response.Redirect("LoginPage.aspx");
            }
            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart1.ChartAreas["ChartArea1"].AxisY.IsLabelAutoFit = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.Interval = -2;
            Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
        
        }

        public void BindSalesChart(string fromDate, string toDate)
        {
            using (Logic_University_Entity context = new Logic_University_Entity())
            {
                DateTime fromm = DateTime.Parse(fromDate);
                DateTime to = DateTime.Parse(toDate);


                var sales =
    context.GenerateReport1.AsEnumerable()
    .Select(x =>
       new {
           RetrivedQuantity = x.Retrived_Qunty,
           Description = x.Description,
           TransDate = x.Trans_Date,
       }
     ).Where(a => (a.TransDate >= fromm) && (a.TransDate <= to))
     .GroupBy(s => new { s.Description })
     .Select(g =>
           new {
               RetrivedQuantity = g.Sum(x => x.RetrivedQuantity),
               Description = g.Key.Description,

           }
     );

                foreach (var sale in sales)
                {
                    Chart1.Series["Series1"].Points.AddXY(sale.Description, sale.RetrivedQuantity);
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string from = fromdatepicker.Text;
            string to = todatepicker.Text;
            BindSalesChart(from, to);
        }
    }
}