Willkommen zu unserer Webengineering Abgabe!

## Wie ist unsere API zu Debuggen? ##

Sie benötigen visual Studio 2022 mit der erweiterung ".NET-Webentwicklung"
Alle benötigten Pakete werden dabei einbezogen und das Projekt kann gestartet werden. Die CRUD-operationen befinden sich in der Hauptdatei: program.cs



## Framework ##

Wir haben uns für das Framework Asp.Net-core entschieden, da mit visual-studio eine minimal-API sehr leicht
gebaut werden kann. Die Anbindung an Postgres gestaltet sich sehr simple, es wird neben Modellen für die Datenbankobjekte
lediglich ein "connection string" mit den richtigen Parametern benötigt. Ganz davon abgesehen sind wir die Syntax von C# gewohnt und 
haben bereits ein wenig Erfahrung mit Webentwicklung über ASP.Net durch den kurs "Webservices" gesammelt.



## Logging ##

unser Code ist eine API, welche CRUD-Operationen ausführt. Das Ergebnis der Operationen ist bereits im HTML-Response Code enthalten,
weshalb wir uns dafür entschieden, nur zu loggen, welches Request gerade gemacht wurde.



## secure your Querys ##

Bei diesem Thema konnten wir leider nicht unser können beweisen, da wir gar keine SQL-Injections haben.
ASP.NET bietet die Möglichkeit des Datenbankzugriffs auch ohne SQL-Injections.



## Version-Control ##

Wir verwendeten Github zur Versionierung. 



## Unsere API ##

Alle Requests werden innerhalb von Program.cs verwaltet. Am unteren Ende ist die Modellierung für Datenbankobjekte zu sehen.
Für den Zugriff auf die Datenbank ist noch ein Datenbank-Context von Nöten. Dieser ist in der Datei DB_Context.cs zu sehen.