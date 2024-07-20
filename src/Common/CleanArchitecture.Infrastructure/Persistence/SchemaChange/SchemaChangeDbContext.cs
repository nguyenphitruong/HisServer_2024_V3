using Emr.Domain.Entities.Emr.Outclinic;
using Emr.Domain.Entities.Emr.Registers;
using Emr.Domain.Entities.Pha;
using Microsoft.EntityFrameworkCore;

namespace Emr.Infrastructure.Persistence.SchemaChange
{
    public class SchemaChangeDbContext : DbContext, IDbContextSchema
    {
        public string Schema { get; }
        //---Register
        public virtual DbSet<emrregister> emrregisters { get; set; }
        public virtual DbSet<emrregisterhi> emrregisterhis { get; set; }
        public virtual DbSet<emrclinicqueue> emrclinicqueues { get; set; }
        public virtual DbSet<emroutclinic> emroutclinics { get; set; }
        public virtual DbSet<EMR_medioutclinic> EMR_medioutclinics { get; set; }
        //---End-----
        public DbSet<PHA_inventoryl> PHA_inventoryls { get; set; }
        public SchemaChangeDbContext(
         DbContextOptions<SchemaChangeDbContext> options, IDbContextSchema schema = null) : base(options)
        {
            Schema = schema?.Schema;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
        }
    }
}
