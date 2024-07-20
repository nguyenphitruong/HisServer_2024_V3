using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Pha.StoreImport;
using Emr.Domain.ReadModel.Pha;
using System;
using System.Collections.Generic;

namespace PT.DomainLayer.AggregatesModel.Pha
{
    public interface IPhaRepository
    {
        List<PHA_inventorylReadModel> GetDrugInventoryByStore();
        List<PHA_inventorylReadModel> GetDrugInventoryByStoreTest();
        List<PHA_inventorylReadModel> GetInventoryByConfig(int i_Siterf, string i_ObjectCode, string i_MedexalCode, int i_TypeExportCode, int i_TypeStoreCode);
        string SaveStoreImport(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, int i_Option);
        string SavePrecription(int i_Siterf, int i_ObjectCode, PHA_prescriptionhModel i_PrescriptionhModel, int i_Option);
    }
}
