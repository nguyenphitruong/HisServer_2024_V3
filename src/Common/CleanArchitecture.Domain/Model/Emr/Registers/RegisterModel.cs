using Emr.Domain.Common;
using Emr.Domain.Model.Emr.Registers.ValuesObject;
using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using System;
using System.Collections.Generic;

namespace Emr.Domain.Model.Emr.Register
{
    public class RegisterModel : BaseModel
    {
        public RegisterModel()
        {
            Patient = new PatientModel();
            RegisterHi = new RegisterHiModel();
            ServicesOrder = new List<EmrServicesOrderModel>();
        }

        public int rowsid { get; set; }
        public string linkid { get; set; }
        public string indepartmentid { get; set; }
        public string medexacode { get; set; }
        public string medexaname { get; set; }
        public string patcode { get; set; }
        public Guid patcodeid { get; set; }
        public string doctorcode { get; set; }
        public DateTime? registerdate { get; set; }
        public string objectcode { get; set; }
        public string objectname { get; set; }
        public String addressfull { get; set; }
        public int? phonenumber { get; set; }
        public int? done { get; set; }
        public int? ispatientnew { get; set; }

        public string patienttype { get; set; }
        public string placetransfercode { get; set; }
        public string placeIntrocode { get; set; }
        public string reson { get; set; }
        public int? active { get; set; }

        public PatientModel Patient { get; set; }
        public RegisterHiModel RegisterHi { get; set; }
        public List<EmrServicesOrderModel> ServicesOrder { get; set; }
    }
}
