namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Goods_Received = new HashSet<Goods_Received>();
            Inventories = new HashSet<Inventory>();
            Inventory_purchase = new HashSet<Inventory_purchase>();
            Wrehse_Trans_Dtl = new HashSet<Wrehse_Trans_Dtl>();
        }

        [Key]
        [StringLength(255)]
        public string Supplier_ID { get; set; }

        [StringLength(255)]
        public string Supplier_Name { get; set; }

        [StringLength(255)]
        public string Contact_Name { get; set; }

        public int? Phone_Num { get; set; }

        public int? Fax_Num { get; set; }

        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods_Received> Goods_Received { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_purchase> Inventory_purchase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wrehse_Trans_Dtl> Wrehse_Trans_Dtl { get; set; }
    }
}
