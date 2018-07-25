namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;


    public class updatelistAndDamageList
    {
        public string Item_Number { get; set; }     
     
        public string Category { get; set; }
        public string Description { get; set; }
        public string Bin_number { get; set; }
        public int Req_Qunty { get; set; }
        public int Available { get; set; }
        public int Collected_qunty { get; set; }
        public int Damage_qnty { get; set; }

        public updatelistAndDamageList(string item_Number, string category, string description, string bin_number, int req_Qunty, int available, int collected_qunty, int damage_qnty)
        {
            Item_Number = item_Number;
            Category = category;
            Description = description;
            Bin_number = bin_number;
            Req_Qunty = req_Qunty;
            Available = available;
            Collected_qunty = collected_qunty;
            Damage_qnty = damage_qnty;
        }
    }
}