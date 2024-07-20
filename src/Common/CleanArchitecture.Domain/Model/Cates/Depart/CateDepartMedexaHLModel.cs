using Emr.Domain.Common;
using Emr.Domain.Model.Cates.Depart.Depart;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cates.Depart
{
    public class CateDepartMedexaHLModel : BaseModel
    {
        public CateDepartMedexaHLModel()
        {
            LstCateDepart = new List<CateDepartModel>();
        }
        public List<CateDepartModel> LstCateDepart;
    }
}
