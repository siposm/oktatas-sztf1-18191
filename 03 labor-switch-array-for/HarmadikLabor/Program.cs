using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmadikLabor
{
    class Program
    {
        static void Main(string[] args)
        {

            // -------------------------------------------------------------------------------------------------------------
            //      ALAP DOLGOK
            // -------------------------------------------------------------------------------------------------------------
            

            // deklarálás és létrehozás
                // deklarálás -> int[] tomb;
                // létrehozás -> ... = new int[ méret ];
            int[] tomb = new int[4];
            string[] karakterlancTomb = new string[2];

            // értékadás
            tomb[0] = 10;
            tomb[1] = 20;
            tomb[2] = 3333;
            tomb[3] = 1;

            karakterlancTomb[0] = "valami";
            karakterlancTomb[1] = "valami2";

            // -----> evszamok, nevek --> vegyük észre, hogy van egy teljesen jól használható tároló eszközöm

            // ugyan úgy mint sima változó esetében
            // felül tudjuk írni a tartalmát
            tomb[0] = 999;

            // érték "lekérdezése"
            int a = tomb[0];

            // matematikai művelet elvégzése is lehetséges közvetlenül
            int b = tomb[1] * tomb[0] + tomb[2];

            
            
            // -------------------------------------------------------------------------------------------------------------
            //      HIBÁK
            // -------------------------------------------------------------------------------------------------------------
            
            // 1.) int vs int[] -- [] használata ami tömböt jelent
            //int tombX = new int[100]; // <-- mi a baja?

            // 2.) mi történik ha olyan elemre mutatok, ami nem létezik?
            //tomb[4] = 90;

            

            // -------------------------------------------------------------------------------------------------------------
            //      ÉRDEKESSÉGEK
            // -------------------------------------------------------------------------------------------------------------
            

            // 1. Hozzunk létre tömböt, aminek egy változó mondja meg, hogy mekkora legyen a mérete.
            int meret = 12;
            int[] tomb2 = new int[meret];

            // 2. Hozzunk létre tömböt, tetszőleges darabszámmal, amit a felhasználó adhat meg.
            Console.Write("Add meg mekkora legyen a tömb mérete: ");
            int tombMeret = int.Parse(Console.ReadLine());
            int[] tomb3 = new int[tombMeret];

            // 3. Írjuk ki a tömb tartalmát a 2. laboron tanult ciklussal.
            int szamlalo = 0;
            int[] tomb4 = new int[5];
            while (szamlalo < 5) // szamlalo <= 5 esetén mi lenne?
            {
                Console.WriteLine("- - " + tomb4[szamlalo++]);
                // szamlalo++;
            }
        }
    }
}
