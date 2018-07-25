namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disbursement_List_dtl
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Disburse_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Item_number { get; set; }

        [StringLength(255)]
        public string Discription { get; set; }

        public int? Quantity { get; set; }

        public virtual Disbursement_List Disbursement_List { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
