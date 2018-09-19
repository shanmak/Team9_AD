using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class HODChooseRep : System.Web.UI.Page
    {
        Logic_University_Entity model = new Logic_University_Entity();


        protected void Page_Load(object sender, EventArgs e)
        {
            /* Code by Kritti*/
            string host = Application["host"].ToString();

            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "HOD")
                {
                    Response.Redirect("LoginPage.aspx");
                }

                using (WebClient webclient = new WebClient())
                {

                    string id = user.Department_ID.ToString();
                    string json = webclient.DownloadString("http://172.17.105.243/AD_Service/WCF/Service1.svc/departmentemployeelist/" + id);
                    List<string> employees = JsonConvert.DeserializeObject<List<string>>(json);               
                    DropDownList1.DataSource = employees.ToList();
                    DropDownList1.DataBind();
                    Label2.Text = Currentrep(user.Department_ID);
                    
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string name = DropDownList1.SelectedItem.Text;
            GridView1.DataSource = Fetch(name);
            GridView1.DataBind();
        }
        public List<Object> Fetch(string name)
        {
            return model.Employees.Where(c => c.Employee_Name== name).Select(c => new { EmployeeID = c.Employee_ID, Name=c.Employee_Name,Role=c.Employee_Role }).ToList<Object>();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
           
            Employee user = (Employee)Session["user"];
            string deptid =  user.Department_ID;
            string empname = (DropDownList1.SelectedValue.ToString());
            Employee rep = model.Employees.Where(x => x.Employee_Name == empname).FirstOrDefault();
            if(rep.Employee_Role != "Employee-Rep" && rep.Employee_Role!= "Delegate")
            {
                UpdateValues1(empname, deptid);
                UpdateValues2(deptid);
                UpdateValues3(empname, deptid);
                string name = DropDownList1.SelectedItem.Text;
                Label2.Text = Currentrep(deptid);
                sendMail();
                lbl_error.Visible = false;
            }
            else
            {
                lbl_error.Text = "*Error:The employee chosen is delegate";
                lbl_error.Visible = true;
            }

            
        }

        public string getemail(string empid)
        {
            string v = model.Employees.Where(x => x.Employee_Name.Equals(empid)).FirstOrDefault<Employee>().Email;
            return v;
        }

        public void sendMail()
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = false;
            string empid = DropDownList1.SelectedValue.ToString();
            mail.To.Add(getemail(empid));
            mail.Subject = "Chosen as Representative";
            string name = DropDownList1.SelectedItem.Text;
            mail.Body = "Hi " + name + "," + Environment.NewLine + "You have been chosen as rep." + Environment.NewLine + "Best Regards," + Environment.NewLine + "Department Head ";
            SmtpClient smtp = new SmtpClient();
            mail.From = new MailAddress("sgsuren1118@gmail.com", "Surendran");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("lguniversityteam@gmail.com", "littleflower");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        public void UpdateValues1(string repname,string departId)
        {           
            Department department = model.Departments.Where(c => c.Department_ID == departId).First<Department>();
            Employee repid = model.Employees.Where(x => x.Employee_Name == repname).FirstOrDefault();
            department.Representative_ID = repid.Employee_ID;            
            model.SaveChanges();
        }

        public void UpdateValues2(string deptid)
        {
            Employee emp = model.Employees.Where(c => c.Department_ID == deptid && c.Employee_Role=="Employee-Rep").FirstOrDefault();
            emp.Employee_Role = "Employee";
            model.SaveChanges();
        }
        public void UpdateValues3(string repname, string departID)
        {
            Employee repid = model.Employees.Where(x => x.Employee_Name == repname).FirstOrDefault();
            Employee emp = model.Employees.Where(c => c.Department_ID == departID && c.Employee_ID == repid.Employee_ID).FirstOrDefault();
            emp.Employee_Role = "Employee-Rep";
            model.SaveChanges();
        }
        public String Currentrep(string deptid)
        {
            try
            {
                var q = model.Employees.Join(model.Departments, (em => em.Employee_ID), d => d.Representative_ID, (em, d) => new { em, d })
                       .Where(x => x.em.Department_ID == deptid)
                       .Select(y => y.em.Employee_Name).FirstOrDefault();
                return q;
            }
            catch (Exception e)
            {
                return "None";
            }
        }
    }
}