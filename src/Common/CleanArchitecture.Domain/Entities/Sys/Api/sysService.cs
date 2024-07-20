namespace Emr.Domain.Entities.Sys.Api
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class sysService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [StringLength(20)]
        public string codeServices { get; set; }

        [StringLength(50)]
        public string nameServices { get; set; }

        [StringLength(20)]
        public string model { get; set; }

        [StringLength(50)]
        public string url { get; set; }

        [StringLength(10)]
        public string method { get; set; }

        [StringLength(20)]
        public string codeServer { get; set; }

        [StringLength(50)]
        public string hostName { get; set; }

        [StringLength(100)]
        public string fullUrl { get; set; }

        public int? active { get; set; }

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
