# TeleTime2.0
Scheduling software

Setup:
LocalDB och Entity framework så inget ska behövas konfigrueras i connectionstringen.

Registrerar man en user så får man bara tillgång till Kalendern.

Deafult-admin men tillgång till alla admin funktioner:

Login: "admin@admin.com"
Password: "AdminAdmin1234!"

_____________________________________________________________________________________________________________________________________

Från funktioner sidan i TeleTime.

Användar roller
När Applikationen körs första gången så skapas olika roller i databasen, dessa har olika nivåer av auktorisering som styrs i "backenden"
och påverkar vad som syns i "frontenden". Det skapas även en deafult Admin och Developer när man startar som sparas i databasen.

- Admin
För att få tillgång till TeleTimes funktioner så måste du vara registrerad som Admin.
Du kommer då få en mer avancerad menu och vara authoriserad till att skapa pass, personer m.m i databasen.

- Developer
En roll för att underlätta när man utvecklar applikationen, alla views som är kopplade till controllers visas
För att enklare kuna testa saker.

- Vanlig användare
Innan man registrerat sig och som vanlig användare får man bara tillgång till startsida,funktioner,kontakt.
Man har även tillgång till registrera sig och login sidan.

Funktioner
- Pass (Shift)
- Kalender (Calender)
- Arbetspass (WorkShift)
- Personer (People)
- Tid (Time)
- Arbetsdag (WorkDay)
- Arbetspass (WorkShift)
API - Kalenderfunktionen
Vi använder oss av DHTMLX Scheduler.NET gratisversion, för att få en trevligare frontend och på ett användarvänligt sätt kunna visa kopplingar och schemaläggningsfunktioner.
Vi använder bara deras kalender och har byggt på med egen kod med Ajax anrop för att skapa funktionalitet som vi vill ha.

Hur man använder kalendern:
Vi har gjort så man kan "dubbeklicka" på en dag på kalender i veckovyn.
Då kan man koppla ett pass till denna dag som sedan visas i kalendern.

Hur man använder applikationen
Schemaläggaren bygger på pass, för att skapa ett pass så får man först börja med att skapa allt ett pass innehåller.

Skapa Personer - Som du sedan kopplar till passet.
Skapa Roller - Vilka roller innehåller passet.
Skapa Tider - Vilken starttid och sluttid ska passet ha.
Databas
