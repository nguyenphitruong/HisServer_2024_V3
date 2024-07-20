using ServiceProvider.Model;
using ServiceProvider;
using ServiceProviderCore.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Emr.Infrastructure.Constans;
using System.Configuration;
using Emr.Infrastructure.Hepper.Provider;
using ServiceProvider.Enum;

namespace Emr.Infrastructure.Repositories
{
    public class apiPublic : AbstracApiPublic
    {

        private Dictionary<string, object> lstService;
        private HttpClient httpClientService;
        private string contentType { get; set; } = "application/json";
        public Dictionary<string, string> lstHeadersDefault;
        private int timeoutDefault = 120;
        private TimeSpan timeout;
        protected string timeoutConfigName = "";

        public apiPublic()
        {
            timeoutConfigName = Constant.ConfigTagName_TimeOutCallICareApi;
            httpClientService = new HttpClient();
            httpClientService.Timeout = Timeout.InfiniteTimeSpan; //vo hieu timeout cua httpclient

            lstHeadersDefault = new Dictionary<string, string>();

            try
            {
                int timeoutConfig = int.Parse(ConfigurationManager.AppSettings[timeoutConfigName]);
                timeout = TimeSpan.FromSeconds(timeoutConfig);

            }
            catch (Exception)
            {
                timeout = TimeSpan.FromSeconds(timeoutDefault);
            }
        }

