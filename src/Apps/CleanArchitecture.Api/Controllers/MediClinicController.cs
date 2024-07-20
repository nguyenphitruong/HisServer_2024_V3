using Emr.Domain.Common;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Emr.Clinics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class MediClinicController : ControllerBase
    {
        private readonly IMediClinicServices RegistryServices;
        public MediClinicController(IMediClinicServices _IRegistryServices)
        {
            RegistryServices = _IRegistryServices;
        }

        [Route("api/EMR/v1/OutClinic/GetListPatientWaitExamsBydate")]
        [HttpPost]
        public async Task<ActionResult> GetListPatientWaitExamsBydate([FromBody] IPara i_jsonICarePara)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetListPatientWaitExamsBydate(i_jsonICarePara));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/OutClinic/GetOutClinicByCode/{i_code}")]
        [HttpGet]
        public async Task<ActionResult> GetOutClinicByCode(string i_code)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetOutClinicByCode(i_code));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/OutClinic")]
        [HttpPost]
        public async Task<ActionResult> SaveOutClinic([FromBody] OutclinicModel i_ClinicModel)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.SaveOutClinic(i_ClinicModel));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        [Route("api/EMR/v1/OutClinic/DeleteOutServicesOrder")]
        [HttpPut]
        public async Task<ActionResult> DeleteOutServicesOrder(string i_code)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.DeleteOutServicesOrder(i_code,"userup"));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }


        [Route("api/EMR/v1/OutClinic/GetListOutHisBypatcode/{i_patcode}")]
        [HttpGet]
        public async Task<ActionResult> GetListOutHisBypatcode(string i_patcode)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetListOutHisBypatcode(i_patcode));
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
