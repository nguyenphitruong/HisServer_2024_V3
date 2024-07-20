namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_invoiceinput")]
    public partial class PHA_invoiceinput
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [StringLength(30)]
        public string form { get; set; }

        [StringLength(30)]
        public string serial { get; set; }

        [StringLength(30)]
        public string no { get; set; }

        public DateTime? date { get; set; }

        [StringLength(30)]
        public string voucher { get; set; }

        public DateTime? voucherdate { get; set; }

        [StringLength(20)]
        public string suppliercode { get; set; }

        public bool? isinvoice { get; set; }

        public int? vat { get; set; }

        public decimal? vatamount { get; set; }

        public decimal? discountamount { get; set; }

        public int? discountrate { get; set; }

        public decimal? totalamount { get; set; }

        public decimal? reallyamount { get; set; }

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
