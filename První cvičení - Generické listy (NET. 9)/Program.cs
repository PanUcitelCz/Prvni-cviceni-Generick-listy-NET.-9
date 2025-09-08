// Tyto "usingy" říkají, z jakých jmenných prostorů budeme brát typy.
// S ImplicitUsings=enable by šlo většinu z nich smazat (kompilátor je má globálně).
using System;                      // Console, String, ...
using System.Collections.Generic;  // List<T>
using System.Linq;                 // LINQ: Where, Sum, ToList, ...
using System.Text;                 // Encoding (volitelně pro UTF-8 výstup). Jednodušeji řečeno: Umí český znaky.
using System.Threading.Tasks;      // Task (zde ho nepoužíváme, ale necháváme kvůli přehlednosti)

namespace První_cvičení___Generické_listy__NET._9_  // Namespace odpovídá RootNamespace v .csproj
{
    // Třída Program je "obal" pro naši metodu Main (vstupní bod aplikace).
    class Program
    {
        // Main je start programu. Parametr args by nesl argumenty z příkazové řádky (zde je nepoužíváme).
        static void Main(string[] args)
        {
            // Volitelné: pokud by v externím okně CMD zlobila diakritika, odkomentuj následující řádek.
            // (Ve VS Debug Console obvykle není potřeba.)
            // Console.OutputEncoding = Encoding.UTF8;

            // ------------------------------------------------------------
            // 1) Seznam (List<string>) a základní operace
            // ------------------------------------------------------------

            // "var" = kompilátor sám odvodí datový typ z pravé strany.
            // Zde vznikne List<string> (seznam řetězců) se 4 položkami.

            var list = new List<string>() { "Pepa", "Karel", "Mirek", "Kryštof" };

            // String.Join(",", list) spojí všechny prvky seznamu do jednoho řetězce odděleného čárkou.
            Console.WriteLine(String.Join(",", list));

            // Přidání nové položky na konec seznamu.
            list.Add("Ivan");
            Console.WriteLine(String.Join(",", list));

            // Odebrání první shodné položky ("Pepa") ze seznamu (pokud existuje).
            list.Remove("Pepa");
            Console.WriteLine(String.Join(",", list));

            // Prázdný řádek kvůli přehlednosti výstupu.
            Console.WriteLine();


            // ------------------------------------------------------------
            // 2) Vytvoření vlastní třídy Student a práce se seznamem Studentů
            // ------------------------------------------------------------

            // Způsob A: vytvořím prázdný objekt a vlastnosti nastavím postupně.
            // Této operaci se říká instanceování (instantiating).
            var s1 = new Student();       // zavolá se prázdný konstruktor
            s1.Jmeno = "Dušan"; // Pokud jsme do proměnné uložili objekt, přistupujeme k jeho vlastnostem pomocí tečky.
            s1.Body = 14;

            // Způsob B: objekt inicializuju přímo pomocí inicializátoru objektu { ... }
            var s2 = new Student() { Jmeno = "Pepa", Body = 15 };

            // Způsob C: použiju náš konstruktor s parametry (viz definice ve třídě Student)
            var s3 = new Student("Karel", 75);

            // Vytvořím prázdný seznam Studentů a přidám do něj tři položky.
            var liststud = new List<Student>();
            liststud.Add(s1);
            liststud.Add(s2);
            liststud.Add(s3);

            // Projdu seznam pomocí foreach (postupně vezmu každý prvek "s").
            // "Console.Write" nevkládá nový řádek, proto se jména vypisují vedle sebe.
            foreach (var s in liststud)
            {
                Console.Write(s.Jmeno + " ");
            }
            // Po cyklu si ručně odřádkujeme.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // ------------------------------------------------------------
            // 3) Rychlá inicializace seznamu Studentů + výpis
            // ------------------------------------------------------------

            // Seznam vytvoříme rovnou s obsahem (čtyři studenti).
            var seznamstudentu = new List<Student>()
            {
                // Zde vytváříme nové instance Student pomocí konstruktoru s parametry.
                new Student("Pepa", 5),
                new Student("Karel", 12),
                new Student("Mirek", 8),
                new Student("Kryštof", 4)
            };

            // Vypíšeme jméno a body každého studenta.
            foreach (var s in seznamstudentu)
            {
                // Skládání řetězců operátorem + (alternativu s interpolací máš hned vedle).
                Console.Write(s.Jmeno + "(" + s.Body + ") ");

                // Alternativa (modernější a čitelná): řetězcová interpolace
                // Console.Write($"{s.Jmeno}({s.Body}) ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // ------------------------------------------------------------
            // 4) Agregace a filtrace pomocí LINQ (Where, Sum, Count)
            // ------------------------------------------------------------

            // Počet prvků v List<T> přes vlastnost Count (není to LINQ, je to přímo vlastnost Listu).
            Console.WriteLine("Počet: " + seznamstudentu.Count);

            // Suma bodů přes "metodu" (delegát) - neanonymní funkce.
            // Sum očekává funkci, která z elementu (Student) "vybere" číslo (int).
            // My jí dáme odkaz na metodu VyberBody (viz níže).
            Console.WriteLine("Suma:" + seznamstudentu.Sum(VyberBody));

            // Totéž kratší cestou přes "lambda výraz".
            // x => x.Body znamená: "vezmi studenta x a vrať x.Body".
            Console.WriteLine("Suma2:" + seznamstudentu.Sum(x => x.Body));

            // Kombinace Where (filtrace) + Sum (součet).
            // Nejprve vezmeme jen studenty s Body > 6 a z nich sečteme Body.
            Console.WriteLine("Suma>6:" + seznamstudentu.Where(x => x.Body > 6).Sum(x => x.Body));

            // ------------------------------------------------------------
            // 5) Vytvoření nového seznamu vybraných studentů a výpis
            // ------------------------------------------------------------

            // Where vrací "líný" (odkládaný) výsledek typu IEnumerable<Student>.
            // ToList() to "zmaterializuje" do List<Student>.
            var vybranistudenti = seznamstudentu.Where(x => x.Body > 6).ToList();

            // List<T>.ForEach(Action<T>) - projdi seznam a na každém prvku proveď akci (zde vypiš Popis).
            // Pozor: tohle je ForEach z Listu, NENÍ to LINQ rozšíření.
            vybranistudenti.ForEach(x => Console.WriteLine(x.Popis));

            // Stejná logika klasickým foreach:
            // foreach (var s in vybranistudenti)
            // {
            //     Console.WriteLine(s.Popis);
            // }

            // Na závěr počkáme na stisk klávesy, aby se okno hned nezavřelo (užitečné při Ctrl+F5).
            Console.ReadKey();
        }

        // ------------------------------------------------------------
        // Pomocná "neanonymní" funkce pro Sum
        // ------------------------------------------------------------
        // Signatura přesně odpovídá tomu, co Sum potřebuje: ze Studenta vrátí int (Body).
        public static int VyberBody(Student stud)
        {
            return stud.Body;
        }
    }

