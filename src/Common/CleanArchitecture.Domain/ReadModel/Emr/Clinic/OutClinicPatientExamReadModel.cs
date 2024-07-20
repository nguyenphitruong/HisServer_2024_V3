using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using System;

namespace Emr.Domain.ReadModel.Emr.Clinic
{
    public class OutClinicPatientExamReadModel
    {
        public int siterf { get; set; }
        public string managercode { get; set; }
        public string patcode { get; set; }
        public string name { get; set; }
        public string sexname { get; set; }
        public string birthday { get; set; }
        public string birthyear { get; set; }
        public string age { get; set; }
        public int? phonenumber { get; set; }
        public string address { get; set; }
        public string objectcode { get; set; }
        public string objectname { get; set; }
        public string nohi { get; set; }
        public int? live { get; set; }
        public int? ratehi { get; set; }
        public DateTime? strday { get; set; }
        public DateTime? endday { get; set; }
        public string servicecode { get; set; }
        public string servicename { get; set; }
        public string medexacode { get; set; }
        public string medexaname { get; set; }
        public DateTime registerdate { get; set; }
        public DateTime examdate { get; set; }
        public DateTime? examfinishdate { get; set; }
        public int paid { get; set; } // 0: chưa khám, 1: đang khám, 2: chuyển phòng, 3: Đã hoàn tất ca khám
        public int done { get; set; } // 0: chưa khám, 1: đang khám, 2: chuyển phòng, 3: Đã hoàn tất ca khám
        public int finish { get; set; } // 0: chưa khám, 1: đang khám, 2: chuyển phòng, 3: Đã hoàn tất ca khám
        public int status { get; set; } // 0: chưa khám, 1: đang khám, 2: chuyển phòng, 3: Đã hoàn tất ca khám
        public int active { get; set; } // 0: chưa khám, 1: đang khám, 2: chuyển phòng, 3: Đã hoàn tất ca khám
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime? timecr { get; set; }
        public DateTime? timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string mmyy { get; set; }
        public string reson { get; set; }
        public PatientSuvivalReadModel Suvival { get; set; }
        public OutclinicReadModel OutclinicCurent { get; set; }
        //public List<OutclinicHisReadModel> LstOutclinicHis { get; set; }

        //public List<TreeViewHReadModel> LstOutclinicHis { get; set; }
    }
}
