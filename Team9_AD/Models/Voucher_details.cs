namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Voucher_details
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        [StringLength(255)]
        public string Approve_ID { get; set; }

        public int? Damage_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Voucher_Date { get; set; }

        public int? Amount { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }
    }
}
