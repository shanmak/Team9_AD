namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Request_completed
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Department_ID { get; set; }

        [StringLength(255)]
        public string Item_Number { get; set; }

        public int? Req_quantity { get; set; }

        public int? Delivered_quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? StoreRequest_ID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
