using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Hepper.Provider
{
    public static class Common
    {
        public static string GetConnectionStringFromAppConfig(string i_connectionStringName)
        {
            try
            {
                string connectionStrEncrypt = ConfigurationManager.ConnectionStrings[i_connectionStringName].ConnectionString;
                //AesEncrypt aes = new AesEncrypt();
                //string connectionStrDecrypt = aes.Decrypt(connectionStrEncrypt);
                //return connectionStrDecrypt;
                return connectionStrEncrypt;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
    }
}
