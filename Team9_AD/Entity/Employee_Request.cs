namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee_Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee_Request()
        {
            Emp_Request_items = new HashSet<Emp_Request_items>();
        }

        [Key]
        public int Request_ID { get; set; }

        [StringLength(255)]
        public string Department_ID { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_Request { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_Request_items> Emp_Request_items { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
