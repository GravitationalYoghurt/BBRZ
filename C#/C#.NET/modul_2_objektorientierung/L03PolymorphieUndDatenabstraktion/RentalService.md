

# **Rental Service**



Wann benutze ich Vererbung und wann ein Interface.


- **Vererbung (Inheritance) ist nicht Code-Sharing**\
    Vererbung ist mehr und anders als Code-Sharing


- **is-A Verhältnis**

	Ist eine Giraffe ein Tier? Ja, eine Giraffe (child class) ist ein (**is-A**) Tier (base class).\
	Ist ein Auto ein Haus? Nein, ein Auto ist kein Haus.


- **Muß geimeinsame Logik teilen**


- **Nur Eigenschaften (properties) oder Methoden Signaturen zu teilen ist nicht genug.**


- **Vererbung kann dich in eine Sackgasse führen!**\
	Vererben muß Sinn machen und sollte nicht überdehnt werden.


- **Frage dich was ist der Punkt?**\
	Wenn es nur um Code-Sharing geht, erstellen eine externe Klasse und erstelle eine Methode 	in dieser Klasse, also noch kein Argument für Vererbung.

$~~$


**RentalCar.cs**

```csharp
public class RentalCar
{
    public int RentalId { get; set; }
    public string CurrentRenter { get; set; }
    public decimal PricePerDay { get; set; }
    public int NumberOfPassengers { get; set; }
    public CarType Style { get; set; }


    public void StartEngine()
    {
        Console.WriteLine("Turn key to ignition setting");
        Console.WriteLine("Turn key to on");
    }

    public void StopEngine() 
    { 
        Console.WriteLine("Turn key to off"); 
    }
}
```

$~~$

**Enums.cs**
```csharp
public enum CarType
{
    Hatchback,
    Sedan,
    SUV,
    Coupe,
    Compact
}
```


Fein, wir beginnen jetzt Autos zu vermieten.


Aber:\
“Good news! Wir haben unseren ersten Truck!“

$~~$
## Vererbung - Inheritance


Oh oh! Das Programm ist für Autovermietung ausgelegt. Die Lösung: Vererbung!


Also anstatt von `RentalCar` haben wir jetzt `RentalVehicle`, gut.\
Wir erstelen eine Klasse `RentalCar` die von `RentalVehicle` erbt und natürlich auch eine Klasse `RentalTruck`, die von `RentalVehicle` erbt.


**RentalCar.cs**
```csharp
public class RentalCar : RentalVehicle
{
}
```
\
**RentalTruck.cs**
```csharp
public class RentalTruck : RentalVehicle
{
}
```

und in unserer Enum `CarType` fügen wir …  nun ja,  ein Coupe-Truck oder Cabrio-Truck? Das paßt nicht besonders gut, also eine eigene `TruckType` Enum:

\
**Enums.cs + TruckType**
```csharp
public enum TruckType
{
    Pickup,
    BoxTruck,
    Flatbed,
    DumpTruck
}
```

und unsere Enum `CarType` kommt von `RentalVehicle` in die Klasse `RentalCar`, in `RentalTruck` erzeugen wir uns eine Property `TruckType`:

\
**RentalCar.cs**
```csharp
public class RentalCar : RentalVehicle
{
    public CarType Style { get; set; }
}
```
\
**RentalTruck.cs**
```csharp
public class RentalTruck : RentalVehicle
{
    public TruckType Style { get; set; }
}
```

Nun haben wir zwei unterschiedliche Typen `CarType` und `TruckType` mit der gleichen Porperty. Macht schon Sinn, da es sich jeweils um die Art des Fahrzeugs handelt, die Ausprägungen aber jeweils unterschiedlich sind.


Anderes Beispiel:\
Wir vermieten (kurzfristig) Matchboxautos und sehen uns an, wie sich die Eigenschaft Gewicht im Verhältnis zum Gewicht der Klasse `RentalTruck` verhält:


