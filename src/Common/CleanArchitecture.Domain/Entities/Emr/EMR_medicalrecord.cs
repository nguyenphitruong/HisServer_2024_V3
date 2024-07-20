namespace Emr.Domain.Entities.Emr
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_medicalrecord")]
    public partial class EMR_medicalrecord
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

        [StringLength(36)]
        public string departid { get; set; }

        [StringLength(36)]
        public string happeid { get; set; }

        public int? typeincode { get; set; }

        public int? meditypecode { get; set; }

        public int? medicode { get; set; }

        public int? objectcode { get; set; }

        [StringLength(20)]
        public string hospincode { get; set; }

        [StringLength(10)]
        public string archivenumber { get; set; }

        [StringLength(10)]
        public string hospnumberin { get; set; }

        [StringLength(10)]
        public string hospnumbertran { get; set; }

        public DateTime? datehospin { get; set; }

        [StringLength(10)]
        public string dochospin { get; set; }

        public DateTime? datehospout { get; set; }

        [StringLength(10)]
        public string dochospout { get; set; }

        public int? treatmentcode { get; set; }

        public int? slovetatuscode { get; set; }

        public int? dischargestatuscode { get; set; }

        public int? treatmentresultcode { get; set; }

        public int? placeintrocode { get; set; }

        public int? placeintroname { get; set; }

        [StringLength(5)]
        public string hostrantypecode { get; set; }

        [StringLength(5)]
        public string hostranincode { get; set; }

        [StringLength(255)]
        public string hostraninname { get; set; }

        [StringLength(5)]
        public string hostranoutcode { get; set; }

        [StringLength(255)]
        public string hostranoutname { get; set; }

        public int? medistatuscode { get; set; }

        public int? filestatuscode { get; set; }

        public int? treatmentday { get; set; }

        public DateTime? reexamdate { get; set; }

        [Column(TypeName = "text")]
        public string icdin { get; set; }

        [Column(TypeName = "text")]
        public string icdout { get; set; }

        [StringLength(255)]
        public string dayofhi { get; set; }

        [StringLength(255)]
        public string instruct { get; set; }

        public bool? gpb { get; set; }

        [MaxLength(1)]
        public byte[] img { get; set; }

        [StringLength(255)]
        public string exareason { get; set; }

        [StringLength(255)]
        public string medireasoncancel { get; set; }

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
