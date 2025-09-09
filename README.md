# C# – 1. cvičení: Generické listy, třídy a LINQ (.NET 9)

**Cíl cvičení**  
- pochopit práci s `List<T>` (přidávání, odebírání, výpis),  
- vytvořit vlastní třídu (`Student`) včetně konstruktorů a vlastností,  
- procvičit základy LINQ (`Count`, `Sum`, `Where`),  
- osvojit si základy práce s projektem v .NET 9 (ImplicitUsings, Nullable).

---

## Požadavky

- **Visual Studio / VS Code** s podporou .NET (SDK **.NET 9**).  
- Základní znalost C# (proměnné, třídy, metody, cykly).  
- Připravený repozitář (nebo lokální projekt) s těmito soubory:
  - `Program.cs` – obsahuje ukázky práce s `List<string>`, třídu `Student` a LINQ.
  - `<Projekt>.csproj` – projektový soubor s nastavením (viz níže).

> **Pozn.:** V `.csproj` je zapnuté `ImplicitUsings` a `Nullable`. Namespace v `Program.cs` může obsahovat podtržítka — je to v pořádku.

---

## Rychlý start (jak spustit)

### Visual Studio
1. Otevři řešení / projekt.
2. Spusť **Debug → Start Without Debugging** (Ctrl+F5) nebo **Start Debugging** (F5).
3. Očekávaný výstup viz níže.

### .NET CLI
```bash
dotnet restore
dotnet run
```

---

## Struktura startovního kódu (shrnutí)

- **List<string>** – ukázka přidání/odebrání a výpisu přes `String.Join`.
- **Třída `Student`** – vlastnosti `Jmeno`, `Body`, odvozená vlastnost `Popis`, tři způsoby vytvoření objektu (konstruktory/objektový inicializátor).
- **LINQ** – `Count`, `Sum`, `Where` (+ lambda), materializace `ToList()`.

> V `Program.cs` je (pro inspiraci) i ukázka `Console.OutputEncoding = Encoding.UTF8;` pro případ problémů s diakritikou v externím okně.

---

## Zadání (4 úlohy)

### Úloha 1 – Založení a ověření projektu
**Cíl:** zprovoznit projekt a pochopit základní nastavení.

1. Otevři projekt a ověř, že v `.csproj` máš:
   - `TargetFramework` = `net9.0`,
   - `ImplicitUsings` = `enable`,
   - `Nullable` = `enable`.
2. Spusť projekt a ověř, že se vypíše aktuální výstup bez chyb (viz **Očekávaný výstup**).
3. (Volitelné) Pokud by diakritika v **externím** okně dělala potíže, odkomentuj v `Main`:
   ```csharp
   Console.OutputEncoding = Encoding.UTF8;
   ```
4. **Commit & push** s popisem: `cv01: projekt zprovozněn`.

**Výstup:** projekt se zkompiluje a spustí, zobrazí se výpis dat.

---

### Úloha 2 – Práce s `List<string>`
**Cíl:** procvičit základní operace nad generickým seznamem.

1. V metodě `Main` vytvoř nový `List<string>` se 3–5 jmény (mohou být jiné než ve vzoru).
2. Proveď postupně:
   - `Add` (přidej aspoň jedno jméno),
   - `Insert` (vloží na pozici 0 nové jméno),
   - `Remove` (odstraň jedno existující jméno),
   - `Contains` + `IndexOf` (ověř přítomnost a případnou pozici).
3. Vypiš seznam jedním řádkem pomocí `String.Join(", ", list)`.
4. (Volitelné) **Setřiď** jména abecedně a vypiš znovu.
5. **Commit & push**: `cv01: operace nad List<string>`.

**Výstup:** viditelně se mění obsah listu podle provedených operací.

---

### Úloha 3 – Třída `Student` a seznam studentů
**Cíl:** vytvořit třídu, instance, a projít list s objekty.

1. Vytvoř / ponech třídu `Student` s vlastnostmi:
   - `public string Jmeno { get; set; } = string.Empty;`
   - `public int Body { get; set; }`
   - `public string Popis => Jmeno + " - " + Body;`
2. Připrav tři různé způsoby vytvoření instancí (A – prázdný konstruktor, B – objektový inicializátor, C – konstruktor s parametry).
3. Ulož je do `List<Student>` a **vypsat**:
   - všechna jména na jeden řádek,
   - potom každého studenta jako `Jmeno(Body)`.
