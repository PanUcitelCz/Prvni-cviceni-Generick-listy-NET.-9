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

## Jak to funguje (podle kódu) – detailní průvodce

Tato sekce krok‑za‑krokem vysvětluje, co přesně dělá poskytnutý kód v `Program.cs` a proč jsou v `.csproj` některá nastavení.

### 1) `using` direktivy a `ImplicitUsings`
- `using System;`, `using System.Collections.Generic;`, `using System.Linq;`, … říká kompilátoru, z jakých **jmenných prostorů (namespaces)** se mají brát typy a rozšíření (např. `List<T>`, `Console`, LINQ metody `Where`, `Sum`).
- V `.csproj` je `ImplicitUsings=enable` → běžné „usingy“ se přidají **globálně** za vás (např. `System`, `System.Linq`). Mít je v souboru explicitně **nevadí** (jen jsou „navíc“).

### 2) `namespace` a `RootNamespace`
- V souboru je `namespace První_cvičení___Generické_listy__NET._9_`. Název vychází z `<RootNamespace>` v `.csproj`.
- Speciální znaky / mezery se převedou na `_`. Tečky v názvu **oddělují úrovně** jmenných prostorů.

### 3) Třída `Program` a metoda `Main`
- `class Program` je kontejner pro vstupní bod aplikace.
- `static void Main(string[] args)` je **start** programu. `args` by nesly argumenty z příkazové řádky (tady se nepoužívají).
- Volitelně lze zapnout `Console.OutputEncoding = Encoding.UTF8;` pro správné zobrazení diakritiky v **externí** konzoli.

### 4) Seznam řetězců: `List<string>` a základní operace
```csharp
var list = new List<string>() { "Pepa", "Karel", "Mirek", "Kryštof" };
Console.WriteLine(String.Join(",", list));

list.Add("Ivan");
Console.WriteLine(String.Join(",", list));

list.Remove("Pepa");
Console.WriteLine(String.Join(",", list));
```
- `var` → typ se **odvodí** z pravé strany (zde `List<string>`).
- `String.Join(",", list)` spojí prvky do jednoho řetězce odděleného čárkou.
- `Add` přidá prvek **na konec** (vrací `void`).
- `Remove("Pepa")` odebere **první shodu** a vrátí `bool` (zda se něco opravdu odebralo). Pro bezpečný zápis:
  ```csharp
  if (list.Remove("Pepa")) { /* úspěch */ }
  ```
- `Console.WriteLine();` bez parametru jen **odřádkuje** (prázdný řádek).

### 5) Třída `Student` – konstrukce objektů
Vytváříme tři objekty třemi způsoby:
```csharp
var s1 = new Student();          // prázdný konstruktor + pozdější nastavení vlastností
s1.Jmeno = "Dušan";
s1.Body = 14;

var s2 = new Student() { Jmeno = "Pepa", Body = 15 }; // objektový inicializátor

var s3 = new Student("Karel", 75); // náš konstruktor s parametry
```
- **Prázdný konstruktor** se hodí, když vlastnosti nastavujete postupně.
- **Objektový inicializátor** je krátký a přehledný u jednoduchých objektů.
- **Konstruktor s parametry** vynucuje, aby některé hodnoty byly známé **při vzniku** objektu.

### 6) Seznam studentů a výpis
```csharp
var liststud = new List<Student> { s1, s2, s3 };

foreach (var s in liststud)
{
    Console.Write(s.Jmeno + " ");
}
Console.WriteLine();
```
- `foreach` projde všechny položky.
- `Console.Write` **neodřádkuje**, proto se za něj přidává `Console.WriteLine()` až na konci.

### 7) Rychlá inicializace kolekce
```csharp
var seznamstudentu = new List<Student>()
{
    new Student("Pepa", 5),
    new Student("Karel", 12),
    new Student("Mirek", 8),
    new Student("Kryštof", 4)
};
```
- Kolekci naplníme **přímo** při vytváření (tzv. collection initializer).

