using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Sys.Config
{
    public class ConfigClinicQueueModel : BaseModel
    {
        public int id { get; set; }
        public int siterf { get; set; }
        public string medexacode { get; set; }
        public int lastnum { get; set; }
        public DateTime dateused { get; set; }
        public int numdayreset { get; set; }
        public bool? isodd { get; set; }
        public int? step { get; set; }
        public int? valueinit { get; set; }
        public string descrp { get; set; }
    }
}
