using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.Entity;

using Team9_AD.AddClass;
using System.Web.UI.WebControls;

namespace Team9_AD
{
    public class ClerkBusinessLogic
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        static string Pending = "Pending";

        public static List<string> GetDepartment()
        {
           
                var departmentlist = model.Departments.ToList<Department>();

                List<string> departmentList = departmentlist.Select(x => x.Department_Name).ToList();

                return departmentList;
          
        }
        public static List<ClerkViewRequest> GetAllPendingRequest(string department, string date)
        {
              if (department.Equals("ALL"))

            {
                 if (date != "")
                    {
                        DateTime datepicker = DateTime.Parse(date);
                        var store_Requests = model.Store_Request.Where(x => x.Status.Equals(Pending) && x.Request_Date == datepicker).ToList();

                        var list = store_Requests.Select(x => new { x.StoreRequest_ID, x.Department.Department_Name, x.Employee.Employee_Name, x.Request_Date, x.Status }).ToList();

                        List<ClerkViewRequest> clerk_Request = list.Select(x => new ClerkViewRequest(x.StoreRequest_ID, x.Department_Name, x.Employee_Name, x.Request_Date, x.Status)).ToList<ClerkViewRequest>();


                        return clerk_Request;
                    }
                    else
                    {
                        var store_Requests = model.Store_Request.Where(x => x.Status.Equals(Pending)).ToList();

                        var list = store_Requests.Select(x => new { x.StoreRequest_ID, x.Department.Department_Name, x.Employee.Employee_Name, x.Request_Date, x.Status }).ToList();

                        List<ClerkViewRequest> clerk_Request = list.Select(x => new ClerkViewRequest(x.StoreRequest_ID, x.Department_Name, x.Employee_Name, x.Request_Date, x.Status)).ToList<ClerkViewRequest>();


                        return clerk_Request;
                    }


            }
            else
            {
             
                    DateTime datepicker = DateTime.Parse(date);
                    Department dept = model.Departments.Where(x => x.Department_Name == department).FirstOrDefault();

                    string depart_id = dept.Department_ID;

                    var store_Requests = model.Store_Request.Where(x => x.Department_ID == depart_id && x.Status.Equals(Pending) && x.Request_Date == datepicker).ToList();

                    var list = store_Requests.Select(x => new { x.StoreRequest_ID, x.Department.Department_Name, x.Employee.Employee_Name, x.Request_Date, x.Status }).ToList();

                    List<ClerkViewRequest> clerk_Request = list.Select(x => new ClerkViewRequest(x.StoreRequest_ID, x.Department_Name, x.Employee_Name, x.Request_Date, x.Status)).ToList<ClerkViewRequest>();

                    return clerk_Request;
                }

        }


        public static List<Store_Request_items> storeRequestItems(int id)
        {
            
                return model.Store_Request_items.Where(x => x.StoreRequest_ID.Equals(id)).ToList<Store_Request_items>();
          
        }


        public static List<ClerkViewRequest> collectedlist()
        {
          

                var result = model.Store_Request.Where(x => x.Status.Equals("Pending")).Join(model.Store_Request_items, sq => sq.StoreRequest_ID, sql => sql.StoreRequest_ID, (sq, sql) => new { sq, sql }).GroupBy(rd => new
                { rd.sql.Item_Number, rd.sql.Inventory, rd.sql.Status }).Select(x => new
                { itemnumber = x.Key.Item_Number, category = x.Key.Inventory.Category, description = x.Key.Inventory.Description, Quty = x.Sum(a => a.sql.Pend_Quantity), location = x.Key.Inventory.Bin_number, Status = x.Key.Status, ava = x.Key.Inventory.Quantity }).ToList();


                List<ClerkViewRequest> List = result.Select(x => new ClerkViewRequest(x.itemnumber, x.category, x.description, x.Quty, x.location, x.Status, x.ava)).Where(x=> x.Quty!=0).ToList<ClerkViewRequest>();
                return List;
          
        }


