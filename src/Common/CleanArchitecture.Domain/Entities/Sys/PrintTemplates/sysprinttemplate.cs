using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Sys.PrintTemplates
{

    [Table("sysprinttemplate")]
    public partial class sysprinttemplate
    {
        public int id { get; set; }

        public int siterf { get; set; }

        [Key]
        [Required]
        [StringLength(100)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string descrip { get; set; }

        public Byte[] tempdata { get; set; }

        [Required]
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
