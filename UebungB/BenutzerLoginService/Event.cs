using System;

namespace CodeKata.EventSourcing.BenutzerLoginService
{
    public abstract class Event
    {
        public abstract string HoleGetAggregateId();

        public DateTime TimeStamp { get; private set; }

        protected Event()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}