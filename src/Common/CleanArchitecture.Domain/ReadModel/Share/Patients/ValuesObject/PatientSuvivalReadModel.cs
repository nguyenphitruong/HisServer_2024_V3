using System;

namespace Emr.Domain.ReadModel.Share.Patients.ValuesObject
{
    public class PatientSuvivalReadModel
    {
        public int rowsid { get; set; }
        public string circuit { get; set; }
        public string heat { get; set; }
        public string pressure { get; set; }
        public string breathing { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string patcode { get; set; }
        public string recordscode { get; set; }
        public int? type { get; set; }
        public int? active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime timecr { get; set; }
        public DateTime timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string ip { get; set; }
        public DateTime mmyy { get; set; }
    }
}
