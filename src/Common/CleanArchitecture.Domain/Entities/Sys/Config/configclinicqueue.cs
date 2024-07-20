using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emr.Domain.Entities.Sys.Config
{
    [Table("configclinicqueue")]
    public partial class configclinicqueue
    {
        public int id { get; set; }

        public int siterf { get; set; }

        [Required]
        [StringLength(20)]
        public string medexacode { get; set; }

        public int lastnum { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateused { get; set; }

        public int numdayreset { get; set; }

        [Column(TypeName = "bit")]
        public bool? isodd { get; set; }

        public int? step { get; set; }

        public int? valueinit { get; set; }

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
