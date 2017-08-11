using System.Collections.Generic;

namespace CodeKata.EventSourcing.Core
{
    public abstract class Aggregat
    {
        public abstract void LoadFromHistory(IReadOnlyCollection<Event> events);
    }
}