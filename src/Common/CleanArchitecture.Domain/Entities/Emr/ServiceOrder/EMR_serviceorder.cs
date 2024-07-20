namespace Emr.Domain.Entities.Emr.ServiceOrder
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_serviceorder")]
    public partial class EMR_serviceorder
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [Required]
        [StringLength(36)]
        public string idlink { get; set; }

        [Required]
        [StringLength(36)]
        public string patid { get; set; }

        [Required]
        [StringLength(10)]
        public string patcode { get; set; }

        [StringLength(36)]
        public string mediid { get; set; }

        [StringLength(36)]
        public string departid { get; set; }

        [StringLength(36)]
        public string happeid { get; set; }

        public int? typepatcode { get; set; }

        public int? placordercode { get; set; }

        public int? medexahcode { get; set; }

        public int? medexalcode { get; set; }

        [StringLength(10)]
        public string docordercode { get; set; }

        public DateTime? dateorder { get; set; }

        [StringLength(250)]
        public string icdorder { get; set; }

        [StringLength(10)]
        public string groupcode { get; set; }

        [StringLength(10)]
        public string typecode { get; set; }

        [StringLength(10)]
        public string groupprintcode { get; set; }

        public int? pricelistcode { get; set; }

        [StringLength(10)]
        public string servicecode { get; set; }

        [StringLength(250)]
        public string servicename { get; set; }

        [StringLength(250)]
        public string servicenameeng { get; set; }

        [StringLength(250)]
        public string servicenamehi { get; set; }

        [StringLength(10)]
        public string unitcode { get; set; }

        public decimal? qty { get; set; }

        public decimal? price { get; set; }

        public decimal? priceovertime { get; set; }

        public decimal? priceforeign { get; set; }

        public decimal? pricehi { get; set; }

        public decimal? difference { get; set; }

        public decimal? total { get; set; }

        [StringLength(36)]
        public string reghiid { get; set; }

        public int? ratehi { get; set; }

        public int? serpayrate { get; set; }

        public int? ratepay { get; set; }

        public int? rateother { get; set; }

        public int? ishi { get; set; }

        public bool? removehi { get; set; }

        public bool? isnoresult { get; set; }

        public bool? ispackage { get; set; }

        public bool? isfree { get; set; }

        public int? times { get; set; }

        public bool? sameteam { get; set; }

        public int? sort { get; set; }

        public int? paid { get; set; }

        public int? done { get; set; }

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
