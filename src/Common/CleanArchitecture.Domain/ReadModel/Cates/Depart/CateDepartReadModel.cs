using Emr.Domain.Model.Cates.Depart.Depart;
using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Cates.Depart
{
    public class CateDepartReadModel : CateDepartModel
    {
        public CateDepartReadModel()
        {
            LstCateMedexaH = new List<CateMedexaHReadModel>();
        }

        public List<CateMedexaHReadModel> LstCateMedexaH;
    }
}
