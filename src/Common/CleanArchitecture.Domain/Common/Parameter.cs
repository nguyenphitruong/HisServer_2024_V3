using System;

namespace Emr.Domain.Common
{
    public class Parameter
    {
        public String fieldname { get; set; }
        public Operation operation { get; set; }
        public Object value { get; set; }
        public TypeOfValue typeofvalue { get; set; }
    }

    public enum Operation
    {
        Equals = 0,
        GreaterThan = 1,
        GreaterThanOrEqual = 2,
        LessThan = 3,
        LessThanOrEqual = 4,
        Contains = 5,
        StartsWith = 6,
        EndsWith = 7,
        ContainsCaseSensitivity = 8
    }

    public enum TypeOfValue
    {
        String = 0,
        Int32 = 1,
        Int64 = 2,
        Decimal = 3,
        DateTime = 4,
        Guid = 5
    }
}
