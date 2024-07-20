namespace Emr.Domain.Entities.Sys.Api
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sysaccount")]
    public partial class sysaccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string idline { get; set; }

        public int siterf { get; set; }

        [Key]
        [StringLength(4)]
        public string usercode { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(10)]
        public string password { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        [StringLength(5)]
        public string depcode { get; set; }

        [StringLength(5)]
        public string empcode { get; set; }

        public int? percode { get; set; }

        public int? active { get; set; }

        public int? status { get; set; }

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
