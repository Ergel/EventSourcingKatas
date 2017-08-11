using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodeKata.EventSourcing.BenutzerLoginService
{
    public class EventStore : IEventStore
    {
        private readonly IList<Event> events = new List<Event>();

        public void Append(Event myEvent)
        {
            events.Add(myEvent);
        }

        
        //todo Benamung fetch??
        public IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T: Event
        {
            //todo: Wegen Aggregate, wird Probleme machen, Wie ist das Konzept??
            var filteredEvents = events.Where(itm => itm.HoleGetAggregateId() == aggregateId).OfType<T>();
            return new ReadOnlyCollection<T>(filteredEvents.ToList());
        }
    }
}