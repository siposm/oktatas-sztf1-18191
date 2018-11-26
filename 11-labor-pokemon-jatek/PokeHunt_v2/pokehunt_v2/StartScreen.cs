using System;
using System.IO;

namespace pokehunt_v2
{
    public static class StartScreen
    {
        public static string pokemonLogo;


        public static void LogoLetrehozas()
        {
            StreamReader sr = new StreamReader("pokemonLogo.txt");
            while (!sr.EndOfStream)
                pokemonLogo += sr.ReadLine() + "\n";

            sr.Close();
        }

        public static void JatekInditas()
        {
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(pokemonLogo);
                Console.ResetColor();
                Console.Write("\n\t\t PRESS <ENTER> TO START GAME");
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);

        }

        public static void JatekLezaras()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t\t\t\t");
            Console.Write("\t\tGAME OVER\t\t\n");
            Console.WriteLine("\t\t\t\t\t");
            Console.ResetColor();
        }
    }
}
