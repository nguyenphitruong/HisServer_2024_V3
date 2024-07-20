namespace Emr.Domain.Entities.Cate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CATE_shareh")]
    public partial class CATE_shareh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(10)]
        public string model { get; set; }

        public string name { get; set; }

        [StringLength(50)]
        public string des { get; set; }

        [StringLength(50)]
        public string ucr { get; set; }

        [StringLength(50)]
        public string uup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timecr { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timeup { get; set; }

        [StringLength(50)]
        public string com { get; set; }

        [StringLength(50)]
        public string mac { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        public int? siterf { get; set; }

        public bool? ismodify { get; set; }

        public int active { get; set; }
    }
}
