using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;
using Team9_AD.AddClass;

namespace Team9_AD
{
    public partial class WarehouseRetrievelList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];

                List<ClerkViewRequest> list = ClerkBusinessLogic.collectedlist();
                if (list.Count != 0)
                {
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                }
                else
                {
                    Img_NoRecord.Visible = true;
                    btn_Update.Visible = false;
                    btn_cancel.Visible = false;
                }

            }
                      
        }       

        protected void Button1_Click(object sender, EventArgs e)
        {
            string host = Application["host"].ToString();
                Employee user = (Employee)Session["user"];
                List<ClerkViewRequest> updatelist = new List<ClerkViewRequest>();

                foreach (GridViewRow gvr in GridView1.Rows)
                {

                    string Item_Number = gvr.Cells[1].Text;
                    string Category = gvr.Cells[2].Text;
                    string Description = gvr.Cells[3].Text;
                    string Bin_number = gvr.Cells[4].Text;
                    int Req_Qunty = Convert.ToInt32(gvr.Cells[5].Text);
                    int Available = Convert.ToInt32(gvr.Cells[6].Text);

                    TextBox txtbox1 = (TextBox)gvr.Cells[7].FindControl(id: "CollectedQuntity") as TextBox;
                    int CollectedQuntity = Convert.ToInt32(value: txtbox1.Text);

                    TextBox textBox2 = (TextBox)gvr.FindControl("DamagedQuantity");
                    int DamagedQuantity = Convert.ToInt32(textBox2.Text);

                     if (CollectedQuntity != 0)
                    {
                    updatelist.Add(new ClerkViewRequest(Item_Number, Category, Description, Req_Qunty, Bin_number, Available, CollectedQuntity, DamagedQuantity));
                    }                
                }
           
            ClerkBusinessLogic.Warelist(updatelist, user);

           
            ClerkBusinessLogic.Disbursementupdate();
            Response.Redirect("Disbursemtlist.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("StationaryRetrievalList.aspx");
        }
    }

   
}