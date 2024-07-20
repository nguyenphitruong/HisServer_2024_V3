namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_follow")]
    public partial class PHA_follow
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(36)]
        public string idh { get; set; }

        [StringLength(36)]
        public string idl { get; set; }

        [StringLength(30)]
        public string slipinputcode { get; set; }

        public int? inputtypecode { get; set; }

        public int? pricelistcode { get; set; }

        [StringLength(30)]
        public string drugcode { get; set; }

        [StringLength(20)]
        public string specificatcode { get; set; }

        public DateTime? inputdate { get; set; }

        public DateTime? invoicedate { get; set; }

        [StringLength(20)]
        public string lotnumber { get; set; }

        public DateTime? ofmanudate { get; set; }

        public DateTime? expirydate { get; set; }

        public decimal? priceunit { get; set; }

        public decimal? pricecost { get; set; }

        public decimal? priceold { get; set; }

        public int? vat { get; set; }

        public decimal? vatamount { get; set; }

        public decimal? discountamount { get; set; }

        public int? discountrate { get; set; }

        public decimal? totalamount { get; set; }

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
