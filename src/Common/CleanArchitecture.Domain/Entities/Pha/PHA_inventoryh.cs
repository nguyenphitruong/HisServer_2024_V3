namespace Emr.Domain.Entities.Pha
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PHA_inventoryh")]
    public partial class PHA_inventoryh
    {
        [Key]
        public string idline { get; set; }
        public int storecode { get; set; }

        [StringLength(10)]
        public string drugcode { get; set; }

        public decimal? qtyt { get; set; }

        public decimal? qtyimp { get; set; }

        public decimal? qtyexp { get; set; }

        public decimal? qtyrep { get; set; }

        public decimal? qtymi { get; set; }

        [StringLength(20)]
        public string lotnumber { get; set; }

        public DateTime? expirydate { get; set; }

        public DateTime? ofmanudate { get; set; }

        public decimal? price { get; set; }

        public decimal? amount { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "text")]
        public string attributes { get; set; }

        [Column(TypeName = "text")]
        public string datalog { get; set; }

        [StringLength(4)]
        public string mmyy { get; set; }

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
