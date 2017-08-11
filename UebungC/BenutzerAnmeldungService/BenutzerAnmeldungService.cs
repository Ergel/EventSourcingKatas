using CodeKata.EventSourcing.Core;

namespace CodeKata.EventSourcing.BenutzerAnmeldungService
{
    public class BenutzerAnmeldungService : ServiceBase, IBenutzerAnmeldungService
    {
        public void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort)
        {
            var eventBenutzerRegistriert = new BenutzerRegistriert(benutzername, passwort, vorname, nachname);
            this.EventStore.Append(eventBenutzerRegistriert);
        }

        public bool DarfBenutzerAnmelden(string benutzername, string passwort)
        {
            var benutzer = this.EventStore.HoleAggregat<Benutzer>(benutzername);
            if (benutzer == null
                || benutzer.IstGesperrt)
            {
                return false;
            }

            return benutzer.Passwort == passwort;
        }

        public void PasswortAendern(string benutzername, string altesPasswort, string neuesPasswort)
        {
            //TODO: Was soll mit dem Geschehen passieren?
            if (DarfBenutzerAnmelden(benutzername, altesPasswort) == false)
            {
                return;
            }

            if (neuesPasswort.Length < 6)
            {
                return;
            }

            var passwortGeandertEvent = new PasswortGeandert(benutzername, neuesPasswort);
            this.EventStore.Append(passwortGeandertEvent);
        }

        public BenutzerAnmeldungService(IEventStore eventStore)
             : base(eventStore)
        {
        }
    }
}