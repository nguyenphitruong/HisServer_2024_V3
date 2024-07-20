using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Pha
{
    [Table("PHA_fltemp")]
    public partial class PHA_fltemp
    {
        public string followid { get; set; }
        [Key]
        [StringLength(36)]
        public string idline { get; set; }
        [StringLength(36)]
        public string idh { get; set; }
        public string codeh { get; set; }
        public string storecode { get; set; }
        public string drugcode { get; set; }
        public decimal? qtyreq { get; set; }
        public decimal? qtyapp { get; set; }
        public string note { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
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
