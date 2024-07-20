using Emr.Domain.Common;
using System;

namespace Emr.Domain.ReadModel.Emr.Registers.ValuesObject
{
    public class BHYTObject : BaseModel
    {
        public int id { get; set; }
        public string codeCard { get; set; }
        public string codeHosp { get; set; }
        public string codeManager { get; set; }
        public string patcode { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public int gland { get; set; }
        public int? isYear { get; set; }
    }
}
