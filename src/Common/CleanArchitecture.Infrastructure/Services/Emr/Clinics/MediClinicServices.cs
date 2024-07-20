using Emr.Domain.Common;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.ReadModel.Emr.Clinic;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Emr.Clinics
{
    public class MediClinicServices : IMediClinicServices
    {
        private IUnitOfWork unitOfWork;

        public MediClinicServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }

        public List<MediClinicModel> GetAll()
        {
            try
            {
                return unitOfWork.ClinicRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OutClinicPatientExamReadModel> GetListPatientWaitExamsBydate(IPara i_jsonICarePara)
        {
            try
            {
                return unitOfWork.ClinicRepository.GetListPatientWaitExamsBydate(i_jsonICarePara);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public OutclinicReadModel GetOutClinicByCode(string i_code)
        {
            try
            {
                return unitOfWork.ClinicRepository.GetOutClinicByCode(i_code);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool SaveOutClinic(OutclinicModel i_ClinicModel)
        {
            bool bResult = false;
            try
            {
                unitOfWork.InitTransaction();
                bResult = unitOfWork.ClinicRepository.SaveOutClinic(i_ClinicModel);
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
        public bool DeleteOutServicesOrder(string i_code, string i_uup)
        {
            bool bResult = false;
            try
            {
                unitOfWork.InitTransaction();
                bResult = unitOfWork.ClinicRepository.DeleteOutServicesOrder(i_code, i_uup);
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


        public List<OutclinicHisReadModel> GetListOutHisBypatcode(string i_patcode)
        {
            try
            {
                return unitOfWork.ClinicRepository.GetListOutHisBypatcode(i_patcode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
