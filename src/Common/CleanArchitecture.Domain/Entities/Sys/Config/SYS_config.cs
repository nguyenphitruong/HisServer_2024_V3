using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Sys.Config
{
    [Table("SYS_config")]
    public partial class SYS_config
    {
        [Key]
        public string idline { get; set; }
        public string code { get; set; }
        public string objcode { get; set; }
        public string objname { get; set; }
        public string objtype { get; set; }
        public int objlength { get; set; }
        public string objctl { get; set; }
        public string objcate { get; set; }
        public string descrp { get; set; }
        public int sort { get; set; }
        public string valcon { get; set; }
        public string label { get; set; }
        public int siterf { get; set; }
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime? timecr { get; set; }
        public string userup { get; set; }
        public DateTime? timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }
    }
}
