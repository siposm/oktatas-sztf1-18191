using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_Foreach
{
    class Program
    {
        static void Main(string[] args)
        {


            // Random szám létrehozása
            Random rand = new Random();
            int szam = rand.Next(0, 10);
            
            Console.WriteLine(szam);

            
            
            // 1.) Generáljunk x db random számot for ciklussal.                                --------------------------------------------------------------------
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("---\t" + rand.Next(0,11));
            }

            
            
            // 2.) Töltsünk fel random számokkal egy tömböt, for ciklust használva.             --------------------------------------------------------------------
            // tömb hosszának lekérzése: tomb.Length
            int[] tomb = new int[100];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rand.Next(0, 100);
            }

            
            
            // 3.) Készítsünk egy tömböt, 100 elemmel.                                          --------------------------------------------------------------------
            // Minden második helyre 7777-et írjunk be, majd külön ciklussal írassuk is ki. 
            int[] tomb2 = new int[100];
            for (int i = 0; i < 100; i+=2)
            {
                // if(i%2==0) is működhetne, DE...
                // használjuk az iterátort
                tomb2[i] = 7777;
            }

            // kiíratás
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(tomb2[i]);
            }


            
            
            // 4.) Tömböt töltsük fel véletlen számokkal.                                       --------------------------------------------------------------------
            int[] tomb3 = new int[40];
            for (int i = 0; i < tomb3.Length; i++)
            {
                tomb3[i] = rand.Next(100);
            }

            
            
            // 5.) Határozzuk meg az elemek összegét.                                           --------------------------------------------------------------------
            int osszeg = 0;
            for (int i = 0; i < tomb3.Length; i++)
            {
                osszeg += tomb3[i];
            }

            
            
            // 6.) Határozzuk meg az elemek átlagát.                                            --------------------------------------------------------------------
            int atlag = 0;
            for (int i = 0; i < tomb3.Length; i++)
            {
                atlag += tomb3[i];
            }
            atlag = atlag / tomb3.Length;

            
            
            // 7.) Határozzuk meg a páratlan elemek átlagát.                                    --------------------------------------------------------------------
            int ptlanAtlag = 0;
            int ptlanDbSzam = 0;
            for (int i = 0; i < tomb3.Length; i++)
            {
                // itt már nem jó az iterátor kettővel való növelése!!
                if (tomb3[i] % 2 == 1)
                {
                    ptlanAtlag += tomb3[i];
                    ptlanDbSzam++;
                }
            }
            ptlanAtlag = ptlanAtlag / ptlanDbSzam;

            
            
            // 8.) Szerepel-e 5-tel osztható szám a tömbben? Ha igen, melyik helyen?            --------------------------------------------------------------------
            //  (!!!) Hivatalosan ezt az Eldöntés programozási tétellel kellene/illene megvalósítani, amely
            // WHILE ciklust követelne meg, azonban most a gyakorlás kedvéért FOR ciklussal csináljuk.
            int index = 0;

            for (int i = 0; i < tomb3.Length; i++)
            {
                if (tomb3[i] % 5 == 0) index = i;
            }

            
            
            // 9.) Hány darab 3-mal osztható szám van a tömbben?                                --------------------------------------------------------------------
            int harommalOszthatoDbSzam = 0;
            for (int i = 0; i < tomb3.Length; i++)
            {
                if (tomb3[i] % 3 == 0) harommalOszthatoDbSzam++;
            }


            // 10. Gyűjtsük ki az összes páros számot. (új tömb használat)                      --------------------------------------------------------------------
            int[] parosSzamok = new int[tomb.Length];
            int parosSzamokIndex = -1;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    parosSzamokIndex++;
                    parosSzamok[parosSzamokIndex] = tomb[i];
                }
            }
            if (parosSzamokIndex != -1)
            {
                for (int i = 0; i < parosSzamokIndex; i++)
                {
                    Console.WriteLine("- - - " + parosSzamok[i]);
                }
            }
            else
                Console.WriteLine("Nem volt páros szám a tömbben.");
        }
    }
}
