using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using Team9_AD.Entity;

namespace Team9_AD
{
    public class RepBusinessLogic
    {
        // To Find the previous collection point
        public string findPreviousCollectionPoint()
        {
            using (Logic_University_Entity t = new Logic_University_Entity())
            {
                var d = from x in t.Departments where x.Representative_ID == "REG002" select x;
                Department d1 = d.FirstOrDefault();
                return d1.Collection_Point;
            }

        }
        // To notify the stor clerk by email regarding change of collection point by department representative
        public void sendNotificationByEmail(Employee emp, string value)
        {
            using (Logic_University_Entity t = new Logic_University_Entity())
            {

                // need to write two sql queries 
                //1) to find the department of the employee logged in using session
                //2) to find the email address of the clerk and send email
                //3) to find the employee email address using session

                Department d = t.Departments.Where(x => x.Department_ID == emp.Department_ID).First<Department>();
                d.Collection_Point = value;
                t.SaveChanges();

                MailMessage mail = new MailMessage();

                mail.IsBodyHtml = true;
               
                mail.To.Add("sanu1306@gmail.com");

                mail.Subject = "Change of Collection Point";
                string departmentName = d.Department_Name;
                string departHead = d.Department_Head;
                string departID = d.Department_ID;
                Employee e = t.Employees.Where(x => x.Employee_ID == emp.Employee_ID).First<Employee>();
                string depRepName = e.Employee_Name;


                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='5', bordercolorlight='#b9dcff', bordercolordark='#006fdd', width='400',align='center',bordercolor='black'><tr><th>Title</th><th>Details</th></tr><tr><td><b>Department</b></td>" + "<td>" + departmentName + "</td></tr>" +
                    "<tr><td><b>Department Head</b></td>" + "<td>" + departHead + "</td></tr>" +
                    "<tr><td><b>Department ID</b></td>" + "<td>" + departID + "</td></tr>" +
                    "<tr><td><b>Department Rep Name</b></td>" + "<td>" + depRepName + "</td></tr>" +
                    "<tr><td><b>Updated Collection Point</b></td>" + "<td>" + value + "</td></tr></table>");



                mail.Body = sb.ToString();

                SmtpClient smtp = new SmtpClient();

                mail.From = new MailAddress("sgsuren1118@gmail.com", "Surendran");

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new System.Net.NetworkCredential("lguniversityteam@gmail.com", "littleflower");

                smtp.EnableSsl = true;

                smtp.Send(mail);

            }
        }
    }
}