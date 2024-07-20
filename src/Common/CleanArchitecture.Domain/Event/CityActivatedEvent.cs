using Emr.Domain.Common;
using Emr.Domain.Entities;

namespace Emr.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
