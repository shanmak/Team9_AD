namespace Team9_AD.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dmg_Goods_Dtl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dmg_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Item_number { get; set; }

        public int? Damage_Qnty { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        [StringLength(255)]
        public string Employee_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Dmg_Date { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
