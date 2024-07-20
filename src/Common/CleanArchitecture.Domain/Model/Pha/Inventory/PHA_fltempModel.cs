using Emr.Domain.Common;
using System;

namespace Emr.Domain.Model.Pha.Inventory
{
    public class PHA_fltempModel : BaseModel
    {
        public string idline { get; set; }
        public string followid { get; set; }
        public string idh { get; set; }
        public string codeh { get; set; }
        public string storecode { get; set; }
        public int? qtyreq { get; set; }
        public int? qtyapp { get; set; }
        public string note { get; set; }
        public string datalog { get; set; }
        public string mmyy { get; set; }
        public string yyyy { get; set; }
        public int? siterf { get; set; }
        public int? active { get; set; }

    }
}
