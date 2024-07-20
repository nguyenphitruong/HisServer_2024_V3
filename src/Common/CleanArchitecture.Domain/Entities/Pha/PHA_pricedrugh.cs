namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_pricedrugh")]
    public partial class PHA_pricedrugh
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        public int? typecode { get; set; }

        public DateTime? datebegin { get; set; }

        public DateTime? dateend { get; set; }

        public int? code { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        public int? sort { get; set; }

        public int? status { get; set; }

        public bool? ishi { get; set; }

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
