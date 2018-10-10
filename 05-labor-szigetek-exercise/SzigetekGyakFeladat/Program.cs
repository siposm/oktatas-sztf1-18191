using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigetekGyakFeladat
{
    class Program
    {

        // 1. feladat
        // Valósítsa meg a tömb véletlenszerű feltöltését!
        static void MeresekGeneralasa(int[] meresiErtekek)
        {
            Random r = new Random();
            for (int i = 0; i < meresiErtekek.Length; i++)
            {
                if (r.Next(0, 11) <= 4) // 40% esély szimulálása
                    meresiErtekek[i] = r.Next(1, 11); // itt már nem lehet benne nulla, hisz az tenger lenne!
                else
                    meresiErtekek[i] = 0;
            }
        }


        // 2. feladat
        // Jelenítse meg a mérési eredményeket a képernyőn!
        static void MeresekMegjelenitese(int[] meresiErtekek)
        {
            Console.WriteLine("");
            Console.WriteLine("- - = = A MÉRT ÉRTÉKEK = = - -");
            for (int i = 0; i < meresiErtekek.Length; i++)
            {
                Console.WriteLine("\t" + meresiErtekek[i]);
            }
        }


        // 3. feladat
        // Határozza meg, hogy hol található (először) a legmagasabb pont, és mennyi ennek a magassága!
        static int[] LegmagasabbPont(int[] meresiErtekek)
        {
            int[] legmagasabbPontIndexek = new int[meresiErtekek.Length]; // hol
            int[] legmagasabbPontErtekek = new int[meresiErtekek.Length]; // mennyi
            int tombIndex = 0;

            // feltételezzük, hogy a max elem az első (0.)
            int maxIndex = 0;
            int maxErtek = meresiErtekek[maxIndex];
            legmagasabbPontErtekek[tombIndex] = maxErtek;
            legmagasabbPontIndexek[tombIndex] = maxIndex;

            for (int i = 1; i < meresiErtekek.Length; i++)
            {
                if (maxErtek < meresiErtekek[i])
                {
                    // van új max
                    maxIndex = i;
                    maxErtek = meresiErtekek[maxIndex];

                    // mivel új max elem van, nullázni kell az eddigieket
                    tombIndex = 0;

                    // eltárolom az új maxot
                    legmagasabbPontErtekek[tombIndex] = maxErtek;
                    legmagasabbPontIndexek[tombIndex] = maxIndex;
                }
                else if (maxErtek == meresiErtekek[i])
                {
                    // a jelenlegi max-al megegyező értéket találtunk
                    tombIndex++;
                    legmagasabbPontErtekek[tombIndex] = meresiErtekek[i];
                    legmagasabbPontIndexek[tombIndex] = i;
                }
            }

            // a két tömbben mostmár ki vannak gyűjtve a max helyek és értékek
            // ebből kell nekünk az első "pár"

            int[] maxVissza = new int[3];
            maxVissza[0] = legmagasabbPontIndexek[0];
            maxVissza[1] = legmagasabbPontErtekek[0];
            maxVissza[2] = tombIndex;

            // < ! >
            // debug módban látható, hogy nem lenne szükség az értékeket tömbben tárolni
            // hiszen úgyis ugyan az az érték lesz... 
            // viszont így jól látható, hogy azonos indexen tárolhatók összetartozó elemek, csak más-más tömbben

            return maxVissza;
        }


        // 4. feladat
        // Adja meg, hogy a legmagasabb pont hányszor fordult elő a repülés során!
        // ---> Ezt a 3. feladatban egyszerűen le lehet kérdezni. (tombindex)

        // 5. feladat
        // Határozza meg a leghosszabb szigetszakasz hosszát!

        // 6. feladat
        // Adja meg, hogy a leghosszabb szigeten található-e az első maximális magasságú mérési pont!

             



        static void Main(string[] args)
        {
            // 1.
            int[] meresiErtekek = new int[30];
            MeresekGeneralasa(meresiErtekek);

            // 2.
            MeresekMegjelenitese(meresiErtekek);

            // 3.
            int[] legMagPontEredmenyek = LegmagasabbPont(meresiErtekek);
            // VAGY
            //int legmagasabbPontIndexe = LegmagasabbPont(meresiErtekek)[0];
            //int legmagasabbPontErteke = LegmagasabbPont(meresiErtekek)[1];
            // utóbbi esetben KÉTSZER hívódik meg a függvény -> fölösleges erőforrás...

            Console.WriteLine("");
            Console.WriteLine("A legmagasabb pont {0}. helyen található, értéke pedig: {1}", legMagPontEredmenyek[0], legMagPontEredmenyek[1]);
            Console.WriteLine("A legmagasabb pont {0} db alkalommal fordult elő.", legMagPontEredmenyek[2] + 1);

        }
    }
}
