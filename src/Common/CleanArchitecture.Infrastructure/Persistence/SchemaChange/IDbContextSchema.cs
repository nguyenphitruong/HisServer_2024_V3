using System;

namespace Emr.Infrastructure.Persistence.SchemaChange
{
    public interface IDbContextSchema
    {
        string Schema { get; }
    }
}
