using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Emr.Infrastructure.Persistence.SchemaChange
{
    public class DbSchemaAwareModelCacheKeyFactory : IModelCacheKeyFactory
    {
        /// <inheritdoc />
        public object Create(DbContext context)
        {
            return new { Type = context.GetType(), Schema = context is IDbContextSchema schema ? schema.Schema : null };
        }
    }
}
