using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emr.Domain.Entities.Emr.Outclinic
{
    [Table("EMR_medioutclinic")]
    public partial class EMR_medioutclinic
    {
        [Key]
        public string idline { get; set; }
        public string idlink { get; set; }
        public string patid { get; set; }
        public string patcode { get; set; }
        public int objectcode { get; set; }
        public string objectname { get; set; }
        public string hospincode { get; set; }
        public string archivenumber { get; set; }
        public string hospnumberin { get; set; }
        public int meditypecode { get; set; }
        public int medicode { get; set; }
        public string docexamcode { get; set; }
        public string docexamname { get; set; }
        public string medexahcode { get; set; }
        public string medexahname { get; set; }
        public string medexalcode { get; set; }
        public string medexalname { get; set; }
        public string servicecode { get; set; }
        public string servicename { get; set; }
        public DateTime? examdate { get; set; }
        public DateTime? examdatefinish { get; set; }
        public int? dayofhi { get; set; }
        public string advice { get; set; }
        public int? treatmentcode { get; set; }
        public int? slovetatuscode { get; set; }
        public int? dischargestatuscode { get; set; }
        public int? treatmentresultcode { get; set; }
        public int? medistatuscode { get; set; }
        public int? statuscode { get; set; }
        public string icd10maincode { get; set; }
        public string icd10mainname { get; set; }
        public string icd10extracode { get; set; }
        public string icd10extraname { get; set; }
        public string examinationdetail { get; set; }
        public decimal? circuit { get; set; }
        public decimal? heat { get; set; }
        public string pressure { get; set; }
        public string breathing { get; set; }
        public decimal? height { get; set; }
        public decimal? weight { get; set; }
        public string spo2 { get; set; }
        public string reason { get; set; }
        public string prehistoric { get; set; }
        public string allergy { get; set; }
        public string note { get; set; }
        public string attributes { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int siterf { get; set; }
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }
    }
}
