using Emr.Domain.Model.Share.Patient;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Share.Patient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        public PatientController(IPatientService i_PatientService)
        {
            patientService = i_PatientService;
        }
        [Route("api/PHA/v1/Patient/{patcode}")]
        [HttpGet]
        public async Task<ActionResult> GetPatientBypatcode(string patcode)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => patientService.GetPatientBypatcode(patcode));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            //catch (Exception ex)
            //{
            //    sr = new ServiceResponseResult(CustomStatusCode.BadRequest, nameof(CustomStatusCode.BadRequest), ex);
            //    LogManager.LogError(ex);
            //    HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, sr);
            //    return new ResponseMessageResult(responseMessage);
            //}
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/Patient/GetPatientByFindContent/{findcontent}")]
        [HttpGet]
        public async Task<ActionResult> GetPatientByFindContent(string findcontent)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => patientService.GetPatientByFindContent(findcontent));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/PHA/v1/Patient")]
        [HttpPost]
        public async Task<ActionResult> SavePatient(PatientModel i_PatientModel)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => patientService.SavePatient(i_PatientModel));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
    }
}
