using System.Linq;
using System.Linq.Expressions;

namespace CodeKata.EventSourcing.BenutzerLoginService
{
    public class BenutzerAnmeldungService : IBenutzerAnmeldungService
    {
        public IEventStore EventStore { get; }

        public void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            var eventBenutzerRegistriert = new BenutzerRegistriert(benutzername, passwort, vorname, nachname);
            this.EventStore.Append(eventBenutzerRegistriert);
        }

        public bool DarfBenutzerAnmelden(string benutzername, string passwort)
        {
            var benutzerRegistriertRelevanteEvent = EventStore.HoleEvents<BenutzerRegistriert>(benutzername).FirstOrDefault();

            if (benutzerRegistriertRelevanteEvent != null)
            {
                return benutzerRegistriertRelevanteEvent.Passwort == passwort;
            }

            return false;
        }

        public BenutzerAnmeldungService(IEventStore eventStore)
        {
            this.EventStore = eventStore;
        }
    }
}