using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch
{
    class Program
    {
        // enum-ot egyelőre nem kell tudnunk !!!
        enum Karakterek
        {
            Vasember,
            Hulk,
            Vízió,
            Pókember
        }

        static void Main(string[] args)
        {
            // switch tab tab, beírjuk az enum nevét, közbe felajánlja a studio, válasszuk ki majd enter
            // alapból legenerálódik minden enum tag-hoz a case
            Karakterek karakterek = Karakterek.Hulk;

            switch (karakterek)
            {
                case Karakterek.Vasember:
                    break;
                case Karakterek.Hulk:
                    break;
                case Karakterek.Vízió:
                    break;
                case Karakterek.Pókember:
                    break;
                default:
                    break;
            }

            // egyéb esetben, "sima" switch
            /*
             * Amire figyelünk:
             *      1. case-k le vannak zárva break-kel mindig
             *      2. legvégén a default eset (alapértelmezett), ha egyik fenti se következne be
             *      3. break-et CSAKIS switch esetében használunk kódban, más esetben NEM mert átláthatatlanná teszi
             */
            string pokemon = "Pikachu";
            switch (pokemon)
            {

                case "Balbasaur":
                    Console.WriteLine("Balbaaaaa");
                    break;

                case "Charmander":
                    Console.WriteLine("CHARIZARD IS THE KING");
                    break;

                case "Pikachu":
                    Console.WriteLine("pika pika");
                    break;

                default:
                    Console.WriteLine("ez a default ág, ha egyik fenti se teljesül akkor ez következik be");
                    break;
            }

        }
    }
}
