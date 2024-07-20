using Emr.Domain.Model.Emr.Register;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Domain.ReadModel.Emr.Registers;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.UniOfWork;
using Newtonsoft.Json.Linq;
using PT.DomainLayer.ReadModel._01.Medical.BHYT;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Emr
{
    public class RegistryServices : IRegistryServices
    {
        private IUnitOfWork unitOfWork;

        public RegistryServices(IUnitOfWork i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public RegisterReadModel GetRegistryByCodeAdmission(string i_CodeAdmission)
        {
            try
            {
                return unitOfWork.RegisterRepo.GetRegistryByCodeAdmission(i_CodeAdmission);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<RegisterHistoryReadModel> GetRegisterHistory(string i_patcode)
        {
            try
            {
                return unitOfWork.RegisterRepo.GetRegisterHistory(i_patcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<RegisterReadModel> GetRegistryListByDate(string i_FromDate, string i_ToDate)
        {
            try
            {
                return unitOfWork.RegisterRepo.GetRegistryListByDate(i_FromDate, i_ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RegisterSlipReadModel SaveRegister(RegisterModel i_MediRegisterModel)
        {
            RegisterSlipReadModel _Result = new RegisterSlipReadModel();
            try
            {
                unitOfWork.InitTransaction();
                _Result = unitOfWork.RegisterRepo.SaveRegister(i_MediRegisterModel);
                unitOfWork.Save();
                unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                throw ex;
            }
            return _Result;
        }
        public BHYTReadModel CheckExpertiseBHYT(int i_Siterf, BHYTGet i_CarePara)
        {
            try
            {
                return unitOfWork.RegisterRepo.CheckExpertiseBHYT(i_Siterf, i_CarePara);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
