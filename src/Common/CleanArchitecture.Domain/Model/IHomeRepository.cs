using System;
using System.Collections.Generic;
using System.Text;

namespace Emr.Domain.Model
{
    public interface IHomeRepository
    {
        List<CateshareLineModel> GetAllHome();
        List<DistrictModel> Create(List<DistrictModel> i_DistrictModel);
    }
}
