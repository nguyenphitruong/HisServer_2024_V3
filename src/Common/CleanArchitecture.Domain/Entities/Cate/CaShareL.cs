namespace Emr.Domain.Entities.Cate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CATE_sharel")]
    public partial class CATE_sharel
    {
        public int id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string code { get; set; }

        [Required]
        [StringLength(10)]
        public string codeh { get; set; }

        [StringLength(10)]
        public string parent { get; set; }

        [StringLength(10)]
        public string acro { get; set; }

        public string name { get; set; }

        public string des { get; set; }

        public int active { get; set; }

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

        public int? siterf { get; set; }

        public bool? ismodify { get; set; }
    }
}
