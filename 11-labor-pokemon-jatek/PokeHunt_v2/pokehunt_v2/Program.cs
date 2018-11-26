using System;

namespace pokehunt_v2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            StartScreen.LogoLetrehozas();
            StartScreen.JatekInditas();

            PokeHuntJatek jatek = new PokeHuntJatek(30, 10);
            jatek.Inicializal();


            while (!jatek.JatekVege)
            {
                jatek.PalyaMegjelenit();
                jatek.Lepes();
            }

            StartScreen.JatekLezaras();
        }
    }
}
