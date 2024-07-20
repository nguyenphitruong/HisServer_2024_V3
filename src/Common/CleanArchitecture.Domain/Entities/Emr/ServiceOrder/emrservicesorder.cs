namespace Emr.Domain.Entities.Emr.ServiceOrder
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrservicesorder")]
    public partial class emrservicesorder
    {
        public string idline { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(36)]
        public string code { get; set; }

        [StringLength(36)]
        public string admincode { get; set; }

        [Required]
        [StringLength(36)]
        public string managecode { get; set; }

        [StringLength(36)]
        public string depcode { get; set; }

        [StringLength(5)]
        public string medexal { get; set; }
        [StringLength(255)]
        public string medexalname { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(5)]
        public string doctorcode { get; set; }

        [StringLength(1)]
        public string patienttype { get; set; }

        [StringLength(1)]
        public string objectcode { get; set; }
        [StringLength(255)]
        public string objectname { get; set; }

        [StringLength(2)]
        public string unitcode { get; set; }
        [StringLength(255)]
        public string unitname { get; set; }


        public DateTime? servicesorderdate { get; set; }

        [Required]
        [StringLength(10)]
        public string servicecode { get; set; }
        [StringLength(255)]
        public string servicename { get; set; }
        public bool? ishi { get; set; }

        public int? servicestypecode { get; set; }

        public int? qty { get; set; }

        public int? amount { get; set; }

        public decimal? ofprice { get; set; }

        public decimal? serprice { get; set; }

        public decimal? hiprice { get; set; }

        public decimal? difprice { get; set; }

        public int paid { get; set; }

        public int done { get; set; }

        public int? finish { get; set; }

        [StringLength(10)]
        public string icd10code { get; set; }

        [StringLength(200)]
        public string icd10name { get; set; }

        public int active { get; set; }

        [StringLength(50)]
        public string ucr { get; set; }

        [StringLength(50)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string com { get; set; }

        [StringLength(25)]
        public string mac { get; set; }

        [StringLength(25)]
        public string ip { get; set; }

        [StringLength(4)]
        public string mmyy { get; set; }

        [StringLength(2)]
        public string year { get; set; }

        [StringLength(2)]
        public string placepoint { get; set; }
    }
}
