using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Share.Patients;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.Share.Patient
{
    public interface IPatientService
    {
        PatientReadModel GetPatientBypatcode(string i_patcode);
        List<PatientReadModel> GetPatientByFindContent(string i_findcontent);
        PatientReadModel SavePatient(PatientModel i_PatientModel);

    }
}
