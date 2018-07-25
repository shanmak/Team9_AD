using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;
using Team9_AD.AddClass;
using System.Net;
using Newtonsoft.Json;

namespace Team9_AD.HodPage
{
    public partial class HodViewDetails : System.Web.UI.Page
    {
        Logic_University_Model model = new Logic_University_Model();

       

        protected void Page_Load(object sender, EventArgs e)
        {

            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
               Employee user = (Employee)Session["user"];

                

                int Id = Convert.ToInt32(Request.QueryString["ID"]);
                using (WebClient webClient = new WebClient())
                {
                    string json = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/HodDetailsPage/" + Id);
                    List<HodReqItem> list = JsonConvert.DeserializeObject<List<HodReqItem>>(json);

                    if (list.Count > 0)
                    {
                       GridView1.DataSource = list;
                        GridView1.DataBind();
                    }
                }

                // var re = model.Emp_Request_items.Where(x => x.Request_ID.Equals(Id)).Select(x => new { x.Inventory.Category, x.Inventory.Description, x.Quantity });
                //GridView1.DataSource = re.ToList();
                //GridView1.DataBind();

            }
        }

                
        

        public List<object> getdata(string Id)
        {
            var re = model.Emp_Request_items.Where(x => x.Request_ID.Equals(Id)).Select(x => new { x.Inventory.Category, x.Inventory.Description, x.Quantity });
            return re.ToList<object>();
        }

        public void Approve_Click(object sender, EventArgs e)
        {
            int Id =Convert.ToInt32(Request["ID"]);
            string status = "Approved";
            string comment = TextBox1.Text;

            updateresponse(status, comment);

            Employee user = (Employee)Session["user"];
            string deptid = user.Department_ID.ToString();
            string empid = user.Employee_ID;
            DateTime date = DateTime.Today;

            List<HodReqItem> hodReqItems = new List<HodReqItem>();
           


            foreach (GridViewRow gvr in GridView1.Rows)
            {
                string Category = gvr.Cells[0].Text;
                string Description = gvr.Cells[1].Text;
                string Quantity = gvr.Cells[2].Text;
                hodReqItems.Add(new HodReqItem(Category, Description, Quantity));

            }

            insertrequesttostore( deptid, empid, date, status, hodReqItems);


        }

        public void updateresponse(string status, string comment)
        {
            int Id =Convert.ToInt32(Request["ID"]);

            {
                var empreq = model.Employee_Request.Where(x => x.Request_ID.Equals(Id)).FirstOrDefault();
                empreq.Status = status;

                List<Emp_Request_items> m = model.Emp_Request_items.Where(x => x.Request_ID.Equals(Id)).ToList<Emp_Request_items>();
                foreach (var i in m)
                {
                    i.Status = status;
                    i.Comments = comment;
                }
            }

            model.SaveChanges();
        }

        public void insertrequesttostore( string deptid, string empid, DateTime date, string status, List<HodReqItem> reqItems)  //,date
        {

           

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


                foreach ( var v in reqItems)
                {
                    var xy = (from z in model.Inventories where z.Description == v.Description select z.Item_Number).SingleOrDefault();
                    Store_Request_items store_Request = new Store_Request_items();

                    store_Request.StoreRequest_ID = storeid.StoreRequest_ID;
                    store_Request.Item_Number = xy;
                    store_Request.Description = v.Description;
                    store_Request.Req_Quantity =Convert.ToInt32(v.Quantity);
                    store_Request.Pend_Quantity = Convert.ToInt32(v.Quantity);
                    store_Request.Status = "Pending";
                    model.Store_Request_items.Add(store_Request);
                    model.SaveChanges();
                }
                
            }
           
        }

        public void Reject_Click(object sender, EventArgs e)
        {
            string Id = Request["ID"];
            string status = "Rejected";
            string comment = TextBox1.Text;
            updateresponse(status, comment);

        }
    }
}