        public static string Warelist(List<ClerkViewRequest> updatelist, Employee user)
        {

            try
            {
                    Wrehse_Trans trans = new Wrehse_Trans();

                    trans.Employee_ID = user.Employee_ID;
                    trans.Trans_Date = DateTime.Now;

                    model.Wrehse_Trans.Add(trans);
                    model.SaveChanges();

                    Wrehse_Trans last = model.Wrehse_Trans.OrderByDescending(x => x.Trans_ID).Take(1).FirstOrDefault();


                    foreach (var v in updatelist)
                    {

                        Wrehse_Trans_Dtl trans_Dtl = new Wrehse_Trans_Dtl();
                        trans_Dtl.Trans_ID = last.Trans_ID;
                        trans_Dtl.Item_number = v.itemnumber;
                        trans_Dtl.Retrived_Qunty = v.CollectedQuntity;
                        trans_Dtl.Available_Qunty = v.CollectedQuntity;
                        model.Wrehse_Trans_Dtl.Add(trans_Dtl);

                        var inventoriesChange = model.Inventories.Where(x => x.Item_Number.Equals(v.itemnumber)).FirstOrDefault();
                        inventoriesChange.Quantity -= v.CollectedQuntity;
                        model.SaveChanges();



                        if (v.DamagedQuantity > 0)
                        {
                            Dmg_Goods_Dtl d = new Dmg_Goods_Dtl();
                            d.Item_number = v.itemnumber;
                            d.Damage_Qnty = v.DamagedQuantity;
                            d.Location = "warehouse";
                            d.Details = "Damage";
                            d.Employee_ID = user.Employee_ID;
                            d.Dmg_Date = System.DateTime.Today;

                            inventoriesChange.Quantity -= v.DamagedQuantity;

                            model.Dmg_Goods_Dtl.Add(d);
                            model.SaveChanges();

                        }
                    }


                    return "UPDATE SUCCESS AND get all item fro store and down from inventory and add damage if ";
                               
            }
            catch (Exception)
            {
                return "ERROR IN UPDATING WAREHOUSE";
            }
        }




        public static string  Disbursementupdate()
        {
            try
            {
                string s = "sus completed request";
                
                    var list = model.Store_Request.Where(x => x.Status == "pending").ToList<Store_Request>();


                    foreach (var v in list)
                    {
                        int id = v.StoreRequest_ID;

                        List<string> test = process(id, v); //pass

                        List<string> done = new List<string>();

                        List<string> pending = new List<string>();
                        foreach (var status in test)
                        {
                            if (status == "Done")
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

                            model.SaveChanges();
                        }

                    }

                try
                {

                    s = disbursementprocess();

                }
                catch (Exception)
                {
                    s = "dis error";
                }

                return s;
            }
            catch (Exception)
            {
                return "req error";
            }
        }




        public static List<String> process(int id, Store_Request Request)
        {
            string rt = "";

            List<string> status = new List<string>();

            var relist = model.Store_Request_items.Where(x => x.StoreRequest_ID == id && x.Status == "Pending").ToList();




                foreach (var v in relist)
                {
                    var itemID = v.Item_Number;

                    var trslist = model.Wrehse_Trans_Dtl.Where(x => x.Available_Qunty != 0 && x.Available_Qunty > 0 && x.Item_number == itemID).FirstOrDefault();

                    if (trslist.Available_Qunty != 0)
                    {
                        if (trslist.Available_Qunty >= v.Pend_Quantity)
                        {
                            if (v.Delv_Quantity == null)
                            {
                                int? Req_quty = v.Pend_Quantity; //for dupliacte table 
                                int? deliver_quantity = v.Req_Quantity; //for duplicate table 
                                DateTime date = DateTime.Now;  //for dupilcate table
                                string depart_id = Request.Department_ID;  //for duplicate table 



                                trslist.Available_Qunty = trslist.Available_Qunty - v.Req_Quantity;
                                v.Delv_Quantity = v.Req_Quantity;
                                v.Pend_Quantity = 0;
                                v.Status = "Done";
                                model.SaveChanges();
                                status.Add("Done");

                                Request_completed Completed = new Request_completed();
                                Completed.Department_ID = depart_id;
                                Completed.Item_Number = v.Item_Number;
                                Completed.Req_quantity = Req_quty;
                                Completed.Delivered_quantity = deliver_quantity;
                                Completed.Date = date;
                                Completed.StoreRequest_ID = v.StoreRequest_ID;

                                model.Request_completed.Add(Completed);
                                model.SaveChanges();


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
                                model.SaveChanges();

                                status.Add("Done");

                                Request_completed Completed = new Request_completed();
                                Completed.Department_ID = depart_id;
                                Completed.Item_Number = v.Item_Number;
                                Completed.Req_quantity = Req_quty;
                                Completed.Delivered_quantity = deliver_quantity;
                                Completed.Date = date;
                                Completed.StoreRequest_ID = v.StoreRequest_ID;

                                model.Request_completed.Add(Completed);
                                model.SaveChanges();
                            }


                        }
                        else
                        {
                            if (v.Delv_Quantity == null)
                            {
                                int bal = (int)(v.Req_Quantity - trslist.Available_Qunty);

                                int? deliver_quantity = trslist.Available_Qunty; // for duplicate table
                                int? Req_quty = v.Pend_Quantity; //for dupliacte table 
                                DateTime date = DateTime.Now;  //for dupilcate table
                                string depart_id = Request.Department_ID;  //for duplicate table 

                                trslist.Available_Qunty = 0;
                                v.Pend_Quantity = bal;
                                v.Delv_Quantity = v.Req_Quantity - bal;
                                model.SaveChanges();
                                status.Add("Pending");


                                Request_completed Completed = new Request_completed();
                                Completed.Department_ID = depart_id;
                                Completed.Item_Number = v.Item_Number;
                                Completed.Req_quantity = Req_quty;
                                Completed.Delivered_quantity = deliver_quantity;
                                Completed.Date = date;
                                Completed.StoreRequest_ID = v.StoreRequest_ID;

                            model.Request_completed.Add(Completed);
                            model.SaveChanges();
                            }

                        }
                    }
                    else
                    {
                        rt = "Available Qunty no more";
                    }

                }

                return status;

        }


