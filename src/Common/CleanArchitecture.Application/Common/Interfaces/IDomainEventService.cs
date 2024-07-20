using System.Threading.Tasks;
using Emr.Domain.Common;

namespace Emr.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
