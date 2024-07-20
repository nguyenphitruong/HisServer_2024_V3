namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_drugitem")]
    public partial class PHA_drugitem
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        public int? group40code { get; set; }

        public int? grouping40code { get; set; }

        public int? subgroup40code { get; set; }

        public int? typevencode { get; set; }

        public int? typegencode { get; set; }

        public int? typedispensecode { get; set; }

        [StringLength(30)]
        public string code { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        public int? typecode { get; set; }

        [StringLength(500)]
        public string typename { get; set; }

        public int? specificatcode { get; set; }

        public int? unitcode { get; set; }

        public int? unitusecode { get; set; }

        public int? routecode { get; set; }

        public int? sort { get; set; }

        public int? status { get; set; }

        [StringLength(255)]
        public string regpaper { get; set; }

        public int? suppliercode { get; set; }

        public int? producercode { get; set; }

        public int? dorigincode { get; set; }

        public bool? ishi { get; set; }

        public decimal? price { get; set; }

        public int? drugpricecode { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "text")]
        public string attributes { get; set; }

        [Column(TypeName = "text")]
        public string datalog { get; set; }

        [Required]
        [StringLength(4)]
        public string mmyy { get; set; }

        [Required]
        [StringLength(4)]
        public string yyyy { get; set; }

        public int? siterf { get; set; }

        public int? active { get; set; }

        [StringLength(150)]
        public string usercr { get; set; }

        public DateTime? timecr { get; set; }

        [StringLength(150)]
        public string userup { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(150)]
        public string computer { get; set; }

        [StringLength(150)]
        public string mac { get; set; }
    }
}
