 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
using System.Net;
using Newtonsoft.Json;
//using System.Security.Cryptography;
//using System.Text;

namespace Team9_AD
{
    public partial class Login_page : System.Web.UI.Page
    {
        /* Code by Santhosh*/
        static Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
            }
            else
            {
                Label1.Visible = true;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string userid, pass;
            userid = username.Value;
            pass = password.Value;
            string host = Application["host"].ToString();

            try
            {
                Employee emp = model.Employees.Where(x => x.Employee_ID == userid && x.Password == pass).FirstOrDefault();
                    Session["user"] = emp;
                    if (emp != null)
                    {
                        if (emp.Employee_Role == "Store-Clerk")
                        {
                            Response.Redirect("ClerkHome.aspx", false);

                        }
                        else if (emp.Employee_Role == "HOD")
                        {
                            Response.Redirect("HODHomePage.aspx", false);

                        }
                        else if (emp.Employee_Role.Equals("Employee")) 
                        {
                     
                            Response.Redirect("EmployeeHome.aspx",false);
                           
                        }
                        else if (emp.Employee_Role.Equals("Employee-Rep"))
                        {
                            Response.Redirect("RepHome.aspx",false);
                        }
                    else if (emp.Employee_Role.Equals("Delegate"))
                    {

                        Response.Redirect("Del_Home_Page.aspx", false);
                    }
                    else if (emp.Employee_Role.Equals("Store-Manager"))
                    {

                        Response.Redirect("ManagerHomePage.aspx", false);
                    }
                    else if (emp.Employee_Role.Equals("Store-Supervisor"))
                    {

                        Response.Redirect("SupervisorHome.aspx", false);
                    }

                }
                //}
            }
            catch (Exception)
            {
                Label1.Text = "please check your UserID and PassWord";
                Label1.Visible = true;
                
                Response.Redirect("Loginpage.aspx",false);
            }

          
        }
    }
}