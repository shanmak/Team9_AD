using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD
{
    public class Voucher
    {
        public string Item_Number { get; set; }
        public int DmgQuantity { get; set; }

        public Voucher(string item_Number, int dmgQuantity)
        {
            Item_Number = item_Number;
            DmgQuantity = dmgQuantity;
        }
    }
}