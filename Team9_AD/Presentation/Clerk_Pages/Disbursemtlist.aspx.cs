using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class Disbursemtlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Mani & Prasanth*/
            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                //using (WebClient webClient = new WebClient())
                //{
                //    string listdepartment = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/listDepartment");



                List<String> listDepartment = ClerkBusinessLogic.GetDepartment();
                if (!listDepartment.Count().Equals(0))
                {
                    listDepartment.Insert(0, "Select Any Department");
                    DropDownList1.DataSource = listDepartment;
                    DropDownList1.DataBind();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                string sus = ClerkBusinessLogic.Disbursementupdate();
            }
            catch (Exception)
            {
                
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            fn_AttachGrid();
        }


        public void fn_AttachGrid()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    MailMessage mm = new MailMessage("sgsuren1118@gmail.com", "smachavel@gmail.com");
                    mm.Subject = "GridView Email";
                    mm.Body = "Hi, <br/> The Following items are ready for disbursement this week.<hr />" + sw.ToString(); ;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "lguniversityteam@gmail.com";
                    NetworkCred.Password = "littleflower";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }

            

        }


        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void btn_ViewDisbmt_Click(object sender, EventArgs e)
        {
            string department_name = DropDownList1.SelectedValue.ToString();

            if (DropDownList1.SelectedIndex == 0)
            {
                GridView1.Visible = false;
               
            }
            else
            {
                using (Logic_University_Entity m = new Logic_University_Entity())
                {
                    var depart = m.Departments.Where(x => x.Department_Name == department_name).FirstOrDefault();

                    string departid = depart.Department_ID;
                    DateTime date = DateTime.Now;
                    var s = date.ToString("yyyy-MM-dd");

                    DateTime da = DateTime.Parse(s);

                    var singlist = m.Disbursement_List.Where(x => x.Department_ID == departid && x.Status == "Pending").ToList();

                    List<Disbursement_List_dtl> list = new List<Disbursement_List_dtl>();

                    foreach (var v in singlist)
                    {

                        list.AddRange(m.Disbursement_List_dtl.Where(x => x.Disburse_ID == v.Disburse_ID).ToList());
                    }

                  

                    var list2 = list.GroupBy(x => new { x.Item_number, x.Discription }).Select(x => new { x.Key.Item_number, x.Key.Discription, request_quantity = x.Sum(y => y.req_qunty), delivered_quantity = x.Sum(y => y.Quantity) }).ToList();


                    if (list2.Count != 0)
                    {
                        Img_NoRecord.Visible = false;
                        GridView1.Visible = true;
                        GridView1.DataSource = list2.ToList();
                        GridView1.DataBind();
                    }
                    else
                    {
                        Img_NoRecord.Visible = true;
                        GridView1.Visible = false;
                        Button3.Enabled = false;
                    }
                }
            }
        }
    }
}