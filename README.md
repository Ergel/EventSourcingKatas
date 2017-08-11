# Event-Sourcing-Katas
Code Katas um das Konzept von Event Sourcing und CQRS zu verstehen, üben und vertiefen. 

## Übung A 
Implementiere bitte die folgende Schnittstelle so, dass
die Änderungen als Ereignis aufgebildet und aufgezeichnet werden.

```csharp
public interface IBenutzerAnmeldungService
{
	void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
	bool DarfBenutzerAnmelden(string benutzername, string passwort);
}
```

In welcher Form und wo diese Ereignisse gespeichert werden sollen, kannst du selber entscheiden.

Diese sind zu beachten:
	Es darf keine relationale Datenbank als Speichermedium genutzt werden.
	Die Ereignisse werden in Vergangenheit formuliert.
	Plausibilitätsprüfungen dürfen ignoriert werden.
	Ausnahmsweise dürfen die Passwörter als Plaintext gespeichert und geschickt werden.
	Unit-Tests müssen geschrieben werden. Du kannst dir selber entscheiden, ob Test-first oder Test-nach.

Ziel der Übung A: Eine andere Sichtweise beim Entwickeln einer Lösung einnehmen.

## Übung B: 
Erweitere bitte die Schnittstelle, damit der Benutzer sein Passwort ändern kann.

```csharp
public interface IBenutzerAnmeldungService
{
	void BenutzerRegistrieren(string benutzername, string vorname, string nachname, string passwort);
	bool DarfBenutzerAnmelden(string benutzername, string passwort);
	void PasswortAendern(string benutzername, string altesPasswort, string neuesPasswort);
}
```

Diese sind zu beachten: 
	Das neue Passwort darf nicht weniger als 6 Zeichen beinhalten. 
	Unit-Tests müssen geschrieben werden. Du kannst dir selber entscheiden, ob Test-first oder Test-nach.
	
Ziel der Übung B: Events filtern, die über gleiche DomainObjekte bzw. Aggregaten operieren. Das Aggregate-Konzept verstehen. Ein Gefühl für Platzieren von Business Regeln und Wiederherstellen den Zustand aus Events bekommen.

## Übung C: 
Folgende Anforderung muss implementiert werden:

Nach 3 fehlgeschlagene Loginversuchen muss der Benutzer gesperrt werden.
Wenn der Benutzername ein vorhandenem enutzer gehört, muss er per Mail über die Sperre informiert werden.

Diese sind zu beachten: 
Unit-Tests müssen geschrieben werden. Du kannst dir selber entscheiden, ob Test-first oder Test-nach.
Diskutiere ob Sperren-Logik bei der Agregate Klasse oder in einer Serviceklasse gekapselt werden soll.
Das Modul zum Schicken von Mails muss in einem separaten Modul implementiert werden.
Du kannst dafür BenutzerAdministrationService nutzen. Diese beide Modulen müssen entkoppelt bleiben.


Ziel der Übung C: Benachrichtigungen zwischen Modulen verstehen. Ein Gefühl für das Handling von Events und Sychronizierung von Zustand der Objekte bekommen.
Vielleicht auch Gedanken über BodundedContext.

## Übung D:
NEventStore als Speichermedium für die Ereignisse einsetzen.
Zielverständnis: Der Einsatz eines Event Stores bietet den Vorteil, dass alle Änderungen am System jederzeit durch eine Wiederholung der Events deterministisch nachgestellt werden können.

## Übung E:
Entwirf deine Schnittstelle erneut, dass du die Funktionen, die Zustand ändern und die Funktionen, die nur Daten abfragen, von einander trennst.



