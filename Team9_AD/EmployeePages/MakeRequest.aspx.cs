using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Team9_AD.AddClass;
using Team9_AD.Models;

namespace Team9_AD.EmployeePages
{
    public partial class MakeRequest : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SetInitialRow();
            }
        }
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));



            dr = dt.NewRow();

            //dr["Column1"] = string.Empty;
            //dr["Column2"] = string.Empty;
            //dr["Column3"] = string.Empty;
            //dr["Column4"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Requestdetails.DataSource = dt;
            Requestdetails.DataBind();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (ViewState["CurrentTable"] != null)
                {
                    int rowIndex = 0;
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            DropDownList Category =
                              (DropDownList)Requestdetails.Rows[rowIndex].Cells[0].FindControl("DropDownList1");
                            DropDownList Description =
                               (DropDownList)Requestdetails.Rows[rowIndex].Cells[1].FindControl("DropDownList2");
                            TextBox Quantity =
                               (TextBox)Requestdetails.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                            DropDownList Unit_Measure =
                              (DropDownList)Requestdetails.Rows[rowIndex].Cells[3].FindControl("DropDownList3");
                            //drCurrentRow = dtCurrentTable.NewRow();
                            // drCurrentRow["RowNumber"] = i + 1;
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Column1"] = Category.Text;
                            drCurrentRow["Column2"] = Description.Text;
                            drCurrentRow["Column3"] = Quantity.Text;
                            drCurrentRow["Column4"] = Unit_Measure.Text;

                            rowIndex++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);

                        Requestdetails.DataSource = dtCurrentTable;
                        Requestdetails.DataBind();

                    }
                    else
                    {
                        Response.Write("null");
                    }

                    SetPreviousData();
                    //ViewState["CurrentTable"] = dtCurrentTable;
                    //Requestdetails.DataSource = ViewState["CurrentTable"];
                    //Requestdetails.DataBind();
                }


            }
        }

        private void SetPreviousData()
        {

            if (ViewState["CurrentTable"] != null)
            {
                int rowIndex = 0;
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        DropDownList box1 = (DropDownList)Requestdetails.Rows[rowIndex].Cells[0].FindControl("DropDownList1");
                        DropDownList box2 = (DropDownList)Requestdetails.Rows[rowIndex].Cells[1].FindControl("DropDownList2");
                        TextBox box3 = (TextBox)Requestdetails.Rows[rowIndex].Cells[2].FindControl("TextBox1");
                        DropDownList box4 = (DropDownList)Requestdetails.Rows[rowIndex].Cells[3].FindControl("DropDownList3");


                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();
                        box4.Text = dt.Rows[i]["Column4"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<EmployeeMakeReq> employeeMakes = new List<EmployeeMakeReq>();

            int count = Requestdetails.Rows.Count;
        
            for (int i = 0; i < count; i++)
            {
                GridViewRow r = Requestdetails.Rows[i];
                DropDownList description = (DropDownList)r.Cells[1].FindControl("DropDownList2");
                TextBox b = (TextBox)r.Cells[2].FindControl("TextBox1");
                string desc = description.Text.ToString();
                int quantity = Convert.ToInt32(b.Text);
                employeeMakes.Add(new EmployeeMakeReq(desc,quantity));
            }

            try
            {
                using (Logic_University_Model entities = new Logic_University_Model())
                {
                    Employee_Request request = new Employee_Request();

                 
                    request.Department_ID = "CMC";
                    request.Employee_ID = "CMC003";
                    request.Date_of_Request = System.DateTime.Now;
                    request.Status = "Pending";
                    entities.Employee_Request.Add(request);
                    entities.SaveChanges();

                    Employee_Request Requestid = entities.Employee_Request.OrderByDescending(x => x.Request_ID).Take(1).FirstOrDefault();

                    foreach (var v in employeeMakes)
                    {
                        var xy = (from z in entities.Inventories where z.Description == v.Description select z.Item_Number).SingleOrDefault();
                        string itemnumber = xy.ToString();
                        Emp_Request_items item = new Emp_Request_items();
                        item.Request_ID = Requestid.Request_ID;
                        item.Item_Number = itemnumber;
                        item.Quantity = v.Quantity;
                        item.Status = "Pending";
                        entities.Emp_Request_items.Add(item);
                        entities.SaveChanges();
                    }

                }

         
            }
            catch (Exception)
            {
                
            }


        }
    }
}