    // ------------------------------------------------------------
    // Definice třídy Student
    // ------------------------------------------------------------
    public class Student
    {
        // Prázdný (výchozí) konstruktor - hodí se, když potřebujeme objekt vytvořit "na prázdno"
        // a až pak mu nastavovat vlastnosti.
        public Student() { }

        // Konstruktor s parametry pro rychlé naplnění při vytváření instance.
        public Student(string Jmeno, int Body)
        {
            // this.Jmmeno odkazuje na vlastnost třídy, Jmeno bez this je parametr metody.
            // Díky tomu se vlastnost nastaví na hodnotu předanou jako parametr.
            // Mohou se díky tomu jmenovat stejně kvůli přehlednosti.
            this.Jmeno = Jmeno;
            this.Body = Body;
        }

        // VLASTNOSTI (Properties)
        // S Nullable=enable by kompilátor varoval, že "Jmeno" může zůstat nenastaveno.
        // Proto mu dáme bezpečnou výchozí hodnotu: prázdný string.
        public string Jmeno { get; set; } = string.Empty;

        /*
           { get; set; } znamená:

           get;  -> veřejný čtecí přístup. Umožňuje získat hodnotu:
                    Console.WriteLine(student.Jmeno);  // použije get

           set;  -> veřejný zápisový přístup. Umožňuje nastavit hodnotu:
                    student.Jmeno = "Pepa";            // použije set

           V pozadí si C# vytvoří skryté soukromé pole (backing field),
           kam se hodnota ukládá. My nemusíme psát extra kód.

           = string.Empty znamená, že výchozí hodnota je prázdný řetězec,
           takže tam nikdy nebude null (to je potřeba kvůli Nullable=enable).
        */

        // int (celé číslo) je datový typ – má implicitní výchozí hodnotu 0, takže tady nic řešit nemusíme.
        public int Body { get; set; }

        // "Expression-bodied" vlastnost (zkrácený zápis get-only).
        // Popis vrátí např. "Karel - 12".
        // => "Vezmi vstup a vyrob výstup" (podobně jako lambda výraz).
        public string Popis => Jmeno + " - " + Body;

        /* Normální zápis s returnem:
            public string Popis
            {
                get { return Jmeno + " - " + Body; }
            }

            // Zkrácený zápis pomocí =>
            public string Popis => Jmeno + " - " + Body;
        */
    }
}

/*
OČEKÁVANÝ VÝSTUP:

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
*/
