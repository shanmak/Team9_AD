namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Emp_Request_items
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Request_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Item_Number { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public string Comments { get; set; }

        public virtual Employee_Request Employee_Request { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
