using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class SupervisorReport : System.Web.UI.Page
    {
        Logic_University_Entity model = new Logic_University_Entity();
        ChartBusinessLogic bl = new ChartBusinessLogic();

        public enum Month
        {
            January = 1,

            February = 2,

            March = 3,

            April = 4,

            May = 5,

            June = 6,

            July = 7,

            August = 8,

            September = 9,

            October = 10,

            November = 11,

            December = 12
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Employee user = (Employee)Session["user"];
                if (user.Employee_Role != "Store-Supervisor")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                categoryDDL.DataBind();
                ListItem li = new ListItem("Select the Category", "-1");
                categoryDDL.Items.Insert(0, li);
                descriptionDDL.DataBind();
                ListItem lis = new ListItem("Select the Description", "-1");
                descriptionDDL.Items.Insert(0, lis);

               
            }

            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart1.Legends.Add("CSE");
            Chart1.Legends.Add("CMC");
            Chart1.Legends.Add("COO");


            Chart1.Legends.Add(new Legend("Legend2"));
            Chart1.Legends.Add(new Legend("Legend3"));

            Chart1.Series[0].IsVisibleInLegend = false;
            Chart1.Series[1].IsVisibleInLegend = false;
            Chart1.Series[2].IsVisibleInLegend = false;

        }

        protected void Group1_CheckedChanged(object sender, EventArgs e)
        {
            if (DeptRadioBtn.Checked)
            {
                
                DeptOrSupp1.DataSource = bl.getDepartmentNames();
                DeptOrSupp1.DataBind();

                DeptOrSupp2.DataSource = bl.getDepartmentNames();
                DeptOrSupp2.DataBind();

                DeptOrSupp3.DataSource = bl.getDepartmentNames();
                DeptOrSupp3.DataBind();

            }

            if (SupplierRadioBtn.Checked)
            {
                DeptOrSupp1.DataSource = bl.getSupplierNames();
                DeptOrSupp1.DataBind();

                DeptOrSupp2.DataSource = bl.getSupplierNames();
                DeptOrSupp2.DataBind();

                DeptOrSupp3.DataSource = bl.getSupplierNames();
                DeptOrSupp3.DataBind();
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DeptRadioBtn.Checked)
            {
                Chart1.Series[0].IsVisibleInLegend = true;
                Chart1.Series[1].IsVisibleInLegend = true;
                Chart1.Series[2].IsVisibleInLegend = true;


                string dep1 = model.Departments.Where(x => x.Department_Name == DeptOrSupp1.SelectedValue).Select(x => x.Department_ID).FirstOrDefault().ToString();
                string dep2 = model.Departments.Where(x => x.Department_Name == DeptOrSupp2.SelectedValue).Select(x => x.Department_ID).FirstOrDefault().ToString();
                string dep3 = model.Departments.Where(x => x.Department_Name == DeptOrSupp3.SelectedValue).Select(x => x.Department_ID).FirstOrDefault().ToString();
                string itemname = descriptionDDL.SelectedValue.ToString();

                Chart1.Series[0].LegendText = dep1;
                Chart1.Series[1].LegendText = dep2;
                Chart1.Series[2].LegendText = dep3;

                int count = lstMonths.Items.Count;
                string[] message = new string[count];
                int j = 0;
                for (int i = 0; i < count; i++)
                {
                    if (lstMonths.Items[i].Selected)
                    {
                        message[j] = lstMonths.Items[i].ToString();
                        j++;
                    }
                }

                BindSalesChart(dep1, dep2, dep3, itemname, message);
            }

            else
            {
                Chart1.Series[0].IsVisibleInLegend = true;
                Chart1.Series[1].IsVisibleInLegend = true;
                Chart1.Series[2].IsVisibleInLegend = true;


                string sup1 = model.Supplier_Goods_received.Where(x => x.Supplier_Name == DeptOrSupp1.SelectedValue).Select(x => x.Supplier_ID).ToString();
                string sup2 = model.Supplier_Goods_received.Where(x => x.Supplier_Name == DeptOrSupp2.SelectedValue).Select(x => x.Supplier_ID).ToString();
                string sup3 = model.Supplier_Goods_received.Where(x => x.Supplier_Name == DeptOrSupp3.SelectedValue).Select(x => x.Supplier_ID).ToString();
                string itemname = descriptionDDL.SelectedValue.ToString();

                Chart1.Series[0].LegendText = sup1;
                Chart1.Series[1].LegendText = sup2;
                Chart1.Series[2].LegendText = sup3;

                int count = lstMonths.Items.Count;
                string[] message = new string[count];
                int j = 0;
                for (int i = 0; i < count; i++)
                {
                    if (lstMonths.Items[i].Selected)
                    {
                        message[j] = lstMonths.Items[i].ToString();
                        j++;
                    }
                }

                BindSalesChart_Supplier(sup1, sup2, sup3, itemname, message);
            }
        }

        public void BindSalesChart(string dep1, string dep2, string dep3, string item, string[] mont)
        {

            var depart1trans = model.Disbursement_List.Join(model.Disbursement_List_dtl, (dl => dl.Disburse_ID), (dld => dld.Disburse_ID), (dl, dld) => new { dl, dld })
                .Where(x => x.dl.Department_ID == dep1 && x.dld.Discription == item)
                .Select(x => new { x.dld.Quantity, x.dl.Disburse_date });
            var depart2trans = model.Disbursement_List.Join(model.Disbursement_List_dtl, (dl => dl.Disburse_ID), (dld => dld.Disburse_ID), (dl, dld) => new { dl, dld })
               .Where(x => x.dl.Department_ID == dep2 && x.dld.Discription == item)
               .Select(x => new { x.dld.Quantity, x.dl.Disburse_date });
            var depart3trans = model.Disbursement_List.Join(model.Disbursement_List_dtl, (dl => dl.Disburse_ID), (dld => dld.Disburse_ID), (dl, dld) => new { dl, dld })
             .Where(x => x.dl.Department_ID == dep3 && x.dld.Discription == item)
             .Select(x => new { x.dld.Quantity, x.dl.Disburse_date });
            List<Departtrans> depart1transaction = new List<Departtrans>();
            List<Departtrans> depart2transaction = new List<Departtrans>();
            List<Departtrans> depart3transaction = new List<Departtrans>();
            foreach (var v in depart1trans)
            {
                depart1transaction.Add(new Departtrans((int)v.Quantity, Convert.ToDateTime(v.Disburse_date)));
            }
            foreach (var v in depart2trans)
            {
                depart2transaction.Add(new Departtrans((int)v.Quantity, Convert.ToDateTime(v.Disburse_date)));
            }
            foreach (var v in depart3trans)
            {
                depart3transaction.Add(new Departtrans((int)v.Quantity, Convert.ToDateTime(v.Disburse_date)));
            }
            AddChart(depart1transaction, mont, "Series1");
            AddChart(depart2transaction, mont, "Series2");
            AddChart(depart3transaction, mont, "Series3");

        }

        public void BindSalesChart_Supplier(string sup1, string sup2, string sup3, string item, string[] mont)
        {


            var sup1trans = model.Supplier_Goods_received.Where(x => x.Supplier_ID == sup1).Select(x => new { x.Quantity, x.Date }).ToList();
            var sup2trans = model.Supplier_Goods_received.Where(x => x.Supplier_ID == sup2).Select(x => new { x.Quantity, x.Date }).ToList();
            var sup3trans = model.Supplier_Goods_received.Where(x => x.Supplier_ID == sup3).Select(x => new { x.Quantity, x.Date }).ToList();

            List<SupplierTrans> supp1transaction = new List<SupplierTrans>();
            List<SupplierTrans> supp2transaction = new List<SupplierTrans>();
            List<SupplierTrans> supp3transaction = new List<SupplierTrans>();
            foreach (var v in sup1trans)
            {
                supp1transaction.Add(new SupplierTrans((int)v.Quantity, Convert.ToDateTime(v.Date)));
            }
            foreach (var v in sup2trans)
            {
                supp2transaction.Add(new SupplierTrans((int)v.Quantity, Convert.ToDateTime(v.Date)));
            }
            foreach (var v in sup3trans)
            {
                supp3transaction.Add(new SupplierTrans((int)v.Quantity, Convert.ToDateTime(v.Date)));
            }
            AddChart_Supplier(supp1transaction, mont, "Series1");
            AddChart_Supplier(supp2transaction, mont, "Series2");
            AddChart_Supplier(supp3transaction, mont, "Series3");

        }




        protected void categoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //descriptionDDL.Enabled = true;
            var q = model.Inventories.Where(p => p.Category == categoryDDL.SelectedValue).Select(p => p.Description).ToList();
            descriptionDDL.DataSource = q;
            descriptionDDL.DataBind();
            
        }

        public void AddChart(List<Departtrans> d, string[] month, string series)
        {
            for (int i = 0; month[i] != null; i++)
            {
                string mnth = month[i];
                string x;
                int depvalue = 0;

                foreach (Departtrans trans in d)
                {
                    DateTime y = Convert.ToDateTime(trans.Date);
                    x = (Enum.Parse(typeof(Month), trans.Date.Month.ToString()).ToString());

                    if (month[i] == x)
                    {
                        depvalue = depvalue + (int)trans.Quantity;
                    }
                }
                if (depvalue >= 0)
                {
                    Chart1.Series[series].Points.AddXY(month[i], (double)depvalue);
                }
                if (i == 11)
                {
                    break;
                }
            }
        }

        public void AddChart_Supplier(List<SupplierTrans> d, string[] month, string series)
        {
            for (int i = 0; month[i] != null; i++)
            {
                string mnth = month[i];
                string x;
                int supvalue = 0;

                foreach (SupplierTrans trans in d)
                {
                    DateTime y = Convert.ToDateTime(trans.Date);
                    x = (Enum.Parse(typeof(Month), trans.Date.Month.ToString()).ToString());

                    if (month[i] == x)
                    {
                        supvalue = supvalue + (int)trans.Quantity;
                    }
                }
                if (supvalue >= 0)
                {
                    Chart1.Series[series].Points.AddXY(month[i], (double)supvalue);
                }
                if (i == 11)
                {
                    break;
                }
            }
        }

    }
}