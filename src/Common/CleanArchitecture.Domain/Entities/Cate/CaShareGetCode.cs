namespace Emr.Domain.Entities.Cate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CaShareGetCode")]
    public partial class CaShareGetCode
    {
        public int id { get; set; }
        [Key]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(10)]
        public string model { get; set; }

        public string name { get; set; }

        public string begin { get; set; }

        public string end { get; set; }

        public DateTime? year { get; set; }

        public int? step { get; set; }

        public int? values { get; set; }

        public int? maxValues { get; set; }

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
    }
}
