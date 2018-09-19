namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseGood
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Item_Number { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public int Available_Quantity { get; set; }

        public int Order_Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier_ID { get; set; }

        public int Phonenumber { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
