using Emr.Domain.Common;

namespace Emr.Domain.Model.Sys.Menu
{
    public class SysMenuModel : BaseModel
    {
        public int moduleId { get; set; } /**/
        public string modulecode { get; set; } /**/
        public string moduleName { get; set; } /**/
        public string moduleIconString { get; set; } /**/
        public int? moduleOrder { get; set; } /**/

        public int id { get; set; } /**/
        public string code { get; set; } /*code*/
        public string name { get; set; } /*tên*/
        public string descr { get; set; } /*Mô tả*/
        public string iconstring { get; set; }
        public int order { get; set; }
        public int? active { get; set; } /*Trạng thái sử dụng*/

        //public List<SysViewModel> lstView { get; set; }
        //public List<SysModuleModel> lstModule { get; set; }
        public string appname { get; set; }
        public string nameview { get; set; }
    }
}
