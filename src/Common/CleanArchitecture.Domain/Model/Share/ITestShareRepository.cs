using Emr.Domain.ReadModel.Pha;
using System.Collections.Generic;

namespace Emr.Domain.Model.Share
{
    public interface ITestShareRepository
    {
        List<PHA_inventorylReadModel> GetDrugInventoryByStoreTest();

    }
}
