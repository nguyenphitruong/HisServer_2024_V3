namespace Emr.Domain.Entities.Emr
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EMR_happenning")]
    public partial class EMR_happenning
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
        public string mediid { get; set; }

        [StringLength(36)]
        public string tranid { get; set; }

        [StringLength(36)]
        public string hiid { get; set; }

        public DateTime? datecreate { get; set; }

        [StringLength(500)]
        public string content { get; set; }

        [StringLength(10)]
        public string doccode { get; set; }

        [StringLength(500)]
        public string treamentcontent { get; set; }

        public string takecareofcontent { get; set; }

        [StringLength(10)]
        public string nursingperform { get; set; }

        [StringLength(500)]
        public string monitor { get; set; }

        public string executeorder { get; set; }

        [StringLength(500)]
        public string diet { get; set; }

        [StringLength(20)]
        public string circui { get; set; }

        public int? blomin { get; set; }

        public int? blomax { get; set; }

        public int? heartb { get; set; }

        public decimal? temper { get; set; }

        public decimal? weight { get; set; }

        public decimal? spo2 { get; set; }

        public decimal? height { get; set; }

        public decimal? bmi { get; set; }

        [StringLength(10)]
        public string bmistr { get; set; }

        public int? specialistcode { get; set; }

        [Column(TypeName = "text")]
        public string specialist { get; set; }

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
