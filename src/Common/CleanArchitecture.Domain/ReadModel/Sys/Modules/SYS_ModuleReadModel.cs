using Emr.Domain.Entities.Sys.Menus;
using Emr.Domain.ReadModel.Sys.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.ReadModel.Sys.Modules
{
    public class SYS_ModuleReadModel
    {
        public SYS_ModuleReadModel()
        {
            chilren = new List<SYS_MenuReadModel>();
        }
        public int id { get; set; }
        public string modulecode { get; set; }
        public string modulename { get; set; }
        public string modulepath { get; set; }
        public string moduleicon { get; set; }
        public string note { get; set; }
        public int siterf { get; set; }
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }

        public List<SYS_MenuReadModel> chilren { get; set; }
    }
}
