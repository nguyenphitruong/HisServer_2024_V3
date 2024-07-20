using Emr.Domain.Common;

namespace Emr.Domain.Model.Pay.Services
{
    public class PayGroupServiceModel : BaseModel
    {

        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public int? active { get; set; }

        public string ucr { get; set; }

    }
}
