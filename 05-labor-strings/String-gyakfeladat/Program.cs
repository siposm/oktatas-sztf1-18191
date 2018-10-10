using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_gyakfeladat
{
    class Program
    {


        static string NeptunGeneral()
        {

            Random r = new Random();
            char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string neptunKod = "";

            for (int i = 0; i < 6; i++) // neptun kód karakterszáma
            {

                if (r.Next(0,2) == 0)
                {
                    // betű - abc-ből valamilyek karakter
                    neptunKod += abc[r.Next(0, abc.Length)]; // nem kell -1 !!!
                }
                else
                {
                    // szám - 0-9
                    neptunKod += r.Next(0, 10);
                }
            }

            return neptunKod;
            
        }

        static int BetuSzamlal(string bemenet)
        {
            int szamlalo = 0;
            for (int i = 0; i < bemenet.Length; i++)
            {
                if ( char.IsLetter(bemenet[i]) )
                {
                    szamlalo++;
                }
            }
            return szamlalo;
        }

        static string SpaceTorol(string bemenet)
        {
            string vissza = "";

            for (int i = 0; i < bemenet.Length; i++)
            {
                if (bemenet[i] != ' ')
                {
                    vissza += bemenet[i];
                }
            }

            return vissza;
        }

        static bool PalindromE(string eredetiSzoveg) // spacek gondot okozhatnak !!!
        {
            bool palindrom = true;

            string forditottSzoveg = "";

            // string spaceMentesSzoveg = SpaceTorol(eredetiSzoveg); // >> erre is lenne lehetőség

            // készítettünk egy fordított stringet
            for (int i = eredetiSzoveg.Length-1; i >= 0; i--)
            {
                forditottSzoveg += eredetiSzoveg[i];
            }

            // vizsgálat egyszerűen azonos helyen lévő karakterek összehasonlítása
            for (int i = 0; i < eredetiSzoveg.Length; i++)
            {
                if (eredetiSzoveg[i] != forditottSzoveg[i])
                {
                    palindrom = false;
                }
            }

            return palindrom;
        }

        static void MatrixGeneral(char[,] matrix)
        {
            Random r = new Random();
            char[] abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = abc[r.Next(0, abc.Length)];
                }
            }
        }

        static void MatrixKiir(char[,] matrix)
        {
            Console.WriteLine("\n\tA MÁTRIX:\n------------------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        static int[] MatrixSorbanSzam(char[,] matrix)
        {
            // A. opció: string-be összefűzzük elválasztó karakterekkel
            // B. opció: tömbbe kigyűjtük

            int[] sorokbanSzamok = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (char.IsDigit(matrix[i, j]))
                        sorokbanSzamok[i]++;
                }
            }

            return sorokbanSzamok;
        }

        static int[] MatrixOszlopbanBetu(char[,] matrix)
        {
            // A. opció: string-be összefűzzük elválasztó karakterekkel
            // B. opció: tömbbe kigyűjtük

            int[] oszlopokbanBetuk = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (char.IsLetter(matrix[j,i])) // mj.: ha ez a for ciklus felállása!
                        oszlopokbanBetuk[i]++;
                }
            }

            return oszlopokbanBetuk;
        }


        static void Main(string[] args)
        {


             // 0. Írjon programot, amely előállít egy véletlen Neptun kódot!
             // A Neptun kódok 6 karakterből állnak. Minden karakter az angol ABC nagybetűje, illetve 0 és 9 közötti számjegy lehet.
            
            string nk = NeptunGeneral();
            Console.WriteLine(nk);


            // 1. Írjon programot, amely egy szöveges változóban megszámolja a betűket!

            int szam = BetuSzamlal(nk);
            Console.WriteLine("{0}-ben {1} db betű van.", nk, szam);


            // 2. Írjon programot, amely egy szövegből eltűnteti a szóközöket.

            string spacekNelkul = SpaceTorol("A szegedi egyetemen különleges méltányosságot kapott a hivatalvezető lánya.");
            Console.WriteLine(spacekNelkul);


            // 3. Írjon programot, amely egy szövegről megmondja, hogy palindrom-e.
            // Megjegyzés: ezt rekurzív programozási tétellel volna optimális megvalósítani.
            
            // space-k bezavarhatnak, ezért töröljük előtte őket
            bool elsoEset = PalindromE(SpaceTorol("indul a görög aludni"));
            bool masodikEset = PalindromE(SpaceTorol("alma")); // de meghívható metóduson belülről is a SpaceTorol
            Console.WriteLine(elsoEset);
            Console.WriteLine(masodikEset);

            // 4. Írjon programot, amely egy mátrixot feltölt véletlenszerűen
            //      [0-9] számokkal és karakterekkel (A..Z).
            // Reprezentálja a mátrixot a konzolon.
            // Ezt követően, vizsgálja meg, hogy soronként hány szám található a mátrixban.
            // Ezt követően, vizsgálja meg, hogy oszloponként hány betű található a mátrixban.
            char[,] matrix = new char[6,5];
            MatrixGeneral(matrix);
            MatrixKiir(matrix);

            int[] szamDb = MatrixSorbanSzam(matrix);

            Console.WriteLine("\n\n");

            for (int i = 0; i < szamDb.Length; i++)
            {
                Console.WriteLine(
                    "a {0}. sorban {1} db szám található",
                    i , szamDb[i]
                    );
            }

            int[] betuDb = MatrixOszlopbanBetu(matrix);

            Console.WriteLine("\n\n");

            for (int i = 0; i < betuDb.Length; i++)
            {
                Console.WriteLine(
                    "a {0}. oszlopban {1} db betű található",
                    i, betuDb[i]
                    );
            }
        }
    }
}
