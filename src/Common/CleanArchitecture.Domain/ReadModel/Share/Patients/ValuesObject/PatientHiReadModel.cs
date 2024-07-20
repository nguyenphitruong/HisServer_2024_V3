using System;

namespace Emr.Domain.ReadModel.Share.Patients.ValuesObject
{
    public class PatientHiReadModel
    {
        public int rowsid { get; set; }
        public string numbercode { get; set; }
        public string idlink { get; set; }
        public string patcode { get; set; }
        public System.DateTime? fromdate { get; set; }
        public System.DateTime? totate { get; set; }
        public int gland { get; set; }
        public bool? isYear { get; set; }
        public byte[] img { get; set; }
        public string filePath { get; set; }
        public int? active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime timecr { get; set; }
        public DateTime timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string ip { get; set; }
        public bool? isusing { get; set; }
    }
}
