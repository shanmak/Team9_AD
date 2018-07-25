using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;
using Team9_AD.AddClass;

namespace Team9_AD.HodPage
{
    public partial class HodViewPage : System.Web.UI.Page
    {
        Logic_University_Model model = new Logic_University_Model();
        protected void Page_Load(object sender, EventArgs e)
        {
            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                using (WebClient webClient = new WebClient())
                {
                    string id = user.Department_ID.ToString();
                    string listrequest = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/HodViewPage/" + id);

                    List<HodViewlist> list = JsonConvert.DeserializeObject<List<HodViewlist>>(listrequest);
                    

                    if (list.Count != 0)
                    {
                        GridView1.DataSource = list;
                        GridView1.DataBind();
                    }

                }
            }

                 
    /*
           var list= model.Employee_Request.Where(x => x.Status == "Pending").ToList();

           var list1 = list.Select(x => new HodViewlist(x.Request_ID, x.Employee.Employee_Name, x.Status)).ToList();
            GridView1.DataSource = list1;
            GridView1.DataBind();

    */
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            GridViewRow r = (GridViewRow)b.NamingContainer;
            string ID = GridView1.DataKeys[r.RowIndex].Values[0].ToString();
            Response.Redirect("HodViewDetails.aspx?ID=" + ID);
        }
    }
}