### 8) Výpis s konkatenací vs. interpolací
```csharp
Console.Write(s.Jmeno + "(" + s.Body + ") ");
// Alternativa:
Console.Write($"{s.Jmeno}({s.Body}) ");
```
- **Interpolace** (`$"..."`) je čitelnější a méně náchylná k chybám než skládání `+`.

### 9) LINQ: `Count`, `Sum`, `Where`, `ToList`, `List<T>.ForEach`
```csharp
Console.WriteLine("Počet: " + seznamstudentu.Count);

Console.WriteLine("Suma:" + seznamstudentu.Sum(VyberBody));
Console.WriteLine("Suma2:" + seznamstudentu.Sum(x => x.Body));

Console.WriteLine("Suma>6:" + seznamstudentu.Where(x => x.Body > 6).Sum(x => x.Body));

var vybranistudenti = seznamstudentu.Where(x => x.Body > 6).ToList();
vybranistudenti.ForEach(x => Console.WriteLine(x.Popis));
```
- `seznamstudentu.Count` je **vlastnost** `List<T>` (O(1)). Alternativou je LINQ `seznamstudentu.Count()` (metoda), která u `List<T>` také umí odpovědět efektivně.
- `Sum(VyberBody)` používá **metodu** (viz níže); `Sum(x => x.Body)` používá **lambda výraz**. Obě varianty dělají totéž.
- `Where(...)` vrací **odkládaný (deferred)** výsledek `IEnumerable<Student>` – nic se dosud nevypočítalo. Až `ToList()` (nebo jiné „terminální“ volání jako `Sum`) **materializuje** data.
- `List<T>.ForEach(Action<T>)` **není** LINQ – je to metoda přímo na typu `List<T>` a vrací `void`. Používej ji jen pro **vedlejší efekty** (tisk apod.). Pro transformace a dotazy je vhodnější LINQ (`Select`, `Where`, …).

### 10) `Console.ReadKey()`
- Na konci `Main` drží okno **otevřené**, aby se ihned nezavřelo (užitečné při `Ctrl+F5`). V `F5` režimu (debug) ji klidně můžete vynechat.

### 11) Metoda `VyberBody` a její signatura
```csharp
public static int VyberBody(Student stud) => stud.Body;
```
- Tato metoda odpovídá delegátu `Func<Student, int>`, který **`Sum`** očekává. Je to „pojmenovaná“ alternativa k `x => x.Body`.

### 12) Třída `Student` – vlastnosti, konstruktory, `Popis`
```csharp
public class Student
{
    public Student() { }

    public Student(string Jmeno, int Body)
    {
        this.Jmeno = Jmeno;  // "this" odlišuje vlastnost od parametru stejného jména
        this.Body = Body;
    }

    public string Jmeno { get; set; } = string.Empty; // díky Nullable=enable se vyhneme null
    public int Body { get; set; }

    public string Popis => Jmeno + " - " + Body; // "expression-bodied" getter
}
```
- `Jmeno` má **výchozí hodnotu** `string.Empty`, aby nebylo nikdy `null` (v souladu s `Nullable=enable`).
- `Popis` je **read‑only** vlastnost zkráceným zápisem „expression‑bodied“. Vypočítává se **při čtení** (neukládá se).

### 13) `.csproj` – co znamenají položky
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>          <!-- konzolová app -->
    <TargetFramework>net9.0</TargetFramework>  <!-- .NET 9 -->
    <RootNamespace>První_cvičení___Generické_listy__NET._9_</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>    <!-- globální usingy -->
    <Nullable>enable</Nullable>                <!-- nulová bezpečnost -->
  </PropertyGroup>
