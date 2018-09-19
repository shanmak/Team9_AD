using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Timers;
using System.Web;

using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Team9_AD.Clerk_Goods_Maintenance;
using Team9_AD.Entity;


namespace Team9_AD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            Application["host"] = "172.17.105.243";  // nus subash
            //Application["host"] = "192.168.1.60";  // Maheen home
            //Application["host"] = "192.168.1.126";

            System.Timers.Timer LowInventorytimer = new System.Timers.Timer();
            //Interval to 24hrs (8.64e+7 milliseconds).
            LowInventorytimer.Interval = 8.64e+7 ;
            LowInventorytimer.AutoReset = true;
            LowInventorytimer.Enabled = true;
            LowInventorytimer.Elapsed += new ElapsedEventHandler(SendLowStock);

            System.Timers.Timer VoucherGenerationTimer = new System.Timers.Timer();
            VoucherGenerationTimer.Interval = 8.64e+7;
            VoucherGenerationTimer.AutoReset = true;
            VoucherGenerationTimer.Enabled = true;
            VoucherGenerationTimer.Elapsed += new ElapsedEventHandler(CheckMonthEnd);

        }

        private void CheckMonthEnd(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Day == DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                Businesslogic.GenerateVoucher();

            }
        }


        private void SendLowStock(object sender, ElapsedEventArgs e)
        {
            List<Inventory> stockList = Businesslogic.informLowStockItems();
            if (stockList.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" <table border='5', bordercolorlight='#b9dcff', bordercolordark='#006fdd', width='400',align='center',bordercolor='black'><tr><th>Item Name</th><th>Available Quantity</th><th>Re-Order Quantity</th></tr>");

                foreach (Inventory item in stockList)
                {
                    sb.Append("<tr><td>" + item.Description + " </td>" + "<td>" + item.Quantity + "</td> " + "<td>" + item.Reorder_level + "</td></tr>");
                }
                sb.Append("</table>");
                MailMessage mm = new MailMessage("sgsuren1118@gmail.com", "sgsuren1118@gmail.com");
                mm.Subject = "Low Inventory Alert";
                mm.Body = "The Following Items are : <hr />" + sb.ToString(); ;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "sgsuren1118@gmail.com";
                NetworkCred.Password = "littleflower";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }   
        }
    }
}