using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_csata
{
    class Program
    {
        static void Main(string[] args)
        {
            // tömb létrehozása
            Random r = new Random();
            int[] tomb = new int[10];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = r.Next(0, 1001);
            }


            // For ciklussal hogyan is néz ki a kiíratás?
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine("a(z) {0}. elem értéke: \t [{1}]", i, tomb[i]);
            }

            Console.WriteLine("==============================================");

            // Foreach ciklussal hogyan nézne ki ugyan ez?
            int counter = 0;
            foreach (int item in tomb)
            {
                Console.WriteLine("a(z) {0}. elem értéke: \t [{1}]", counter++, item);
                // vagy counter++ itt, és fent nem inkrementáljuk
            }



            Console.WriteLine("==============================================");



            // FELADATOK MEGVALÓSÍTÁSA FOREACH CIKLUSSAL ===================================================================
            /*
             * Az itt következő feladatok ugyan azok, mint amiket a 3. laboron vettünk for ciklussal.
             * Viszont gyakorlásképpen csináljuk meg, hogy lássuk mi a különbség (pozitívum és negatívum).
             * 
             */



            // 1.) Generáljunk x db random számot foreach ciklussal. --------------------------------------------------

            // Mivel a foreach csak valamilyen adatstruktúrán -jelenleg tömbön- tud végigmenni,
            // ezért ha ilyen nem áll rendelkezésre, nem tudunk kivitelezni vele
            // "számláló" ciklust...



            // 2.) Töltsünk fel random számokkal egy tömböt, foreach ciklust használva. --------------------------------------------------

            // látható, hogy csak adat kiolvasásra használható jól igazán
            // módosításra, majd visszaírásra nem
            foreach (int item in tomb)
            {
                // item = 0;
                // tomb[item] = 0;
            }




            // 5.) Határozzuk meg az elemek összegét. --------------------------------------------------
            int osszeg = 0;
            foreach (int item in tomb)
            {
                osszeg += item;
            }
            Console.WriteLine("az elemek összege: {0}", osszeg);



            // 6.) Határozzuk meg az elemek átlagát.  --------------------------------------------------
            int atlag = osszeg / tomb.Length;
            Console.WriteLine("az elemek átlaga: {0}", atlag);
            // vagy közvetlen elosztjuk a kiíratáskor: 
            //Console.WriteLine("az elemek átlaga: {0}" , osszeg/tomb.Length);




            // 7.) Határozzuk meg a páratlan elemek átlagát. --------------------------------------------------
            int paratlanDbSzam = 0;
            int paratlanAtlag = 0;
            foreach (int item in tomb)
            {
                if (item % 2 == 1) // item = tomb[i]
                {
                    paratlanDbSzam++;
                    paratlanAtlag = item;
                }
            }
            Console.WriteLine("a páratlan elemek átlaga {0}", paratlanAtlag / paratlanDbSzam);




            // 8.) Szerepel-e 5-tel osztható szám a tömbben? Ha igen, melyik helyen? --------------------------------------------------

            // itt már sokkal sokkal célszerűbb lenne for ciklus használata
            // lévén, hogy index-et szeretnénk megkapni...

            //  (!!!) Hivatalosan ezt az Eldöntés programozási tétellel kellene/illene megvalósítani, amely
            // WHILE ciklust követelne meg, azonban most a gyakorlás kedvéért FOREACH ciklussal csináljuk.

            int index = -1;
            int szamlalo = 0;
            foreach (int item in tomb)
            {
                if (item % 5 == 0)
                {
                    index = szamlalo;
                }
                szamlalo++;
            }
            if (index != -1)
            {
                Console.WriteLine("igen, pl. a {0}. helyen", index);
            }
            else
            {
                Console.WriteLine("nem szerepel");
            }



            // 9.) Hány darab 3-mal osztható szám van a tömbben? --------------------------------------------------
            int harommalOszthatoakSzama = 0;
            foreach (int item in tomb)
            {
                if (item % 3 == 0)
                {
                    harommalOszthatoakSzama++;
                }
            }
            Console.WriteLine("{0} db 3-mal osztható szám van", harommalOszthatoakSzama);



            // 10. Gyűjtsük ki az összes páros számot. (új tömb használat) --------------------------------------------------
            int[] tomb2 = new int[tomb.Length];
            index = -1; // miért -1? majd korrigálni kell +1-gyel
            foreach (int item in tomb)
            {
                if (item % 2 == 0)
                {
                    index++;
                    tomb2[index] = item;
                }
            }
            if (index != -1)
            {
                Console.WriteLine("{0} db páros szám volt, melyek:", index + 1);
                for (int i = 0; i < index + 1; i++)
                {
                    Console.WriteLine("\t" + tomb2[i]);
                }
            }
            else
            {
                Console.WriteLine("nem volt páros szám");
            }


        }
    }
}
