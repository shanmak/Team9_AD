using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.AddClass;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class HODViewDetails : System.Web.UI.Page
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        protected void Page_Load(object sender, EventArgs e)
        {                     

            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "HOD")
                {
                    Response.Redirect("LoginPage.aspx");
                }

                int Id = Convert.ToInt32(Request.QueryString["ID"]);
                             

                var list = model.Emp_Request_items.Where(x => x.Request_ID.Equals(Id)).Select(x => new { x.Inventory.Category, x.Inventory.Description, x.Quantity });

                if (list.Count() > 0)
                {
                    GridView1.DataSource = list.ToList();
                    GridView1.DataBind();
                }
            }
        }                   
                
        protected void Button2_Click(object sender, EventArgs e)
        {            
            int gridsize = GridView1.Rows.Count;
            int count = 0;

            string itemnumber = "";

            Employee user = (Employee)Session["user"];
            string deptid =  user.Department_ID.ToString();
            string empid =   user.Employee_ID;
            DateTime date = DateTime.Today;

            List<HodReqItem> hodReqItems = new List<HodReqItem>();

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvr.FindControl("SelectCheckBox");

                if (chk.Checked == true)
                {
                    GridViewRow r = (GridViewRow)chk.NamingContainer;

                    string Descri = gvr.Cells[1].Text;

                    var item = (from z in model.Inventories where z.Description == Descri select z.Item_Number).SingleOrDefault();
                    itemnumber = item.ToString();
                    string status1 = "Approved";
                    string comment1 = TextBox1.Text;

                      updateresponse(status1, comment1, itemnumber);

                    string Category = gvr.Cells[0].Text;
                    string Description = gvr.Cells[1].Text;
                    string Quantity = gvr.Cells[2].Text;

                    hodReqItems.Add(new HodReqItem(itemnumber, Quantity, Description));

                }
                else
                {
                    count = count + 1;
                    GridViewRow r = (GridViewRow)chk.NamingContainer;
                    string Descri = gvr.Cells[1].Text;
                    string itemID = model.Inventories.Where(x => x.Description == Descri).Select(y => y.Item_Number).FirstOrDefault();
                    string status1 = "Rejected";
                    string comment2 = TextBox1.Text;
                       updateresponse(status1, comment2, itemID);

                }
            }

            int Id = Convert.ToInt32(Request["ID"]);
          
            string comment = TextBox1.Text;

             updateEmplyeeRequest(Id);

            SendMail(empid);
            insertrequesttostore(deptid, empid, date, hodReqItems);

            Response.Write(@"<script language='javascript'>alert('Approved  successfully');window.location.href='HodViewPage.aspx'</script>");

        }

        public static void updateEmplyeeRequest(int Id)
        {
                    
            var empreq = model.Employee_Request.Where(x => x.Request_ID ==Id).FirstOrDefault();
            empreq.Status = "Completed";
            model.SaveChanges();
        }

        public void updateresponse(string status, string comment, string itemID)
        {
            string resID = Request["ID"];
            int Id =  Convert.ToInt32(resID);

            string itemnum = itemID;
            {
                List<Emp_Request_items> m = model.Emp_Request_items.Where(x => x.Request_ID.Equals(Id) && x.Item_Number.Equals(itemnum)).ToList<Emp_Request_items>();
                foreach (var i in m)
                {
                    i.Status = status;
                    if (status == "Rejected")
                    {
                        i.Comments = comment;
                    }
                }
            }

            model.SaveChanges();
        }


        public void insertrequesttostore(string deptid, string empid, DateTime date, List<HodReqItem> reqItems)  //,date
        {


            Store_Request sr = new Store_Request()
            {
                Department_ID = deptid,
                Employee_ID = empid,
                Request_Date = date,
                Status = "Pending"
            };

            model.Store_Request.Add(sr);

            model.SaveChanges();

            Store_Request storeid = model.Store_Request.OrderByDescending(x => x.StoreRequest_ID).Take(1).FirstOrDefault();


            foreach (var v in reqItems)
            {
              //  var xy = (from z in model.Inventories where z.Description == v.Description select z.Item_Number).SingleOrDefault();
                Store_Request_items store_Request = new Store_Request_items();

                store_Request.StoreRequest_ID = storeid.StoreRequest_ID;
                store_Request.Item_Number = v.Itemnumber;
                store_Request.Description = v.description;
                store_Request.Req_Quantity = Convert.ToInt32(v.Quantity);
                store_Request.Pend_Quantity = Convert.ToInt32(v.Quantity);
                store_Request.Status = "Pending";

                model.Store_Request_items.Add(store_Request);

                model.SaveChanges();
            }



            // Response.Write("request approve and send to store request");
        }

        protected void SendMail(string emp)
        {
            Employee user = (Employee)Session["user"];
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = false;
            string empid = user.Employee_ID;
            string mv = model.Employees.Where(x => x.Employee_ID == empid).FirstOrDefault<Employee>().Email;



            Employee name = model.Employees.Where(x => x.Employee_ID == emp).FirstOrDefault();
            mail.To.Add(mv);
            mail.Subject = "Request Approval Status";
            mail.Body = "Hi Dude," + Environment.NewLine + "Your Stationery request has been processed. Please check the Inventory System Application." + Environment.NewLine + "Best Regards," + Environment.NewLine + "Head of Department";
            SmtpClient smtp = new SmtpClient();
            mail.From = new MailAddress("lguniversityteam@gmail.com", "Surendran");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("lguniversityteam@gmail.com", "littleflower");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HodViewPage.aspx");
        }
    }
}