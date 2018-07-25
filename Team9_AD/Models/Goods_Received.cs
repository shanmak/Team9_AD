namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Goods_Received
    {
        [Key]
        [StringLength(255)]
        public string Received_Code { get; set; }

        [StringLength(255)]
        public string Item_Number { get; set; }

        [StringLength(255)]
        public string Category { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Quantity_Recevied { get; set; }

        [StringLength(255)]
        public string Supplier_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Received_Date { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
