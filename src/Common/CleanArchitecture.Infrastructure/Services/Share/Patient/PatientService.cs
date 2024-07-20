using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Emr.Registers;
using Emr.Domain.ReadModel.Share.Patients;
using Emr.Infrastructure.UniOfWork;
using System;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Share.Patient
{
    public class PatientService : IPatientService
    {
        private IUnitOfWorkShare unitOfWork;

        public PatientService(IUnitOfWorkShare i_UnitOfWork)
        {
            unitOfWork = i_UnitOfWork;
        }
        public PatientReadModel GetPatientBypatcode(string i_patcode)
        {
            try
            {
                return unitOfWork.PatientRepo.GetPatientBypatcode(i_patcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PatientReadModel> GetPatientByFindContent(string i_findcontent)
        {
            try
            {
                return unitOfWork.PatientRepo.GetPatientByFindContent(i_findcontent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientReadModel SavePatient(PatientModel i_PatientModel)
        {
            PatientReadModel _Result = new PatientReadModel();
            try
            {
                unitOfWork.InitTransaction();
                _Result = unitOfWork.PatientRepo.SavePatient(i_PatientModel);
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

    }
}