**Exkurs:**
```csharp
public class RentalTruck : RentalVehicle
{
    public TruckType Style { get; set; }
    public int Weigth { get; set; }
}

public class Matchbox : RentalVehicle 
{
    public int Weight { get; set; }
}
```

Ist das Gewicht von Matchboxautos wirklich vergleichbar mit dem Gewicht von LKWs?\
Hat es die selbe Funktion?

Also der Umstand, dass Properties den gleichen Namen und sogar den gleichen Typen haben heißt nicht, dass sie die gleiche Funktion haben.


Zurück:\
Nun gut, wir habe jetzt ein robusteres System. Wir haben Vererbung verwendet, was geholfen hat, da wir jetzt die ‘base Klasse‘ `RentalVehicle` haben und gemeinsam genutzte Properties und Methoden, aber auch spezifische Methoden und Properties der jeweiligen Klasse (`RentalCar` und `RentalTruck`).


Noch nicht erwähnt: Unsere Freundin W. lebt am Attersee und ihr ahnt es schon. Sie möchte jetzt auch Motorboote vermieten. Ohoh? Nein, nein! Eigentlich kein Problem. Unsere Properties passen soweit und auch unsere Methoden funktionieren grundsätzlich. Allenfalls müssen sie überschrieben werden.


Wir fügen einfach eine Klasse `RentalMotorBoat` hinzu:

\
**RentalMotorBoat.cs**
```csharp
public class  RentalMotorBoat : RentalVehicle
{
}
```

Soweit so gut. Wir haben nur die Rechnung ohne unsere Freundin W. gemacht. Sie hat jetzt Segelboote im Verleih!\
Die Properties passen noch soweit, aber unsere Methoden? `StartEngine()`, `StopEngine()`? Bei einem Segelboot? Gut wir probieren es aus und fügen eine Klasse hinzu:

\
**RentalSailboat.cs** (hypothetisch)
```csharp
public class RentalSailBoat : RentalVehicle
{
}
```

Wir erben also von `RentalVehicle`. Ein Segelboot hat eine `RentalId`, eine:n `CurrentRenter` auch `PricePerDay` und `NumberOfPassengers`. Aber unsere Probleme tauchen auf bei `StartEngine()` und `StopEngine()`. Ein Segelboot hat nun mal keinen Motor. Was wir machen könnten wäre diese Methoden zu überschreiben. Dazu müssen wir sie in der base class als `virtual` setzen.

\
**RentalVehicles.cs**
```csharp
public virtual void StartEngine()
{
    Console.WriteLine("Turn vehicle key to ignition setting");
    Console.WriteLine("Turn vehicle key to on");
}

public virtual void StopEngine() 
{ 
    Console.WriteLine("Turn vehicle key to off"); 
}
```

und überschreiben `override` in unserer `RentalSailboat` Klasse:

\
**RentalSailboat.cs** (hypothetisch)
```csharp
public class RentalSailBoat : RentalVehicle
{
    public override void StartEngine()
    {
        throw new Exception("I do not have any engine to start");
    }
}
```
\
Nun sind wir in einer Sackgasse. Wir haben diese zwei Methoden die nichts machen bzw. überhaupt nicht aufgerufen werden sollten. Methoden die nichts machen könnten eine falsche Erwartungshaltung hervorbringen. Und eine exception ist auch keine Lösung. Wir haben nun diesen Code der fehlgeleitet ist. Wenn wir beispielsweise den Code weitergeben müssen wir aktiv darauf hinweisen, dass es da diese zwei Methoden gibt die bitte nicht aufzurufen sind. Das ist unsauber. Hier sind es für Übungszwecke zwei Methoden, stellen wir uns vor es sind 30…

Stell dir vor die Methode heißt nicht `StartEngine()` sondern `SetDatabase()`, und du erwartest, dass etwas passiert was aber tatsächlich nie stattfindet (da wäre dann die exception zumindest hilfreich den Fehler zu finde). Also du möchtest diese Methode nicht ohne exception, aber mit nun auch nicht optimal.


