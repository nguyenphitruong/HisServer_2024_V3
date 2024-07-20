using Emr.Domain.Common;
using Emr.Domain.Model.Share;
using Emr.Domain.ReadModel.Emr.Registers.ValuesObject;
using Emr.Domain.ReadModel.Share.Patients;
using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Emr.Registers
{
    public class RegisterReadModel : BaseModel
    {
        public RegisterReadModel()
        {
            patient = new PatientReadModel();
            registerHi = new RegisterHiReadModel();
            lstServicesOrderModel = new List<EmrServicesOrderModel>();
        }
        public int rowsid { get; set; }
        public string managecode { get; set; }
        public string indepartmentid { get; set; }
        public string medexacode { get; set; }
        public string medexaname { get; set; }
        public string patcode { get; set; }
        public string doctorcode { get; set; }
        public DateTime? registerdate { get; set; }
        public string objectcode { get; set; }
        public string objectname { get; set; }
        
        public String addressfull { get; set; }
        public int? phonenumber { get; set; }
        public int? done { get; set; }
        public bool? ispatientnew { get; set; }

        public string patienttype { get; set; }
        public string paceregistercode { get; set; }
        public string placetransfercode { get; set; }
        public string placeIntrocode { get; set; }
        public string reson { get; set; }
        public int active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime? timecr { get; set; }
        public DateTime? timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string ip { get; set; }

        public PatientReadModel patient { get; set; }
        public RegisterHiReadModel registerHi { get; set; }
        public List<EmrServicesOrderModel> lstServicesOrderModel { get; set; }
    }
}
