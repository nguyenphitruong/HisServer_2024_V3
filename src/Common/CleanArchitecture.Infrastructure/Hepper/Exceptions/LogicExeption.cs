using System;

namespace Emr.Infrastructure.Hepper.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException()
        {

        }

        public LogicException(string strmessage)
            : base(String.Format("Lỗi logic: {0}", strmessage))
        {

        }

    }
}
