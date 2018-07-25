using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;

namespace Team9_AD.HodPage
{
    public partial class HodChooseRep : System.Web.UI.Page
    {
         Logic_University_Model model = new Logic_University_Model();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            string host = Application["host"].ToString();

            if (!IsPostBack)
            {
                Employee user =(Employee) Session["user"];             

                using (WebClient webclient = new WebClient())
                {
                   
                    string id = user.Department_ID.ToString();
                    string json = webclient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/departmentemployeelist/" + id);
                    List<string> employees = JsonConvert.DeserializeObject<List<string>>(json);


                    DropDownList1.DataSource = employees.ToList();
                    DropDownList1.DataBind();
                        
                        }

               
            }
        }

     

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Write(DropDownList1.SelectedItem.Text + " was clicked");
            string name = DropDownList1.SelectedItem.Text;
            GridView1.DataSource = Fetch(name);
            GridView1.DataBind();
        }

        public List<Employee> Fetch(string name)
        {
            return model.Employees.Where(c => c.Employee_Name.Contains(name)).ToList<Employee>();
            //return model.Employees.ToList<Employee>();

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
           Employee user =(Employee) Session["user"];

            string deptid = user.Department_ID.ToString();

            string empid = (DropDownList1.SelectedItem.Text);

            UpdateValues(empid);
            string name = DropDownList1.SelectedItem.Text;
            Label1.Text = name + " has been selected as rep";

        }

        public void UpdateValues(string repid)
        {
            Employee user =(Employee) Session["user"];
            string ss = user.Department_ID.ToString();
            Department department = model.Departments.Where(c => c.Department_ID == ss).First<Department>();
            department.Representative_ID = repid;
            model.SaveChanges();
        }
    }
}