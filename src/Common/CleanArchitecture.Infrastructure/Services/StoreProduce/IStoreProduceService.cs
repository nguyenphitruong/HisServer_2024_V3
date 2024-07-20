using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.ReadModel.Pha;
using Emr.Domain.ReadModel.Share.Patients;
using System.Collections.Generic;

namespace Emr.Infrastructure.Services.StoreProduce
{
    public interface IStoreProduceService
    {
        List<PHA_inventorylReadModel> GetSP_InventoryBySchema(List<SchemasMMYYModel> i_Schemas);
        //List<PatientReadModel> GetPatientByFindContent(string i_findcontent);
        //PatientReadModel SavePatient(PatientModel i_PatientModel);
    }
}
