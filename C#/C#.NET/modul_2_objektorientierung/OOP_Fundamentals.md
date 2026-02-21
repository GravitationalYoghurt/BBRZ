# OOP Fundamentals

- [Namespaces](#Namespaces)

  * [Der System-Namespace](#der-system-namespace)

  * [Der globale Namespace](#der-globale-namespace)

- [Classes](#Classes)

  * [Klassenvariablen](#Klassenvariablen)

  * [Methoden](#Methoden)

  * [Konstruktor](#Konstruktoren)


## **Namespaces**

**Namespaces in C\#** sind eine zentrale Struktur zur Organisation von Code. Sie fungieren als logische Container für Klassen, Schnittstellen, Strukturen, Aufzählungen und andere (verschachtelte) Namespaces, um die Übersichtlichkeit und Wartbarkeit von Programmen zu erhöhen, insbesondere in größeren Projekten.

#### **1. Zweck und Funktion**

- **Organisation**: Namespaces helfen, verwandte Typen (z. B. Klassen, Interfaces) zusammenzufassen. Beispielsweise kann ein Projekt mit mehreren Modulen (z. B. `DataAccess`, `BusinessLogic`, `Presentation`) jeweils einen eigenen Namespace verwenden.

- **Namenskonflikte vermeiden**: Sie ermöglichen es, gleichnamige Klassen in verschiedenen Namespaces zu definieren. So können zwei Bibliotheken beide eine Klasse `Console` haben, ohne dass es zu Konflikten kommt.

- **Namensraum-Hierarchie**: Namespaces können verschachtelt sein, z. B. `MyCompany.MyProject.Data`, was die logische Struktur des Codes widerspiegelt.

#### **2. Syntax und Deklaration**

Ein Namespace wird mit dem `namespace`-Schlüsselwort definiert:

```csharp
namespace MeineAnwendung.Datenbank  
{  
    class Verbindung  
    {  
        // Klasseninhalt  
    }  
}
```

- Die `.`-Trennung erzeugt eine Hierarchie.

- Namespaces sind **implizit öffentlich** und dürfen keine Zugriffsmodifizierer (wie `public`, `private`) enthalten.

- **Open-ended**: Es ist erlaubt, mehrere Deklarationen mit demselben vollqualifizierten Namen zu haben – sie fügen sich in denselben Namensraum ein.

#### **3. Verwendung mit `using`**

Um Typen aus einem Namespace ohne vollständigen Namen zu verwenden, wird der `using`-Direktive verwendet:

```csharp
using MeineAnwendung.Datenbank;  
// Jetzt kann man einfach 'Verbindung' schreiben  
Verbindung conn = new Verbindung();
```

- `using` importiert den Namespace in den Gültigkeitsbereich der Datei.

- **Reihenfolge**: `using`-Direktiven müssen vor Klassendeklarationen stehen.

#### **4. Qualifizierte Namen und Aliase**

- **Vollqualifizierter Name**: Wenn mehrere gleichnamige Typen existieren, muss der vollständige Name verwendet werden:

```csharp
System.Console.WriteLine("Hallo");  
MeineAnwendung.Datenbank.Verbindung.Open();
```

- **Alias mit `using`**: Um lange oder mehrdeutige Namen zu vereinfachen:

```csharp
using DB = MeineAnwendung.Datenbank;  
using Console = System.Console;  
DB.Verbindung conn = new DB.Verbindung();  
Console.WriteLine("Test");
```

#### **5. Best Practices und Empfehlungen**

- **Namensgebung**: Verwende **PascalCase** (z. B. `MyCompany.Data`, `Litware.Security`).

- **Firmenname als Präfix**: Um Namenskonflikte zwischen Unternehmen zu vermeiden (z. B. `Fabrikam.Math`).

- **Strukturierung**: Organisiere nach **Funktionalität** (z. B. `Models`, `Services`, `Controllers`) und nicht nach organisatorischen Hierarchien.

- **Vermeide zu viele kleine Namespaces**: Gruppiere logisch zusammengehörige Klassen.

- **Verwende Visual Studio-Feature "Sync Namespaces"**: Automatisch synchronisiert Namespace und Ordnerstruktur.

#### **6. Hinter den Kulissen**

- **Kein Laufzeit-Overhead**: Namespaces sind rein eine Sprach- und Compiler-Struktur. Der CLR (Common Language Runtime) kennt sie nicht direkt.

- **Klassenname = Namespace + Name**: Intern ist der vollständige Klassename `Namespace.ClassName` (z. B. `System.Console`), die Punkt-Schreibweise ist nur syntaktischer Zucker.

#### **7. Zusammenfassung**

Namespaces sind **nicht optional**, sondern essenziell für die strukturierte Entwicklung in C\#. Sie sind der Schlüssel zur Vermeidung von Namenskonflikten, zur besseren Lesbarkeit und zur professionellen Codeorganisation – besonders in Projekten, die mehrere Entwickler oder externe Bibliotheken nutzen.

---

### **Der System-Namespace**

Der **System-Namespace** ist der **zentrale und grundlegende Namespace** in C\# und .NET. Er wird automatisch in jedes C\#-Projekt eingebunden und enthält die grundlegendsten Typen und Funktionen, die für nahezu alle Programme erforderlich sind.

#### **Wichtige Inhalte**

- **Grundlegende Datentypen**: `int` (`Int32`), `string` (`String`), `bool` (`Boolean`), `double` (`Double`), `char` (`Char`), `DateTime`, `TimeSpan`, `Guid`, etc.

- **Konsolenfunktionen**: `Console.WriteLine()`, `Console.ReadLine()` für Ein- und Ausgabe.

- **Mathematische Funktionen**: `Math.Sqrt()`, `Math.Max()`, etc.

- **Umwandlung und Formatierung**: `Convert`, `IFormattable`, `IConvertible`.

- **Delegaten und Events**: `Action`, `Func`, `EventHandler`.

- **Schnittstellen für grundlegende Funktionalität**: `IDisposable`, `IComparable`, `ICloneable`.

#### **Beispiel**

```csharp
using System; // Ermöglicht die Nutzung von Typen wie Console, DateTime, etc.  
  
class Program  
{  
    static void Main()  
    {  
        Console.WriteLine(DateTime.Now); // System.Console, System.DateTime  
    }  
}
```

Ohne den `System`-Namespace wäre selbst ein einfaches "Hello World" nicht möglich. Er ist die **technische Basis** jeder .NET-Anwendung.

---


### **Der globale Namespace**

Der **Basisnamespace** in C\# ist der **globale Namespace** (auch *global namespace* genannt).  Er ist der übergeordnete, unsichtbare Container, in dem alle anderen Namespaces und Typen ohne explizite Namespace-Zuordnung automatisch landen.

#### **Wichtige Eigenschaften**

- **Unbenannter Standardnamespace**: Klassen oder Typen, die außerhalb eines `namespace`-Blocks definiert sind, gehören zum globalen Namespace.

```csharp
class MeineKlasse { } // Befindet sich im globalen Namespace
```

- **Zugriff mit `global::`**: Der `global::`-Präfix erzwingt die Suche im globalen Namespace, was bei Namenskonflikten hilfreich ist.

```csharp
global::System.Console.WriteLine("Immer das .NET System");
```

- **Keine manuelle Deklaration**: Der globale Namespace wird implizit vom Compiler verwaltet.

#### **Beispiel für Namenskonflikt**

```csharp
namespace MeineApp {  
    class System { } // Eigenes System  
    class Program {  
        static void Main() {  
            var sys1 = new System();        // MeineApp.System  
            var sys2 = new global::System(); // .NET System  
        }  
    }  
}
```

Der globale Namespace ist somit die Wurzel aller Namenshierarchien in C\#.



---

---
$~~$

## **Classes**

### **Einführung zu Klassen in C#**

In C# ist eine **Klasse** ein Bauplan für Objekte und bildet die Grundlage der objektorientierten Programmierung.  Sie fasst Daten (Felder, Eigenschaften) und Verhalten (Methoden) zusammen.

##### **1. Struktur einer Klasse**
Eine Klasse wird mit dem Schlüsselwort `class` definiert, gefolgt von einem Namen (üblicherweise großgeschrieben) und einem Rumpf in geschweiften Klammern:

```csharp
public class Person
{
    // Felder
    private string name;

    // Eigenschaften
    public string Name { get; set; }
    public int Alter { get; set; }

    // Methoden
    public void Vorstellen()
    {
        Console.WriteLine($"Ich heiße {Name} und bin {Alter} Jahre alt.");
    }
}
```

##### **2. Bestandteile einer Klasse:**
1. **Felder**: Speichern internen Zustand (häufig `private`).
2. **Eigenschaften**: Steuern den Zugriff auf Felder (`get`/`set`). 
3. **Methoden**: Definieren Aktionen, die ein Objekt ausführen kann.
4. **Konstruktoren**: Initialisieren neue Objekte (z. B. `public Person()`). 

##### **3. Zugriffsmodifizierer**
- `public`: Zugriff von überall.
- `private`: Nur innerhalb der Klasse (Standard für Felder).
- `protected`, `internal`: Für Vererbung und Assembly-Interne.

##### **4. Objekterzeugung**
Über das Schlüsselwort `new`:
```csharp
Person p = new Person();
p.Name = "Anna";
p.Alter = 25;
p.Vorstellen();
```

Jede Klasse in C# erbt automatisch von `Object` (aus `System`), was grundlegende Methoden wie `ToString()` oder `Equals()` bereitstellt.

$~~$

![Graphic Scheme Class](https://raw.githubusercontent.com/GravitationalYoghurt/BBRZ/refs/heads/main/C%23/C%23.NET/modul_2_objektorientierung/Images/class_scheme_01.png)

$~~$
---
### **Klassenvariablen**

Variablen der Klasse in C#

In C# sind **Variablen** innerhalb einer Klasse als **Felder** (Fields) bekannt und dienen zur Speicherung von Daten. Sie können entweder **Instanzfelder** sein, die für jedes Objekt einer Klasse separat existieren, oder **statische Felder** (mit dem `static`-Schlüsselwort), die einmalig pro Klasse existieren und von allen Instanzen gemeinsam genutzt werden.

#### **1. Felder (Fields)**
- **Instanzfelder** gehören zu einer bestimmten Instanz (Objekt) der Klasse. Jedes Objekt hat seine eigene Kopie des Feldes.
- **Statische Felder** werden einmalig beim Laden der Klasse initialisiert und sind über den Klassennamen zugänglich, z. B. `Klasse.FeldName`.

#### **2. Eigenschaften (Properties)**
- **Eigenschaften** sind eine abstrakte Darstellung von Feldern, die zusätzliche Logik (z. B. Validierung) beim Lesen (`get`) oder Schreiben (`set`) ermöglichen.
- Sie werden oft verwendet, um den direkten Zugriff auf Felder zu kontrollieren. Beispiel:
  ```csharp
  public string Name { get; set; }
  ```
- **Statische Eigenschaften** sind wie statische Felder: Sie gehören der Klasse an und werden mit `static` deklariert:
  ```csharp
  public static int AnzahlMitarbeiter { get; set; }
  ```

#### **3. Statische Klassen und Mitglieder**
- Eine **statische Klasse** kann nicht instanziiert werden und dient ausschließlich zur Gruppierung von statischen Methoden und Eigenschaften.
- Alle Mitglieder einer statischen Klasse müssen ebenfalls **statisch** sein.
- Zugriff erfolgt direkt über den Klassennamen: `Klasse.Methode()` oder `Klasse.Eigenschaft`.

#### **4. Zusammenfassung**
- **Felder**: Speichern Daten (instanz- oder statisch).
- **Eigenschaften**: Bieten kontrollierten Zugriff auf Felder mit `get`/`set`.
- **Statische Member**: Gemeinsam genutzte Daten oder Methoden, die über den Klassennamen aufgerufen werden, ohne Instanz zu benötigen.

Diese Konzepte sind zentral für die objektorientierte Programmierung in C# und helfen, Code strukturiert, wiederverwendbar und sicher zu gestalten.

$~~$
### **Eigenschaften (Properties)**

In C# sind **Properties** (Eigenschaften) eine sichere und flexible Methode, um auf private Felder einer Klasse zuzugreifen.  Sie kapseln das Feld und ermöglichen eine kontrollierte Lese- und Schreiboperation über **Getter** (`get`) und **Setter** (`set`). 

#### **1. Grundlegende Syntax**
```csharp
public class Person
{
    private string name;  // Privates Feld

    public string Name    // Eigenschaft
    {
        get { return name; }     // Getter: gibt den Wert zurück
        set { name = value; }    // Setter: weist den Wert zu („value“ ist der übergebene Wert)
    }
}
```
- **`get`**: Wird beim Lesen der Eigenschaft aufgerufen. 
- **`set`**: Wird beim Schreiben aufgerufen; `value` ist der zugewiesene Wert. 

#### **2. Auto-Implementierte Properties**
Wenn keine zusätzliche Logik benötigt wird, kann C# das Hintergrundfeld automatisch generieren:
```csharp
public string Name { get; set; }
```
Der Compiler erstellt hier automatisch ein privates Feld. 

#### **3. Validierung im Setter**
Der Setter kann verwendet werden, um Eingaben zu prüfen:
```csharp
private int alter;
public int Alter
{
    get { return alter; }
    set 
    { 
        if (value >= 0)
            alter = value;
        else
            throw new ArgumentException("Alter darf nicht negativ sein.");
    }
}
```

#### **4. Schreibgeschützte oder lesegeschützte Properties**
- Nur lesbar: `get` ohne `set`:
  ```csharp
  public string Name { get; private set; } // Nur innerhalb der Klasse setzbar
  ```
- Nur schreibbar: selten, aber möglich mit `set` ohne `get`. 

#### **5. Statische Properties**
Gehören zur Klasse, nicht zur Instanz:
```csharp
public static int Anzahl { get; set; }
```

#### **Vorteile von Properties**
- **Kapselung**: Direkter Zugriff auf Felder wird verhindert. 
- **Validierung**: Eingaben können im `set` geprüft werden. 
- **Flexibilität**: Logik kann später hinzugefügt werden, ohne die Schnittstelle zu ändern.






### **Felder**



---
### **Methoden**

**Methoden in C#** sind grundlegende Bausteine zur Strukturierung und Wiederverwendung von Code. Sie kapseln Funktionalitäten, die bei Bedarf aufgerufen werden können, und helfen dabei, den Code übersichtlich und wartbar zu gestalten – ein zentrales Prinzip des DRY-Prinzips (Don’t Repeat Yourself).

#### **1. Definition und Aufbau**
Eine Methode wird definiert mit einer **Zugriffsebene** (z. B. `public`, `private`), einem **Rückgabetyp** (z. B. `int`, `string`, `void`), einem **Namen**, und optional einer **Parameterliste** in Klammern. Der Code, der ausgeführt wird, steht in geschweiften Klammern `{}`.

Beispiel:
```csharp
public int Addiere(int a, int b)
{
    return a + b;
}
```

#### **2. Rückgabewert**
- **Mit Rückgabewert**: Die Methode gibt einen Wert an den Aufrufer zurück (z. B. `int`, `string`). Der Rückgabetyp muss mit dem `return`-Wert übereinstimmen.
- **Ohne Rückgabewert**: Verwende `void`, wenn keine Daten zurückgegeben werden sollen. Eine `return`-Anweisung ohne Wert beendet die Methode.

#### **3. Aufruf einer Methode**
Ein Methodenaufruf erfolgt durch den **Namen der Methode** gefolgt von Klammern `()`. Bei Methoden mit Parametern werden die Argumente innerhalb der Klammern übergeben.

Beispiel:
```csharp
int ergebnis = Addiere(5, 3); // Ergebnis: 8
```

#### **4. Statische vs. Instanzmethoden**
- **Statische Methoden** (`static`) gehören zur Klasse selbst und können ohne Instanz aufgerufen werden.
- **Instanzmethoden** werden auf ein Objekt der Klasse angewendet und haben Zugriff auf Instanzdaten.

#### **5. Weitere wichtige Aspekte**
- **Methodenüberladung**: Mehrere Methoden mit gleichem Namen, aber unterschiedlicher Parameterliste sind möglich.
- **Parameterübergabe**: Werte werden standardmäßig nach Wert übergeben. Für Verweisübergabe (Veränderung im Aufrufer) wird `ref` oder `out` verwendet.
- **Benannte Argumente**: Bei Aufruf können Argumente mit Namen angegeben werden, was die Lesbarkeit erhöht.

### **Konstruktoren**

Konstruktoren haben im Unterschied zu Methoden keinen Rückgabewert und tragen den Namen ihrer Klasse.

```csharp
class OverloadConstructor  
{  
    public OverloadConstructor()  
    {  
    }  
}
```
---
End

