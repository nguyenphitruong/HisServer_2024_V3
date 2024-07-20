using Emr.Domain.Model.Sys.PrintTemplates;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Sys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class SysController : ControllerBase
    {
        private readonly ISysServices SysServices;
        public SysController(ISysServices _ISysServices)
        {
            SysServices = _ISysServices;
        }

        #region sysAccounts
        //Get All Account
        [Route("api/v1/Sys/Account")]
        [HttpGet]
        public async Task<ActionResult> GetAccount()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetAccount());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysAccount/UpdateAccount/{i_Code}")]
        [HttpPost]
        public async Task<ActionResult> Update(string i_Code)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.Update(i_Code));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysAccount/Login/{i_UserName}/{i_Pass}")]
        [HttpGet]
        public async Task<ActionResult> Login(string i_UserName, string i_Pass)
        {
            //int i_Siterf = Convert.ToInt32(this.Request.Headers.GetValues("siterf").First());
            //string i_UserName = i_jsonData["username"].ToString();
            //string i_Pass = i_jsonData["password"].ToString();
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.Login(1, i_UserName, i_Pass));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysAccount/GetMenuByUsernameAndAppName/{i_Username}/{i_TypeUserCode}/{i_AppName}")]
        [HttpGet]
        public async Task<ActionResult> GetMenuByUsernameAndAppName(string i_Username, string i_TypeUserCode, string i_AppName)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetMenuByUsernameAndAppName(1, i_Username, i_TypeUserCode, i_AppName));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        #endregion

        #region sysApi
        [Route("api/EMR/v1/SysApi/{offset}/{limit}")]
        [HttpGet]
        public async Task<ActionResult> GetApiAll(int offset, int limit)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetApiAll(offset, limit));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        #endregion

        #region sysPrintTemplate
        [Route("api/EMR/v1/SysPrintTemplate/{offset}/{limit}")]
        [HttpGet]
        public async Task<ActionResult> GetPrintTemplatebySiterf(int offset, int limit)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetPrintTemplatebySiterf(1, offset, limit));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysPrintTemplate/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetPrintTemplatebyId(int id)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetPrintTemplatebyId(1, id));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysPrintTemplate/GetPrintTemplatebyCode/{Code}")]
        [HttpGet]
        public async Task<ActionResult> GetPrintTemplatebyCode(string code)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetPrintTemplatebyCode(1, code));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        [Route("api/EMR/v1/SysPrintTemplate")]
        [HttpPost]
        public async Task<ActionResult> CreatePrintTemplate([FromBody] SysPrintTemplateModel i_SysPrintTemplateDTO)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.CreatePrintTemplate(1, i_SysPrintTemplateDTO));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }


        [Route("api/EMR/v1/SysPrintTemplate/{i_IdLine}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePrintTemplate(int i_IdLine)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.DeletePrintTemplate(1, i_IdLine));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }


        [Route("api/EMR/v1/SysPrintTemplate")]
        [HttpPut]
        public async Task<ActionResult> UpdatePrintTemplate([FromBody] SysPrintTemplateModel i_SysPrintTemplateDTO)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.UpdatePrintTemplate(1, i_SysPrintTemplateDTO));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        #endregion
        #region sysconfig
        [Route("api/EMR/v1/SysConfig")]
        [HttpGet]
        public async Task<ActionResult> GetSysConfigByCode()
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.GetSysConfigByCode(1, "i_Code"));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        #endregion 

        //Get All Services
        //[Route("api/v1/Sys/Services")]
        //[HttpGet]
        //public async Task<ActionResult> GetServices()
        //{
        //    ServiceResult sr = null;
        //    try
        //    {
        //        var retObj = _SysServices.GetServices();
        //        sr = new ServiceResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (ValidatorExeption ex)
        //    {
        //        sr = new ServiceResult(CustomStatusCode.BadRequest, nameof(CustomStatusCode.BadRequest), ex);
        //        LogManager.LogError(ex);

        //        HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, sr);
        //        return new ResponseMessageResult(responseMessage);
        //    }
        //    catch (LogicException ex)
        //    {
        //        sr = new ServiceResult(CustomStatusCode.LogicError, nameof(CustomStatusCode.LogicError), ex);
        //        LogManager.LogError(ex);
        //        HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, sr);
        //        return new ResponseMessageResult(responseMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        sr = new ServiceResult(CustomStatusCode.BadRequest, nameof(CustomStatusCode.BadRequest), ex);
        //        LogManager.LogError(ex);
        //        HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, sr);
        //        return new ResponseMessageResult(responseMessage);
        //    }
        //    return Ok(sr);
        //}

        #region sysApi
        [Route("api/EMR/v1/SysCreateStructureData/{i_mmyy}")]
        [HttpGet]
        public async Task<ActionResult> CreateStructureDataNew(string i_mmyy)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => SysServices.CreateStructureDataNew(i_mmyy));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        #endregion
    }

}
