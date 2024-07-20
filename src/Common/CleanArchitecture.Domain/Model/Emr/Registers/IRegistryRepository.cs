using Emr.Domain.Model.Emr.Register;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Domain.ReadModel.Emr.Registers;
using PT.DomainLayer.ReadModel._01.Medical.BHYT;
using System.Collections.Generic;

namespace Emr.Domain.Model.Emr.Registers
{
    public interface IRegistryRepository
    {
        List<RegisterReadModel> GetRegistryListByDate(string i_FromDate, string i_ToDate);
        RegisterReadModel GetRegistryByCodeAdmission(string i_CodeAdmission);
        //PatientReadModel GetPatientBypatcode(string i_patcode);
        List<RegisterHistoryReadModel> GetRegisterHistory(string i_patcode);
        //List<PatientReadModel> GetPatientByFindContent(string i_findcontent);

        RegisterSlipReadModel SaveRegister(RegisterModel i_MediRegisterModel);

        BHYTReadModel CheckExpertiseBHYT(int i_Siterf, BHYTGet i_CarePara);
    }
}
