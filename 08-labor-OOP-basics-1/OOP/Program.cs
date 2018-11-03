using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{

    class Pokemon
    {
        public string nev;
        public string tipus;
        public int erosseg;
        public string[] legyozhetoTipusok;

        public void Bemutatkozas()
        {
            Console.WriteLine("Szia én {0} vagyok!", nev);
            string sum = "";
            for (int i = 0; i < legyozhetoTipusok.Length; i++)
            {
                sum += legyozhetoTipusok[i] + ", ";
            }
            Console.WriteLine("Én a {0} típusokat győzöm le.", sum);
        }

        public bool LegyezhetoE(string tipus)
        {
            for (int i = 0; i < legyozhetoTipusok.Length; i++)
            {
                if (legyozhetoTipusok[i] == tipus)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ErosebbE(int masikErosseg)
        {
            if (erosseg > masikErosseg)
                return true;
            else
                return false;
        }

        public bool ErosebbE(Pokemon pokemon)
        {
            // erősebb ha legalább 3-mal nagyobb az erőssége és nincs benne
            // a legyőzhető típusokban

            bool benneVan = LegyezhetoE(pokemon.tipus);
            bool erosebb = false;

            if (erosseg - pokemon.erosseg >= 3)
            {
                erosebb = true;
            }

            if (!benneVan && erosebb)
                return true;
            else
                return false;
        }
    }






    class Program
    {

        static string Legerosebb(string[] nevek, int[] erossegek)
        {
            // maximum kiválasztás
            int max = 0;
            for (int i = 1; i < nevek.Length; i++)
            {
                if (erossegek[i] > erossegek[max]) // itt van a lényegi különbség
                {
                    max = i;
                }
            }
            return nevek[max];
        }

        static string Legerosebb_obj(Pokemon[] tomb)
        {
            // maximum kiválasztás
            int max = 0;
            for (int i = 1; i < tomb.Length; i++)
            {
                if (tomb[i].erosseg > tomb[max].erosseg) // itt van a lényegi különbség
                {
                    max = i;
                }
            }
            return tomb[max].nev;
        }

        static void Bemutatkozas(Pokemon[] pokemonok)
        {
            for (int i = 0; i < pokemonok.Length; i++)
            {
                pokemonok[i].Bemutatkozas();
                Console.WriteLine();
            }
        }

        static void Valaszto()
        {
            Console.WriteLine("\n===============================\n");
        }

        static void Main(string[] args)
        {
            string[] nevek = { "Bulbasaur", "Charmander", "Machamp" };
            string[] tipusok = { "növény", "tűz", "kő" };
            int[] erossegek = { 1, 3, 9 };

            Console.WriteLine("A legerősebb: {0}" , Legerosebb(nevek, erossegek));

            //********************************************

            // KÜLÖNÁLLÓ OBJEKTUMOK LÉTREHOZÁSA

            Pokemon p1 = new Pokemon();
            p1.nev = "Bulbasaur";
            p1.tipus = "növény";
            p1.erosseg = 1;

            Pokemon p2 = new Pokemon();
            p2.nev = "Charmander";
            p2.tipus = "tűz";
            p2.erosseg = 3;

            Pokemon p3 = new Pokemon();
            p3.nev = "Machamp";
            p3.tipus = "kő";
            p3.erosseg = 9;





            // POKEMON TÍPUSOKAT TARTALMAZÓ TÖMB LÉTREHOZÁSA

            // létrehozás ugyan úgy történik mint int-ek esetében
            // csak most nem int típusokat tartalmaz hanem pokemon típusokat
            // minta: int[] tomb = new int[3];
            Pokemon[] tomb = new Pokemon[3];
            tomb[0] = new Pokemon(); // fontos, hogy létre is kell hozni az objektumot!!!
            tomb[0].nev = "Bulbasaur";
            tomb[0].tipus = "növény";
            tomb[0].erosseg = 1;
            tomb[0].legyozhetoTipusok = new string[3]; // fontos, hogy létre is kell hozni a tömböt!!!
            tomb[0].legyozhetoTipusok[0] = "víz";
            tomb[0].legyozhetoTipusok[1] = "tűz";
            tomb[0].legyozhetoTipusok[2] = "föld";


            tomb[1] = new Pokemon();
            tomb[1].nev = "Charmander";
            tomb[1].tipus = "tűz";
            tomb[1].erosseg = 3;
            tomb[1].legyozhetoTipusok = new string[2];
            tomb[1].legyozhetoTipusok[0] = "kő";
            tomb[1].legyozhetoTipusok[1] = "föld";


            tomb[2] = new Pokemon();
            tomb[2].nev = "Machamp";
            tomb[2].tipus = "kő";
            tomb[2].erosseg = 9;
            tomb[2].legyozhetoTipusok = new string[2];
            tomb[2].legyozhetoTipusok[0] = "kő";
            tomb[2].legyozhetoTipusok[1] = "levegő";

            Console.WriteLine("A legerősebb (obj): {0}", Legerosebb_obj(tomb));




            Valaszto();


            Bemutatkozas(tomb);

            Valaszto();



            Console.WriteLine("{0} legyőzi a víz típust? -> {1}" , tomb[0].nev , tomb[0].LegyezhetoE("víz"));


            Console.WriteLine("{0} erősebb mint {1}? -> {2}", tomb[0].nev, tomb[1].nev, tomb[0].ErosebbE(tomb[1].erosseg));


            Console.WriteLine("{0} erősebb mint {1}? -> {2}", tomb[2].nev, tomb[0].nev, tomb[2].ErosebbE(tomb[0]));



            Valaszto();

        }
    }
}
