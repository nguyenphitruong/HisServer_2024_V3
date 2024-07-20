namespace Emr.Domain.Entities.Sys.Api
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sysserver")]
    public partial class sysserver
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string idline { get; set; }

        [Key]
        [StringLength(20)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string hostname { get; set; }

        public int? active { get; set; }

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
    }
}
