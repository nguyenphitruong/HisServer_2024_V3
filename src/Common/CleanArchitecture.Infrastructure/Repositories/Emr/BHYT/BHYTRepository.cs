using Emr.Domain.Model.Share.BHYT;
using Emr.Domain.ReadModel.Emr.BHYT;
using Emr.Infrastructure.Constans;
using Emr.Infrastructure.Hepper.Exceptions;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PT.DomainLayer.ReadModel._01.Medical.BHYT;
using ServiceProvider.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emr.Infrastructure.Repositories.BHYT
{
    public class BHYTRepository
    {
        //public string strSend;
        public string strResult;
        private string strBody;
        apiPublic apiServiceProvider;
        private MyDbShareContext dbContext;
        public BHYTRepository(MyDbShareContext i_Context)
        {
            dbContext = i_Context;
            apiServiceProvider = new apiPublic();
        }


        public BHYTReadModel BHYTResponse(int i_Siterf, BHYTGet i_CarePara)
        {
            BHYTReadModel result = new BHYTReadModel();
            try
            {
                //string username = ConfigurationManager.AppSettings["Username"];
                //string password = ConfigurationManager.AppSettings["Password"];
                List<string> lstCodeSysSetting = new List<string>();

                lstCodeSysSetting.Add(ConstantColumn.UserNameBHYT.ToString());
                lstCodeSysSetting.Add(ConstantColumn.PasswordBHYT.ToString());

                //var lstSysSettingSelect = dbContext.syssettings.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1 && lstCodeSysSetting.Contains(x.code)).Select(s => new { s.code, s.strvalues }).ToList();
                //var lstSysSettingSelect = dbContext.sysAccounts.AsNoTracking().Where(x => x.siterf == i_Siterf && x.active == 1).ToList();


                //if (lstSysSettingSelect.Count == 0)
                //{
                //    throw new LogicException("Không lấy đươc thông tin tài khoản Giám định BHYT từ Syssetting! Vui lòng kiểm tra lại !");
                //}
                //else
                //{
                //string username = lstSysSettingSelect.Where(x => x.empcode == ConstColumnName.UserNameBHYT.ToString()).Select(s => s.strvalues).FirstOrDefault();
                //string password = lstSysSettingSelect.Where(x => x.empcode == ConstColumnName.PasswordBHYT.ToString()).Select(s => s.strvalues).FirstOrDefault();

                string username = "79768_BV";
                string password = "57f714a5c454f9a64ad3e69c1abb6ecc";

                Dictionary<string, string> lstHeadersDefault = new Dictionary<string, string>();

                lstHeadersDefault.Add(ConstantColumn.siterf, i_Siterf.ToString());
                lstHeadersDefault.Add(ConstantColumn.username, "");
                lstHeadersDefault.Add(ConstantColumn.token, "");

                Dictionary<string, string> jsonBody = new Dictionary<string, string>();
                apiServiceProvider.SetHeaderDefault(lstHeadersDefault);

                jsonBody.Add(ConstantColumn.username, username);
                jsonBody.Add(ConstantColumn.password, password);

                strBody = JsonConvert.SerializeObject(jsonBody);
                //string i_ServiceCode, string i_ExtendURL, Dictionary< string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary< string, string> i_BodyHeader
                string fullUri = "http://egw.baohiemxahoi.gov.vn/api/token/take";
                strResult = apiServiceProvider.CallServiceViettel("BHYTGetToken", null, null, null, strBody, null, null, fullUri);


                JObject jResult = JsonConvert.DeserializeObject<JObject>(strResult);
                KQPhienLamViecReadModel plv = new KQPhienLamViecReadModel();
                plv = JsonConvert.DeserializeObject<KQPhienLamViecReadModel>(jResult.ToString());
                //Nếu OK =>Lấy thông tin thẻ BHYT và lịch sử khám chữa bệnh 
                if (plv.APIKey != null)
                {
                    Dictionary<string, string> i_Parameter = new Dictionary<string, string>();
                    i_Parameter.Add(ConstantColumn.token, plv.APIKey.access_token);
                    i_Parameter.Add(ConstantColumn.id_token, plv.APIKey.id_token);

                    i_Parameter.Add(ConstantColumn.username, username);
                    i_Parameter.Add(ConstantColumn.password, password);

                    //string fullUri1 = "https://egw.baohiemxahoi.gov.vn/api/egw/KQNhanLichSuKCB2024";
                    string fullUri1 = "http://egw.baohiemxahoi.gov.vn/api/egw/api/egw/NhanLichSuKCB2018";

                    string i_JsonBodyBHYTFuction = JsonConvert.SerializeObject(i_CarePara);
                    string strResultBHYTFuction = apiServiceProvider.CallServiceViettel("BHYTFuction", null, null, i_Parameter, i_JsonBodyBHYTFuction, null, null, fullUri1);
                    JObject jResultBHYTFuction = JsonConvert.DeserializeObject<JObject>(strResultBHYTFuction);
                    result = JsonConvert.DeserializeObject<BHYTReadModel>(strResultBHYTFuction);
                }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
