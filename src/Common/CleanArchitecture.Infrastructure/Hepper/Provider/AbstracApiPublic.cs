using ServiceProvider.Enum;
using System.Collections.Generic;

namespace Emr.Infrastructure.Hepper.Provider
{
    interface AbstracApiPublic
    {
        string CallServiceViettel(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri);

        T CallServiceViettel<T>(ServiceCode i_ServiceCode, Dictionary<string, string> i_ParaExtendURL, Dictionary<string, string> i_HeadersPlus, Dictionary<string, string> i_Parameter, string i_BodyJson, string i_BodyText, Dictionary<string, string> i_BodyHeader, string fullUri);
    }
}
