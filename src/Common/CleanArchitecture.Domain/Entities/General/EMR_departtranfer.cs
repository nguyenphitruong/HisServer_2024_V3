namespace Emr.Domain.Entities.General
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_departtranfer")]

    public partial class EMR_departtranfer
    {

        [Key]
        [StringLength(36)]
        public string idline { get; set; }

        [Required]
        [StringLength(36)]
        public string idlink { get; set; }

        [Required]
        [StringLength(36)]
        public string patid { get; set; }

        [Required]
        [StringLength(10)]
        public string patcode { get; set; }

        [Required]
        [StringLength(36)]
        public string mediid { get; set; }

        [StringLength(36)]
        public string tranid { get; set; }

        public DateTime? trandate { get; set; }

        public DateTime? recedate { get; set; }

        [StringLength(3)]
        public string medexahtrancode { get; set; }

        [StringLength(6)]
        public string medexaltrancode { get; set; }

        [StringLength(3)]
        public string medexahrececode { get; set; }

        [StringLength(6)]
        public string medexalrececode { get; set; }

        [StringLength(10)]
        public string docincode { get; set; }

        [StringLength(10)]
        public string docoutcode { get; set; }

        [Column(TypeName = "text")]
        public string icdtranin { get; set; }

        [Column(TypeName = "text")]
        public string icdtranout { get; set; }

        public int? transtatuscode { get; set; }

        [StringLength(36)]
        public string roomid { get; set; }

        [StringLength(10)]
        public string roomcode { get; set; }

        [StringLength(255)]
        public string roomname { get; set; }

        [StringLength(36)]
        public string bedid { get; set; }

        [StringLength(10)]
        public string bedcode { get; set; }

        [StringLength(255)]
        public string bedname { get; set; }

        public int? statuscode { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "text")]
        public string attributes { get; set; }

        [Column(TypeName = "text")]
        public string datalog { get; set; }

        [Required]
        [StringLength(4)]
        public string mmyy { get; set; }

        [Required]
        [StringLength(4)]
        public string yyyy { get; set; }

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
