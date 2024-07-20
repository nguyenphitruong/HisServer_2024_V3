using static Emr.Infrastructure.Hepper.Provider.CustomEnum;

namespace Emr.Infrastructure.Hepper.Provider
{
    public class ServiceResponseResult
    {

        public CustomStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ServiceResponseResult(CustomStatusCode i_Code, string i_Message) : this(i_Code, i_Message, null)
        {
        }

        public ServiceResponseResult(CustomStatusCode i_Code, string i_Message, object i_data)
        {
            Code = i_Code;
            Message = i_Message;
            Data = i_data;
        }

    }
}
