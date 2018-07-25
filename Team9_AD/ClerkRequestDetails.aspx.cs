using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;

namespace Team9_AD
{
    public partial class CLerk_request_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["ID"];

            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                using (WebClient webClient = new WebClient())
                {
                    String rawJSON = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/listClerkRequest/"+id);
                    List<Store_Request_items> store_Requests_items = JsonConvert.DeserializeObject<List<Store_Request_items>>(rawJSON);
                    if (!store_Requests_items.Count().Equals(0))
                    {
                        GridView1.DataSource = store_Requests_items;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("Record Not Found");
                    }
                }
            }
        }
    }
}