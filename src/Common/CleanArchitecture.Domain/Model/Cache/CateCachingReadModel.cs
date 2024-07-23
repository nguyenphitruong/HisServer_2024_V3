using Emr.Domain.ReadModel.Cates.Hospital;
using Emr.Domain.ReadModel.Cates.Icd10;
using Emr.Domain.ReadModel.Cates.ValueObject;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cache
{
    public class CateCachingReadModel
    {
        public CateCachingReadModel()
        {
            LstCachingCateShareHeader = new List<CateLineReadModel>();
            LstCachingCateShareLine = new List<CateLineReadModel>();
            LstCachingCateICD10 = new List<CateICD10ReadModel>();
            LstCachingCateHopital = new List<CateHospitalReadModel>();
        }

        public List<CateLineReadModel> LstCachingCateShareHeader { get; set; }
        public List<CateLineReadModel> LstCachingCateShareLine { get; set; }
        public List<CateICD10ReadModel> LstCachingCateICD10 { get; set; }
        public List<CateHospitalReadModel> LstCachingCateHopital { get; set; }
    }
}
