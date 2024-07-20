using Emr.Domain.Common;
using System.Collections.Generic;

namespace Emr.Domain.Model.Sys.Api
{
    public class SysServerModel : BaseModel
    {
        public string codeServer { get; set; }
        public string nameServer { get; set; }
        public string hostName { get; set; }
        public int? active { get; set; }
        public List<SysServicesModel> lstSysServicesModel { get; set; }
    }
}
