using System;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Sys.Api
{
    public class SysApiConfigReadModel
    {
        public List<SysApiReadModel> lstApiValueObject { get; set; }
        public string idline { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string hostname { get; set; }
        public int? active { get; set; }
        public string ucr { get; set; }
        public string uup { get; set; }
        public DateTime? timecr { get; set; }
        public DateTime? timeup { get; set; }
        public string com { get; set; }
        public string mac { get; set; }
        public string ip { get; set; }
    }
}
