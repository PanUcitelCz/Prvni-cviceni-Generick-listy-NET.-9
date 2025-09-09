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
