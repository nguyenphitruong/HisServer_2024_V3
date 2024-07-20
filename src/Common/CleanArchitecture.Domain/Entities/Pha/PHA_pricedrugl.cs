namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_pricedrugl")]
    public partial class PHA_pricedrugl
    {
        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [Required]
        [StringLength(36)]
        public string idh { get; set; }

        [StringLength(30)]
        public string drugcode { get; set; }

        public int? typecalcode { get; set; }

        public decimal? price { get; set; }

        public decimal? vat { get; set; }

        public int? sort { get; set; }

        public int? status { get; set; }

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
