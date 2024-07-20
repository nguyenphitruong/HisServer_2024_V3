using Emr.Domain.Model.Cache;
using Emr.Domain.ReadModel.Cates.Depart;
using Emr.Domain.ReadModel.Cates.Hospital;
using Emr.Domain.ReadModel.Cates.Icd10;
using Emr.Domain.ReadModel.Cates.ValueObject;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Modules;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cates
{
    public interface ICateRepository
    {
        CateCachingReadModel GetCateCaching();
        List<CateLineReadModel> GetAllCachingCateShareLine();
        List<CateICD10ReadModel> GetAllCachingCateICD10();
        List<CateHospitalReadModel> GetAllCachingCateHopital();
        List<SysApiConfigReadModel> GetApiAll();
        PayGroupCatePriceServiceReadModel GetCachingCateServiceCate();


        //List<CateLineReadModel> GetLstCateLineByListCode(int i_Siterf, IPara i_CarePara);
        //CateDepartMedexaHLReadModel GetCateDepartMedexaHLAll(int i_Siterf);
        List<CateMedexaLReadModel> GetCateMedexaLAll(int i_Siterf);
        List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf);
        //void GetCateCach();
        //void GetCateIcd10Caching();
        //void GetCateHospitalCaching();
        //List<CateCachingReadModel> GetCateICD10All();
        // List<CateHospitalReadModel> GetCateHospitalAll();
    }
}
