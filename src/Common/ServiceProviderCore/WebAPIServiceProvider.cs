using ServiceProvider.Enum;
using ServiceProvider.Model;
using ServiceProviderCore.Enum;
using ServiceProviderCore.Util;
using System.Text;
using JsonConverter = ServiceProviderCore.Util.JsonConverter;

namespace ServiceProvider
{
    public class ICareWebApiServiceProvider : IServiceProvider
    {

        private Dictionary<string, object> lstService;
        private HttpClient httpClientService;
        private string contentType { get; set; } = "application/json";
        public Dictionary<string, string> lstHeadersDefault;
        private int timeoutDefault = 120;
        private TimeSpan timeout;

        public ICareWebApiServiceProvider()
        {
            httpClientService = new HttpClient();
            httpClientService.Timeout = Timeout.InfiniteTimeSpan; //vo hieu timeout cua httpclient

            lstHeadersDefault = new Dictionary<string, string>();

            try
            {
                int timeoutConfig = 200;
                if (timeoutConfig > 0)
                {
                     timeoutConfig = 200;
                    timeout = TimeSpan.FromSeconds(timeoutConfig);
                }
                else
                    timeout = TimeSpan.FromSeconds(timeoutDefault);

            }
            catch (Exception)
            {
                timeout = TimeSpan.FromSeconds(timeoutDefault);
            }
        }