</Project>
```
- **SDK‑style projekt**: moderní formát, méně boilerplate (VS doplní spoustu věcí samo).
- `OutputType=Exe` → spustitelná konzolová aplikace (místo knihovny `Library`).
- `TargetFramework=net9.0` → kompilace a běh na .NET 9.
- `RootNamespace` → výchozí jmenný prostor pro nové soubory.
- `ImplicitUsings` / `Nullable` – viz výše.

### 14) Co se děje při běhu programu (sekvence)
1. Vytvoří se `List<string>` a provede pár operací (`Add`, `Remove`), pokaždé se vypíše stav přes `String.Join`.
2. Vytvoří se tři `Student` objekty různými způsoby a přidají se do `liststud`; vypíší se jejich jména.
3. Vznikne nový `List<Student>` (`seznamstudentu`) s pevně danými daty.
4. Provede se několik dotazů/operací LINQ (`Count`, `Sum`, `Where + Sum`) a vypíšou se výsledky.
5. Vyfiltrují se studenti s `Body > 6` → `vybranistudenti`, pro každý se vypíše `Popis`.
6. `Console.ReadKey()` drží okno otevřené.

---

## Časté chyby a jak se jim vyhnout
- **`NullReferenceException`** u `Jmeno`: použij výchozí hodnotu `string.Empty` a/nebo inicializuj v konstruktoru.
- **Záměna `Count` vs. `Count()`**: u `List<T>` dej přednost **vlastnosti** `Count`. Metoda `Count()` je LINQ rozšíření (užitečné u `IEnumerable<T>` obecně).
- **`List<T>.ForEach` vs. `foreach`**: `ForEach` je pohodlné pro jednoduché side‑effects, ale `foreach` je čitelnější a univerzálnější.
- **Zapomenuté `ToList()`**: pokud chcete výsledek `Where(...)` **použít vícekrát** nebo ho předat metodě očekávající `List<T>`, nezapomeňte **materializovat**.

---

## Co zkusit dál (rozšiřující nápady)
- Přidej do `Student` metodu `bool Prospel(int min = 10)` a filtruj podle ní.
- Najdi **TOP N** studentů (`OrderByDescending(x => x.Body).Take(N)`).
- Ulož/vytiskni výsledky do CSV (string builder, `File.WriteAllText`).



---

## Jak na to **bez terminálu** (klikací postup ve Visual Studiu)

> Studenti nemusí používat žádný příkazový řádek. Všechny kroky jsou „klikací“ ve Visual Studiu 2022+.

### A) Založení projektu (klikací)
1. Otevři **Visual Studio** → **Create a new project**.  
2. Vyber šablonu **Console App** (C#, **.NET**) a potvrď **Next**.  
3. Zadej **Project name** (např. `Cv01-Listy`) a **Location**. Klikni **Next**.  
4. V **Framework** vyber **.NET 9.0** (pokud ho nevidíš, doinstaluj .NET SDK).  
5. **Create**.

### B) Nastavení vlastností projektu (klikací)
1. V **Solution Exploreru** klikni **pravým** na projekt → **Properties**.  
2. V levém menu **Build** / **General** najdeš:
   - **Nullable** → nastav **Enable** (zapne kontrolu `null`).  
   - **Implicit global usings** → **Enable** (VS automaticky přidá běžné `using`).  
3. V menu **Application** nastav:
   - **Target Framework** → **.NET 9.0** (odpovídá `TargetFramework=net9.0`).  
   - **Output type** → **Console Application** (odpovídá `OutputType=Exe`).  
   - **Default namespace** → např. `PrvniCviceni.GenerickeListy.NET9` (odpovídá `RootNamespace`).  
4. Ulož (**Ctrl+S**). Visual Studio provede zápis do `.csproj` za tebe.

### C) Přidání souborů (klikací)
1. V **Solution Exploreru** klikni pravým na projekt → **Add → New Item…**.  
2. Zvol **Class** → pojmenuj **Student.cs** → **Add**.  
3. Do `Program.cs` vlož hlavní ukázkový kód (část se `Main`).  
4. Do `Student.cs` vlož definici třídy `Student` (viz níže).

### D) Spuštění (klikací)
- Zvol v horní liště konfiguraci **Debug** a **Any CPU**.  
- Klikni **▶ Start** (F5) nebo **Debug → Start Without Debugging** (Ctrl+F5).  
- Pokud se okno hned zavře, používej **Ctrl+F5** (spustí bez ladění a **počká na klávesu**).

### E) (Volitelné) Klonování repozitáře z GitHubu – klikací
1. Visual Studio úvodní obrazovka → **Clone a repository**.  
2. Vlož **URL repozitáře** (z GitHubu → **Code** → kopírovat odkaz).  
3. Vyber **Path** (kam se to stáhne) → **Clone**.  
4. Po otevření řešení můžeš okamžitě **Start** (F5).

---

## `.csproj` – vysvětlení „co je co“ + **klikací cesta v UI**

Níže je stejný kód, jaký si VS ukládá do projektového souboru. **Není nutné ho ručně editovat** – vše umíme nastavit klikáním v **Project → Properties**.

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

- **`Sdk="Microsoft.NET.Sdk"`**  
  Moderní styl projektů. VS se postará o většinu „nudného“ nastavování.  
  *Klikací obdoba:* nevystavuje se přímo, je to default Visual Studia.

- **`OutputType` = `Exe`**  
  Vytváří **spustitelnou** konzolovou aplikaci. Alternativa je `Library` (DLL).  
  *Klikací obdoba:* **Project → Properties → Application → Output type** = *Console Application*.

- **`TargetFramework` = `net9.0`**  
  Určuje, pro jaký .NET běžíme (dostupné API a featury jazyka).  
  *Klikací obdoba:* **Project → Properties → Application → Target Framework** = *.NET 9.0*.

- **`RootNamespace`**  
  Výchozí jmenný prostor nových souborů. Z nepovolených znaků se stanou podtržítka `_`.  
  *Klikací obdoba:* **Project → Properties → Application → Default namespace**.

- **`ImplicitUsings` = `enable`**  
  VS/kompilátor **automaticky** přidá běžné `using` (např. `System`, `System.Linq`). Méně psaní.  
  *Klikací obdoba:* **Project → Properties → Build → Implicit global usings** = *Enable*.

- **`Nullable` = `enable`**  
  Zapne **nulovou bezpečnost** – kompilátor upozorní, když by proměnná mohla být `null`.  
  *Klikací obdoba:* **Project → Properties → Build → Nullable** = *Enable*.

---

## OOP základ pro toto cvičení (velmi podrobně)

### Třída (`class`)
- **Definice šablony**: popisuje **jak vypadá objekt** (jaké má **vlastnosti/fields/properties** a **chování/metody**).  
- V našem kódu jsou třídy dvě: `Program` (obal s metodou `Main`) a `Student` (naše doménová entita).

**Ukázka:**
```csharp
public class Student
{
    // Vlastnosti
    public string Jmeno { get; set; } = string.Empty;
    public int Body { get; set; }

