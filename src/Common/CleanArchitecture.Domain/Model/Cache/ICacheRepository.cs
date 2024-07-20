using Emr.Domain.ReadModel.Pay.Services;
using Emr.Domain.ReadModel.Sys.Api;
using Emr.Domain.ReadModel.Sys.Modules;
using System.Collections.Generic;

namespace Emr.Domain.Model.Cache
{
    public interface ICacheRepository
    {
        CateCachingReadModel GetCateCaching();
        List<SysApiConfigReadModel> GetApiAll();
        PayGroupCatePriceServiceReadModel GetCachingCateServiceCate();
        List<SYS_ModuleReadModel> GetMenuAll(int i_Siterf);

    }
}
