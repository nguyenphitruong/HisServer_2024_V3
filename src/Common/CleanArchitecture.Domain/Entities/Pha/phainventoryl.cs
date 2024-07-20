namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("phainventoryl")]
    public partial class phainventoryl
    {
        public int? id { get; set; }

        [StringLength(36)]
        public string folowid { get; set; }

        [StringLength(10)]
        public string drugcode { get; set; }

        [StringLength(255)]
        public string drugname { get; set; }

        [StringLength(2)]
        public string storecode { get; set; }

        [StringLength(255)]
        public string storename { get; set; }

        [StringLength(2)]
        public string storegroupcode { get; set; }

        [StringLength(255)]
        public string storegroupname { get; set; }

        public DateTime? dateinput { get; set; }

        public decimal? qtbe { get; set; }

        public decimal? qtyim { get; set; }

        public decimal? qtyex { get; set; }

        public decimal? qtyvi { get; set; }

        public decimal? qtyen { get; set; }

        public int? active { get; set; }

        [StringLength(255)]
        public string ucr { get; set; }

        [StringLength(255)]
        public string uup { get; set; }

        public DateTime? timecr { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(255)]
        public string com { get; set; }

        [StringLength(255)]
        public string mac { get; set; }

        [StringLength(255)]
        public string ip { get; set; }

        [StringLength(4)]
        public string mmyy { get; set; }

        [StringLength(2)]
        public string year { get; set; }

        [Key]
        [StringLength(36)]
        public string code { get; set; }
    }
}
