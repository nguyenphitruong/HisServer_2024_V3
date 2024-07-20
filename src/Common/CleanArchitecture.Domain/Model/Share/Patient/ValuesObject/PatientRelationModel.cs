using System;

namespace Emr.Domain.Model.Share.Patient.ValuesObject
{
    public class PatientRelationModel
    {
        public int rowsid { get; set; }
        public string patcode { get; set; }
        public string relationcode { get; set; }
        public string relationname { get; set; }
        public string relationcultural { get; set; }

    }
}
