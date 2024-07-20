using Emr.Domain.Common;
using Emr.Domain.ReadModel.Emr.Clinic;
using System.Collections.Generic;

namespace Emr.Domain.Model.Emr.Clinics
{
    public interface IMediClinicRepository
    {
        List<MediClinicModel> GetAll();
        List<OutClinicPatientExamReadModel> GetListPatientWaitExamsBydate(IPara i_jsonIPara);
        bool SaveOutClinic(OutclinicModel i_ClinicModel);
        bool DeleteOutServicesOrder(string i_code, string i_uup);
        OutclinicReadModel GetOutClinicByCode(string i_code);
        List<OutclinicHisReadModel> GetListOutHisBypatcode(string i_patcode);
    }
}