4. **Commit & push**: `cv01: trida Student a zakladni vypisy`.

**Výstup:** seznam jmen a seznam `Jmeno(Body)`.

---

### Úloha 4 – LINQ: filtrace a agregace
**Cíl:** použít `Where`, `Count`, `Sum`, případně `Average`, a pracovat s výsledky.

1. Nad `List<Student>` vypiš:
   - `Počet:` (celkový počet prvků),
   - `Suma:` (součet bodů – jednou přes **metodu** `VyberBody`, podruhé přes **lambda** `x => x.Body`),
   - `Suma>6:` (součet bodů studentů s body > 6).
2. Vytvoř **vyfiltrovaný seznam** `vybranistudenti` (body > 6) pomocí `Where(...).ToList()`.
3. Vypiš `Popis` všech studentů z `vybranistudenti` (každého na nový řádek).
4. (Volitelné) Vypočti `Average` bodů a najdi **TOP 1** studenta (`OrderByDescending(x => x.Body).First()`). 
5. **Commit & push**: `cv01: linq filtrace a agregace`.

**Výstup:** agregované hodnoty a výpis vybraných studentů.

---

## Očekávaný výstup (pro vzorová data v repozitáři)

```
Pepa,Karel,Mirek,Kryštof
Pepa,Karel,Mirek,Kryštof,Ivan
Karel,Mirek,Kryštof,Ivan

Dušan Pepa Karel


Pepa(5) Karel(12) Mirek(8) Kryštof(4)

Počet: 4
Suma:29
Suma2:29
Suma>6:20
Karel - 12
Mirek - 8
```

> Pozor: Pokud použiješ **jiná** vstupní data, budou součty/počty jiné – to je v pořádku. Důležitá je správnost postupu.

---

## Kontrolní otázky (sebe‑test)

1. Co vrací `List<T>.Add` a `List<T>.Remove` a jaký je mezi nimi rozdíl?  
2. Proč `Where(...)` vrací „líný“ `IEnumerable<T>` a k čemu slouží `ToList()`?  
3. Jaký je rozdíl mezi metodou `Sum(VyberBody)` a `Sum(x => x.Body)`?  
4. K čemu slouží `ImplicitUsings` a `Nullable` v `.csproj`?  
5. Jak bys upravil program, aby zobrazil jen studenty **nesplnivší** min. počet bodů (např. `< 10`)?

---

## Časté trable

- **Diakritika v konzoli**: v externím okně může být potřeba `Console.OutputEncoding = Encoding.UTF8;`.  
- **Namespace**: nemusí přesně odpovídat `RootNamespace` – to nevadí, ale drž se jednoho stylu v rámci projektu.  
- **LINQ using**: s `ImplicitUsings=enable` není nutné `using System.Linq;` psát ručně; mít ho navíc ničemu nevadí.

---

## Odevzdání

1. **Commit & push** po každé úloze (min. 4 commity).  
2. Vytvoř **pull request**/odevzdej odkaz na svůj repozitář dle pokynů vyučujícího.  
3. V PR popiš, co jsi upravil a které části (úlohy) jsou hotové.

---

### Bonus (nepovinné)

- Seřaď `vybranistudenti` podle `Body` sestupně a vypiš **TOP N** (N zadej proměnnou).  
- Doplň metodu `bool Prospel(int hranice = 10)` a vypiš jen studenty, kteří prošli.  
- Převeď výpis `Jmeno(Body)` na interpolaci `$"{s.Jmeno}({s.Body})"` a porovnej čitelnost.

---

Hodně zdaru při práci!


---

## Jak to funguje – podrobná procházka kódem

Níže je vysvětleno **co přesně dělá každý důležitý kus kódu** v tvých souborech `Program.cs` a `.csproj`.

### 1) Hlavička souboru a `using` direktivy
```csharp
using System;                      // Console, String, ...
using System.Collections.Generic;  // List<T>
using System.Linq;                 // LINQ: Where, Sum, ToList, ...
using System.Text;                 // Encoding (např. UTF-8 pro diakritiku)
using System.Threading.Tasks;      // Task (v ukázce nepoužito, jen informativně)
```

- `using` říká, **z jakých jmenných prostorů** bereme typy.
- V `.csproj` je `ImplicitUsings=enable`, takže časté `using` přidává kompilátor **globálně**. Mít je zde navíc **nevadí**, je to přehlednější pro začátečníky.

