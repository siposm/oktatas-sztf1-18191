using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_feladatok
{
    class Program
    {

        // *******************************************
        //              M E T Ó D U S O K
        // *******************************************

        // bekérések
        static string BekeresVegyes()
        {
            Console.Write("Adj megy egy karatersorozatot: ");
            string x = Console.ReadLine();
            return x;
        }

        static string[] BekeresNev()
        {
            Console.Write("Add meg a vezeték neved: ");
            string x = Console.ReadLine();
            Console.Write("Add meg a kereszt neved: ");
            string y = Console.ReadLine();

            string[] vissza = new string[2];
            vissza[0] = x;
            vissza[1] = y;

            return vissza;
        }

        static string[] BekerNevEvszam()
        {
            Console.WriteLine("Add meg az adatokat a következő formában: [veznév]@[kernev]@[évszám].");
            string bemenet = Console.ReadLine();

            string[] daraboltBemenet = bemenet.Split('@');

            return daraboltBemenet;
        }


        // vizsgálatok, feladatok
        static void NagybetusseAlakitas(string bemenet)
        {
            string vissza = "";
            for (int i = 0; i < bemenet.Length; i++)
            {
                vissza += char.ToUpper(bemenet[i]); // visszatérési értékkel teszi nagybetűssé!!!
            }
            Console.WriteLine(vissza);
        }

        static void NagybetusE(string veznev, string kernev)
        {
            string ujVeznev = "";
            string ujKernev = "";

            Console.WriteLine("EREDETI");
            Console.WriteLine(veznev + " " + kernev);

            // vezeték név
            ujVeznev += veznev[0].ToString().ToUpper();
            for (int i = 1; i < veznev.Length; i++)
            {
                ujVeznev += veznev[i];
            }

            // keresztnév
            ujKernev += kernev[0].ToString().ToUpper();
            for (int i = 1; i < kernev.Length; i++)
            {
                ujKernev += kernev[i];
            }


            Console.WriteLine("MÓDOSÍTOTT");
            Console.WriteLine(veznev + " " + kernev);
        }

        static void Megfordit(string[] bemenet)
        {
            string vissza = "";
            string eredeti = "";

            for (int i = 0; i < bemenet.Length; i++)
            {
                eredeti += bemenet[i] + " ";
            }

            for (int i = eredeti.Length-1; i >= 0; i--)
            {
                vissza += eredeti[i];
            }

            Console.WriteLine("EREDETI: " + eredeti);
            Console.WriteLine("MÓDOSÍTOTT: " + vissza);
        }



        // Érdekesebb megvalósítás:

        static string[] NevBeker()
        {
            Console.Write("Add meg a vezeték neved: ");
            string veznev = Console.ReadLine();
            Console.Write("Add meg a keresztneved: ");
            string kernev = Console.ReadLine();

            string[] vissza = new string[2];
            vissza[0] = veznev;
            vissza[1] = kernev;

            return vissza;
        }

        static string[] NagybetusNev(string[] bemenet)
        {
            string ujVeznev = "";
            string ujKernev = "";

            // vezeték név
            ujVeznev += bemenet[0][0].ToString().ToUpper();
            for (int i = 1; i < bemenet[0].Length; i++)
                ujVeznev += bemenet[0][i];

            // keresztnév
            ujKernev += bemenet[1][0].ToString().ToUpper();
            for (int i = 1; i < bemenet[1].Length; i++)
                ujKernev += bemenet[1][i];

            Console.WriteLine(
                "EREDETI: " + bemenet[0] + " " + bemenet[1]);
            Console.WriteLine(
                "MODOSITOTT: " + ujVeznev + " " + ujKernev);


            return new string[] { ujVeznev, ujKernev };
        }





        static void Main(string[] args)
        {

            /* 
             * MINDEN ESETBEN KÜLÖN METÓDUSSAL VALÓSÍTSA MEG A FELADATOT!
             * 
             * Készítsen konzolos alkalmazást, amely...
             * 
             * 1. FELADAT
             * ...a felhasználótól bekér egy tetszőleges karaktersorozatot, majd azt kiírja a konzolra csupa nagybetűvel.
             * 
             * 
             * 2. FELADAT
             * ...a felhasználótól bekéri a teljes nevét, majd megvizsgálja, hogy az első-első betű nagybetű-e.
             * Ha igen, akkor ne végezzen módosítást.
             * Ha viszont kis betű, akkor tegye őket nagybetűvé és írassa ki az eredeti majd módosított állapotot.
             * 
             * 
             * 3. FELADAT
             * ... amely bekér egy karatersorozatot a felhasználótól.
             * A karatersorozat várható formája a következő: ___@___@___
             * Ahol az első __ hely a vezetéknevet, a második __ hely a keresztnevet, az utolsó __ pedig az évszámot reprezentálja.
             * Írja ki az eredeti és fordított sorrendben a karaktereket.
             * 
             * */

            // 1. FELADAT
            string bekertAdat = BekeresVegyes();
            NagybetusseAlakitas(bekertAdat);

            // 2. FELADAT
            string[] bekertnev = BekeresNev();
            NagybetusE(bekertnev[0], bekertnev[1]);

            // 3. FELADAT
            Megfordit(BekerNevEvszam()); // metódus metódusba ágyazva

        }
    }
}
