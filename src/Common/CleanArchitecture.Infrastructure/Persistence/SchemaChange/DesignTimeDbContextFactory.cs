using Emr.Infrastructure.Hepper.Lib;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging.Abstractions;

namespace Emr.Infrastructure.Persistence.SchemaChange
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchemaChangeDbContext>
    {
        /// <inheritdoc />
        public SchemaChangeDbContext CreateDbContext(string[] args)
        {
            //return DependencyInjection.GetSchemaChangeDbContext(NullLoggerFactory.Instance);
            return Library.GetSchemaChangeDbContext();
        }
    }
}
