namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disbursement_List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement_List()
        {
            Disbursement_List_dtl = new HashSet<Disbursement_List_dtl>();
        }

        [Key]
        public int Disburse_ID { get; set; }

        [StringLength(255)]
        public string Department_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Disburse_date { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement_List_dtl> Disbursement_List_dtl { get; set; }
    }
}
