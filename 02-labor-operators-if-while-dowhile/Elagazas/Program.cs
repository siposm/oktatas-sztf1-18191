using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elagazas
{
    class Program
    {
        static void Main(string[] args)
        {

            // -------------------------------------------------------
            //                  E L Á G A Z Á S
            // -------------------------------------------------------

            // 1. szerkezeti bemutatás                  -----------------------------------------------------------------
            bool feltetel = true;
            if (feltetel)
                Console.WriteLine("igaz"); // 1 db utasítás
            else
            {
                Console.WriteLine("hamis");
                Console.WriteLine("még egy kiírás...."); // kódblokk {..}
            }



            // 2. Érték egyezőség vizsgálat             -----------------------------------------------------------------
            string nev = "Ultron";
            if (nev == "Ultron")
            {
                Console.WriteLine("A név megegyezik.");
            }
            else
                Console.WriteLine("A név eltér.");



            // 3. Érték nem egyezőség vizsgálat         -----------------------------------------------------------------
            if (nev != "Ultron")
                Console.WriteLine("A név eltér");
            else
                Console.WriteLine("A név megegyezik.");



            // 4. Érték kisebb/nagyobb vizsgálat        -----------------------------------------------------------------
            int x = 200;
            if (x >= 10)
                Console.WriteLine("Az érték nagyobb vagy egyenlő mint tíz.");



            // 5. Egymásba ágyazhatósági lehetőség      -----------------------------------------------------------------
            // adott szám x és y közötti tartományban van-e
            x = 200;
            if (x < 300) // felső limit
            {
                // kisebb mint 300
                if (x > 199) // alsó limit
                {
                    // nagyobb mint 199
                    if (x == 200) // 200 az?
                    {
                        Console.WriteLine("A szám 200!");
                    }
                    else
                    {
                        // bármi lehet
                        // itt
                        // úgy sem lépne ide, ha x = 200
                    }
                }
            }



            // 6. Összetett feltételek megadása         -----------------------------------------------------------------
            // 6.1. adott szám x és y között van-e
            x = 200;
            if (x < 300 && x > 190)
            {
                Console.WriteLine("Az x szám 300 és 190 között van.");
            }

            // 6.2. az ember neve Feca vagy Feri?
            string emberNev = "Feri";
            if (emberNev == "Feca" || emberNev == "Feri")
            {
                Console.WriteLine("A név vagy Feca vagy Feri.");
            }

            // 6.3. rövidzár kiértékelés
            // Órákon elhangzott!

            // 7. Modulós osztás tipikus példája        -----------------------------------------------------------------
            int szam = 10;
            bool parosE;
            // string uzenet; ---> ha csak így lenne, hibásnak jelzi, nézzük meg !!!
            string uzenet = "";
            if (szam % 2 == 0)
            {
                uzenet = "Az 'a' változó (" + szam + ") páros szám, mert kettővel osztva a maradék nulla.";
                parosE = true;
            }
            Console.WriteLine(uzenet);

        }
    }
}
