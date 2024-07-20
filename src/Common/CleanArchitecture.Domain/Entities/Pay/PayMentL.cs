namespace Emr.Domain.Entities.Pay
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PayMentL")]
    public partial class PayMentL
    {
       
        public string idline { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string codePayL { get; set; }

        public string codePayH { get; set; }

        public string dateColect { get; set; }

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

    
        public string codeServices { get; set; }

        public bool? isBHYT { get; set; }

    
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int quantity { get; set; }

        
        public decimal price { get; set; }

       
        public decimal amount { get; set; }

        public int? done { get; set; }

        public int? paid { get; set; }

        [StringLength(25)]
        public string codeInPay { get; set; }

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
