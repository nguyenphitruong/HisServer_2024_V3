using Emr.Domain.Common;

namespace Emr.Domain.ReadModel.Cates.ValueObject
{
    public class CateLineReadModel : BaseModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string codeh { get; set; }
        public string parent { get; set; }
        public string acro { get; set; }
        public string name { get; set; }
        public string des { get; set; }
    }
}
