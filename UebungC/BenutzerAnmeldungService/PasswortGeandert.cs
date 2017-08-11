using CodeKata.EventSourcing.Core;

namespace CodeKata.EventSourcing.BenutzerAnmeldungService
{
    public class PasswortGeandert : Event
    {
        public string Benutzername { get; }
        public string NeuesPasswort { get; }

        public PasswortGeandert(string benutzername, string neuesPasswort)
        {
            Benutzername = benutzername;
            NeuesPasswort = neuesPasswort;
        }

        public override string HoleGetAggregateId()
        {
            return this.Benutzername;
        }
    }
}