### 2) Namespace (jmenný prostor)
```csharp
namespace První_cvičení___Generické_listy__NET._9_
{
    // ...
}
```
- Namespace obvykle odpovídá `RootNamespace` v `.csproj`.
- Znaky, které nelze použít v identifikátoru, se automaticky **převedou na podtržítka** (`_`). To je důvod, proč vidíš tolik `_`.

### 3) Třída `Program` a vstupní bod `Main`
```csharp
class Program
{
    static void Main(string[] args)
    {
        // ... hlavní tělo programu ...
        Console.ReadKey();
    }
}
```
- `Main` je **start** aplikace. `args` by nesl argumenty z příkazové řádky (v ukázce je nepoužíváme).
- `Console.ReadKey()` na konci zabrání okamžitému zavření konzole při spuštění mimo debugger.

> Tip: Pokud máš potíže s diakritikou v **externí** konzoli, můžeš zapnout UTF‑8:
> ```csharp
> Console.OutputEncoding = Encoding.UTF8;
> ```

### 4) Práce s `List<string>` – základ
```csharp
var list = new List<string>() { "Pepa", "Karel", "Mirek", "Kryštof" };
Console.WriteLine(String.Join(",", list)); // => spojí prvky čárkou

list.Add("Ivan");                          // přidá na konec
Console.WriteLine(String.Join(",", list));

list.Remove("Pepa");                       // odstraní první výskyt "Pepa"
Console.WriteLine(String.Join(",", list));

Console.WriteLine(); // prázdný řádek pro přehlednost
```
- **Inicializátor kolekce** `{ ... }` založí `List<string>` se čtyřmi položkami.
- `String.Join` vytvoří **jeden řetězec** z prvků listu.
- `Add` a `Remove` mění obsah; `Remove` vrací `true/false` podle toho, zda položku našel.
- Samostatný `WriteLine()` vloží **prázdný řádek**.

### 5) Třída `Student` a práce s objekty
```csharp
var s1 = new Student();            // prázdný konstruktor
s1.Jmeno = "Dušan";
s1.Body = 14;

var s2 = new Student() { Jmeno = "Pepa", Body = 15 }; // objektový inicializátor
var s3 = new Student("Karel", 75);                    // konstruktor s parametry

var liststud = new List<Student>();
liststud.Add(s1);
liststud.Add(s2);
liststud.Add(s3);

foreach (var s in liststud)         // foreach projde položky
{
    Console.Write(s.Jmeno + " ");   // Write = bez odřádkování
}
Console.WriteLine();                 // ruční odřádkování
Console.WriteLine();
Console.WriteLine();
```
- Tři **různé způsoby** vytvoření instance: (A) prázdný konstruktor, (B) inicializátor, (C) konstruktor s parametry.
- `foreach` je idiomatický způsob, jak projít všechny položky.
- Rozdíl `Console.Write` vs `Console.WriteLine`: první **ne**odřádkuje, druhý **ano**.

### 6) „Rychlé“ naplnění seznamu `Student` a výpis
```csharp
var seznamstudentu = new List<Student>()
{
    new Student("Pepa", 5),
    new Student("Karel", 12),
    new Student("Mirek", 8),
    new Student("Kryštof", 4)
};

foreach (var s in seznamstudentu)
{
    Console.Write(s.Jmeno + "(" + s.Body + ") ");
    // Alternativa (čistší): Console.Write($"{s.Jmeno}({s.Body}) ");
}
Console.WriteLine();
Console.WriteLine();
```
- Opět **inicializátor kolekce** – tentokrát rovnou s objekty `Student`.
- Výpis dvakrát odřádkuje, aby od sebe oddělil bloky výstupu.

### 7) LINQ: `Count`, `Sum`, `Where`, `ToList`
```csharp
Console.WriteLine("Počet: " + seznamstudentu.Count);

Console.WriteLine("Suma:" + seznamstudentu.Sum(VyberBody));   // přes metodu
Console.WriteLine("Suma2:" + seznamstudentu.Sum(x => x.Body)); // totéž lambdou

Console.WriteLine("Suma>6:" + 
    seznamstudentu.Where(x => x.Body > 6).Sum(x => x.Body));   // filtrace + součet
```
- `Count` je **vlastnost** `List<T>` (není to LINQ).
- `Sum(VyberBody)` předá **odkaz na metodu** (delegát) – viz další bod.
- `Sum(x => x.Body)` je totéž, ale zápis pomocí **lambda výrazu**.
- `Where` vrací **líný** `IEnumerable<T>`; až při `Sum`, resp. při `ToList` dojde k **materializaci**.

