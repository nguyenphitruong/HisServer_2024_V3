namespace Emr.Domain.Entities.Pay
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PayService
    {
        [Key]
        [StringLength(36)]
        public string codeServicesOrder { get; set; }

        [Required]
        [StringLength(25)]
        public string codeAdmission { get; set; }

        [Required]
        [StringLength(25)]
        public string codeManager { get; set; }

        [Required]
        [StringLength(25)]
        public string codeIndepartment { get; set; }

        public int? codeClinic { get; set; }

        [StringLength(16)]
        public string patcode { get; set; }

        public int? codeDoctor { get; set; }

        public int? typePatient { get; set; }

        public int? codeObject { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateServicesOrder { get; set; }

        [StringLength(10)]
        public string codeServices { get; set; }

        public int? codeTypeServices { get; set; }

        public int? amount { get; set; }

        public double? price { get; set; }

        public int? paid { get; set; }

        public int? done { get; set; }

        public int? finish { get; set; }

        [StringLength(10)]
        public string codeIcd10 { get; set; }

        [StringLength(200)]
        public string nameIcd10 { get; set; }

        public bool? active { get; set; }

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

        [StringLength(4)]
        public string year { get; set; }
    }
}
