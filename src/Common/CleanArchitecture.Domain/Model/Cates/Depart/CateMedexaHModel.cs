using Emr.Domain.Common;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cates.Depart
{
    public class CateMedexaHModel : BaseModel
    {
        public CateMedexaHModel()
        {
            LstCateMedexaL = new List<CateMedexaLModel>();
        }
        public int siterf { get; set; }
        public int rowsid { get; set; }
        public string code { get; set; }
        public string departcode { get; set; }
        public string name { get; set; }
        public int? active { get; set; }

        public List<CateMedexaLModel> LstCateMedexaL;
    }
}
