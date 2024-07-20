using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Emr.Registers
{
    public class ClinicQueueModel : BaseModel
    {
        public int id { get; set; }
        public int siterf { get; set; }
        public string patcode { get; set; }
        public string managercode { get; set; }
        public string serviceidline { get; set; }
        public string servicecode { get; set; }
        public string servicename { get; set; }
        public string medexacode { get; set; }
        public string medexaname { get; set; }
        public string codearea { get; set; }
        public int ordinal { get; set; }
        public string priobcode { get; set; }
        public int status { get; set; }
        public DateTime? beginwait { get; set; }
        public DateTime? endwait { get; set; }
        public DateTime? overdate { get; set; }
        public int active { get; set; }
    }
}
