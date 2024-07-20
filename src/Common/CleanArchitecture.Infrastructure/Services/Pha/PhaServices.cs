using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Pha.StoreImport;
using Emr.Domain.ReadModel.Pha;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Pha
{
    public class PhaServices : IPhaServices
    {
        private IUnitOfWork unitOfWork;
        public PhaServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public List<PHA_inventorylReadModel> GetDrugInventoryByStore()
        {
            try
            {
                return unitOfWork.PhaRepo.GetDrugInventoryByStore();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PHA_inventorylReadModel> GetDrugInventoryByStoreTest()
        {
            try
            {
                return unitOfWork.PhaRepo.GetDrugInventoryByStoreTest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PHA_inventorylReadModel> GetInventoryByConfig(int i_Siterf, string i_ObjectCode, string i_MedexalCode, int i_TypeExportCode, int i_TypeStoreCode)
        {
            try
            {
                return unitOfWork.PhaRepo.GetInventoryByConfig(i_Siterf, i_ObjectCode, i_MedexalCode, i_TypeExportCode, i_TypeStoreCode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SaveStoreImport(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, int i_Option)
        {
            string bResult = string.Empty;
            try
            {
                unitOfWork.InitTransaction();
                bResult = unitOfWork.PhaRepo.SaveStoreImport(i_Siterf, i_PHA_storeimporthModel, i_Option);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
            return bResult;
        }
        public string SavePrecription(int i_Siterf, int i_ObjectCode, PHA_prescriptionhModel i_PrescriptionhModel, int i_Option)
        {
            string bResult = string.Empty;
            try
            {
                unitOfWork.InitTransaction();
                bResult = unitOfWork.PhaRepo.SavePrecription(i_Siterf, i_ObjectCode, i_PrescriptionhModel, i_Option);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
            return bResult;
        }
    }
}
