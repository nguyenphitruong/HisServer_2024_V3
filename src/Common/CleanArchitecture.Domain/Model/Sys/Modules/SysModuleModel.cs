using Emr.Domain.Common;
using Emr.Domain.Model.Sys.Menu;
using System.Collections.Generic;

namespace Emr.Domain.Model.Sys.Modules
{
    public class SysModuleModel : BaseModel
    {
        public int id { get; set; } /**/
        public string code { get; set; } /*code*/
        public string name { get; set; } /**/
        public string nameview { get; set; }
        public string descr { get; set; } /**/
        public string iconstring { get; set; } /**/
        public int? active { get; set; } /*Trạng thái sử dụng*/
        public int? order { get; set; }
        public List<SysMenuModel> lstMenu { get; set; }
    }
}
