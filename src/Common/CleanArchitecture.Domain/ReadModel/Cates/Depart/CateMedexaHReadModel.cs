using Emr.Domain.Model.Cates.Depart;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Cates.Depart
{
    public class CateMedexaHReadModel : CateMedexaHModel
    {
        public CateMedexaHReadModel()
        {
            LstCateMedexaL = new List<CateMedexaLReadModel>();
        }
        public List<CateMedexaLReadModel> LstCateMedexaL;
    }
}
