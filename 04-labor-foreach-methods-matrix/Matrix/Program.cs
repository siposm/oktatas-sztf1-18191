using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {

        // metódusok ugyan úgy működnek 2D tömbök esetén mint sima tömbbel vagy változóval


        static string[,] MtxLetrehoz() // véletlen alapú feltöltés
        {
            string[,] mtx = new string[3, 6];
            Random r = new Random();

            for (int i = 0; i < mtx.GetLength(0); i++)
                for (int j = 0; j < mtx.GetLength(1); j++)
                    if (r.Next(2) == 0)
                        mtx[i, j] = "A";
                    else
                        mtx[i, j] = "B";

            return mtx;
        }
        static void MatrixFeltolt(int[,] matrix) // feltöltjük random számokkal a mátrixot
        {
            Random r = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++) // sorok
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // oszlopok
                {
                    matrix[i, j] = r.Next(0, 10);
                }
            }
        }

        static string[,] MatrixVisszaAdas() // visszaadunk egy string típusú mátrixot tele X-el
        {
            string[,] karakterlancMatrix = new string[4,10];

            for (int i = 0; i < karakterlancMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < karakterlancMatrix.GetLength(1); j++)
                {
                    karakterlancMatrix[i, j] = "X";
                }
            }
            
            return karakterlancMatrix;
        }

        static void MatrixFeldolgoz(string[,] matrix) // kiírjuk a mátrix tartalmát
        {
            for (int i = 0; i < matrix.GetLength(0); i++) // sorok
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // oszlopok
                {
                    Console.Write("  " + matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void MatrixFeldolgoz(int[,] matrix) // kiírjuk a mátrix tartalmát
        {
            for (int i = 0; i < matrix.GetLength(0); i++) // sorok
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // oszlopok
                {
                    Console.Write("  " + matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }



        static void Main(string[] args)
        {
            int sor = 9;
            int oszlop = 5;

            int[,] matrix = new int[sor, oszlop];

            // hivatkozás elemekre
            int valamelyikElem = matrix[1, 3];

            // értékadás valamelyik elemnek
            matrix[1, 3] = 110;

            // elemek számának lekérdezése
            int sorokSzama = matrix.GetLength(0);
            int oszlopokSzama = matrix.GetLength(1);

            // feltöltés
            MatrixFeltolt(matrix);


           

            // MÁTRIX BEJÁRÁSA (KÉT FOR CIKLUSSAL)
            for (int i = 0; i < matrix.GetLength(0); i++) // sorok
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // oszlopok
                {
                    Console.Write("  " + matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }


            Console.WriteLine("---------------------------------------------------------");

            string[,] karLancMatrix = MatrixVisszaAdas();
            MatrixFeldolgoz(karLancMatrix);

            int[,] mtx2 = new int[4,3];
            int[,] mtx3 = new int[5,5]; // négyzetes mtx

            MatrixFeltolt(mtx2);
            MatrixFeldolgoz(mtx2);

            Console.WriteLine("\n\n");

            MatrixFeltolt(mtx3);
            MatrixFeldolgoz(mtx3);

            Console.WriteLine("\n\n");

            MatrixFeldolgoz(MtxLetrehoz());
        }
    }
}
