using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using Team9_AD.Entity;

namespace Team9_AD.Clerk_Goods_Maintenance
{
    public class Businesslogic
    {
        static Logic_University_Entity model = new Logic_University_Entity();

        public static void SendLowStock()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" <table border='5', bordercolorlight='#b9dcff', bordercolordark='#006fdd', width='400',align='center',bordercolor='black'><tr><th>Item Name</th><th>Available Quantity</th><th>Re-Order Quantity</th></tr>");
            List<Inventory> stockList = informLowStockItems();
            foreach (Inventory item in stockList)
            {
                sb.Append("<tr><td>" + item.Description + " </td>" + "<td>" + item.Quantity + "</td> " + "<td>" + item.Reorder_level + "</td></tr>");
            }
            sb.Append("</table>");
            MailMessage mm = new MailMessage("sgsuren1118@gmail.com", "sgsuren1118@gmail.com");
            mm.Subject = "Low Inventory Alert";
            mm.Body = "The Following Items are : <hr />" + sb.ToString(); ;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "sgsuren1118@gmail.com";
            NetworkCred.Password = "littleflower";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }



        public static void recordDamageDetails(String Itemnumber, int Quantity, String Location)
        {
            Dmg_Goods_Dtl dmg = new Dmg_Goods_Dtl();
            dmg.Item_number = Itemnumber;
            dmg.Damage_Qnty = Quantity;
            dmg.Location = Location;

            dmg.Employee_ID = "ENG002";
            dmg.Details = " ";
            dmg.Dmg_Date = System.DateTime.Now;
            model.Dmg_Goods_Dtl.Add(dmg);
            model.SaveChanges();
        }

        public static void createEmployee(string name, string depart_Id, string emp_role)
        {
            Employee newEmp = new Employee();
            newEmp.Employee_ID = " ";
            newEmp.Employee_Name = name;
            newEmp.Department_ID = depart_Id;
            newEmp.Employee_Role = emp_role;
            newEmp.Password = "logic123";
            model.Employees.Add(newEmp);
            model.SaveChanges();
        }

        public static void editEmployee(string emp_Id)
        {
            Employee editEmp = model.Employees.Where(x => x.Employee_ID == emp_Id).First();
        }
        public static void createVoucher(string description, int quantity, Employee emp)
        {
            Voucher_details newVoucher = new Voucher_details();
            newVoucher.Employee_ID = "STR003";
            //newVoucher.Damage_ID = (from x in model.Dmg_Goods_Dtl select x.Dmg_ID).Last();
            newVoucher.Voucher_Date = System.DateTime.Today;
            newVoucher.Amount = 34;
            model.Voucher_details.Add(newVoucher);
            model.SaveChanges();
        }
        public static List<Inventory> informLowStockItems()
        {
            //return model.Inventories.Where(x => x.Quantity < x.Reorder_level).Select(x=> new Inventory{x.Supplier.;
            return model.Inventories.Where(x => x.Quantity < x.Reorder_level).ToList<Inventory>();
        }
        public static List<Object> PurchaseGoods()
        {
            var xy = model.Inventories.Join(model.Suppliers, (inv => inv.Supplier_ID_1), s => s.Supplier_ID, (inv, s) => new { inv, s })
                       .Where(x => x.inv.Reorder_level >= x.inv.Quantity)
                       .Select(x => new { x.inv.Description, x.inv.Reorder_qty, x.inv.Quantity, x.inv.Supplier_ID_1, x.s.Phone_Num }).ToList<Object>();
            return xy;
            //return model.Inventories.Where(x=> x.Quantity <x.Reorder_level).Select(x=> new Inventory { x.Description, x.Reorder_qty, x.Quantity, x.Supplier_ID_1.Select})
        }
        public static string getItemNumber(string description)
        {
            return (from z in model.Inventories where z.Description == description select z.Item_Number).SingleOrDefault().ToString();
        }
        public static int calculateDamageAmount(int dmg_id)
        {

            return 0;
        }
        public static List<Inventory> purchaseOrder(string supplier)
        {
            return model.Inventories.Where(x => x.Quantity < x.Reorder_level && x.Supplier_ID_1 == supplier).ToList<Inventory>();
            //return model.Inventories.Where(x => x.Quantity < x.Reorder_level && x.Supplier_ID_1 == supplier).ToList<Inventory>();

        }


        public static List<Inventory> list()
        {

            //List<Inventory> list = model.Inventories.ToList<Inventory>();
            //foreach (var i in list)
            //{

            //}
           return model.Inventories.AsNoTracking().ToList();
            //return model.Inventories.ToList<Inventory>();
        }


        public static void AddItem(string itemnumber, string category, string description, int reorder_level, int reorder_qty, decimal price, string unit_measure, int quantity, string bin_number, string suppiler_ID_1, string suppiler_ID_2, string suppiler_ID_3)
        {
            using (Logic_University_Entity entities = new Logic_University_Entity())
            {
                Inventory inventory = new Inventory
                {
                    Item_Number = itemnumber,
                    Category = category,
                    Description = description,
                    Reorder_level = reorder_level,
                    Reorder_qty = reorder_qty,
                    Price = price,
                    Unit_Measure = unit_measure,
                    Quantity = quantity,
                    Bin_number = bin_number,
                    Supplier_ID_1 = suppiler_ID_1,
                    Supplier_ID_2 = suppiler_ID_2,
                    Supplier_ID_3 = suppiler_ID_3,
                };
                entities.Inventories.Add(inventory);
                entities.SaveChanges();

            }
        }


        public static void Edititem(string itemnumber, int quantity, string suppiler_ID_1, string suppiler_ID_2, string suppiler_ID_3)
        {
            using (Logic_University_Entity entities = new Logic_University_Entity())
            {

                Inventory inventory = entities.Inventories.Where(p => p.Item_Number == itemnumber).First<Inventory>();

                inventory.Quantity = quantity;
                inventory.Supplier_ID_1 = suppiler_ID_1;
                inventory.Supplier_ID_2 = suppiler_ID_2;
                inventory.Supplier_ID_3 = suppiler_ID_3;

                entities.SaveChanges();
            }
        }

        public static void Deleteitem(string itemnumber)
        {
            using (Logic_University_Entity entities = new Logic_University_Entity())
            {
                Inventory inventory = entities.Inventories.Where(p => p.Item_Number == itemnumber).First<Inventory>();
                entities.Inventories.Remove(inventory);
                entities.SaveChanges();
            }
        }
        public static void GenerateVoucher()
        {
            List<Dmg_Goods_Dtl> VoucherForDmg = model.Dmg_Goods_Dtl.Where(x => x.Details == "pending").ToList(); ;
            var xy = model.Dmg_Goods_Dtl.Where(x => x.Details == "pending").GroupBy(x => new { x.Item_number }).Select(x => new { x.Key.Item_number, v = x.Sum(y => y.Damage_Qnty) }).ToList();
            List<Voucher> Voucherlist = xy.Select(x => new Voucher(x.Item_number, (int)x.v)).ToList<Voucher>();
            if (Voucherlist.Count != 0)
            {
                foreach (var item in Voucherlist)
                {
                    Voucher_details newVoucher = new Voucher_details();
                    newVoucher.Item_Number = item.Item_Number;
                    newVoucher.Approve_ID = "STR001";
                    newVoucher.Voucher_Date = System.DateTime.Now;
                    newVoucher.Quantity = item.DmgQuantity;
                    newVoucher.Amount = item.DmgQuantity * GetItemPrice(item.Item_Number);
                    newVoucher.Status = "Pending";
                    model.Voucher_details.Add(newVoucher);
                    model.SaveChanges();     
                }   
            }
            foreach (Dmg_Goods_Dtl dmg in VoucherForDmg)
            {
                dmg.Details = "done";
            }
            SendVoucher();
        }

        private static decimal? GetItemPrice(string Itemnumber)
        {
            decimal? price = model.Inventories.Where(x => x.Item_Number == Itemnumber).Select(x => x.Price).FirstOrDefault();
            return price;
        }

        private static List<Voucher_details> GetVoucherdetails()
        {
            return model.Voucher_details.Where(x => x.Status == "pending").ToList();
        }

        private static void SendVoucher()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sp = new StringBuilder();
            List<Voucher_details> stockList = GetVoucherdetails();

            List<Voucher_details> max = stockList.Where(x => x.Amount > 250).ToList();
            List<Voucher_details> min = stockList.Where(x => x.Amount < 250).ToList();
            if (max.Count != 0)
            {
                sb.Append(" <table border='5', bordercolorlight='#b9dcff', bordercolordark='#006fdd', width='400',align='center',bordercolor='black'><tr><th>Item Name</th><th>Quantity</th><th>Voucher Amount</th><th>Voucher Date</th></tr>");
                foreach (var voucher in max)
                {
                    string description = model.Inventories.Where(x => x.Item_Number == voucher.Item_Number).Select(x => x.Description).FirstOrDefault().ToString();
                    sb.Append("<tr><td>" + description + " </td>" + "<td>" + voucher.Quantity + "</td> "  + "<td>" + voucher.Amount + "</td> " + "<td>" + voucher.Voucher_Date + "</td></tr>");
                }
                sb.Append("</table>");
                MailMessage manager = new MailMessage("sgsuren1118@gmail.com", "sgsuren1118@gmail.com");
                manager.Subject = "Voucher Generation Alert";
                manager.Body = "The Following Vouchers are for your approval : <hr />" + sb.ToString();
                manager.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "sgsuren1118@gmail.com";
                NetworkCred.Password = "littleflower";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(manager);
            }
            if (min.Count != 0)
            {
                sp.Append(" <table border='5', bordercolorlight='#b9dcff', bordercolordark='#006fdd', width='400',align='center',bordercolor='black'><tr><th>Item Name</th><th>Quantity</th><th>Voucher Amount</th><th>Voucher Date</th></tr>");
                foreach (Voucher_details voucher in stockList)
                {
                    string description = model.Inventories.Where(x => x.Item_Number == voucher.Item_Number).Select(x => x.Description).FirstOrDefault().ToString();
                    sp.Append("<tr><td>" + description + " </td>" + "<td>" + voucher.Quantity + "<td>" + voucher.Amount + "</td> " + "<td>" + voucher.Voucher_Date + "</td></tr>");
                }
                sp.Append("</table>");
                MailMessage supervisor = new MailMessage("sgsuren1118@gmail.com", "smachavel@gmail.com");
                supervisor.Subject = "Voucher Generation Alert";
                supervisor.Body = "The Following vouchers are for your approval: <hr />" + sp.ToString(); ;
                supervisor.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "sgsuren1118@gmail.com";
                NetworkCred.Password = "littleflower";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(supervisor);
            }
        }

    }
}