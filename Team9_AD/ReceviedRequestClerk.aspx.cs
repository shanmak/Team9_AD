using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using Team9_AD.Models;

namespace Team9_AD
{
    public partial class Recevied_request_clerk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                using (WebClient webClient = new WebClient())
                {
                    string listdepartment=webClient.DownloadString("http://"+host+"/AD_Service/WCF/Service1.svc/listDepartment");
                    String rawJSON = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/listClerkRequest");
                    List<Store_Request> store_Requests = JsonConvert.DeserializeObject<List<Store_Request>>(rawJSON);
                    List<String> listDepartment = JsonConvert.DeserializeObject<List<String>>(listdepartment);

                    if (!listDepartment.Count().Equals(0))
                    {
                        listDepartment.Insert(0, "ALL");
                        DropDownList1.DataSource = listDepartment;
                        DropDownList1.DataBind();
                    }

                    if (!store_Requests.Count().Equals(0))
                    {
                        GridView1.DataSource = store_Requests;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("Record Not Found");
                    }



                }
                
            }

            
        }

        protected void GridView(object sender, EventArgs e)
        {

            Button b = (Button)sender;
             GridViewRow r = (GridViewRow)b.NamingContainer;
            string ID = GridView1.DataKeys[r.RowIndex].Values[0].ToString();
                       
            Response.Redirect("ClerkRequestDetails.aspx?ID="+ID);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string department_name = DropDownList1.SelectedValue;
          
           
            string host = Application["host"].ToString();

            if (department_name.Equals("ALL"))
            {
                using (WebClient webClient = new WebClient())
                {
                    String rawJSON = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/listClerkRequest");
                    List<Store_Request> store_Requests = JsonConvert.DeserializeObject<List<Store_Request>>(rawJSON);

                    if (!store_Requests.Count().Equals(0))
                    {
                        GridView1.DataSource = store_Requests;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("Record Not Found");
                    }

                }
            }
            else
            {
                using (WebClient webClient = new WebClient())
                {
                    String rawJSON = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/selectDepartment/" + department_name);
                    List<Store_Request> store_Requests = JsonConvert.DeserializeObject<List<Store_Request>>(rawJSON);

                    if (!store_Requests.Count().Equals(0))
                    {
                        GridView1.DataSource = store_Requests;
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

