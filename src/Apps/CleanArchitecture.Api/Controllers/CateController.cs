using Emr.Domain.Common;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.ReadModel.Sys.Modules;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services;
using Emr.Infrastructure.Services.Emr.Clinics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class CateController : ControllerBase
    {
        private readonly ICateServices CateServices;
        public CateController(ICateServices i_ICateServices)
        {
            CateServices = i_ICateServices;
        }

        //[Route("api/EMR/v1/Cates/GetCateCaching")]
        [Route("api/PHA/v1/Cates/GetCateICD10All")]
        [HttpGet]
        public async Task<ActionResult> GetCateCaching()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => CateServices.GetCateCaching());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        #region sysApi
        //[Route("api/EMR/v1/SysApi/{offset}/{limit}")]
        //[HttpGet]
        //public async Task<ActionResult> GetApiAll()
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => CateServices.GetApiAll());
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}
        #endregion
        #region Services
        [Route("api/PHA/v1/Cate/Services")]
        [HttpGet]
        public async Task<ActionResult> GetServiceCateAll()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => CateServices.GetCachingCateServiceCate());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        //[Route("api/PHA/v1/SYS/GetMenuAll")]
        [Route("api/PHA/v1/Inventory/GetMenuAll")]
        [HttpGet]
        public async Task<ActionResult> GetMenuAll()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => CateServices.GetMenuAll(1));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        #endregion

        //[Route("api/EMR/v1/Cates/GetLstCateLineByListCode")]
        //[HttpPost]
        //public async Task<ActionResult> GetLstCateLineByListCode([FromBody] IPara i_jsonData)
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => CateServices.GetLstCateLineByListCode(1,i_jsonData));
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}




        //[Route("api/EMR/v1/Cates/GetCateHospitalAll")]
        //[HttpGet]
        //public async  Task<ActionResult> GetCateHospitalAll()
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => CateServices.GetCateHospitalAll());
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}

        //[Route("api/EMR/v1/Cates/Depart")]
        //[HttpGet]
        //public async Task<ActionResult> GetCateDepartMedexaHLAll()
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => CateServices.GetCateDepartMedexaHLAll(1));
        //        sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}


        //[Route("api/EMR/v1/Cates/Depart/GetCateCateMedexaLAll")]
        //[HttpGet]
        //public async Task<ActionResult> GetCateCateMedexaLAll()
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => CateServices.GetCateCateMedexaLAll(1));
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
