using Emr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.ReadModel.Cates.ValueObject
{
    public class CateHeaderReadModel: BaseModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string des { get; set; }
        public int acttive { get; set; }
    }
}
