namespace Emr.Domain.Entities.Sys.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sysview")]
    public partial class sysview
    {
        
        public int siterf { get; set; }

        [Key]
        [Column(Order = 0)]
        public string idline { get; set; }

        public int menuid { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string descr { get; set; }

        public int active { get; set; }

        [StringLength(20)]
        public string usercr { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime timecr { get; set; }

        [StringLength(20)]
        public string userup { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }
    }
}