Wir befinden uns also in einer Sackgasse mit unserer Vererbung. Es hat alles Sinn gemacht, aber plötzlich nicht mehr.

Wir haben diese eigenartige Situation wo wir uns die Frage stellen **is-A** `RentalCar` ein `RentalVehicle`? Klar! Aber macht das wirklich Sinn? Ist das tatsächlich die Vererbungsstruktur die wir benötigen?

Was wir hier machen sind zwei verschiedene Dinge: einmal Rental und einmal Vehicle. Und wir dachten diese zwei Dinge passen ganz gut zusammen. Wenn wir diese zwei aber nun trennen und sagen: ok, wir machen Vehicle zu unserer base class und Rental als child class und dann Car als child class von Rental, dann hätte Car beide Vererbungen, sowohl von Vehicle als auch von Rental. Eigentlich auch möglich, aber vernünftig? Alles ein großes Durcheinander.


Wir könnten auch sagen, wir behalten uns in der RentalVehicle class nur den Property teil und nehmen die Fahrzeug-Methoden raus. Auch möglich, aber was ist der Wert? Wir haben vier Properties, wie soll das helfen? Ok, wir wiederholen uns nicht (DRY). Gut, tun wir nicht. Aber wir zementieren uns in die Rental base class ein für gerade mal vier (auto-) Properties. 


Es braucht also einen besseren Weg.


$~~$



# Der bessere Weg!


Wir starten ein neues Projekt und nennen es **BetterRentalService**.


Wir beginne nun damit, dass wir zwei verschiedene Dinge haben, *Rental* und *Vehicle*.


Wir machen uns ein Interface und nennen es `IRental`. Wir übernehmen die Properties `RentalID`, `CurrentRenter` und `PricePerDay`, lassen aber die Eigenschaft `NumberOfPassengers` weg, da wir uns voll auf Rental konzentrieren. `public` brauchen wir für die Properties in unserem Interface ebenso nicht.

\
**BetterRentalService/IRental.cs**
```csharp
public interface IRental
{
    int RentalId { get; set; }
    string CurrentRenter { get; set; }
    decimal PricePerDay { get; set; }
}
```

Jetzt haben wir ein Rental, einen Verleih. Und oben habe wir unser Interface, das wir auf alles anwenden was ein Rental ist.


Nun erzeugen wir unsere **Klasse Vehicle** als Vererbungsbasis. `NumberOfPassengers` scheint hier als Property gut zu funktionieren. Das ist jetzt noch keine so tolle Vererbung, also geben wir unsere zwei Methoden `StartEngine()` und `StopEngine()` auch noch dazu.

\
**BetterRentalService/LandVehicles.cs**
```csharp
public class Vehicle
{
    public int NumberOfPassengers { get; set; }


    public virtual void StartEngine()
    {
        Console.WriteLine("Turn vehicle key to ignition setting");
        Console.WriteLine("Turn vehicle key to on");
    }

    public virtual void StopEngine()
    {
        Console.WriteLine("Turn vehicle key to off");
    }
}
```

Wobei wir hier wieder auf das Problem stoßen, dass wir kein Segelboot sauber abbilden können. Also nenne wir unsere Klasse mal `LandVehicle` (Benennung könnte besser sein).


`public class Vehicle`       wird zu      `public class LandVehicle`


Unsere Enums passen noch, also copy&past in unseren `BetterRentalService` (Achtung auf den Namespace!  `RentalService`  →  `BetterRentalService`)


Wir erzeugen uns wieder unser `RentalCar` und erben von `LandVehicle` und `IRental`. Wir übernehmen die Property `CarType` und implementieren unser Interface `IRental` (Strg + .).

\
**BetterRentalService/RentalCar.cs**
```csharp
public class RentalCar : LandVehicle, IRental
{
    public CarType Style { get; set; }
    public int RentalId { get; set; }
    public string CurrentRenter { get; set; }
    public decimal PricePerDay { get; set; }
}
```

