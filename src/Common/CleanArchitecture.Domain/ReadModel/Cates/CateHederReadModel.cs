using Emr.Domain.Common;

namespace Emr.Domain.ReadModel.Cates
{
    public class CateHederReadModel : BaseModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string des { get; set; }
    }
}
