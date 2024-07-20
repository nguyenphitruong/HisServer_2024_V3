using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Emr.Domain.Entities.Emr.Registers
{

    [Table("emrclinicqueue")]
    public partial class emrclinicqueue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int siterf { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }
        public string managercode { get; set; }

        public string serviceidline { get; set; }


        [StringLength(20)]
        public string servicecode { get; set; }

        [StringLength(255)]
        public string servicename { get; set; }

        [StringLength(20)]
        public string medexacode { get; set; }
        [StringLength(255)]
        public string medexaname { get; set; }

        [StringLength(20)]
        public string areacode { get; set; }

        public int ordinal { get; set; }

        [StringLength(20)]
        public string priobcode { get; set; }

        public int status { get; set; }

        public DateTime? beginwait { get; set; }

        public DateTime? endwait { get; set; }

        public DateTime? overdate { get; set; }

        public int active { get; set; }

        [StringLength(20)]
        public string usercr { get; set; }
        public DateTime timecr { get; set; }

        [StringLength(20)]
        public string userup { get; set; }
        public DateTime timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }
    }
}
