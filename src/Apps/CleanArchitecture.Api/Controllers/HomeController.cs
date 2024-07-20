using Emr.Domain.Model;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService i_HomeService)
        {
            homeService = i_HomeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHome(CancellationToken cancellationToken)
        {
            ServiceResponseResult sr = null;
            try
            {
                var retObj = await Task.Run(() => homeService.GetAllHome());
                sr = new ServiceResponseResult(CustomStatusCode.OK, nameof(CustomStatusCode.OK), retObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(sr);
        }

       // [HttpPost]
        //public async Task<ActionResult> Create(List<DistrictModel> i_DistrictModel)
        //{
        //    ServiceResponseResult sr = null;
        //    try
        //    {
        //        var retObj = await Task.Run(() => homeService.Create(i_DistrictModel));
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
