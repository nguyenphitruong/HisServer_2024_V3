using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emr.Domain.Entities.Sys
{
   
    [Table("SYS_noseriline")]
    public class SYS_noseriline
    {
        public int siterf { get; set; }
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(20)]
        public string code { get; set; }
        public string name { get; set; }
        public int lastnum { get; set; }
        [StringLength(10)]
        public string prefix { get; set; }

        [StringLength(10)]
        public string surfix { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateused { get; set; }

        public string yearused { get; set; }

        [Required]
        [StringLength(255)]
        public string typereset { get; set; }

        [StringLength(2)]
        public string typechar { get; set; }

        public int numreset { get; set; }

        public int? step { get; set; }

        public int? valueinit { get; set; }

        [StringLength(20)]
        public string lennum { get; set; }

        [StringLength(255)]
        public string descrp { get; set; }

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