    // Konstruktor s parametry
    public Student(string jmeno, int body)
    {
        Jmeno = jmeno;
        Body = body;
    }

    // Vypočítávaná vlastnost (read-only)
    public string Popis => Jmeno + " - " + Body;
}
```

#### Druhy tříd (nejčastější v C#)
- **Obyčejná třída** (reference type) – jde instancovat přes `new`. *(Student)*  
- **`static class`** – nejde instancovat; všechny členy musí být `static`. Užívá se pro **pomocné funkce**.  
- **`abstract class`** – nejde přímo instancovat; slouží jako **základ** pro dědičnost a může mít abstraktní metody.  
- **`sealed class`** – **nelze** z ní dědit (uzamčená).  
- **`partial class`** – definice třídy může být **rozdělena** do více souborů.  
- **Generická třída** – má **typový parametr**, např. `List<T>`, `Dictionary<TKey, TValue>`.  
- **`record class`** – třída s důrazem na **data a rovnost** podle hodnot (hodí se na DTO/immutable objekty).  
- *(Pro úplnost)* **vnořené třídy** (nested) – třída **uvnitř** jiné třídy.

> V začátku ti bude stačit obyčejná třída. Ostatní modifikátory se hodí postupně podle potřeby.

### Objekt (instance třídy)
- **Konkrétní „kus“** vytvořený z třídy pomocí `new`.  
- Držen **v paměti na haldě** (heap), proměnná ukládá **referenci**.

**Ukázka:**
```csharp
var s1 = new Student("Karel", 75); // s1 je objekt (instance) třídy Student
```
- K jeho členům přistupujeme **tečkou**: `s1.Jmeno`, `s1.Body`, `s1.Popis`.

### Vlastnost (`property`) vs. pole (`field`)
- **Pole (field)** je „holá proměnná“ uvnitř třídy (bez logiky).  
- **Vlastnost (property)** má **`get; set;`** – lze doplnit logiku, validaci nebo jen nechat auto‑generovat **backing field**.

**Doporučení:** V aplikačním kódu používej **vlastnosti**. Pole nech pro interní implementační detaily, případně `readonly` konstanty.

### Metoda
- **Funkce uvnitř třídy** – něco **dělá** (má název, parametry, typ návratu).

**Druhy metod (užitečné rozdělení):**
- **Instance vs. `static`**:  
  - *Instance metoda* pracuje s **konkrétním objektem** (`this`). Volá se přes instanci: `s1.Vypis()`.  
  - *Statická metoda* patří třídě jako celku. Volá se přes název třídy: `Console.WriteLine(...)`.
- **`void` vs. návratová hodnota**:  
  - `void` nic **nevrací** (má typ návratu `void`).  
  - Jiný typ (např. `int`, `string`) znamená, že **vrací výsledek** přes `return`.
- **Čistá (pure) vs. vedlejší účinky**:  
  - *Pure* metoda vrací výsledek **bez** změny stavu (snadno testovatelná).  
  - Metoda s *vedlejšími účinky* mění stav (např. zapisuje do konzole, mění vlastnosti).
- **Synchronní vs. asynchronní**:  
  - *Synchronní* běží „teď hned“.  
  - *Asynchronní* vrací `Task/Task<T>` a může využít `await` (v tomto cvičení neřešíme).
- **Speciální metody**:  
  - **Konstruktory** – jmenují se stejně jako třída, **bez** návratového typu. Slouží k inicializaci objektu.  
  - **Finalizer** (`~Třída`) – vzácně používaný „destruktor“ (spravuje ho GC; běžně se nepíše).

**Ukázka několika metod:**
```csharp
public class Knihovna
{
    // Statická "pomocná" metoda
    public static int Secti(int a, int b) => a + b;

