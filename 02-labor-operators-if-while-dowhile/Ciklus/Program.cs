using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciklus
{
    class Program
    {
        static void Main(string[] args)
        {

            // -------------------------------------------------------
            //                  C I K L U S O K
            // -------------------------------------------------------

            // 1. while - elöltesztelő ciklus           -----------------------------------------------------------------
            bool ciklusbanMaradasiFeltetel = true;
            int szamlalo = 0;
            while (ciklusbanMaradasiFeltetel /*== true*/)
            {
                Console.WriteLine("OOOOOOOOOOOO");
                szamlalo++;
                if (szamlalo == 10)
                    ciklusbanMaradasiFeltetel = false;
            }

            // Végtelen ciklus bemutatása
            /*while (true)
            {
                Console.WriteLine("llll");
            }*/

            // 2. do...while - hátultesztelő ciklus     -----------------------------------------------------------------s
            string bekertNev = "";
            do
            {
                Console.Clear();
                Console.Write("Add meg a neved:\t");
                bekertNev = Console.ReadLine();
            } while (bekertNev == "");
            Console.WriteLine("A neved:\t" + bekertNev);


                
            Console.ReadLine();
        }
    }
}
