using Emr.Domain.Model.Emr.Register;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Domain.ReadModel.Emr.Registers;
using Newtonsoft.Json.Linq;
using PT.DomainLayer.ReadModel._01.Medical.BHYT;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Emr
{
    public interface IRegistryServices
    {
        List<RegisterReadModel> GetRegistryListByDate(string i_FromDate, string i_ToDate);
        RegisterReadModel GetRegistryByCodeAdmission(string i_CodeAdmission);
        List<RegisterHistoryReadModel> GetRegisterHistory(string i_patcode);
        RegisterSlipReadModel SaveRegister(RegisterModel i_MediRegisterModel);
        BHYTReadModel CheckExpertiseBHYT(int i_Siterf, BHYTGet i_CarePara);
    }
}
