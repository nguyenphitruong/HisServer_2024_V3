using Emr.Domain.Model.Emr.Register;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Emr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    //   [Route("api/[controller]")]
    // [Route("api")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegistryServices RegistryServices;
        public RegisterController(IRegistryServices _IRegistryServices)
        {
            RegistryServices = _IRegistryServices;
        }


        #region RegisterInfo
        [Route("api/v1/Medical/Registry/GetRegistryListByDate/{i_FromDate}/{i_ToDate}")]
        [HttpGet]
        public async Task<ActionResult> GetRegistryListByDate(string i_FromDate, string i_ToDate)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetRegistryListByDate(i_FromDate, i_ToDate));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }
        /// <summary>
        /// Example
        /// </summary>
        /// <returns></returns>
        [Route("api/v1/Medical/Registry/GetRegistryByCodeAdmission/{i_CodeAdmission}")]
        [HttpGet]
        public async Task<ActionResult> GetRegistryByCodeAdmission(string i_CodeAdmission)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetRegistryByCodeAdmission(i_CodeAdmission));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        /// <summary>
        /// Example
        /// </summary>
        /// <returns></returns>
        [Route("api/EMR/v1/Medical/Register/GetRegisterHistory/{patcode}")]
        [HttpGet]
        public async Task<ActionResult> GetRegisterHistory(string patcode)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.GetRegisterHistory(patcode));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }


        [Route("api/EMR/v1/Register/SaveRegister")]
        //[Route("api/EMR/v1/Patient")]
        [HttpPost]
        //public async Task<ActionResult> Create(List<DistrictModel> i_DistrictModel, CancellationToken cancellationToken)
        public async Task<ActionResult> SaveRegister([FromBody] RegisterModel i_RegisterModel)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.SaveRegister(i_RegisterModel));
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

        //[Route("api/EMR/v1/Patient/a")]
        //[HttpPost]
        //public async Task<ActionResult> Create(List<PatientHiModel> i_DistrictModel)
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //       // var retObj = await Task.Run(() => homeService.Create(i_DistrictModel));
        //       // sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return Ok(sr);
        //}
        #endregion


        /// <summary>
        /// Check cổng giám định BHYT
        /// </summary>
        /// sample={"maThe":"DN4797413001617","hoTen":"NGUYỄN PHI TRƯỜNG","ngaySinh":"19/08/1988"}
        /// <param name="i_CarePara"></param>
        /// <returns></returns>
        [Route("api/PHA/v1/Patient/CheckExpertiseBHYT")]
        [HttpPost]
        public async Task<ActionResult> CheckExpertiseBHYT( BHYTGet i_CarePara)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => RegistryServices.CheckExpertiseBHYT(1, i_CarePara));
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
