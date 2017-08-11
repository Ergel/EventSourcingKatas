using System.Collections.Generic;

namespace CodeKata.EventSourcing.BenutzerLoginService
{
    public interface IEventStore
    {
        void Append(Event @event);
        IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T : Event;
    }
}