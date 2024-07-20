using Emr.Domain.ReadModel.Share;
using PT.DomainLayer.ReadModel.Share;
using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Emr.Clinic
{
    public class OutclinicHisReadModel
    {
        public List<EmrServicesOrderReadModel> lstServicesOrder { get; set; }
        public List<EmrDrugsOrderReadModel> lstDrugsOrder { get; set; }

        public int siterf { get; set; }
        public int id { get; set; }
        public String code { get; set; }
        public string idlink { get; set; }
        public string patcode { get; set; }
        public string objectcode { get; set; }
        public string objectname { get; set; }
        public string medexahcode { get; set; }
        public string medexahname { get; set; }
        public string medexalcode { get; set; }
        public string medexalname { get; set; }
        public string servicecode { get; set; }
        public string servicename { get; set; }
        public string doctorcode { get; set; }
        public string doctorname { get; set; }
        public int status { get; set; }
        public string icd10maincode { get; set; }
        public string icd10mainname { get; set; }
        public string icd10extracode { get; set; }
        public string icd10extraname { get; set; }
        public string examinationdetail { get; set; }//Chi tiết khám json theo chuyên khoa khám
        public string circuit { get; set; }
        public string heat { get; set; }
        public string pressure { get; set; }
        public string breathing { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string spo2 { get; set; }
        public string reason { get; set; }//lý do khám
        public string prehistoric { get; set; }//tiền sử
        public string allergy { get; set; }//di ứng
        public string solvecode { get; set; }//xử trí
        public string solvename { get; set; }//xử trí:nhập viện, ra viện
        public string treatmentresultcode { get; set; }
        public string treatmentresultname { get; set; }//kết quả điều trị
        public string dischargestatuscode { get; set; }//tình trạng ra viện
        public string dischargestatusname { get; set; }
        public DateTime? examdate { get; set; }//ngày khám
        public DateTime? examdatefinish { get; set; }
        public int? dayofhi { get; set; }//ngày nghỉ BH
        public string advice { get; set; }//lời dặn
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }

    }
}
