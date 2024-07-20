namespace Emr.Domain.Entities.Pay.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("CATE_cateservices")]
    public partial class CATE_cateservices
    {
     
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string groupservicescode { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(300)]
        public string name { get; set; }

        public int? active { get; set; }

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
