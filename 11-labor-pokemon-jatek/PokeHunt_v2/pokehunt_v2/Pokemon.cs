using System;
namespace pokehunt_v2
{
    // https://pokemondb.net/pokedex/all
    enum PokemonTipus
    {
        Fű, Föld, Elektromos, Harcos, Mérgező, Szellem, Psziho, Tűz, Jég, Víz, Általános
    }

    class Pokemon
    {
        string nev;
        int eroszint;
        PokemonTipus tipus;
        static Random rand;
        bool elkapva;
        int xPoz;
        int yPoz;


        public Pokemon(string nev, int eroszint, PokemonTipus tipus, int xPoz, int yPoz)
        {
            this.nev = nev;
            this.eroszint = eroszint;
            this.tipus = tipus;

            this.xPoz = xPoz;
            this.yPoz = yPoz;
            rand = new Random();
            elkapva = false;
        }

        public bool Elkapva
        {
            get { return elkapva; }
            set { elkapva = value; }
        }
        public int XPoz
        {
            get { return xPoz; }
            set { xPoz = value; }
        }
        public int YPoz
        {
            get { return yPoz; }
            set { yPoz = value; }
        }
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
        public int Eroszint
        {
            get { return eroszint; }
            set { eroszint = value; }
        }
        public PokemonTipus Tipus
        {
            get { return tipus; }
            set { tipus = value; }
        }


        public char Megjelenit()
        {
            return nev.ToUpper()[0];
        }

        public void Lep(int palyaMagassag, int palyaSzelesseg)
        {
            int irany = rand.Next(0, 4);
            if (irany == 0) // fel
            {
                if (PalyanBelulVan(XPoz, YPoz - 1, palyaMagassag, palyaSzelesseg))
                    this.YPoz -= 1;
            }
            else if (irany == 1) // le
            {
                if (PalyanBelulVan(XPoz, YPoz + 1, palyaMagassag, palyaSzelesseg))
                    this.YPoz += 1;
            }
            else if (irany == 2) // balra
            {
                if (PalyanBelulVan(XPoz - 1, YPoz, palyaMagassag, palyaSzelesseg))
                    this.XPoz -= 1;
            }
            else // jobbra
            {
                if (PalyanBelulVan(XPoz + 1, YPoz, palyaMagassag, palyaSzelesseg))
                    this.XPoz += 1;
            }
        }

        private bool PalyanBelulVan(int x, int y, int palyaMagassag, int palyaSzelesseg)
        {
            if (x >= 0 && x < palyaSzelesseg)
                if (y >= 0 && y < palyaMagassag)
                    return true;

            return false;
        }
    }
}
