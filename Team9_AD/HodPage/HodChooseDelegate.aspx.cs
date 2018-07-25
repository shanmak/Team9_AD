using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;

namespace Team9_AD.HodPage
{
    public partial class HodChooseDelegate : System.Web.UI.Page
    {
        Logic_University_Model model = new Logic_University_Model();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["deptid"] = "CMC";
                DropDownList1.DataSource = GetEmployees();
                DropDownList1.DataTextField = "Employee_Name";
                DropDownList1.DataValueField = "Employee_ID";
                DropDownList1.DataBind();
            }
        }

        public List<Employee> GetEmployees()
        {
            string ss = Session["deptid"].ToString();
            return model.Employees.Where(c => c.Department_ID == ss && c.Employee_Role != "HOD").ToList<Employee>();
            //  return model.Employees.ToList<Employee>();
        }

        protected void Button1_Click(object sender, EventArgs e)
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
            string deptid = Session["deptid"].ToString();
            DateTime startdate = Convert.ToDateTime(textbox1.Text);
            DateTime enddate = Convert.ToDateTime(textbox2.Text);
            string empid = (DropDownList1.SelectedValue.ToString());
            string status = "Active";
            InsertValues(deptid, empid, startdate, enddate, status);
            // string empid = getempid(empid);
            //  DateTime date = textbox1.Text;
            //  string fromdate, todate;
            Label1.Text = textbox1.Text + " is selected as start date";
            Label2.Text = textbox2.Text + " is selected as end date";

        }

        public void InsertValues(string deptid, string empid, DateTime startdate, DateTime enddate, string status) //, 
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
        }

    }
}