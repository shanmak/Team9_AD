using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Timers;
using System.Web;

using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Team9_AD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
           // Application["host"] = "192.168.56.1";  //without wifi
          //  Application["host"] = "192.168.0.18";   
            Application["host"] = "172.17.62.113";  // nus

          //  RouteConfig.RegisterRoutes(RouteTable.Routes);
          //  BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Timers.Timer myTimer = new System.Timers.Timer();
            // Set the Interval to 5 seconds (5000 milliseconds).
            myTimer.Interval = 30000;
            myTimer.AutoReset = true;
            myTimer.Elapsed += new ElapsedEventHandler(checkdate);
            myTimer.Enabled = true;
        }
        public void checkdate(object a, EventArgs e)
        {
            if (System.DateTime.Now.DayOfWeek.Equals(DayOfWeek.Friday))
            {
               // sendMail();
            }

        }
        public void sendMail()
        {
            // use your mailer code
            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = true;

           // mail.To.Add("e0283989@u.nus.edu");

           // mail.To.Add("pktmani2009.ms@gmail.com");

            mail.Subject = "BIRTHDAY";

            System.Text.Encoding Enc = System.Text.Encoding.ASCII;

            mail.Body = "Keep Smiling, Be happy, and make all your dream comes true in coming years. Wish you a very Happy Birthday!";

            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress("sgsuren1118@gmail.com", "HAPPY BIRTHDAY");

            smtp.Host = "smtp.gmail.com";

            smtp.Port = 587;

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new System.Net.NetworkCredential("sgsuren1118@gmail.com", "littleflower");

            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}