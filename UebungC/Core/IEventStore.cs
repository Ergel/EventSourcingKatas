using System.Collections.Generic;

namespace CodeKata.EventSourcing.Core
{
    public interface IEventStore
    {
        void Append(Event @event);
        IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T : Event;
        IReadOnlyCollection<Event> HoleEvents(string aggregateId);
        T HoleAggregat<T>(string aggregateId) where T : Aggregat, new();
    }
}