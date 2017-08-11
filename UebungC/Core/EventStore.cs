using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodeKata.EventSourcing.Core
{
    public class EventStore : IEventStore
    {
        private readonly IList<Event> events = new List<Event>();

        public void Append(Event myEvent)
        {
            events.Add(myEvent);
        }

        //todo Benamung fetch??
        public IReadOnlyCollection<T> HoleEvents<T>(string aggregateId) where T : Event
        {
            //todo: Wegen Aggregate, wird Probleme machen, Wie ist das Konzept??
            var filteredEvents = events.Where(itm => itm.HoleGetAggregateId() == aggregateId)
                .OfType<T>()
                .OrderBy(itm => itm.TimeStamp).ToList();

            return new ReadOnlyCollection<T>(filteredEvents.ToList());
        }

        public IReadOnlyCollection<Event> HoleEvents(string aggregateId)
        {
            var passendeEvents = events.Where(x => x.HoleGetAggregateId().CompareTo(aggregateId) == 0);
            return new ReadOnlyCollection<Event>(passendeEvents.ToList());
        }

        public T HoleAggregat<T>(string aggregateId) where T : Aggregat, new()
        {
            var aggregat = new T();
            var benutzerEvents = HoleEvents(aggregateId);
            aggregat.LoadFromHistory(benutzerEvents);

            return aggregat;
        }
    }
}