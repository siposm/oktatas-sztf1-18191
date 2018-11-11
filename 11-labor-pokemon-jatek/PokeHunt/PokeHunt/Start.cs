using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeHunt
{
    public static class Start
    {
        public static string pokemonLogo;

        
        public static void LogoLetrehozas()
        {
            StreamReader sr = new StreamReader("pokemonLogo.txt");
            while (!sr.EndOfStream)
            {
                pokemonLogo += sr.ReadLine() + "\n";
            }
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
            Console.Write("\n\t\t GAME OVER");
            Console.ResetColor();
        }
    }
}
