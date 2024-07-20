using System;
using System.Collections.Generic;

namespace ServiceProvider.Model
{    
    public partial class SysServerModel
    {
        public int rowid { get; set; }
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
        public List<SysApiModel> lstApiValueObject { get; set; }
    }
}
