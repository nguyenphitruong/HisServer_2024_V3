using Emr.Domain.Model.Cache;
using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Modules;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services
{
    public interface ICateServices
    {
        //List<CateLineReadModel> GetLstCateLineByListCode(int i_Siterf, IPara i_CarePara);
        //CateDepartMedexaHLReadModel GetCateDepartMedexaHLAll(int i_Siterf);
        //List<CateMedexaLReadModel> GetCateCateMedexaLAll(int i_Siterf);
        //void GetCateCach();
        //void GetCateIcd10Caching();
        //void GetCateHospitalCaching();

        //List<CateHospitalReadModel> GetCateHospitalAll();
        //List<CateICD10ReadModel> GetCateICD10All();

        CateCachingReadModel GetCateCaching();
        List<SysApiConfigReadModel> GetApiAll();
        PayGroupCatePriceServiceReadModel GetCachingCateServiceCate();
        List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf);
    }
}
