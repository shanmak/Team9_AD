namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Department")]
    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Approvers = new HashSet<Approver>();
            Disbursement_List = new HashSet<Disbursement_List>();
            Employees = new HashSet<Employee>();
            Employee_Request = new HashSet<Employee_Request>();
            Request_completed = new HashSet<Request_completed>();
            Store_Request = new HashSet<Store_Request>();
        }

        [Key]
        [StringLength(255)]
        public string Department_ID { get; set; }

        [StringLength(255)]
        public string Department_Name { get; set; }

        [StringLength(255)]
        public string Department_Head { get; set; }

        public int? Phone_Num { get; set; }

        public int? Fax_Num { get; set; }

        [StringLength(255)]
        public string Collection_Point { get; set; }

        [StringLength(255)]
        public string Representative_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Approver> Approvers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement_List> Disbursement_List { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Request> Employee_Request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request_completed> Request_completed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Request> Store_Request { get; set; }
    }
}
