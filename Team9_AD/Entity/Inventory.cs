namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            Disbursement_List_dtl = new HashSet<Disbursement_List_dtl>();
            Dmg_Goods_Dtl = new HashSet<Dmg_Goods_Dtl>();
            Emp_Request_items = new HashSet<Emp_Request_items>();
            Goods_Received = new HashSet<Goods_Received>();
            Request_completed = new HashSet<Request_completed>();
            Store_Request_items = new HashSet<Store_Request_items>();
            Supplier_Goods_received = new HashSet<Supplier_Goods_received>();
            Wrehse_Trans_Dtl = new HashSet<Wrehse_Trans_Dtl>();
        }

        [Key]
        [StringLength(255)]
        public string Item_Number { get; set; }

        [StringLength(255)]
        public string Category { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Reorder_level { get; set; }

        public int? Reorder_qty { get; set; }

        public decimal? Price { get; set; }

        [StringLength(255)]
        public string Unit_Measure { get; set; }

        public int? Quantity { get; set; }

        [StringLength(255)]
        public string Bin_number { get; set; }

        [StringLength(255)]
        public string Supplier_ID_1 { get; set; }

        [StringLength(255)]
        public string Supplier_ID_2 { get; set; }

        [StringLength(255)]
        public string Supplier_ID_3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement_List_dtl> Disbursement_List_dtl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dmg_Goods_Dtl> Dmg_Goods_Dtl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_Request_items> Emp_Request_items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods_Received> Goods_Received { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request_completed> Request_completed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Request_items> Store_Request_items { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier_Goods_received> Supplier_Goods_received { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wrehse_Trans_Dtl> Wrehse_Trans_Dtl { get; set; }
    }
}
