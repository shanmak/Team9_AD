namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier_Goods_received
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Item_Number { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Supplier_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(255)]
        public string Supplier_Name { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
