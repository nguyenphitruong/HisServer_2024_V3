using System;

namespace ServiceProvider.Model
{
    public partial class SysApiModel
    {
        public int rowid { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string url { get; set; }
        public string method { get; set; }
        public string fullurl { get; set; }
        public string servercode { get; set; }
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
