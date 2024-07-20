using ServiceProviderCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProviderCore.Util
{
    public static class ApiFunctions
    {
        public static bool CheckResultFromResponse(DataObject i_dobData)
        {
            try
            {
                if (i_dobData != null)
                {
                    if (i_dobData[ConstColumnName.Code].ToString() == ((int)EnumResultAPI.OK).ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new Exception("DataObject rỗng");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
