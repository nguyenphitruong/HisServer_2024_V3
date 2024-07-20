namespace Emr.Domain.Entities.Emr.Registers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emrregisterhi")]
    public partial class emrregisterhi
    {
    
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siterf { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rowsid { get; set; }

        [StringLength(36)]
        public string managecode { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(200)]
        public string exemptions { get; set; }

        [StringLength(15)]
        public string nohi { get; set; }

        public int? ratehi { get; set; }

        public int? ratepay { get; set; }

        public int? rateother { get; set; }

        public int? level { get; set; }

        public int? reason { get; set; }

        public decimal? minpay { get; set; }

        public decimal? maxpay { get; set; }

        public decimal? salary { get; set; }

        public bool? isusing { get; set; }

        [StringLength(255)]
        public string files { get; set; }

        [StringLength(255)]
        public string filename { get; set; }

        public bool? approved { get; set; }

        public int? active { get; set; }

        [StringLength(20)]
        public string ucr { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timecr { get; set; }

        [StringLength(20)]
        public string uup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }

        public int? typerouteexamid { get; set; }

        public bool? avepapertransfer { get; set; }
    }
}
