namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store_Request()
        {
            Store_Request_items = new HashSet<Store_Request_items>();
        }

        [Key]
        public int StoreRequest_ID { get; set; }

        [StringLength(255)]
        public string Department_ID { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Request_Date { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Request_items> Store_Request_items { get; set; }
    }
}
