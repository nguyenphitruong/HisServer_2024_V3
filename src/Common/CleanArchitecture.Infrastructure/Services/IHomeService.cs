using Emr.Domain.Model;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services
{
    public interface IHomeService
    {
        List<CateshareLineModel> GetAllHome();
        List<DistrictModel> Create(List<DistrictModel> i_DistrictModel);
    }
}
