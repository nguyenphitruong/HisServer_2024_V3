using Emr.Domain.Common;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.ReadModel.Emr.Clinic;
//using PT.DomainLayer.ReadModel._01.Medical.Clinic;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Emr.Clinics
{
    public interface IMediClinicServices
    {
        List<MediClinicModel> GetAll();
        List<OutClinicPatientExamReadModel> GetListPatientWaitExamsBydate(IPara i_jsonICarePara);
        bool SaveOutClinic(OutclinicModel i_ClinicModel);
        bool DeleteOutServicesOrder(string i_code, string i_uup);
        OutclinicReadModel GetOutClinicByCode(string i_code);
        List<OutclinicHisReadModel> GetListOutHisBypatcode(string i_patcode);
    }
}
