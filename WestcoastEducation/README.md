# Westcoast Education

Console-applikation i C# för Inlämningsuppgift 1. Projektet innehåller arv, interface, associationer, loopar, villkor och JSON-hantering av kurser.

## Krav
- .NET 10 SDK (projektfilen använder `net10.0`)
- Visual Studio med .NET desktop/console development workload

## Starta i Visual Studio
1. Packa upp ZIP-filen.
2. Öppna `WestcoastEducation.csproj` i Visual Studio.
3. Vänta tills projektet har laddats.
4. Högerklicka på projektet och välj **Set as Startup Project** om det behövs.
5. Tryck `Ctrl+F5` för att köra utan felsökning.

## Funktioner
- Lägga till och lista kurser.
- Skilja på klassrum och distans med `CourseFormat`.
- Lägga till och lista studerande.
- Lägga till lärare, utbildningsledare och administratörer.
- Spara/läsa kurser från JSON.
- Hindra dubbla kursnummer.

## GitHub och Learnpoint
1. Skapa ett publikt repository på GitHub.
2. Ladda upp projektfilerna (inte `bin` eller `obj`).
3. Kopiera länken till det publika repot.
4. Skicka in ZIP-filen och GitHub-länken på Learnpoint.

## Viktigt att kunna förklara
- `Person` är basklassen som innehåller gemensamma personuppgifter.
- `Teacher` ärver från `Person`; `EducationManager` ärver från `Teacher`; `Administrator` ärver från `EducationManager`.
- `IDisplayable` gör att olika objekt kan presenteras med `GetDisplayInfo()`.
- `EducationCenter` hanterar listorna och registreringen.
- `CourseJsonService` sparar och läser kurslistan med `System.Text.Json`.
- `CourseFormat` skiljer klassrumskurser från distanskurser.
