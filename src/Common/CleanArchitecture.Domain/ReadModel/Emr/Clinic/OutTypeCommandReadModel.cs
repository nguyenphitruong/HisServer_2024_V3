using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Emr.Clinic
{
    public class OutTypeCommandReadModel
    {
        public string managecode { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public List<OutItemOrderReadModel> LstItem { get; set; }

    }
}
