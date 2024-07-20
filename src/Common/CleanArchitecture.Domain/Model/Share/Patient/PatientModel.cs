using Emr.Domain.Common;
using Emr.Domain.Model.Share.Patient.ValuesObject;

namespace Emr.Domain.Model.Share.Patient
{
    public class PatientModel : BaseModel
    {
        public PatientModel()
        {
            PatientHi = new PatientHiModel();
            PatientRelation = new PatientRelationModel();
            PatientSuvival = new PatientSuvivalModel();
        }
        public int rowsid { get; set; }
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
        public string sexname { get; set; }
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

        public string findcontent { get; set; }


        public PatientHiModel PatientHi { get; set; }
        public PatientRelationModel PatientRelation { get; set; }
        public PatientSuvivalModel PatientSuvival { get; set; }

    }
}
