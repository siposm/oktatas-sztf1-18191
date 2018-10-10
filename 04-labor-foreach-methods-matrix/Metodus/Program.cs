using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodus
{
    class Program
    {

        // PÉLDA 0.
        static void Valaszto()
        {
            Console.WriteLine("");
            Console.WriteLine("=================================");
            Console.WriteLine("");
        }
        
        // PÉLDA 1.
        static int Osszeado (int a, int b)
        {
            // int c = a + b; return c;
            return a + b;
        }


        // PÉLDA 2.
        static void TombFeltolt(int[] tomb)
        {
            Random r = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = r.Next(0, 1001);
            }
        }

        // PÉLDA 3.
        static int ParosElemekSzama(int[] tomb)
        {
            int db = 0;
            foreach (int item in tomb)
            {
                if (item % 2 == 0)
                {
                    db++;
                }
            }
            return db;
        }



        // METÓDUS TÚLTERHELÉS
        
        // 1.
        static string NevKiiras(string kerNev)
        {
            string vissza = "";
            vissza = kerNev;
            return vissza;
        }

        // 2.
        static string NevKiiras(string vezNev, string kerNev)
        {
            string vissza = "";
            vissza = vezNev + kerNev;
            return vissza;
        }

        // 3.
        static string NevKiiras(string vezNev, string kozepsoNev, string kerNev)
        {
            string vissza = "";
            vissza = vezNev + kozepsoNev + kerNev;
            return vissza;
        }





        static void Main(string[] args)
        {
            // PÉLDA 1.
            int eredmeny = Osszeado(10, 20);
            Console.WriteLine(eredmeny);

            // PÉLDA 0.
            Valaszto();

            // PÉLDA 2.
            int[] tomb = new int[10];
            TombFeltolt(tomb);
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine("{0}.: \t {1}" , i , tomb[i]);
            }

            // PÉLDA 3.
            Valaszto();
            Console.WriteLine("{0} db páros szám van a tömbben." , ParosElemekSzama(tomb));


            // PÉLDA TÚLTERHELÉSRE
            Console.WriteLine(NevKiiras("Tamás"));
            Console.WriteLine(NevKiiras("Kovács", "Tamás"));
            Console.WriteLine(NevKiiras("Tóth", "Béla", "Ferenc"));
        }
    }
}
