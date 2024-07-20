namespace Emr.Domain.Entities.Pay.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CATE_priceservices")]
    public partial class CATE_priceservices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string groupservicescode { get; set; }

        [StringLength(300)]
        public string groupservicesname { get; set; }

        [Required]
        [StringLength(10)]
        public string cateservicescode { get; set; }

        [StringLength(300)]
        public string cateservicesname { get; set; }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(300)]
        public string name { get; set; }

        [Required]
        [StringLength(10)]
        public string bhytcode { get; set; }

        [StringLength(300)]
        public string bhytname { get; set; }

        public int? ischeck { get; set; }

        [StringLength(10)]
        public string unitcode { get; set; }

        [StringLength(50)]
        public string unitname { get; set; }

        public decimal? ofprice { get; set; }

        public decimal? hiprice { get; set; }

        public decimal? serprice { get; set; }

        public decimal? difprice { get; set; }

        public int? ishi { get; set; }

        public int? vat { get; set; }

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
    }
}
