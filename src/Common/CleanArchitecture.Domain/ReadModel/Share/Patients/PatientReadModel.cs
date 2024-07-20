using Emr.Domain.Common;
using Emr.Domain.ReadModel.Emr.Registers;
using Emr.Domain.ReadModel.Share.Patients.ValuesObject;
using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Share.Patients
{
    public class PatientReadModel : BaseModel
    {
        //public PatientReadModel()
        //{
        //    PatientHi = new PatientHiReadModel();
        //    PatientRelation = new PatientRelationReadModel();
        //    PatientSuvival = new PatientSuvivalReadModel();
        //}

        public string patcode { get; set; }
        public string patid { get; set; }
        public string name { get; set; }
        public string nameunsiger { get; set; }
        public string birthday { get; set; }
        public string birthyear { get; set; }
        public int? age { get; set; }
        public int? phonenumber { get; set; }
        public string email { get; set; }
        public int? agecode { get; set; }
        public int sexcode { get; set; }
        public int jobcode { get; set; }
        public int nationcode { get; set; }
        public int nationNatycode { get; set; }
        public int religioncode { get; set; }
        public string village { get; set; }
        public string citycode { get; set; }
        public string districtcode { get; set; }
        public string wardscode { get; set; }
        public string addresworkplace { get; set; }
        public string barcode { get; set; }
        public string relationcode { get; set; }
        public int? Ischildren { get; set; }
        public int? active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime? timecr { get; set; }
        public DateTime? timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string mmyy { get; set; }

        public string findcontent { get; set; }
        public PatientHiReadModel PatientHi { get; set; }
        //public PatientRelationReadModel PatientRelation { get; set; }
        public PatientSuvivalReadModel PatientSuvival { get; set; }
        public List<RegisterHistoryReadModel> RegisterHistory { get; set; }


    }
}
