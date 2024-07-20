using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services.Pay.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesServices ServicesServices;
        public ServicesController(IServicesServices i_IServicesServices)
        {
            ServicesServices = i_IServicesServices;
        }
        /// <summary>
        /// Example
        /// </summary>
        /// <returns></returns>
        //[Route("api/PAY/v1/Services")]
        //[HttpGet]
        //public async Task<ActionResult> GetServiceCateAll()
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => ServicesServices.GetServiceCateAll());
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
