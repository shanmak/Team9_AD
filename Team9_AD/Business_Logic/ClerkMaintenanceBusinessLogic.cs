using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using Team9_AD.Entity;


namespace Team9_AD
{
    public class ClerkMaintenanceBusinessLogic
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        static Model m = new Model();

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
        public static void recordDamageDetails(String Itemnumber, int Quantity, String Location,Employee user)
        {
            Dmg_Goods_Dtl dmg = new Dmg_Goods_Dtl();
            dmg.Item_number = Itemnumber;
            dmg.Damage_Qnty = Quantity;
            dmg.Location = Location;

            dmg.Employee_ID = user.Employee_ID;
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
           // newVoucher.Item_Number = (from x in model.Dmg_Goods_Dtl select x.Dmg_ID).Last();
            newVoucher.Voucher_Date = System.DateTime.Today;
            newVoucher.Amount = 34;
            model.Voucher_details.Add(newVoucher);
            model.SaveChanges();
        }

       public static int GetAvailableQuantity(string item_Number)
        {
            return (int)(model.Inventories.Where(x => x.Item_Number == item_Number).Select(x => x.Quantity).FirstOrDefault());
        }

        public static void IncreaseInventory(string item_Number, int? quantity)
        {
            Inventory m = model.Inventories.Where(x => x.Item_Number == item_Number).FirstOrDefault();
            m.Quantity = quantity;
            model.SaveChanges();
        }

        public static List<Inventory> informLowStockItems()
        {
            //return model.Inventories.Where(x => x.Quantity < x.Reorder_level).Select(x=> new Inventory{x.Supplier.;
            return model.Inventories.Where(x => x.Quantity < x.Reorder_level).ToList<Inventory>();
        }
        public static List<PurchaseGood> PurchaseGoods()
        {
            return m.PurchaseGoods.Where(x => x.Status == "Pending").AsNoTracking().ToList();
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

        public static string AddnewInventory(Inventory inventory)
        {
            try
            {
                model.Inventories.Add(inventory);

                model.SaveChanges();

                return "susccess";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public static void Deleteitem(string Description)
        {
                PurchaseGood goods = m.PurchaseGoods.Where(p => p.Description == Description && p.Status == "Pending").FirstOrDefault();
                m.PurchaseGoods.Remove(goods);
                m.SaveChanges();  
        }

        public static void Edititem(string Description, int quantity)
        {         
                PurchaseGood goods = m.PurchaseGoods.Where(p => p.Description == Description && p.Status == "Pending").FirstOrDefault();
                goods.Order_Quantity = quantity;
                model.SaveChanges();
         }
        
        public static List<string> GetSupplier()
        {     
          return  model.Suppliers.Select(x => x.Supplier_Name).ToList<string>();
        }

        public static string GetSupplierByName(string name)
        {
            return model.Suppliers.Where(x => x.Supplier_Name == name).Select(y => y.Supplier_ID).FirstOrDefault();
        }
    }
}