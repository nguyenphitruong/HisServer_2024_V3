using Emr.Domain.Common;

namespace Emr.Domain.Model.Sys.Config
{
    public class SysconfigModel : BaseModel
    {
        public string idline { get; set; }
        public string code { get; set; }
        public string objcode { get; set; }
        public string objname { get; set; }
        public string objtype { get; set; }
        public int objlength { get; set; }
        public string objctl { get; set; }
        public string objcate { get; set; }
        public string descrp { get; set; }
        public int sort { get; set; }
        public string valcon { get; set; }
        public string label { get; set; }
    }
}
