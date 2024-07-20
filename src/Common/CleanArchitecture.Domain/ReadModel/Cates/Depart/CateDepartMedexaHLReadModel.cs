using System.Collections.Generic;

namespace Emr.Domain.ReadModel.Cates.Depart
{
    public class CateDepartMedexaHLReadModel
    {
        public CateDepartMedexaHLReadModel()
        {
            LstCateDepart = new List<CateDepartReadModel>();
        }
        public List<CateDepartReadModel> LstCateDepart;
    }
}
