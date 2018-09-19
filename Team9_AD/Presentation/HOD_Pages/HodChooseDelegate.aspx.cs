using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class HodChooseDelegate : System.Web.UI.Page
    {
        Logic_University_Entity model = new Logic_University_Entity();


        static string deptid;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Code by Kritti*/

            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "HOD")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                ValidateDelg();
                DropDownList1.DataSource = GetEmployees();
                DropDownList1.DataTextField = "Employee_Name";
                DropDownList1.DataValueField = "Employee_ID";
                DropDownList1.DataBind();            
                deptid = user.Department_ID;
                Label2.Text = CurrentDel(deptid);
                if (Label2.Text != "None")
                    Revoke_btn.Enabled = true;
                else
                    Revoke_btn.Enabled = false;
            }    
        }

        public void ValidateDelg()
        {
            try
            {
                Employee user = (Employee)Session["user"];
                string ss = user.Department_ID;
          
                Approver approver = model.Approvers.Where(c => c.Department_ID == ss && c.Status == "Active").First<Approver>();
                if (approver.End_Date < DateTime.Today)
                {
                    approver.Status = "Inactive";
                }
                model.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public String CurrentDel(string deptid)
        {
            try
            {

                var result = model.Approvers.Where(x => x.Department_ID.Equals(deptid) && x.Status == "Active").FirstOrDefault();
                string s = result.Employee.Employee_Name;

                if (result == null)
                {
                    return "None";
                }
                else
                {
                    return s;

                }
            }
            catch (Exception e)
            {
                return "None";
            }
        }

        public List<Employee> GetEmployees()
        {
            Employee user = (Employee)Session["user"];
            string ss = user.Department_ID;    
            return model.Employees.Where(c => c.Department_ID == ss && c.Employee_Role != "HOD").ToList<Employee>();
        }

        protected void ViewEmployee_Clicked(object sender, EventArgs e)
        {
            string name = DropDownList1.SelectedItem.Text;
            GridView1.DataSource = Fetch(name);
            GridView1.DataBind();
        }

        public object Fetch(string name)
        {
            return model.Employees.Where(c => c.Employee_Name == name).Select(c => new { c.Employee_ID, c.Employee_Name, c.Employee_Role }).ToList();
        }

        protected void Select_Delegate_Click(object sender, EventArgs e)
        {
            Employee user = (Employee)Session["user"];
            string deptid = user.Department_ID;
            DateTime startdate = Convert.ToDateTime(txt_StartDate.Text);
            DateTime enddate = Convert.ToDateTime(txt_EndDate.Text);
            string empid = (DropDownList1.SelectedValue.ToString());
            string status = "Active";
            Employee rep = model.Employees.Where(x => x.Department_ID == deptid && x.Employee_Role == "Employee-Rep").FirstOrDefault();
            bool insert = InsertValues(deptid, empid, startdate, enddate, status, rep);
            
            if(insert == true)
            {
                sendMail();
                Label2.Text = CurrentDel(deptid);
                Revoke_btn.Enabled = true;
                Employee x = model.Employees.Where(y => y.Employee_ID == empid).FirstOrDefault();
                x.Employee_Role = "Delegate";
                model.SaveChanges();
                lbl_error.Visible = false;
            }
            else if (insert==false)
            {
                if (CurrentDel(deptid) != "None")
                {
                    lbl_error.Text = "Error:Assigning Delegate is not successful. Revoke your current Delegate and try again!!";
                    lbl_error.Visible = true;

                    if(rep.Employee_ID == empid)
                    {
                        lbl_error.Text = "Error:Assigning Delegate is not successful. The Employee chosen is Department Representative.";
                        lbl_error.Visible = true;
                    }
                }
                else if (rep.Employee_ID == empid)
                {
                    lbl_error.Text = "Error:Assigning Delegate is not successful. The Employee chosen is Department Representative.";
                    lbl_error.Visible = true;
                }
            }
            

        }

        public string getemail(string empid)
        {
            string v = model.Employees.Where(x => x.Employee_ID==empid).FirstOrDefault<Employee>().Email;
            return v;
        }
        public void sendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = false;
                string empid = DropDownList1.SelectedValue.ToString();
                mail.To.Add(getemail(empid));
                mail.Subject = "Chosen as Delegate";
                string name = DropDownList1.SelectedItem.Text;
                DateTime startdate = Convert.ToDateTime(txt_StartDate.Text);
                DateTime enddate = Convert.ToDateTime(txt_EndDate.Text);
                mail.Body = "Hi " + name + "," + Environment.NewLine + "You have been chosen as delegate from " + startdate + " to " + enddate + "." + Environment.NewLine + "Best Regards," + Environment.NewLine + "Department Head ";
                SmtpClient smtp = new SmtpClient();
                mail.From = new MailAddress("sgsuren1118@gmail.com", "Surendran");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("lguniversityteam@gmail.com", "littleflower");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                //return "erro";
            }
        }

        public bool InsertValues(string deptid, string empid, DateTime startdate, DateTime enddate, string status, Employee rep) //, 
        {
            if(CurrentDel(deptid) == "None"  && rep.Employee_ID != empid)
            {
                Approver approver = new Approver()
                {
                    Department_ID = deptid,
                    Employee_ID = empid,
                    Start_Date = startdate,
                    End_Date = enddate,
                    Status = status

                };
                model.Approvers.Add(approver);
                model.SaveChanges();
               
                return true;
            }
            else
            {
                
                return false;
            }      
        }

        protected void Revoke_Btn_Click(object sender, EventArgs e)
        {
            process(deptid);
            Label2.Text = CurrentDel(deptid);
            lbl_error.Visible = false;
            Revoke_btn.Enabled = false;
            Employee y = model.Employees.Where(x => x.Department_ID == deptid && x.Employee_Role == "Delegate").FirstOrDefault();
            y.Employee_Role = "Employee";
            model.SaveChanges();
        }

        public void process(string dp)
        {
            Approver emp = model.Approvers.Where(x => x.Department_ID == dp && x.Status == "Active").FirstOrDefault();
            emp.Status = "Inactive";
            model.SaveChanges();
        }
    }
}