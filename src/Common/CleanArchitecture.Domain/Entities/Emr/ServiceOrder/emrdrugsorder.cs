namespace Emr.Domain.Entities.Emr.ServiceOrder
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrdrugsorder")]
    public partial class emrdrugsorder
    {
        public int? id { get; set; }

        [Key]
        [StringLength(36)]
        public string code { get; set; }

        [StringLength(36)]
        public string admincode { get; set; }

        [StringLength(36)]
        public string managecode { get; set; }

        [StringLength(36)]
        public string depcode { get; set; }

        [StringLength(5)]
        public string medexal { get; set; }

        [StringLength(255)]
        public string medexalname { get; set; }

        [StringLength(5)]
        public string objectcode { get; set; }

        [StringLength(255)]
        public string objectname { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(5)]
        public string doctorcode { get; set; }

        [StringLength(255)]
        public string docrorname { get; set; }

        [StringLength(5)]
        public string patienttype { get; set; }
        public int? placordercode { get; set; }

        public DateTime? drugorderdate { get; set; }

        [StringLength(10)]
        public string drugcode { get; set; }

        [StringLength(255)]
        public string drugname { get; set; }

        [StringLength(5)]
        public string drugtypecode { get; set; }

        public int? done { get; set; }

        public int? finish { get; set; }

        [StringLength(5)]
        public string icd10code { get; set; }

        [StringLength(255)]
        public string icd10name { get; set; }

        public int? idstore { get; set; }

        [StringLength(200)]
        public string stractiveingre { get; set; }

        public bool? multiactiveingre { get; set; }

        public decimal? ofprice { get; set; }

        public decimal? serprice { get; set; }

        public decimal? hiprice { get; set; }

        public decimal? difprice { get; set; }

        public decimal? serpayrate { get; set; }

        public int? qtymor { get; set; }

        public int? qtydin { get; set; }

        public int? qtyaft { get; set; }

        public int? qtynig { get; set; }

        public int? qtyday { get; set; }

        public decimal? qty { get; set; }

        public decimal? total { get; set; }

        [StringLength(200)]
        public string usage { get; set; }

        [StringLength(2)]
        public string unitcode { get; set; }

        [StringLength(255)]
        public string unitname { get; set; }

        [StringLength(3)]
        public string routecode { get; set; }

        [StringLength(255)]
        public string routename { get; set; }

        [StringLength(3)]
        public string usecode { get; set; }

        [StringLength(255)]
        public string usename { get; set; }

        public int? ishi { get; set; }

        public bool? removehi { get; set; }

        public int? sort { get; set; }

        [StringLength(36)]
        public string biddinglidline { get; set; }

        public int? priceid { get; set; }

        public DateTime? dateorder { get; set; }

        public int? ratehi { get; set; }

        public int? ratepay { get; set; }

        public int? rateother { get; set; }

        public int? content { get; set; }

        public int? active { get; set; }

        [StringLength(255)]
        public string ucr { get; set; }

        [StringLength(255)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(255)]
        public string com { get; set; }

        [StringLength(255)]
        public string mac { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        [StringLength(4)]
        public string mmyy { get; set; }

        [StringLength(2)]
        public string year { get; set; }
    }
}
