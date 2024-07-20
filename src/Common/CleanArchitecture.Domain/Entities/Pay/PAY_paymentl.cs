namespace Emr.Domain.Entities.Pay
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PAY_paymentl")]
    public partial class PAY_paymentl
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

        [StringLength(50)]
        public string userpay { get; set; }

        public DateTime? datepay { get; set; }

        [Required]
        [StringLength(36)]
        public string idh { get; set; }

        public int? pricelistcode { get; set; }

        public int? ishi { get; set; }

        public int? ratehi { get; set; }

        public int? ratepay { get; set; }

        public int? serpayrate { get; set; }

        [Required]
        [StringLength(10)]
        public string servicecode { get; set; }

        [StringLength(250)]
        public string servicename { get; set; }

        [Required]
        [StringLength(10)]
        public string unitcode { get; set; }

        public decimal? qty { get; set; }

        public decimal? price { get; set; }

        public decimal? priceovertime { get; set; }

        public decimal? priceforeign { get; set; }

        public decimal? pricehi { get; set; }

        public decimal? difference { get; set; }

        public decimal? amount { get; set; }

        public decimal? amounthi { get; set; }

        public decimal? amountpatpay { get; set; }

        public decimal? amountpatcopay { get; set; }

        public decimal? amountpatpatcopay { get; set; }

        public decimal? amountpatpaid { get; set; }

        public decimal? amountdiscount { get; set; }

        public decimal? amountsourcepayattach { get; set; }

        public decimal? amountpathavepay { get; set; }

        public decimal? discount { get; set; }

        public decimal? sourcepayattach { get; set; }

        public int? vatrate { get; set; }

        public decimal? vat { get; set; }

        public decimal? amountvat { get; set; }

        public int? discoutype { get; set; }

        public int? discourate { get; set; }

        [StringLength(500)]
        public string discountname { get; set; }

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
