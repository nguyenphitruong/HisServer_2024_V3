namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_prescriptionl")]
    public partial class PHA_prescriptionl
    {
        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(36)]
        public string idh { get; set; }

        [StringLength(20)]
        public string codeh { get; set; }

        [StringLength(20)]
        public string storecode { get; set; }
        public string drugcode { get; set; }

        [StringLength(36)]
        public string followid { get; set; }

        [StringLength(20)]
        public string lotnumber { get; set; }

        public DateTime? expirydate { get; set; }

        public DateTime? ofmanudate { get; set; }

        public int? qtyreq { get; set; }

        public int? qtyapp { get; set; }

        public decimal? price { get; set; }

        public int? vatrate { get; set; }

        public decimal? vat { get; set; }

        public int? statuscode { get; set; }

        public bool? ishi { get; set; }

        [StringLength(36)]
        public string biddinghidline { get; set; }

        [StringLength(36)]
        public string biddinglidline { get; set; }

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