```csharp
var vybranistudenti = seznamstudentu.Where(x => x.Body > 6).ToList();
vybranistudenti.ForEach(x => Console.WriteLine(x.Popis)); // List<T>.ForEach
```
- `ToList()` převádí z „líného“ **IEnumerable** na konkrétní **List**.
- `List<T>.ForEach(Action<T>)` je **metoda listu** (není to LINQ rozšíření), která na každém prvku provede akci.

### 8) Pomocná metoda pro `Sum`
```csharp
public static int VyberBody(Student stud)
{
    return stud.Body;
}
```
- Signatura odpovídá tomu, co `Sum` potřebuje: **funkci, která z `Student` vrátí `int`**.
- V praxi se dnes častěji používá **lambda** (`x => x.Body`), ale je důležité vědět, že to celé stojí na **delegátech** (odkazech na funkce).

### 9) Třída `Student` – konstrukce a vlastnosti
```csharp
public class Student
{
    public Student() { }                       // prázdný konstruktor

    public Student(string Jmeno, int Body)     // konstruktor s parametry
    {
        this.Jmeno = Jmeno;                    // "this" odkazuje na vlastnost třídy
        this.Body = Body;
    }

    public string Jmeno { get; set; } = string.Empty; // non-null díky Nullable=enable
    public int Body { get; set; }                      // int má výchozí 0

    public string Popis => Jmeno + " - " + Body;       // expression-bodied property
}
```
- **Auto‑implemented properties** (`{ get; set; }`) – C# si sám vytvoří **backing field**.
- `Jmeno` má výchozí hodnotu `string.Empty`, protože s `Nullable=enable` kompilátor hlídá, aby nebyl `null`.
- `Popis` je **read‑only** vlastnost, která se dopočítává „na požádání“ (zkrácený zápis `=>`).

---

## `.csproj` – co znamenají jednotlivé položky

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>První_cvičení___Generické_listy__NET._9_</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

- **`Sdk="Microsoft.NET.Sdk"`** – moderní „SDK styl“ projektů (méně ručního nastavování).
- **`OutputType`** = `Exe` → kompiluje se **spustitelná** konzolová aplikace (alternativa je `Library` pro DLL).
- **`TargetFramework`** = `net9.0` → cílové API a jazykové možnosti .NET 9.
- **`RootNamespace`** → výchozí namespace pro nové soubory. Editor z nepovolených znaků dělá `_`.
- **`ImplicitUsings`** = `enable` → kompilátor automaticky přidá „běžné“ `using` (globální usings).
- **`Nullable`** = `enable` → zapíná **nulovou bezpečnost** pro referenční typy. Kompilátor varuje, když bys mohl pracovat s `null`.

---

## Drobné nuance a časté chyby
- `Console.Write` vs `Console.WriteLine` – pamatuj, že `Write` **neodřádkuje**.
- `Where(...).ToList()` – nezapomeň na `ToList()`, když potřebuješ **konkrétní list**, ne jen „líný“ výsledek.
- `List<T>.ForEach` není LINQ – pokud ti chybí, kontroluj, že proměnná je opravdu **List**, ne **IEnumerable**.
- U ne‑ASCII jmen (např. „Kryštof“) se ujisti, že soubor je **UTF‑8** a konzole taky (viz `OutputEncoding`).

---

## Mini‑mapa programu (co se vypíše a proč)

1. **Seznam jmen**: založíš list, vypíšeš „Pepa,Karel,Mirek,Kryštof“, přidáš „Ivan“, odebereš „Pepa“.  
2. **List Studentů (3 způsoby vytvoření)**: vypíšeš jen jména (`Dušan Pepa Karel`).  
3. **Seznam Studentů (rychle)**: vypíšeš `Jmeno(Body)` pro 4 studenty.  
4. **LINQ agregace**: `Počet`, `Suma`, `Suma2`, `Suma>6`.  
5. **Vybraní studenti**: vypíše se `Popis` u těch, co mají `Body > 6`.  
6. **`ReadKey`**: program čeká na klávesu, než se zavře.

---

Tím bys měl rozumět **každému řádku** spuštěného programu i konfiguraci projektu.