das gleiche für `RentalTruck`

\
**BetterRentalService/RentalTruck.cs**
```csharp
public class RentalTruck : LandVehicle, IRental
{
    public TruckType Style { get; set; }
    public int RentalId { get; set; }
    public string CurrentRenter { get; set; }
    public decimal PricePerDay { get; set; }
}
```
\
Jetzt haben wir also wieder unser `RentalCar` und unser `RentalTruck`. Und die Vererbungsstruktur erlaubt uns auch wieder auf die Methoden `StartEngine()` und `StopEngine()` zuzugreifen. Wir haben `NumberOfPassengers`. Wir haben also geteilte Logik nicht unbedingt geteilte Properties oder Signatures. Wir haben die Idee, dass beide ein Landfahrzeug sind. Wir können jetzt verschiedene Arten von Landfahrzeugen hinzufügen, SUV, Bus, usw.


Wir haben aber auch die Idee des Verleihs. Wir ‘duplizieren‘ unsere Properties. Jetzt könnte der Einwand kommen, dass das doch ein Verstoß gegen DRY ist. Jein. Es ist keine Wiederholung. Und der Grund dafür ist die Frage welche Logik, welchen Code schreibe ich für diese Properties. 


Anders rum: Stellen wir uns vor die Methode `StartEngine()` befindet sich sowohl in `RentalCar` als auch in `RentalTruck`. Wenn sich nun eine Änderung in der Logik dieser Methode ergibt, dann muß ich das in jeder Klasse vornehemen. Vergesse ich es irgendwo, dann habe ich einen Fehler.

DRY ist dabei das Prinzip uns vor solchen Fehlern zu beschützen. Und bei den Properties wird dafür gesorgt, dass wir z.B. die gleichen Namen verwenden. Wir müssen dabei sehr wohl aufpassen auf etwaige Logik in unseren gettern und settern. Aber das ist keine Verletzung von DRY.

Es ist auch eine zwangsläufige Duplizierung, da wir keine Mehrfachvererbungen haben. Wir können nicht von `Rental` und `LandVehicle` erben. Sie sind auch nicht verwandt. `Rental` hat nichts per se mit `LandVehicle` zu tun solange ich diese zwei Umstände nicht aktiv verbinde.


Also wir haben eine gewisse Dopplung in der Implementation unserer Logik, aber das kann ok sein. In unserem Code ist es definitiv eine Anforderung.


Aber sehen wir uns nun unser Segelboot an. Es ist kein LandVehicle, also erben wir auch nicht davon, aber wir wollen es vermieten, also implementieren wir unser Interface.

\
**BetterRentalService/RentalSailboat.cs**
```csharp
public class RentalSailboat : IRental
{
    public int RentalId { get; set; }
    public string CurrentRenter { get; set; }
    public decimal PricePerDay { get; set; }
}
```

Da wir noch keine eigenen Properties oder Methoden für `RentalSailboat` haben paßt das mal.

Quick and easy. Wir haben nun ein Segelboot im Verleih.

$~~$

## Die Anwendung

Wie verwenden wir unser Gerüst nun in der Main-Methode?


**BetterRentalService/Program.cs**
```csharp
List<IRental> rentals = new List<IRental>();

rentals.Add(new RentalTruck() { CurrentRenter = "Truck Renter"});
rentals.Add(new RentalSailboat() { CurrentRenter = "Sailboat Renter" });
rentals.Add(new RentalCar() { CurrentRenter = "Car Renter" });

foreach (var r in rentals)
{
    if (r is RentalTruck t)
    {
        Console.WriteLine($"Truck is rented by: {t.CurrentRenter}");
    }
    if (r is RentalSailboat s)
    {
        Console.WriteLine($"Sailboat is rented by: {s.CurrentRenter}");

    }
}
```


$~~$
--
based on: [Inheritance vs Interfaces in C\#: Object Oriented Programming](https://youtu.be/4sxyDXt1igs?si=9Zc8vKeJHSHUYMPC)