        private async Task<string> GetListClientSettingByComputerName(string i_ExtendURL, Dictionary<string, string> i_HeadersPlus)
        {
            try
            {
                //string fullUri = ClientInfoModel.sysApiClientSettingURL + i_ExtendURL;
                string fullUri = i_ExtendURL;

                HttpRequestMessage request = CreateRequest(HttpMethod.Get, fullUri, i_HeadersPlus, null, null);
                return await SendRequest(request, timeout);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void GetListService()
        {
            try
            {
                //api/EMR/v1/SysApi/{offset}/{limit}
                //     string urlapi = ConfigurationManager.AppSettings[Constant.SysApiURL];
                string urlapi = "https://localhost:5001/api/EMR/v1/SysApi/0/1000";
                //urlapi = urlapi.Replace("5001","5000");
                //   var task = Task.Run(() => CallGetSysApiService(ClientInfoModel.sysApiConfigUrl, null));
                var task = Task.Run(() => CallGetSysApiService(urlapi, null));
                task.Wait();
                DataObject result = JsonConverter.DeserializeJsonToObject<DataObject>(task.Result);

                if (ApiFunctions.CheckResultFromResponse(result) == true)
                {
                    List<SysServerModel> lstServer = JsonConverter.DeserializeJsonToObject<List<SysServerModel>>(result[ConstColumnName.Data].ToString());

                    lstService = new Dictionary<string, object>();
                    foreach (SysServerModel itemServer in lstServer)
                    {
                        foreach (SysApiModel itemApi in itemServer.lstApiValueObject)
                        {
                            ServiceInfo serInfo = new ServiceInfo();
                            serInfo.id = itemApi.rowid;
                            serInfo.serverIP = itemServer.code;
                            serInfo.code = itemApi.code.TrimEnd();
                            serInfo.module = itemApi.model;
                            serInfo.content = itemApi.fullurl;
                            serInfo.method = itemApi.method;
                            // serInfo.version = itemApi.version;
                            if (!lstService.ContainsKey(serInfo.code))
                            {
                                lstService.Add(serInfo.code, serInfo);
                            }
                            else
                            {
                                throw new Exception("Trùng Key !");
                            }
                        }
                    }

                    if (lstService.Count <= 0)
                    {
                        throw new Exception("Không lấy được thông tin dịch vụ");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ServiceInfo GetService(string serviceCode)
        {
            try
            {
                if (lstService == null || lstService.Count <= 0)
                    GetListService();

                return lstService[serviceCode.Trim()] as ServiceInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> CallGetSysApiService(string i_Uri, Dictionary<string, string> i_Headers)
        {
            try
            {
                HttpRequestMessage request = CreateRequest(HttpMethod.Get, i_Uri, i_Headers, null, null);
                return await SendRequest(request, timeout);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> CallApiService(string i_ServiceCode, string i_ExtendURL, Dictionary<string, string> i_Headers, Dictionary<string, string> i_Parameter, string i_BodyJson)
        {
            try
            {
                if (i_Headers == null)
                {
                    i_Headers = new Dictionary<string, string>();
                }
                i_Headers.Add("IdRequest", Guid.NewGuid().ToString());

                ServiceInfo serInfo = GetService(i_ServiceCode);
                string fullUri = serInfo.uri;
                if (i_ExtendURL.Length > 0)
                {
                    fullUri = serInfo.uri + "/" + i_ExtendURL;
                    fullUri = fullUri.Replace(" ", "");
                }
                fullUri = fullUri.Replace("//", "/");
                fullUri = fullUri.Replace("https:/", "https://").TrimEnd();


                HttpRequestMessage request = null;
                switch (serInfo.method.Trim())
                {
                    case "HttpGet":
                        request = CreateRequest(HttpMethod.Get, fullUri, i_Headers, i_Parameter, null);
                        break;
                    case "HttpPost":
                        request = CreateRequest(HttpMethod.Post, fullUri, i_Headers, i_Parameter, i_BodyJson);
                        break;
                    case "HttpDelete":
                        request = CreateRequest(HttpMethod.Delete, fullUri, i_Headers, i_Parameter, i_BodyJson);
                        break;
                    case "HttpPut":
                        request = CreateRequest(HttpMethod.Put, fullUri, i_Headers, i_Parameter, i_BodyJson);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                return await SendRequest(request, timeout);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private HttpRequestMessage CreateRequest(HttpMethod i_HttpMethod, string i_Uri, Dictionary<string, string> i_Headers, Dictionary<string, string> i_Parameter, string i_BodyJson)
        {
            try
            {
                //// tam thoi de test                            
                i_Uri = i_Uri.Replace("5001","5000");

                //i_Uri = i_Uri.Replace("10.0.0.44:7770", "localhost:7770"); //EMR
                //i_Uri = i_Uri.Replace("10.0.0.44:7771", "localhost:7771"); //PHA
                //i_Uri = i_Uri.Replace("10.0.0.44:7772", "localhost:7772"); //PAY
                //i_Uri = i_Uri.Replace("10.0.1.21:7776", "10.0.1.51:7776"); //RIS
                //i_Uri = i_Uri.Replace("10.0.1.21:7778", "10.0.1.51:7778"); //LIS


                //i_Uri = i_Uri.Replace("10.0.0.44:7770", "localhost:7770"); //EMR
                //i_Uri = i_Uri.Replace("10.0.0.44:7771", "localhost:7771"); //PHA
                //i_Uri = i_Uri.Replace("10.0.0.44:7772", "localhost:7772"); //PAY

                //i_Uri = i_Uri.Replace("10.0.0.44:7776", "localhost:7776"); //RIS
                //i_Uri = i_Uri.Replace("10.0.0.44:7778", "localhost:7778"); //LIS

                //i_Uri = i_Uri.Replace("10.0.0.44:7770", "localhost:7770");
                //i_Uri = i_Uri.Replace("10.0.1.51:7770", "localhost:7770");

                UriBuilderExt builder = new UriBuilderExt(i_Uri);
                // add parameter
                if (i_Parameter != null && i_Parameter.Count > 0)
                {
                    foreach (var key in i_Parameter.Keys)
                    {
                        builder.AddParameter(key, i_Parameter[key]);
                    }
                }

                HttpRequestMessage request = new HttpRequestMessage(i_HttpMethod, builder.Uri);

                if (request != null)
                {
                    // add header default
                    if (lstHeadersDefault != null && lstHeadersDefault.Count > 0)
                    {
                        foreach (var key in lstHeadersDefault.Keys)
                        {
                            request.Headers.Add(key, lstHeadersDefault[key]);
                        }
                    }

                    // add header
                    if (i_Headers != null && i_Headers.Count > 0)
                    {
                        foreach (var key in i_Headers.Keys)
                        {
                            request.Headers.Add(key, i_Headers[key]);
                        }
                    }

                    // add body
                    if (i_BodyJson != null)
                    {
                        request.Content = new StringContent(i_BodyJson, Encoding.UTF8, "application/json");
                    }

                    //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);                           
                }

                return request;
            }
            catch (HttpRequestException ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_Request"></param>
        /// <param name="i_TimeOut">Second Timeout</param>
        /// <returns></returns>
        private async Task<string> SendRequest(HttpRequestMessage i_Request, TimeSpan i_TimeOut)
        {
            try
            {

                CancellationTokenSource source = new CancellationTokenSource();
                source.CancelAfter(i_TimeOut);
                CancellationToken cancellationToken = source.Token;

                using (var response = await httpClientService.SendAsync(i_Request, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    string servermessage = String.Empty;
                    if (response.IsSuccessStatusCode)
                        return await StreamToStringAsync(stream);
                    else
                        servermessage = await StreamToStringAsync(stream);
                   // LoggerForSerilog2.LogError(response); //log sendRequest khong thanh cong

                    switch (response.StatusCode)
                    {
                        case System.Net.HttpStatusCode.Unauthorized:
                            throw new System.UnauthorizedAccessException(response.ToString());
                        case System.Net.HttpStatusCode.Forbidden:
                            throw new System.UnauthorizedAccessException(response.ToString());
                        case System.Net.HttpStatusCode.RequestTimeout:
                            throw new System.TimeoutException();
                        default:
                            throw new HttpRequestException(String.Format("Client:{0} Server: {1}", response.ToString(), servermessage));
                    }

                }
            }
            catch (TaskCanceledException ex)
            {
                throw new TimeoutException("Time out exception :", ex);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        public void SetHeaderDefault(Dictionary<string, string> i_lstHeaders)
        {
            try
            {
                if (i_lstHeaders != null && i_lstHeaders.Count > 0)
                {
                    List<string> lstKey = new List<string>(i_lstHeaders.Keys);

                    foreach (string key in lstKey)
                    {
                        if (lstHeadersDefault.ContainsKey(key) == true)
                            lstHeadersDefault[key] = i_lstHeaders[key];
                        else
                            lstHeadersDefault.Add(key, i_lstHeaders[key]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> GetHeaderDefault()
        {
            try
            {
                return lstHeadersDefault;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Gọi api
        /// </summary>
        /// <param name="i_ServiceCode">Code của api</param>
        /// <param name="i_HeadersPlus">Các header ngoài danh sách header default</param>
        /// <param name="i_Parameter">Danh sách tham số</param>
        /// <param name="i_BodyJson">Chuỗi dạng json được thêm vào body</param>
        /// <returns></returns>
        //public string CallService(string i_ServiceCode, string i_ExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson)
        //{
        //    try
        //    {
        //        var task = Task.Run(() => CallApiService(i_ServiceCode, i_ExtendURL, i_HeadersPlus, i_Parameter, i_BodyJson));
        //        task.Wait();
        //        return task.Result;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Goi Api
        /// </summary>
        /// <param name="i_ServiceCode">Code của api</param>
        /// <param name="i_ParaExtendURL">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng /, nối tiếp vào URL, không phải dạng ?</param>
        /// <param name="i_HeadersPlus">Các header ngoài danh sách header default</param>
        /// <param name="i_Parameter">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng ?</param>
        /// <param name="i_BodyJson">Chuỗi dạng json được thêm vào body</param>
        /// <returns></returns>

        public string CallService(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson)
        {
            try
            {
                string extendURL = "";
                if (i_ParaExtendURL != null && i_ParaExtendURL.Count > 0)
                {
                    foreach (var key in i_ParaExtendURL.Keys)
                    {
                        extendURL = string.Format("{0}/{1}", extendURL, i_ParaExtendURL[key]);
                    }
                }

                Task<string> task = null;

                if (i_ServiceCode == ServiceCode.GetListClientSettingByComputerName)
                {
                    task = Task.Run(() => GetListClientSettingByComputerName(extendURL, i_HeadersPlus));
                }
                else
                {
                    task = Task.Run(() => CallApiService(i_ServiceCode.ToString(), extendURL, i_HeadersPlus, i_Parameter, i_BodyJson));
                }
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Goi Api tra ve ket qua la object kieu T
        /// </summary>
        /// <param name="i_ServiceCode">Code của api</param>
        /// <param name="i_ParaExtendURL">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng /, nối tiếp vào URL, không phải dạng ?</param>
        /// <param name="i_HeadersPlus">Các header ngoài danh sách header default</param>
        /// <param name="i_Parameter">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng ?</param>
        /// <param name="i_BodyJson">Chuỗi dạng json được thêm vào body</param>
        /// <returns></returns>

        public T CallService<T>(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson)
        {
            try
            {
                string extendURL = "";
                if (i_ParaExtendURL != null && i_ParaExtendURL.Count > 0)
                {
                    foreach (var key in i_ParaExtendURL.Keys)
                    {
                        extendURL = string.Format("{0}/{1}", extendURL, i_ParaExtendURL[key]);
                    }
                }

                Task<string> task = null;

                if (i_ServiceCode == ServiceCode.GetListClientSettingByComputerName)
                {
                    task = Task.Run(() => GetListClientSettingByComputerName(extendURL, i_HeadersPlus));
                }
                else
                {
                    task = Task.Run(() => CallApiService(i_ServiceCode.ToString(), extendURL, i_HeadersPlus, i_Parameter, i_BodyJson));
                }
                task.Wait();

                return JsonConverter.DeserializeJsonToObject<T>(task.Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public T CallServiceAutoConvert<T>(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson)
        {
            try
            {
                string extendURL = "";
                if (i_ParaExtendURL != null && i_ParaExtendURL.Count > 0)
                {
                    foreach (var key in i_ParaExtendURL.Keys)
                    {
                        extendURL = string.Format("{0}/{1}", extendURL, i_ParaExtendURL[key]);
                    }
                }

                Task<string> task = null;

                if (i_ServiceCode == ServiceCode.GetListClientSettingByComputerName)
                {
                    task = Task.Run(() => GetListClientSettingByComputerName(extendURL, i_HeadersPlus));
                }
                else
                {
                    task = Task.Run(() => CallApiService(i_ServiceCode.ToString(), extendURL, i_HeadersPlus, i_Parameter, i_BodyJson));
                }
                task.Wait();

                DataObject resultDob = JsonConverter.DeserializeJsonToObject<DataObject>(task.Result);
                if (ApiFunctions.CheckResultFromResponse(resultDob) == true)
                {
                    return JsonConverter.DeserializeJsonToObject<T>(resultDob[ConstColumnName.Data].ToString());
                }
                else
                {
                    DataObject error = JsonConverter.DeserializeJsonToObject<DataObject>(resultDob[ConstColumnName.Data].ToString());
                    throw new Exception(error[ConstColumnName.Message].ToString());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
