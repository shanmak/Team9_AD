namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wrehse_Trans_Dtl
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Trans_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Item_number { get; set; }

        [StringLength(255)]
        public string Supplier_ID { get; set; }

        public int? Retrived_Qunty { get; set; }

        public int? Available_Qunty { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Wrehse_Trans Wrehse_Trans { get; set; }
    }
}
