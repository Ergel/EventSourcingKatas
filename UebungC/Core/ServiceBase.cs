namespace CodeKata.EventSourcing.Core
{
    public abstract class ServiceBase
    {
        public IEventStore EventStore { get; }

        public ServiceBase(IEventStore eventStore)
        {
            this.EventStore = eventStore;
        }
    }
}
