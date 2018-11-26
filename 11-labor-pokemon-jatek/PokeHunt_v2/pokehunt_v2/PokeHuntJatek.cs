using System;
using System.IO;

namespace pokehunt_v2
{
    class PokeHuntJatek
    {
		Random rand;
        Pokemon[] pokemonok;
        int palyaSzelesseg;
        int palyaMagassag;
        bool jatekVege;

        public bool JatekVege
        {
            get { return jatekVege; }
            set { jatekVege = value; }
        }

        public PokeHuntJatek(int palyaSzelesseg, int palyaMagassag)
        {
            this.palyaSzelesseg = palyaSzelesseg;
            this.palyaMagassag = palyaMagassag;

            jatekVege = false;
        }


        public void Inicializal()
        {
            pokemonok = new Pokemon[PokemonokSzama()];

            StreamReader sr = new StreamReader("pokemonok.txt");
            int index = 0;
            rand = new Random();

            while (!sr.EndOfStream)
            {
                // adatok szétszedése
                string[] adatok = sr.ReadLine().Split('|');

                // példány létrehozása
                Pokemon pokemon = new Pokemon(
                    adatok[0],
                    rand.Next(0, 10),
                    (PokemonTipus)Enum.Parse(typeof(PokemonTipus), adatok[1]),
                    rand.Next(palyaSzelesseg),
                    rand.Next(palyaMagassag) // --> [0,palyamagassag]
                    );

                // példány eltárolása a tömbben
                pokemonok[index++] = pokemon;
            }
            sr.Close();
        }

        private int PokemonokSzama()
        {
            StreamReader sr = new StreamReader("pokemonok.txt");
            int dbszam = 0;
            while (!sr.EndOfStream)
            {
                dbszam++;
                sr.ReadLine();
            }
            sr.Close();
            return dbszam;
        }

        public void PalyaMegjelenit()
        {
            Console.Clear();

            for (int i = 0; i < palyaMagassag; i++) // SOROK száma
            {
                for (int j = 0; j < palyaSzelesseg; j++) // OSZLOPOK száma
                    Console.Write(".");

                Console.WriteLine("");
            }

            PokemonokMegjelenit();

        }

        private void PokemonokMegjelenit()
        {
            for (int i = 0; i < pokemonok.Length; i++)
            {
                if (!pokemonok[i].Elkapva)
                {
                    Console.SetCursorPosition(pokemonok[i].XPoz, pokemonok[i].YPoz);
                    PokemonMegjelenit(pokemonok[i]);
                }
            }
        }

        private void PokemonMegjelenit(Pokemon p)
        {
            /* Alapvető sárga háttér fekete betűvel:
             * Console.BackgroundColor = ConsoleColor.Yellow;
             * Console.ForegroundColor = ConsoleColor.Black;
            */

            // Pokemonok saját színei

            switch (p.Tipus)
            {
                case PokemonTipus.Elektromos:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case PokemonTipus.Föld:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case PokemonTipus.Fű:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case PokemonTipus.Harcos:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case PokemonTipus.Jég:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PokemonTipus.Mérgező:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PokemonTipus.Psziho:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case PokemonTipus.Szellem:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case PokemonTipus.Tűz:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case PokemonTipus.Víz:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case PokemonTipus.Általános:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }

            Console.Write(p.Megjelenit());
            Console.ResetColor();
        }

        public void Lepes()
        {
            Console.SetCursorPosition(0, palyaMagassag);
            PokemonHelp();


            Console.Write("\nEnter the x,y coordinates\nof the Pokemon what you want to cache: ");


            //Thread.Sleep(1000);
            string[] koordinatak = new string[2];
            string beolvasott = Console.ReadLine();

            if (beolvasott == "")
            {
                koordinatak[0] = "-1";
                koordinatak[1] = "-1";
            }
            else
            {
                koordinatak[0] = beolvasott.Split(',')[0];
                koordinatak[1] = beolvasott.Split(',')[1];
            }


            PokemonElkap(
                int.Parse(koordinatak[0]),
                int.Parse(koordinatak[1])
                );



            PokemonLep();

            if (Vegevan())
                this.JatekVege = true;
        }

        private void PokemonElkap(int x, int y)
        {
            if (PalyanBelulVan(x, y))
            {
                for (int i = 0; i < pokemonok.Length; i++)
                {
                    if (pokemonok[i].XPoz == x && pokemonok[i].YPoz == y)
                        pokemonok[i].Elkapva = true;
                }
            }
        }

        private bool PalyanBelulVan(int x, int y)
        {
            if (x >= 0 && x < palyaSzelesseg)
                if (y >= 0 && y < palyaMagassag)
                    return true;

            return false;
        }

        private void PokemonLep()
        {
            for (int i = 0; i < pokemonok.Length; i++)
                pokemonok[i].Lep(palyaMagassag, palyaSzelesseg);
        }

        private void PokemonHelp()
        {
            Console.WriteLine("\nPokemonok helyzete:");
            for (int i = 0; i < pokemonok.Length; i++)
                if (!pokemonok[i].Elkapva)
                    Console.WriteLine(" > {0}\t{1}:{2}", pokemonok[i].Nev, pokemonok[i].XPoz, pokemonok[i].YPoz);
        }

        private bool Vegevan()
        {
            for (int i = 0; i < pokemonok.Length; i++)
                if (!pokemonok[i].Elkapva)
                    return false;

            return true;
        }

    }
}
