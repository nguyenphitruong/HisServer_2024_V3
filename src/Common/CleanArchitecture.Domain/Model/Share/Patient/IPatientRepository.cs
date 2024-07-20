using Emr.Domain.ReadModel.Share.Patients;
using System.Collections.Generic;

namespace Emr.Domain.Model.Share.Patient
{
    public interface IPatientRepository
    {
        PatientReadModel GetPatientBypatcode(string i_patcode);
        List<PatientReadModel> GetPatientByFindContent(string i_findcontent);
        PatientReadModel SavePatient(PatientModel i_PatientModel);
    }
}
