using Emr.Domain.Common;

namespace Emr.Domain.Model.Cates.Depart
{
    public class CateMedexaLModel : BaseModel
    {
        public int siterf { get; set; }

        public int rowsid { get; set; }

        public string code { get; set; }

        public string codeh { get; set; }

        public string name { get; set; }

        public string servicevalues { get; set; }

        public int? active { get; set; }

    }
}
