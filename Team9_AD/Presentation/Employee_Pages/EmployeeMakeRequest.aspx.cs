using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.AddClass;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class EmployeeMakeRequest : System.Web.UI.Page
    {
        static Logic_University_Entity sm = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Code by Padma*/
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                if (user.Employee_Role != "Employee")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                SetInitialRow();

                DropDownList Category = (DropDownList)Requestdetails.Rows[0].Cells[0].FindControl("DropDownList1");
                Category.DataBind();
                ListItem l = new ListItem("Select the category", "-1");
                Category.Items.Insert(0, l);



                DropDownList Description = (DropDownList)Requestdetails.Rows[0].Cells[1].FindControl("DropDownList2");
                Description.DataBind();
                ListItem li = new ListItem("Select the description", "-1");
                Description.Items.Insert(0, li);

            }
        }
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));
            dr = dt.NewRow();
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dr["Column4"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;

            Requestdetails.DataSource = dt;
            Requestdetails.DataBind();
        }
        protected void Unit_Measure(object sender, EventArgs e)
        {
            TextBox tb;
            GridViewRow gv = (GridViewRow)(sender as Control).Parent.Parent;
            int z = gv.RowIndex;
            DropDownList dd2 = (DropDownList)Requestdetails.Rows[z].FindControl("DropDownList2");
            tb = (TextBox)Requestdetails.Rows[z].FindControl("TextBox2");
            string selectedvalue = dd2.Text.ToString();
            tb.Text = (from x in sm.Inventories where x.Description == dd2.SelectedValue.ToString() select x.Unit_Measure).FirstOrDefault();
            tb.DataBind();
        }



        protected void btn_Addrequest_Click(object sender, EventArgs e)
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList Category =
                          (DropDownList)Requestdetails.Rows[rowIndex].Cells[0].FindControl("DropDownList1");
                        DropDownList Description =
                           (DropDownList)Requestdetails.Rows[rowIndex].Cells[1].FindControl("DropDownList2");
                        TextBox Quantity =
                           (TextBox)Requestdetails.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                        TextBox Unit_Measure =
                          (TextBox)Requestdetails.Rows[rowIndex].Cells[3].FindControl("TextBox2");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Column1"] = Category.SelectedValue;
                        drCurrentRow["Column2"] = Description.SelectedValue;
                        drCurrentRow["Column3"] = Quantity.Text;
                        drCurrentRow["Column4"] = Unit_Measure.Text;



                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;
                    Requestdetails.DataSource = dtCurrentTable;
                    Requestdetails.DataBind();

                }
                else
                {
                   
                }

                SetPreviousData();
              
            }



        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)Requestdetails.Rows[rowIndex].Cells[0].FindControl("DropDownList1");
                        DropDownList box2 = (DropDownList)Requestdetails.Rows[rowIndex].Cells[1].FindControl("DropDownList2");
                        TextBox box3 = (TextBox)Requestdetails.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                        TextBox box4 = (TextBox)Requestdetails.Rows[rowIndex].Cells[3].FindControl("TextBox2");


                        box1.SelectedValue = dt.Rows[i]["Column1"].ToString();
                        box2.SelectedValue = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void btn_Submitrequest_Click(object sender, EventArgs e)
        {
            List<EmployeeMakeReq> employeeMakes = new List<EmployeeMakeReq>();

            int count = Requestdetails.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                GridViewRow r = Requestdetails.Rows[i];
                DropDownList description = (DropDownList)r.Cells[1].FindControl("DropDownList2");
                TextBox b = (TextBox)r.Cells[2].FindControl("TextBox1");
                string desc = description.Text.ToString();
                int quantity = Convert.ToInt32(b.Text);
                employeeMakes.Add(new EmployeeMakeReq(desc, quantity));
            }

            try
            {
                Employee user = (Employee)Session["user"];
                using (Logic_University_Entity entities = new Logic_University_Entity())
                {
                    Employee_Request request = new Employee_Request();


                    request.Department_ID = user.Department_ID;
                    request.Employee_ID = user.Employee_ID;
                    request.Date_of_Request = System.DateTime.Now;
                    request.Status = "Pending";
                    entities.Employee_Request.Add(request);
                    entities.SaveChanges();

                    Employee_Request Requestid = entities.Employee_Request.OrderByDescending(x => x.Request_ID).Take(1).FirstOrDefault();

                    foreach (var v in employeeMakes)
                    {
                        var xy = (from z in entities.Inventories where z.Description == v.Description select z.Item_Number).SingleOrDefault();
                        string itemnumber = xy.ToString();
                        Emp_Request_items item = new Emp_Request_items();
                        item.Request_ID = Requestid.Request_ID;
                        item.Item_Number = itemnumber;
                        item.Quantity = v.Quantity;
                        item.Status = "Pending";
                        entities.Emp_Request_items.Add(item);
                        entities.SaveChanges();
                    }


                    btn_Submitrequest.Enabled = false;
                }

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = false;
                string empid = user.Employee_ID;
                string mv = sm.Employees.Where(x => x.Employee_ID == empid).FirstOrDefault<Employee>().Email;
                mail.To.Add(mv);
                mail.Subject = "Application for Stationary requests";
                string name = user.Employee_Name;
                mail.Body = "Hi HOD," + Environment.NewLine + "I've applied for stationary." + Environment.NewLine + "Best Regards," + Environment.NewLine + name;
                SmtpClient smtp = new SmtpClient();
                mail.From = new MailAddress("lguniversityteam@gmail.com", "Surendran");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("lguniversityteam@gmail.com", "littleflower");
                smtp.EnableSsl = true;
                smtp.Send(mail);


                Response.Write(@"<script language='javascript'>alert('Request Sent successfully');window.location.href='EmployeeHome.aspx'</script>");


            }
            catch (Exception)
            {

            }


        }

    
        public void btn_delete(object sender, EventArgs e)
        {

       

            Button lb = (Button)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowid = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowid]);
                    }
                }
                ViewState["CurrentTable"] = dt;
                Requestdetails.DataSource = dt;
                Requestdetails.DataBind();
            }
            SetPreviousData();
        }
    }   
}