    // Instance metoda (potřebuje objekt)
    public void VypisStudenta(Student s) => Console.WriteLine($"{s.Jmeno} ({s.Body})");

    // Metoda s návratovou hodnotou
    public bool Prospel(Student s, int hranice = 10) => s.Body >= hranice;

    // "Void" metoda s vedlejším účinkem (výpis do konzole)
    public void Vypis(string text) => Console.WriteLine(text);
}
```

### Modifikátory přístupu (stručně, ale důležité)
- `public` – viditelné **odkudkoli**.  
- `private` – viditelné **jen uvnitř třídy** (default pro členy).  
- `internal` – viditelné v **rámci projektu/assembly**.  
- `protected` – viditelné v **potomcích** (dědičnost).

> V ukázkách používáme `public` u třídy `Student`, aby s ní mohl pracovat i kód v `Program.cs`.

---

## Co z toho si odnést (shrnutí pro studenty)
- `class` = **šablona**, `object` = **konkrétní instance** vytvořená přes `new`.  
- **Vlastnosti** (`get; set;`) jsou preferované pro data objektu.  
- **Metody** dělí chování na smysluplné kousky (instance vs. static, vrací/nevrací).  
- **LINQ** výrazně zjednodušuje práci se seznamy: `Where`, `Sum`, `Count`, `ToList`.  
- V **Properties** projektu (klikací) umíme nastavit vše důležité; **terminál není potřeba**.

