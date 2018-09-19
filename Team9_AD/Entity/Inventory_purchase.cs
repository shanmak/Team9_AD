namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventory_purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_purchase()
        {
            Invent_Pur_Dtl = new HashSet<Invent_Pur_Dtl>();
            Invent_Pur_Dtl1 = new HashSet<Invent_Pur_Dtl>();
        }

        [Key]
        public int Purchase_ID { get; set; }

        [StringLength(255)]
        public string Supplier_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invent_Pur_Dtl> Invent_Pur_Dtl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invent_Pur_Dtl> Invent_Pur_Dtl1 { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
