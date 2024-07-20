using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emr.Infrastructure.Persistence.SchemaChange
{
    public class SchemaChangeProductEntityConfiguration : IEntityTypeConfiguration<SchemaChangeProduct>
    {
        private readonly string _schema;

        public SchemaChangeProductEntityConfiguration(string schema)
        {
            _schema = schema;
        }

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<SchemaChangeProduct> builder)
        {
            if (!string.IsNullOrWhiteSpace(_schema))
                builder.ToTable(nameof(SchemaChangeDbContext.PHA_inventoryls), _schema);

            builder.HasKey(product => product.rowid);
        }
    }
}
