using Emr.Domain.Common;
using System;

namespace Emr.Domain.ReadModel.Share
{
    public class PayServicesOrderReadModel : BaseModel
    {
        public int id { get; set; }
        public string codeServicesOrder { get; set; }
        public string codeAdmission { get; set; }
        public string codeManager { get; set; }
        public string codeIndepartment { get; set; }
        public int codeClinic { get; set; }
        public string patcode { get; set; }
        public int codeDoctor { get; set; }
        public int typePatient { get; set; }
        public int codeObject { get; set; }
        public DateTime dateServicesOrder { get; set; }
        public string codeServices { get; set; }
        public int codeTypeServices { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public int paid { get; set; }
        public int done { get; set; }
        public int finish { get; set; }
        public string codeIcd10 { get; set; }
        public string nameIcd10 { get; set; }
    }
}
