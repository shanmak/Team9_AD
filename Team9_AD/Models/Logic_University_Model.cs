namespace Team9_AD.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Logic_University_Model : DbContext
    {
        public Logic_University_Model()
            : base("name=Logic_University_Model")
        {
        }

        public virtual DbSet<Approver> Approvers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Disbursement_List> Disbursement_List { get; set; }
        public virtual DbSet<Disbursement_List_dtl> Disbursement_List_dtl { get; set; }
        public virtual DbSet<Dmg_Goods_Dtl> Dmg_Goods_Dtl { get; set; }
        public virtual DbSet<Emp_Request_items> Emp_Request_items { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Request> Employee_Request { get; set; }
        public virtual DbSet<Goods_Received> Goods_Received { get; set; }
        public virtual DbSet<Invent_Pur_Dtl> Invent_Pur_Dtl { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Inventory_purchase> Inventory_purchase { get; set; }
        public virtual DbSet<Store_Request> Store_Request { get; set; }
        public virtual DbSet<Store_Request_items> Store_Request_items { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Voucher_details> Voucher_details { get; set; }
        public virtual DbSet<Wrehse_Trans> Wrehse_Trans { get; set; }
        public virtual DbSet<Wrehse_Trans_Dtl> Wrehse_Trans_Dtl { get; set; }
        public virtual DbSet<GenerateReport1> GenerateReport1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disbursement_List>()
                .HasMany(e => e.Disbursement_List_dtl)
                .WithRequired(e => e.Disbursement_List)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Voucher_details)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.Employee_ID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Voucher_details1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.Approve_ID);

            modelBuilder.Entity<Employee_Request>()
                .HasMany(e => e.Emp_Request_items)
                .WithRequired(e => e.Employee_Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Disbursement_List_dtl)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Dmg_Goods_Dtl)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Emp_Request_items)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Store_Request_items)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Wrehse_Trans_Dtl)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory_purchase>()
                .HasMany(e => e.Invent_Pur_Dtl)
                .WithRequired(e => e.Inventory_purchase)
                .HasForeignKey(e => e.Purchase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory_purchase>()
                .HasMany(e => e.Invent_Pur_Dtl1)
                .WithRequired(e => e.Inventory_purchase1)
                .HasForeignKey(e => e.Purchase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store_Request>()
                .HasMany(e => e.Store_Request_items)
                .WithRequired(e => e.Store_Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Inventories)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_ID_1);

            modelBuilder.Entity<Wrehse_Trans>()
                .HasMany(e => e.Wrehse_Trans_Dtl)
                .WithRequired(e => e.Wrehse_Trans)
                .WillCascadeOnDelete(false);
        }
    }
}
