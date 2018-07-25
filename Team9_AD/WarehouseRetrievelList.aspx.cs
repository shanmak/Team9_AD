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
using Team9_AD.Models;

namespace Team9_AD
{
    public partial class WarehouseRetrievelList : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                using (Logic_University_Model lg = new Logic_University_Model())
                {
                    string test = "Pending";

                    var result = lg.Store_Request_items.Where(x => x.Status.Equals(test)).GroupBy(gd => new
                    { gd.Item_Number, gd.Inventory, gd.Status }).Select(y => new
                    { y.Key.Item_Number, y.Key.Inventory.Category, y.Key.Inventory.Description, y.Key.Inventory.Bin_number, Req_Qunty = y.Sum(a => a.Req_Quantity), Available = y.Key.Inventory.Quantity }).ToList();

                    // var result2 = lg.Store_Request_items.Where(x => x.Status.Equals("Pending")).GroupBy(rd => new { rd.Item_Number, rd.Inventory, rd.Status }).Select(x => new { ItemCode = x.Key.Item_Number, Quty = x.Sum(a => a.Req_Quantity), location = x.Key.Inventory.Bin_number, Status = x.Key.Status, available=x.Key.Inventory.Quantity });
                    //List<Object> list = new List<object>();
                    //foreach( var v in reslut)
                    //{
                    //    list.Add(v);
                    //}
                    var result3 = lg.Store_Request.Where(x => x.Status.Equals(test)).Join(lg.Store_Request_items, c => c.StoreRequest_ID, o => o.StoreRequest_ID, (c, o) => new { c, o }).Where(x => x.o.Status == "Pending").GroupBy(gd => new
                    { gd.o.Item_Number, gd.o.Inventory }).Select(y => new
                    { y.Key.Item_Number, y.Key.Inventory.Category, y.Key.Inventory.Description, y.Key.Inventory.Bin_number, Req_Qunty = y.Sum(a => a.o.Pend_Quantity), Available = y.Key.Inventory.Quantity }).ToList();

                    GridView1.DataSource = result3;
                    GridView1.DataBind();
                }
            }
                         

         /*   string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                using (WebClient webClient = new WebClient())
                {
                    var warehoslist = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/WarehouseRetrievelList");                
                    
                    var list = JsonConvert.DeserializeObject<List<WarehouseRetrievelListJson>>(warehoslist);

                    if (!list.Count().Equals(0))
                    {                   
                                              
                        GridView1.DataSource = list;
                        GridView1.DataBind();
                    }
                }
            }
            */

            
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string host = Application["host"].ToString();

            List<updatelistAndDamageList> updatelist = new List<updatelistAndDamageList>();

            foreach (GridViewRow gvr in GridView1.Rows)
            {
         
                string Item_Number = gvr.Cells[0].Text;
                string Category = gvr.Cells[1].Text;
                string Description = gvr.Cells[2].Text;
                string Bin_number = gvr.Cells[3].Text;
                int Req_Qunty = Convert.ToInt32(gvr.Cells[4].Text);
                int Available = Convert.ToInt32(gvr.Cells[5].Text);

                TextBox txtbox1 = (TextBox)gvr.Cells[6].FindControl(id: "CollectedQuntity") as TextBox;
                int CollectedQuntity = Convert.ToInt32(value: txtbox1.Text);

                TextBox textBox2 = (TextBox)gvr.FindControl("DamagedQuantity");
                int DamagedQuantity = Convert.ToInt32(textBox2.Text);


                updatelist.Add(new updatelistAndDamageList(Item_Number, Category, Description, Bin_number, Req_Qunty, Available, CollectedQuntity, DamagedQuantity));


            }

           /* string joutput = JsonConvert.SerializeObject(updatelist);

            using (WebClient webclient = new WebClient())
            {
                webclient.Headers.Add("Content-type", "application/json");
                string result = webclient.UploadString("http://" + host + "/AD_Service/WCF/Service1.svc/Updatewarehouse", "POST", joutput);
                Response.Write(result.ToString());

            }
            */
           

            

            
          using (Logic_University_Model lg = new Logic_University_Model())
            {
                Employee user = (Employee)Session["user"];
                Wrehse_Trans trans = new Wrehse_Trans();
              //  trans.Trans_ID = 1;
                trans.Employee_ID = "STR003";
                trans.Trans_Date = DateTime.Now;

                lg.Wrehse_Trans.Add(trans);
                lg.SaveChanges();

             Wrehse_Trans last= lg.Wrehse_Trans.OrderByDescending(x => x.Trans_ID).Take(1).FirstOrDefault();

                foreach (var v in updatelist) {

                    Wrehse_Trans_Dtl trans_Dtl = new Wrehse_Trans_Dtl();
                    trans_Dtl.Trans_ID = last.Trans_ID;
                    trans_Dtl.Item_number = v.Item_Number;
                    trans_Dtl.Retrived_Qunty = v.Collected_qunty;
                    trans_Dtl.Available_Qunty = v.Collected_qunty;
                    lg.Wrehse_Trans_Dtl.Add(trans_Dtl);

                    var inventoriesChange =  lg.Inventories.Where(x => x.Item_Number.Equals(v.Item_Number)).FirstOrDefault();
                    inventoriesChange.Quantity -= v.Collected_qunty;
                    lg.SaveChanges();


                      if(v.Damage_qnty>0)
                    {
                        Dmg_Goods_Dtl d = new Dmg_Goods_Dtl();
                          d.Item_number = v.Item_Number;
                          d.Damage_Qnty = v.Damage_qnty;
                          d.Location = "warehouse";
                          d.Details = "Damage";
                          d.Employee_ID = user.Employee_ID;
                          d.Dmg_Date = System.DateTime.Today;
                          lg.Dmg_Goods_Dtl.Add(d);
                          lg.SaveChanges();

                    }



}

            }
            
    

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Disbursemtlist.aspx");
        }
    }

   
}