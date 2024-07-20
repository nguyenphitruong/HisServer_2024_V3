using ServiceProvider.Enum;
using System.Collections.Generic;

namespace ServiceProvider
{
    interface IServiceProvider
    {        
        string CallService(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson);

        T CallService<T>(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson);
    }
}
