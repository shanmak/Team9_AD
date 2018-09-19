namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Approver
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Department_ID { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_Date { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
