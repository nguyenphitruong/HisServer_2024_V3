namespace Emr.Domain.Entities.Emr.Outclinic
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("emroutclinic")]
    public partial class emroutclinic
    {
        public int? siterf { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Key]
        [StringLength(36)]
        public string code { get; set; }

        [StringLength(36)]
        public string managecode { get; set; }

        [StringLength(8)]
        public string patcode { get; set; }

        [StringLength(1)]
        public string objectcode { get; set; }

        [StringLength(100)]
        public string objectname { get; set; }

        [StringLength(5)]
        public string medexahcode { get; set; }

        [StringLength(100)]
        public string medexahname { get; set; }

        [StringLength(5)]
        public string medexalcode { get; set; }

        [StringLength(100)]
        public string medexalname { get; set; }

        [StringLength(10)]
        public string servicecode { get; set; }

        [StringLength(255)]
        public string servicename { get; set; }

        [StringLength(5)]
        public string doctorcode { get; set; }

        [StringLength(100)]
        public string doctorname { get; set; }

        public int? status { get; set; }

        [StringLength(10)]
        public string icd10maincode { get; set; }

        [StringLength(255)]
        public string icd10mainname { get; set; }

        [StringLength(50)]
        public string icd10extracode { get; set; }

        [StringLength(200)]
        public string icd10extraname { get; set; }

        [Column(TypeName = "text")]
        public string examinationdetail { get; set; }

        [StringLength(50)]
        public string circuit { get; set; }

        [StringLength(50)]
        public string heat { get; set; }

        [StringLength(50)]
        public string pressure { get; set; }

        [StringLength(10)]
        public string breathing { get; set; }

        [StringLength(50)]
        public string height { get; set; }

        [StringLength(50)]
        public string weight { get; set; }

        [StringLength(50)]
        public string spo2 { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        [StringLength(255)]
        public string prehistoric { get; set; }

        [StringLength(255)]
        public string allergy { get; set; }

        [StringLength(2)]
        public string solvecode { get; set; }

        [StringLength(100)]
        public string solvename { get; set; }

        [StringLength(2)]
        public string treatmentresultcode { get; set; }

        [StringLength(100)]
        public string treatmentresultname { get; set; }

        [StringLength(50)]
        public string dischargestatuscode { get; set; }

        [StringLength(100)]
        public string dischargestatusname { get; set; }

        public DateTime? examdate { get; set; }

        public DateTime? examdatefinish { get; set; }

        public int? dayofhi { get; set; }

        [StringLength(255)]
        public string advice { get; set; }

        public int? active { get; set; }

        [StringLength(50)]
        public string usercr { get; set; }

        public DateTime? timecr { get; set; }

        [StringLength(50)]
        public string userup { get; set; }

        public DateTime? timeup { get; set; }

        [StringLength(255)]
        public string computer { get; set; }

        public string attributes { get; set; }
    }
}
