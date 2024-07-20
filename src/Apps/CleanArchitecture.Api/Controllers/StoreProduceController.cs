using Emr.Domain.Model.Share.Patient;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Share.Patient;
using Microsoft.AspNetCore.Mvc;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;
using System.Threading.Tasks;
using System;
using Emr.Infrastructure.Services.StoreProduce;
using Emr.Domain.Model.Share;
using System.Collections.Generic;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class StoreProduceController : ControllerBase
    {
        private readonly IStoreProduceService storeProduceService;
        public StoreProduceController(IStoreProduceService i_storeProduceService)
        {
            storeProduceService = i_storeProduceService;
        }
        [Route("api/EMR/v1/StoreProduce/{patcode}")]
        [HttpGet]
        public async Task<ActionResult> GetSP_InventoryBySchema(List<SchemasMMYYModel> i_Schemas)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => storeProduceService.GetSP_InventoryBySchema(i_Schemas));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        //[Route("api/EMR/v1/Patient/GetPatientByFindContent/{findcontent}")]
        //[HttpGet]
        //public async Task<ActionResult> GetPatientByFindContent(string findcontent)
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => patientService.GetPatientByFindContent(findcontent));
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}

        //[Route("api/EMR/v1/Patient")]
        //[HttpPost]
        //public async Task<ActionResult> SavePatient(PatientModel i_PatientModel)
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => patientService.SavePatient(i_PatientModel));
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}
    }
}
