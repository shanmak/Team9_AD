namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wrehse_Trans
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wrehse_Trans()
        {
            Wrehse_Trans_Dtl = new HashSet<Wrehse_Trans_Dtl>();
        }

        [Key]
        public int Trans_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Trans_Date { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wrehse_Trans_Dtl> Wrehse_Trans_Dtl { get; set; }
    }
}
