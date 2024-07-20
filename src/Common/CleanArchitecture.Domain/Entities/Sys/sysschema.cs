using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Sys
{
    [Table("sysschema")]
    public class sysschema
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rowid { get; set; }
        [Key]
        public string mmyy { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string datalog { get; set; }

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
