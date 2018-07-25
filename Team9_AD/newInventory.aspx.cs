using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Team9_AD
{
    public partial class newInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Added by Sanu - Start
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Sanu - End
        protected void Button1_Click(object sender, EventArgs e)
        {

            string host = Application["host"].ToString();

            Logic_University_Model logic = new Logic_University_Model();
            logic.Configuration.ProxyCreationEnabled = false;
            Response.Clear();

            Inventory inventory = new Inventory();

            inventory.Item_Number = TextBox1.Text;
            inventory.Category = TextBox2.Text;
            inventory.Description = TextBox3.Text;
            inventory.Reorder_level = Convert.ToInt32(TextBox4.Text);
            inventory.Reorder_qty = Convert.ToInt32(TextBox5.Text);
            inventory.Price = Convert.ToDecimal(TextBox6.Text);
            inventory.Unit_Measure = TextBox7.Text;
            inventory.Quantity = Convert.ToInt32(TextBox8.Text);
            inventory.Bin_number = TextBox9.Text;
            inventory.Supplier_ID_1 = TextBox10.Text;
            inventory.Supplier_ID_2 = TextBox11.Text;
            inventory.Supplier_ID_3 = TextBox12.Text;         

            
            string joutput = JsonConvert.SerializeObject(inventory);         
            
            using (WebClient webclient = new WebClient())
            {
               webclient.Headers.Add("Content-type", "application/json");            
               string result=  webclient.UploadString("http://"+host+"/AD_Service/WCF/Service1.svc/Update","POST", joutput);
               Response.Write(result.ToString());           

            }

            

           
           
            }
        }
    }
