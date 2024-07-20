using System.Collections.Generic;

namespace ServiceProvider
{
    public static class ServiceProviderManager
    {

        public static ICareWebApiServiceProvider icareWebApiService;

        static ServiceProviderManager()
        {
            try
            {
                if (lstHeadersDefault == null)
                    lstHeadersDefault = new Dictionary<string, string>();
                if (icareWebApiService == null)
                    icareWebApiService = new ICareWebApiServiceProvider();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public static Dictionary<string, string> lstHeadersDefault { get; set; }
        public static void SetHeaderDefault(Dictionary<string, string> i_lstHeaders)
        {
            try
            {
                if (i_lstHeaders != null && i_lstHeaders.Count > 0)
                {
                    foreach (var key in i_lstHeaders.Keys)
                    {
                        if (lstHeadersDefault.ContainsKey(key) == true)
                            lstHeadersDefault[key] = i_lstHeaders[key];
                        else
                            lstHeadersDefault.Add(key, i_lstHeaders[key]);
                    }

                    icareWebApiService.SetHeaderDefault(lstHeadersDefault);
                }
                
               
            }
            catch (System.Exception ex)
            {
                throw ex;                
            }

        }

        public static Dictionary<string, string> GetHeaderDefault()
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
    }
}
