using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[10];

            Random r = new Random();

            for (int i = 0; i < tomb.Length; i++)
                tomb[i] = r.Next(9);

            Console.WriteLine("EREDETI:");
            foreach (int elem in tomb)
                Console.WriteLine(elem);


            Console.WriteLine("==========");

            /* 1.)
             * gyűjtsük ki a tömbből, az összes
             * páros számot
             * egy új tömbbe
             * */
            Console.WriteLine("PÁROSAK:");
            int parosDarab = 0;
            int idx = -1;
            foreach (int item in tomb)
                if (item % 2 == 0) parosDarab++;

            int[] parosak = new int[parosDarab];

            foreach (int item in tomb)
                if (item % 2 == 0)
                    parosak[++idx] = item;

            // kiiras
            foreach (int item in parosak)
                Console.WriteLine(">> " + item);


            /* 2.)
             * határozzuk meg a páratlan
             * elemek átlagát
             * */
            double sum = 0;
            int ptlanDb = tomb.Length - parosDarab;
            foreach (int item in tomb)
                if (item % 2 == 1)
                    sum += item;


            Console.WriteLine(
                "A páratlan elemek szummája: {0}\n" +
                "A páratlan elemek darabszáma: {1}\n" +
                "A páratlan elemek átlaga: {2}\n",
                sum, ptlanDb, sum / ptlanDb
                );

        }
    }
}
