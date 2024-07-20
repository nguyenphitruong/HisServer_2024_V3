using System;

namespace Emr.Domain.ReadModel.Share
{
    public class CaGetCodeReadModel
    {
        public string code { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string begin { get; set; }
        public string end { get; set; }
        public DateTime? year { get; set; }
        public int? step { get; set; }
        public int? values { get; set; }
        public int? maxValues { get; set; }
    }
}
