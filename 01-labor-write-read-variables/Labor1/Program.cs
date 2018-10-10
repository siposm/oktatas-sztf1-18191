using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 1. FELADAT --------------------------------------------------
            // Konzolra kiírás.
            
            Console.WriteLine("Hello pénteki kurzus!");

            // 2. FELADAT --------------------------------------------------
            // Kérjünk be egy nevet és írjuk is ki azt.
           
            Console.WriteLine("Add meg Vasember polgári nevét:");
            string szuperhosNeve = Console.ReadLine();
            Console.WriteLine(szuperhosNeve);

            // 3. FELADAT --------------------------------------------------
            // Kérjünk be egy számot, majd írjuk ki a 10-szeresét.
            
            Console.WriteLine("Adj meg egy tetszőleges számot:");
            // a) megoldás
            string szamStringkent = Console.ReadLine();
            int szamIntkent = int.Parse(szamStringkent);
            // b) megoldás
            //      összevontuk a beolvasást a parse-olással
            //      eggyel kevesebb változó használata és rövidebb kód
            int bekertSzam = int.Parse(Console.ReadLine());

            int tizszerese = bekertSzam * 10; // külön változban a szorzást elvégezni
            Console.WriteLine("A bekért szám ez {" + bekertSzam + "}, a módosított pedig:" + bekertSzam * 10); // kiíráskor elvégezni a szorzást

            // 4. FELADAT --------------------------------------------------
            // Változó átalakítás.

            // 4.1. stringgé alakítás
            string x = bekertSzam.ToString();
            
            // 4.2. parse-olás
            string y = "4";
            int z = int.Parse(y);

            // 4.3. kasztolás (értékvesztés esetén!)
            int valtozo = 255; // byte: 0-255
            byte masikValtozo = (byte)valtozo;
            //Console.WriteLine(masikValtozo);

            
            // 5. FELADAT
            // Téglalap a és b oldalát bekérni, eltárolni egy-egy változóban
            // majd a területét és kerületét kiszámolni és kiírni a következő formában:
            // "Kerület={változó} [tabulátor] terület={változó}."
            Console.WriteLine("Add meg az 'a' oldalt.");
            int aOldal = int.Parse(Console.ReadLine());
            Console.WriteLine("Add meg az 'b' oldalt.");
            int bOldal = int.Parse(Console.ReadLine());

            // kerület: (a+b)*2
            int kerulet = (aOldal + bOldal) * 2; // figyeljünk itt is a matematikailag helyes zárójelezésre!

            // terület: a*b
            int terulet = aOldal * bOldal;

            Console.WriteLine("Kerület={"+kerulet+"} \t Terület={"+terulet+"}");
        }
    }
}
