using System.Collections.Generic;
using CodeKata.EventSourcing.Core;

namespace CodeKata.EventSourcing.BenutzerAnmeldungService
{
    //todo    Klarmachen, dass es hier nicht um ein Aggregat geht, sondern um ein ReadModel
    public class Benutzer : Aggregat
    {
        public Benutzer()
        {
        }

        public string Benutzername { get; internal set; }
        public string Passwort { get; internal set; }
        public string Vorname { get; internal set; }
        public string Nachname { get; internal set; }
        public bool IstGesperrt { get; set; }

        public void Replay(BenutzerRegistriert myEvent)
        {
            this.Vorname = myEvent.Vorname;
            this.Nachname = myEvent.Nachname;
            this.Benutzername = myEvent.Benutzername;
            this.Passwort = myEvent.Passwort;
        }

        public void Replay(PasswortGeandert myEvent)
        {
            this.Passwort = myEvent.NeuesPasswort;
        }

        public override void LoadFromHistory(IReadOnlyCollection<Event> events)
        {
            foreach (dynamic @event in events)
            {
                this.Replay(@event);
            }
        }
    }
}