using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            // mini menü / start-screen készítése
            Start.LogoLetrehozas();
            Start.JatekInditas();

            // a játék elstartolt...
            PokeHuntJatek jatek = new PokeHuntJatek(30,10);
            jatek.Inicializal();
            

            while(!jatek.JatekVege)
            {
                jatek.PalyaMegjelenit();
                jatek.Lepes();
            }

            Start.JatekLezaras();

        }
    }
}
