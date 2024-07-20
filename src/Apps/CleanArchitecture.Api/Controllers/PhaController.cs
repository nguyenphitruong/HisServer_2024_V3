using Emr.Application.Common.Models;
using Emr.Domain.Model.Pha.Prescription;
using Emr.Domain.Model.Pha.StoreImport;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.Model.Test;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Emr;
using Emr.Infrastructure.Services.Pha;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class PhaController : ControllerBase
    {
        private readonly IPhaServices PhaServices;
        private string i_UserName;
        public PhaController(IPhaServices i_PhaServices)
        {
            PhaServices = i_PhaServices;
        }
        //[Route("api/PHA/v1/Inventory/GetDrugInventoryByStore")]
        [Route("api/PHA/v1/Inventory/GetDrugInventoryByStore")]
        [HttpGet]
        public async Task<ActionResult> GetDrugInventoryByStore()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => PhaServices.GetDrugInventoryByStore());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);


        }
        [Route("api/PHA/v1/Inventory/GetDrugInventoryByStoreTest")]
        [HttpGet]
        public async Task<ActionResult> GetDrugInventoryByStoreTest()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => PhaServices.GetDrugInventoryByStoreTest());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);


        }

        [Route("api/PHA/v1/Inventory/GetInventoryByConfig/{i_ObjectCode}/{i_MedexalCode}/{i_TypeExportCode}/{i_TypeStoreCode}")]
        [HttpGet]
        public async Task<ActionResult> GetInventoryByConfig(string i_ObjectCode, string i_MedexalCode, int i_TypeExportCode, int i_TypeStoreCode)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => PhaServices.GetInventoryByConfig(1, i_ObjectCode, i_MedexalCode, i_TypeExportCode, i_TypeStoreCode));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (LogicException ex)
            {
                sr = new ServiceResponseResult(CustomStatusCode.LogicError, nameof(CustomStatusCode.LogicError), ex);
                //LogManager.LogError(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/PHA/v1/StoreImport/SaveStoreImport")]
        [HttpPost]
        public async Task<ActionResult> SaveStoreImport(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, int i_Option)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => PhaServices.SaveStoreImport(1, i_PHA_storeimporthModel, i_Option));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (LogicException ex)
            {
                sr = new ServiceResponseResult(CustomStatusCode.LogicError, nameof(CustomStatusCode.LogicError), ex);
                //LogManager.LogError(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/PHA/v1/Precription/SavePrecription")]
        [HttpPost]
        public async Task<ActionResult> SavePrecription(int i_Siterf, int i_ObjectCode, PHA_prescriptionhModel i_PrescriptionhModel, int i_Option)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => PhaServices.SavePrecription(1, i_ObjectCode, i_PrescriptionhModel, i_Option));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (LogicException ex)
            {
                sr = new ServiceResponseResult(CustomStatusCode.LogicError, nameof(CustomStatusCode.LogicError), ex);
                //LogManager.LogError(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/PHA/v1/PostTest")]
        [HttpPost]
        //public async Task<ActionResult> SaveStoreImport(int i_Siterf, PHA_storeimporthModel i_PHA_storeimporthModel, int i_Option)
        public async Task<ActionResult> PostTest(int i_Siterf, TestModel i_TestModel)
        {
            ServiceResponseResult sr = null;
            try
            {
                //var retObj = await Task.Run(() => PhaServices.SaveStoreImport(1, i_PHA_storeimporthModel, i_Option));
                //var retObj = await Task.Run(() => PhaServices.SaveStoreImport(1, i_PHA_storeimporthModel, 1));

                var retObj = await Task.Run(() => PhaServices.GetDrugInventoryByStore());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (LogicException ex)
            {
                sr = new ServiceResponseResult(CustomStatusCode.LogicError, nameof(CustomStatusCode.LogicError), ex);
                //LogManager.LogError(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }


    }
}
