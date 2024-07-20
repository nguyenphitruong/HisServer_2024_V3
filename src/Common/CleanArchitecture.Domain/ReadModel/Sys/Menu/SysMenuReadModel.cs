using Emr.Domain.Model.Sys.Menu;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Sys.Menu
{
    public class SysMenuReadModel : SysMenuModel
    {
        public int moduleId { get; set; } /**/
        public string modulecode { get; set; } /**/
        public string moduleName { get; set; } /**/
        public string moduleIconString { get; set; } /**/
        public int? moduleOrder { get; set; } /**/

       // public List<SysMenuReadModel> lstMenu;
        

        //public List<SysViewReadModel> lstView { get; set; }
        //public List<SysModuleReadModel> lstModule { get; set; }
    }
}
