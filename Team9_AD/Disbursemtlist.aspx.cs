using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;

namespace Team9_AD
{
    public partial class Disbursemtlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "";
            using (Logic_University_Model m = new Logic_University_Model())
            {
                var list = m.Store_Request.Where(x => x.Status == "pending").ToList<Store_Request>();


                foreach (var v in list)
                {
                    int id = v.StoreRequest_ID;

                           List<string> test =  process(id, v); //pass

                    List<string> done = new List<string>();

                    List<string> pending = new List<string>();
                    foreach( var status in test)
                    {
                        if (status =="Done")
                        {
                            done.Add(status);
                        }
                        else
                        {
                            pending.Add(status);
                        }
                    }

                    if (test.Count.Equals(done.Count))
                    {
                        v.Status = "Done";

                        m.SaveChanges();
                    }

                }

                Response.Write(s);
            }
        }
        public static List<String> process(int id, Store_Request Request)
        {
            string rt="";

            List<string> status = new List<string>();

            using (Logic_University_Model m = new Logic_University_Model())
            {
                var relist = m.Store_Request_items.Where(x => x.StoreRequest_ID == id && x.Status == "Pending").ToList();



                foreach (var v in relist)
                {
                    var itemID = v.Item_Number;
                   
                    var trslist = m.Wrehse_Trans_Dtl.Where(x => x.Available_Qunty != 0 && x.Available_Qunty > 0 && x.Item_number == itemID).FirstOrDefault();

                    if (trslist.Available_Qunty != 0)
                    {
                        if (trslist.Available_Qunty >= v.Pend_Quantity )
                        {
                            if (v.Delv_Quantity==null)
                            {
                                int? Req_quty = v.Pend_Quantity; //for dupliacte table 
                                int? deliver_quantity = v.Req_Quantity; //for duplicate table 
                                DateTime date = DateTime.Now;  //for dupilcate table
                                string depart_id = Request.Department_ID;  //for duplicate table 


                                trslist.Available_Qunty = trslist.Available_Qunty - v.Req_Quantity;
                                v.Delv_Quantity = v.Req_Quantity;
                                v.Pend_Quantity = 0;
                                v.Status = "Done";
                                m.SaveChanges();
                                status.Add("Done");

                               

                            }
                            else
                            {
                                int? Req_quty = v.Pend_Quantity; //for dupliacte table 
                                int? deliver_quantity = v.Pend_Quantity; //for duplicate table 
                                DateTime date = DateTime.Now;  //for dupilcate table
                                string depart_id = Request.Department_ID;  //for duplicate table 

                                trslist.Available_Qunty = trslist.Available_Qunty - v.Pend_Quantity;
                                v.Delv_Quantity = v.Delv_Quantity + v.Pend_Quantity;
                                v.Pend_Quantity = 0;
                                v.Status = "Done";
                                m.SaveChanges();

                                status.Add("Done");
                            }


                        }
                        else
                        {
                            if (v.Delv_Quantity==null)
                            {
                                int bal = (int)(v.Req_Quantity - trslist.Available_Qunty);

                                int? deliver_quantity = trslist.Available_Qunty; // for duplicate table
                                int? Req_quty = v.Pend_Quantity; //for dupliacte table 
                                DateTime date = DateTime.Now;  //for dupilcate table
                                string depart_id = Request.Department_ID;  //for duplicate table 

                                trslist.Available_Qunty = 0;
                                v.Pend_Quantity = bal;
                                v.Delv_Quantity = v.Req_Quantity - bal;
                                m.SaveChanges();
                                status.Add("Pending");
                            }
                         
                        }
                    }
                    else
                    {
                        rt= "Available Qunty no more";
                       
                    }

                }

                return status;
            }

        }
    }
}