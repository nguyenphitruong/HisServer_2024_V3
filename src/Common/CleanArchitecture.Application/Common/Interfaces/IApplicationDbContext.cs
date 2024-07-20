using System.Threading;
using System.Threading.Tasks;
using Emr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Emr.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<City> Cities { get; set; }

        DbSet<District> Districts { get; set; }

        DbSet<Village> Villages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
