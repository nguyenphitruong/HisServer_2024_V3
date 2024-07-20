using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Pha;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.Services.Share.Patient;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Services.StoreProduce
{
    public class StoreProduceService : IStoreProduceService
    {
        private IUnitOfWorkShare unitOfWork;

        public StoreProduceService(IUnitOfWorkShare i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public List<PHA_inventorylReadModel> GetSP_InventoryBySchema(List<SchemasMMYYModel> i_Schemas)
        {
            ;
            try
            {
                return unitOfWork.StoreProduceRepo.GetSP_InventoryBySchema(i_Schemas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<PatientReadModel> GetPatientByFindContent(string i_findcontent)
        //{
        //    try
        //    {
        //        return unitOfWork.PatientRepo.GetPatientByFindContent(i_findcontent);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public PatientReadModel SavePatient(PatientModel i_PatientModel)
        //{
        //    PatientReadModel _Result = new PatientReadModel();
        //    try
        //    {
        //        unitOfWork.InitTransaction();
        //        _Result = unitOfWork.PatientRepo.SavePatient(i_PatientModel);
        //        unitOfWork.Save();
        //        unitOfWork.CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        unitOfWork.RollbackTransaction();
        //        throw ex;
        //    }
        //    return _Result;
        //}

    }
}
