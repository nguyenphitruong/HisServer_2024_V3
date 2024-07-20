namespace Emr.Domain.Entities.Pay
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PayMentH")]
    public partial class PayMentH
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string idline { get; set; }

        [Key]
        [StringLength(30)]
        public string codePayH { get; set; }

        [Required]
        [StringLength(25)]
        public string codeAdmission { get; set; }

        [StringLength(25)]
        public string codeManager { get; set; }

        [StringLength(25)]
        public string codeIndepartment { get; set; }

        [StringLength(10)]
        public string codeDepart { get; set; }

        [StringLength(16)]
        public string patcode { get; set; }

        public int? codeObject { get; set; }

        public DateTime? dateIn { get; set; }

        public DateTime? dateOut { get; set; }

        [StringLength(10)]
        public string codeInvoice { get; set; }

        public int? numberInvoice { get; set; }

        public DateTime? dateColect { get; set; }

        public decimal? amount { get; set; }

        public decimal? amountAdvance { get; set; }

        public bool? isBHYT { get; set; }

        public int? amounFree { get; set; }

        public int? done { get; set; }

        public int? paid { get; set; }

        [StringLength(25)]
        public string codeInPay { get; set; }

        [StringLength(25)]
        public string codeDrug { get; set; }

        [StringLength(4)]
        public string year { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string ucr { get; set; }

        [StringLength(50)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string com { get; set; }

        [StringLength(50)]
        public string mac { get; set; }

        [StringLength(50)]
        public string ip { get; set; }
    }
}
