using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CserelgetosJatek
{
    class Program
    {
        // ALAP METÓDUSOK ******************************************************************

        // inicializáljuk a játékteret
        static bool[,] Inicializal()
        {
            bool[,] jatekTer = new bool[5, 5];


            for (int i = 0; i < jatekTer.GetLength(0); i++)
            {
                for (int j = 0; j < jatekTer.GetLength(1); j++)
                {
                    if (i == jatekTer.GetLength(0)/2 && j == jatekTer.GetLength(1)/2)
                    {
                        // játéktér közepe
                        jatekTer[i, j] = true;

                        // szomszédos cellák
                        SzomszedValtoztat(jatekTer, i, j);
                    }
                    /*else
                        jatekTer[i, j] = false;*/
                }
            }

            return jatekTer;
        }

        // megjelenítjük a játékteret
        static void Megjelenit(bool[,] jatekTer)
        {
            Console.Clear();

            for (int i = 0; i < jatekTer.GetLength(0); i++)
            {
                for (int j = 0; j < jatekTer.GetLength(1); j++)
                {
                    if (jatekTer[i, j] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("O\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(".\t");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        // a felhasználó lő egyet x,y koordinátára
        static void Loves(bool[,] jatekTer, int x, int y)
        {
            if (XYJatekTerenBelulVanE(jatekTer, x, y)) // adott lövés játéktéren belül van (= nem indexelünk ki a mátrixból)
            {
                
                if (jatekTer[x, y] == true) jatekTer[x, y] = false;
                else jatekTer[x, y] = true;

                SzomszedValtoztat(jatekTer, x, y);
            }
        }

        // vége van-e a játéknak, azaz minden mező true (X) értékű
        static bool VegeVan(bool[,] jatekTer)
        {
            bool vege = true;

            for (int i = 0; i < jatekTer.GetLength(0); i++)
            {
                for (int j = 0; j < jatekTer.GetLength(1); j++)
                {
                    if (jatekTer[i,j] == false)
                    {
                        vege = false;
                    }
                }
            }

            return vege;
        }



        // SEGÉD METÓDUSOK ******************************************************************

        static void SzomszedValtoztat(bool[,] jatekTer, int i, int j)
        {
            // felső szomszéd (i-1)
            if (i - 1 >= 0)
            {
                if (jatekTer[i - 1, j] == true) jatekTer[i - 1, j] = false;
                else jatekTer[i - 1, j] = true;
            }

            // alsó szomszéd (i+1)
            if (i + 1 < jatekTer.GetLength(0))
            {
                if (jatekTer[i + 1, j] == true) jatekTer[i + 1, j] = false;
                else jatekTer[i + 1, j] = true;
            }

            // bal szomszéd (j-1)
            if (j - 1 >= 0)
            {
                if (jatekTer[i, j - 1] == true) jatekTer[i, j - 1] = false;
                else jatekTer[i, j - 1] = true;
            }

            // jobb szomszéd (j+1)
            if (j + 1 < jatekTer.GetLength(1))
            {
                if (jatekTer[i, j + 1] == true) jatekTer[i, j + 1] = false;
                else jatekTer[i, j + 1] = true;
            }
            
        }

        static bool XYJatekTerenBelulVanE(bool[,] jatekTer, int x, int y)
        {
            // x - sor, y - oszlop
            if (x >= 0 && x < jatekTer.GetLength(0))
            {
                if (y >= 0 && y < jatekTer.GetLength(1))
                {
                    return true;
                }
            }
            return false;
            
            // 2 vagy több return is megengedett, HA logikailag stimmel
            // egyéb esetben csak összekuszálja a kódot
        }

        static void Bekeres(bool[,] jatekTer)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Lövés koordinátái: "); // x,y <- formában!
            string[] xy = Console.ReadLine().Split(',');

            Loves(
                jatekTer, 
                int.Parse(xy[0]), 
                int.Parse(xy[1])
                );
        }
        




        // MAIN ******************************************************************
        static void Main(string[] args)
        {

            
            bool[,] jatekTer = Inicializal();
            

            // játék
            while (VegeVan(jatekTer) == false)
            {
                Megjelenit(jatekTer);
                Bekeres(jatekTer);
            }
            Megjelenit(jatekTer);
           
        }
    }
}
