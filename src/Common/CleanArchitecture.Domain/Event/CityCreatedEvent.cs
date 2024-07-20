using Emr.Domain.Common;
using Emr.Domain.Entities;

namespace Emr.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
