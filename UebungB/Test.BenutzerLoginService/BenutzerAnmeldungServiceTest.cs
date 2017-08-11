using CodeKata.EventSourcing.BenutzerLoginService;
using NUnit.Framework;

namespace CodeKata.EventSourcing.Test.BenutzerLoginService
{
    [TestFixture]
    public class BenutzerAnmeldungServiceTest
    {
        [Test]
        public void TesteBenutzerRegistrieren()
        {
            var benutzerDienst = new BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }

       [Test]
        public void TesteRegistrierteBenutzerDarfAnmelden()
        {
            var benutzerDienst = new BenutzerAnmeldungService(new EventStore());
            benutzerDienst.BenutzerRegistrieren("merkel", "angela", "merkel", "hochgeheim");

            Assert.That(benutzerDienst.DarfBenutzerAnmelden("merkel", "hochgeheim"), Is.True);
        }

        [Test]
        public void TesteNichtRegistrierteBenutzerDarfNichtAnmelden()
        {
            var benutzerDienst = new BenutzerAnmeldungService(new EventStore());
            Assert.That(benutzerDienst.DarfBenutzerAnmelden("nicht registrierte Benutzer", "kennwort"), Is.False);
        }
    }
}
