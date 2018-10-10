using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor02_operator_if_ciklus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // -------------------------------------------------------
            //                  O P E R Á T O R O K
            // -------------------------------------------------------

            int a = 10;
            int b = 30;

            // összeadás
            int c = a + b;

            // egybevont összeadás
            int e = 0;
            e += a; // e = e + a;

            // szorzás
            c = a * b;

            // osztás
            c = a / b;
            c = 0;

            // érték növelése 1-gyel
            c++;
            ++c; // if(++c == 2)
            
            // érték csökkentése 1-gyel
            c--;
            --c;
            
            // modulós osztás
            int d = a % b;  // fekete fehér váltakozása



            Console.ReadLine();
        }
    }
}
