namespace Emr.Domain.Entities.Pay
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PAY_paymenth")]
    public partial class PAY_paymenth
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
        public string idreturn { get; set; }

        [StringLength(10)]
        public string symbol { get; set; }

        [StringLength(10)]
        public string receiptnum { get; set; }

        [StringLength(50)]
        public string userpay { get; set; }

        public DateTime? datepay { get; set; }

        [StringLength(10)]
        public string taxcode { get; set; }

        [StringLength(250)]
        public string namebuyer { get; set; }

        [StringLength(250)]
        public string comaddr { get; set; }

        public int? objectcode { get; set; }

        public int? typepatcode { get; set; }

        public int? typepaycode { get; set; }

        public int? typereceiptcode { get; set; }

        public int? statuspaycode { get; set; }

        [StringLength(20)]
        public string votes { get; set; }

        public int? ratehi { get; set; }

        public decimal? total { get; set; }

        public decimal? totalhi { get; set; }

        public decimal? totalpatcopay { get; set; }

        public decimal? totalpatpay { get; set; }

        public decimal? totalpatpatcopay { get; set; }

        public decimal? totalpatpaid { get; set; }

        public decimal? totaldiscount { get; set; }

        public decimal? totalvocher { get; set; }

        public decimal? totalsourcepayothercosts { get; set; }

        public decimal? totalsourcepayattach { get; set; }

        public decimal? totalvat { get; set; }

        public decimal? totaladvance { get; set; }

        public decimal? totalpathavepay { get; set; }

        public bool? istransfer { get; set; }

        public decimal? totaltransfer { get; set; }

        public decimal? totalcash { get; set; }

        public decimal? totalpattake { get; set; }

        public decimal? totalpatrefund { get; set; }

        public bool? istranferaccounting { get; set; }

        [StringLength(500)]
        public string reason { get; set; }

        public int? discountcode { get; set; }

        [StringLength(500)]
        public string discountname { get; set; }

        [StringLength(500)]
        public string vouchername { get; set; }

        [StringLength(500)]
        public string othercostsname { get; set; }

        [StringLength(500)]
        public string attachname { get; set; }

        [StringLength(36)]
        public string requestadvanceid { get; set; }

        public int? medexahrequestcode { get; set; }

        public int? medexalrequestcode { get; set; }

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
