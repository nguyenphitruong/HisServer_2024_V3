using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.Entities.Sys.Menus
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;


    [Table("SYS_menu")]
    public partial class SYS_menu
    {
        [Key]
        public int id { get; set; }
        public string modulecode { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string icon { get; set; }
        public string component { get; set; }
        public string layout { get; set; }
        public string modulepath { get; set; }
        public string note { get; set; }
        public int siterf { get; set; }
        public int active { get; set; }
        public string usercr { get; set; }
        public DateTime timecr { get; set; }
        public string userup { get; set; }
        public DateTime timeup { get; set; }
        public string computer { get; set; }
        public string mac { get; set; }

    }
}
