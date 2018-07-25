using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;
using System.Net;
using Newtonsoft.Json;

namespace Team9_AD
{
    public partial class Login_page : System.Web.UI.Page
    {
        
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
                using (var webClient = new WebClient())
                {
                    
                    String rawJSON = webClient.DownloadString("http://"+host+"/AD_Service/WCF/Service1.svc/login/" + userid + "/" + pass);
                    Employee emp = JsonConvert.DeserializeObject<Employee>(rawJSON);
                    Session["user"] = emp;
                    if (emp != null)
                    {
                        if (emp.Employee_Role == "Store-Clerk")
                        {
                            Response.Redirect("ClerkHome.aspx",false);
                           
                        }
                        else if (emp.Employee_Role == "HOD")
                        {
                            Response.Redirect("HodPage/HodHomePage.aspx",false);
                           
                        }else if(emp.Employee_Role== "Employee")
                        {
                            Response.Redirect("EmployeePages/EmployeeHome.aspx");
                           
                        }
                    }
                }
            }
            catch (Exception)
            {
                Label1.Visible = true;
                Label1.Text = "please check your UserID and PassWord";
                Response.Redirect("Loginpage.aspx",false);
            }

          
        }
    }
}