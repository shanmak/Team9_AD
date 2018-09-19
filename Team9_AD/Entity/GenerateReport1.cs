namespace Team9_AD.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GenerateReport1
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Trans_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Item_number { get; set; }

        public int? Retrived_Qunty { get; set; }

        [StringLength(255)]
        public string Category { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Trans_Date { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