        public static string disbursementprocess()
        {
            try
            {
                string[] departmentlist = new string[] { "CMC", "COO", "CSE", "ELC", "ENG", "HSE", "MEC", "MED", "REG", "STR" };

                using (Logic_University_Entity m = new Logic_University_Entity())
                {
                    DateTime date = DateTime.Now;
                    var s = date.ToString("yyyy-MM-dd");

                    DateTime da = DateTime.Parse(s);


                    var list = m.Request_completed.Where(x => x.Date == (da)).GroupBy(x => new { x.Department_ID, x.Item_Number, x.Inventory }).Select(x => new { x.Key.Department_ID, x.Key.Item_Number, req_qunty= x.Sum(y=> y.Req_quantity) ,Deli_qunty = x.Sum(y => y.Delivered_quantity), x.Key.Inventory.Description }).ToList();

                    List<DemoClass> demos = new List<DemoClass>();

                    List<ClerkViewRequest> clist = new List<ClerkViewRequest>();

                    foreach (var v in list)
                    {

                       
                        clist.Add(new ClerkViewRequest { Department_ID = v.Department_ID, itemnumber = v.Item_Number, description = v.Description, Requried_qunty = v.req_qunty, delivered_qunty = v.Deli_qunty });
                    }
                    

                    foreach (var d in departmentlist)
                    {
                        

                        List<ClerkViewRequest> disList = new List<ClerkViewRequest>();

                        foreach (var l in clist)
                        {
                            if (l.Department_ID.Equals(d))
                            {
                                disList.Add(l);
                            }
                        }
                        if (disList.Count != 0)
                        {

                            using (Logic_University_Entity dl = new Logic_University_Entity())
                            {
                                Disbursement_List disbursement_List = new Disbursement_List();
                                disbursement_List.Department_ID = d;
                                disbursement_List.Disburse_date = DateTime.Now;
                                disbursement_List.Status = "Pending";

                                dl.Disbursement_List.Add(disbursement_List);
                                dl.SaveChanges();

                                var lastrecord = dl.Disbursement_List.OrderByDescending(x => x.Disburse_ID).Take(1).FirstOrDefault();

                                foreach (var disDetails in disList)
                                {
                                    Disbursement_List_dtl List_Dtl = new Disbursement_List_dtl();
                                    List_Dtl.Disburse_ID = lastrecord.Disburse_ID;
                                    List_Dtl.Item_number = disDetails.itemnumber;
                                    List_Dtl.Quantity = disDetails.delivered_qunty;
                                    List_Dtl.Discription = disDetails.description;
                                    List_Dtl.req_qunty = disDetails.Requried_qunty;

                                    dl.Disbursement_List_dtl.Add(List_Dtl);
                                    dl.SaveChanges();
                                }
                            }

                            disList.Clear();
                        }
                    }
                }

                return "dis trun ";
            }
            catch (Exception exw)
            {
                return exw.Message;
            }
        }
    }
}