namespace Emr.Api.Controllers
{
    /// <summary>
    /// Creator Nguyễn Phi Trường
    /// Date 30/09/2109
    /// </summary>
    public class ResultController : ApiController
    {
        private readonly IResultServices ResultServices;
        public ResultController(IResultServices _IResultServices)
        {
            ResultServices = _IResultServices;
        }
        //[Route("api/v1/Result/GetAll")]
        //[HttpGet]
        //public async Task<ActionResult> GetAll([FromBody]JObject i_jsonData)
        //{
        //    ServiceResult sr = null;
        //    try
        //    {
        //        var retObj = ResultServices.GetAll();
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

        //[Route("api/v1/Result/GetID")]
        //[HttpPost]
        //public async Task<ActionResult> GetID([FromBody]PTParaModel i_Param)
        //{
        //    ServiceResult sr = null;
        //    try
        //    {
        //        var retObj = ResultServices.GetID(i_Param);
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
        //[Route("api/v1/Result")]
        //[HttpPost]
        //public async Task<ActionResult> Save([FromBody]ResultModel i_ResultModel)
        //{
        //    ServiceResult sr = null;
        //    try
        //    {
        //        //TestDTO _TestDTO = JsonConvert.DeserializeObject<TestDTO>(i_jsonData.ToString());

        //        var retObj = ResultServices.Save(i_ResultModel);
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
    }
}
