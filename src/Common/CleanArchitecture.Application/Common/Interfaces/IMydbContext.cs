using Emr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Emr.Application.Common.Interfaces
{
    public interface IMydbContext
    {
        //DbContext Context { get; }  
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }
        public DbSet<casharel> casharels { get; set; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
