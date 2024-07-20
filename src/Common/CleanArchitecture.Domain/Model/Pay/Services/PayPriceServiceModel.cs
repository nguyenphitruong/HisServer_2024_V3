using Emr.Domain.Common;

namespace Emr.Domain.Model.Pay.Services
{
    public class PayPriceServiceModel : BaseModel
    {
        public int id { get; set; }

        public string groupservicescode { get; set; }

        public string groupservicesname { get; set; }

        public string cateservicescode { get; set; }

        public string cateservicesname { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string bhytcode { get; set; }

        public string bhytname { get; set; }

        public int? ischeck { get; set; }

        public string unitcode { get; set; }

        public string unitname { get; set; }

        public decimal? ofprice { get; set; }

        public decimal? hiprice { get; set; }

        public decimal? serprice { get; set; }

        public decimal? difprice { get; set; }

        public int? ishi { get; set; }

        public int? vat { get; set; }

        public int active { get; set; }
        public int? qty { get; set; }


    }
}
