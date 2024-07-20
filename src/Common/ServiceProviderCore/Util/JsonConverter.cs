using Newtonsoft.Json;

namespace ServiceProviderCore.Util
{
    public static class JsonConverter
    {
        public static T DeserializeJsonToObject<T>(string i_jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(i_jsonString);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string SerializeObjectToJson(object i_object)
        {
            try
            {
                return JsonConvert.SerializeObject(i_object);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