        private void GetListService()
        {
            try
            {
                string sysApiConfigUrl = ConfigurationManager.AppSettings[Constant.ConfigTagName_SysApiConfigUrl];

                var task = Task.Run(() => CallGetSysApiService(sysApiConfigUrl, null));
                task.Wait();
                DataObject result = JsonConverter.DeserializeJsonToObject<DataObject>(task.Result);
                if (ApiFunctions.CheckResultFromResponse(result) == true)
                {
                    List<SysServerModel> lstServer = JsonConverter.DeserializeJsonToObject<List<SysServerModel>>(result["Data"].ToString());

                    lstService = new Dictionary<string, object>();
                    foreach (SysServerModel itemServer in lstServer)
                    {
                        foreach (SysApiModel itemApi in itemServer.lstApiValueObject)
                        {
                            ServiceInfo serInfo = new ServiceInfo();
                            serInfo.id = itemApi.rowid;
                            serInfo.serverIP = itemServer.hostname;
                            serInfo.code = itemApi.code;
                            serInfo.module = itemApi.servercode;
                            serInfo.content = itemApi.url;
                            serInfo.method = itemApi.method;
                            //serInfo.version = itemApi.version;
                            if (!lstService.ContainsKey(serInfo.code))
                            {
                                lstService.Add(serInfo.code, serInfo);
                            }
                            else
                            {
                                throw new Exception("Trùng Key !");
                            }

                        }

                        //         Dictionary<string, object> lstServiceTemp = lstService;
                    }

                    if (lstService.Count <= 0)
                    {
                        throw new Exception("Không lấy được thông tin dịch vụ");
                    }
                }
                else
                {
                    throw new Exception("Không lấy được thông tin dịch vụ");
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

                return lstService[serviceCode] as ServiceInfo;
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
                HttpRequestMessage request = CreateRequest(HttpMethod.Get, i_Uri, i_Headers, null, null, null, null);
                return await SendRequest(request, timeout);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> CallApiServiceViettel(string i_ServiceCode, string i_ExtendURL, Dictionary<string, string> i_Headers, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri)
        {
            try
            {
                if (i_Headers == null)
                {
                    i_Headers = new Dictionary<string, string>();
                }
                i_Headers.Add("IdRequest", Guid.NewGuid().ToString());

                //ServiceInfo serInfo = GetService(i_ServiceCode);

                //string fullUri = serInfo.uri + "/" + i_ExtendURL;

                //fullUri = fullUri.Replace("//", "/");
                //fullUri = fullUri.Replace("http:/", "http://");
                //fullUri = fullUri.Replace("https:/", "https://");

                //fullUri = "https://api-vinvoice.viettel.vn/auth/login";
                //urlcreateInvoi = "https://api-vinvoice.viettel.vn/InvoiceAPI/InvoiceWS/createInvoice/0100109106-999";
                //fullUri = "https://api-vinvoice.viettel.vn/services/einvoiceapplication/api/InvoiceAPI/InvoiceWS/createInvoice/0100109106-999";
                //string fullUri = "http://egw.baohiemxahoi.gov.vn/api/token/take";
                //string fullUri1 = "http://egw.baohiemxahoi.gov.vn/api/egw/NhanLichSuKCB2018";
                ServiceInfo serInfo = new ServiceInfo();

                serInfo.method = "HttpPost";

                HttpRequestMessage request = null;
                switch (serInfo.method)
                {
                    case "HttpGet":
                        request = CreateRequest(HttpMethod.Get, fullUri, i_Headers, i_Parameter, null, null, null);
                        break;
                    case "HttpPost":
                        request = CreateRequest(HttpMethod.Post, fullUri, i_Headers, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader);
                        break;
                    case "HttpDelete":
                        request = CreateRequest(HttpMethod.Delete, fullUri, i_Headers, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader);
                        break;
                    case "HttpPut":
                        request = CreateRequest(HttpMethod.Put, fullUri, i_Headers, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader);
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

        private HttpRequestMessage CreateRequest(HttpMethod i_HttpMethod, string i_Uri, Dictionary<string, string> i_Headers, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader)
        {
            try
            {
                // tam thoi de test                
                // i_Uri = i_Uri.Replace("localhost:7770", "10.0.0.44:7770"); //EMR

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
                    //// add BodyJson
                    if (i_BodyJson != null)
                    {
                        request.Content = new StringContent(i_BodyJson, Encoding.UTF8, "application/json");
                    }
                    // add BodyTest
                    if (i_BodyText != null)
                    {
                        //string textBody = "supplierTaxCode=0100109106-999&invoiceNo=C22TYY93&strIssueDate=1646298015000&exchangeUser=0100109106-999";
                        request.Content = new StringContent(i_BodyText, Encoding.UTF8, "application/x-www-form-urlencoded");
                    }
                    //add BodyHeader
                    if (i_BodyHeader != null)
                    {
                        //Dictionary<string, string> test = new Dictionary<string, string>();
                        //test.Add("supplierTaxCode", "0100109106-999");
                        //test.Add("invoiceNo", "C22TYY93");
                        //test.Add("strIssueDate", "1646298015000");
                        //test.Add("exchangeUser", "0100109106-999");

                        request.Content = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");
                        foreach (var key in i_BodyHeader.Keys)
                        {
                            request.Content.Headers.Add(key, i_BodyHeader[key]);
                        }
                    }
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

                    //LogManager.LogError(response); //log sendRequest khong thanh cong                    

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
        public string CallServiceViettel(string i_ServiceCode, string i_ExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri)
        {
            try
            {
                var task = Task.Run(() => CallApiServiceViettel(i_ServiceCode, i_ExtendURL, i_HeadersPlus, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader, fullUri));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Goi Api
        /// </summary>
        /// <param name="i_ServiceCode">Code của api</param>
        /// <param name="i_ParaExtendURL">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng /, nối tiếp vào URL, không phải dạng ?</param>
        /// <param name="i_HeadersPlus">Các header ngoài danh sách header default</param>
        /// <param name="i_Parameter">Danh sách tham số để chuyển thành chuỗi gắn sau URL, dạng ?</param>
        /// <param name="i_BodyJson">Chuỗi dạng json được thêm vào body</param>
        /// <returns></returns>

        public string CallServiceViettel(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri)
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
                task = Task.Run(() => CallApiServiceViettel(i_ServiceCode.ToString(), extendURL, i_HeadersPlus, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader, fullUri));
                task.Wait();
                return task.Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public T CallServiceViettel<T>(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri)
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
                Task<string> task = Task.Run(() => CallApiServiceViettel(i_ServiceCode.ToString(), extendURL, i_HeadersPlus, i_Parameter, i_BodyJson, i_BodyText, i_BodyHeader, fullUri));
                task.Wait();

                return JsonConverter.DeserializeJsonToObject<T>(task.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
