namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_prescriptionh")]
    public partial class PHA_prescriptionh
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(30)]
        public string code { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? pattype { get; set; }

        public int? typecode { get; set; }

        public int? statuscode { get; set; }

        [StringLength(36)]
        public string patid { get; set; }

        [StringLength(14)]
        public string patcode { get; set; }

        [StringLength(36)]
        public string idlink { get; set; }

        [StringLength(36)]
        public string mediid { get; set; }

        public DateTime? datecreate { get; set; }

        [StringLength(10)]
        public string usercreate { get; set; }

        public DateTime? dateapprove { get; set; }

        [StringLength(10)]
        public string userapprove { get; set; }

        public DateTime? datepass { get; set; }

        [StringLength(10)]
        public string userpass { get; set; }

        public bool? isfinish { get; set; }

        public DateTime? dateout { get; set; }

        [StringLength(100)]
        public string icdcode { get; set; }

        [StringLength(500)]
        public string icdname { get; set; }

        [StringLength(20)]
        public string nohi { get; set; }

        [StringLength(10)]
        public string medexacode { get; set; }

        [StringLength(255)]
        public string medexaname { get; set; }

        [StringLength(10)]
        public string doccode { get; set; }

        [StringLength(255)]
        public string docname { get; set; }

        public decimal? total { get; set; }

        public decimal? patpay { get; set; }

        public decimal? payhi { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        public int? objectcode { get; set; }

        public int? pricelistcode { get; set; }

        public int? ratepay { get; set; }

        public int? rateother { get; set; }

        [StringLength(36)]
        public string idlinehi { get; set; }

        [StringLength(20)]
        public string votes { get; set; }

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
