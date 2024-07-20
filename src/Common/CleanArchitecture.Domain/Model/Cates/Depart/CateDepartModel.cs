using Emr.Domain.Common;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cates.Depart.Depart
{
    public class CateDepartModel : BaseModel
    {
        public CateDepartModel()
        {
            LstCateMedexaH = new List<CateMedexaHModel>();
        }
        public int siterf { get; set; }
        public int rowsid { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool? istreament { get; set; }
        public int? active { get; set; }

        public List<CateMedexaHModel> LstCateMedexaH;

    }
}
