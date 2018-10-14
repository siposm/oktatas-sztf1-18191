using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kavezo
{
    class Program
    {

        // = = = = 1.)
        static string[,] BekerArlista()
        {
            KiirSzines("Árlista feltöltése. (Formátum: termék,ár [enter])", true);
            string bemenet = "";
            bool bekeresVege = false;
            while ( !bekeresVege )
            {
                string beolv = Console.ReadLine();
                if (beolv == "")
                    bekeresVege = true;
                else
                {
                    bemenet += beolv + "&"; // legutolsó végére is odafűzi majd » el kell távolítani
                }
            }
            
            // kávé,240&sör,450&bor,600 <- ez a bemenetben lévő formátum
            string[] termekek = bemenet.Split('&'); // megkapjuk a kávé=240 formátumokat
            // utolsó alkalommal hozzáfűzte a & karaktert, ezért lesz egy fölösleges elem a végén
            string[,] termekEsAr = new string[termekek.Length-1, 2]; // mátrixba 2 oszlopba eltároljuk
            
            for (int i = 0; i < termekek.Length-1; i++) // ',' mentén is szétszedjük és beletesszük a megfelelő helyre
            {
                termekEsAr[i, 0] = termekek[i].Split(',')[0];
                termekEsAr[i, 1] = termekek[i].Split(',')[1];
            }
            return termekEsAr;
        }

        // színes üzenetet ír ki, opcinálisan új sorba vagy folytatólagosan
        static void KiirSzines(string kiirandoSzoveg , bool ujSorba)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            if (ujSorba)
                Console.WriteLine(kiirandoSzoveg);
            else
                Console.Write(kiirandoSzoveg);

            
            Console.ResetColor();
        }

        // = = = = 4.)
        // bekérjük, hogy melyik napot szeretné lekérdezni a boltvezető
        static int MelyikNap()
        {
            KiirSzines("** NAPI ÖSSZESÍTŐ LEKÉRDEZÉSE **\nMelyik napra vagy kíváncsi?\t", false);
            return int.Parse(Console.ReadLine()) - 1;
        }

        // = = = = 10.)
        static void KiirEredmeny(string[,] arlista, int limitDb, string[] napiItalokIsmerlodesNelkul, int[] dbSzamok)
        {
            int vegosszeg = 0;
            for (int i = 0; i <= limitDb; i++) // <= !!!
            {
                int ar = 0;
                for (int x = 0; x < arlista.GetLength(0); x++)
                {
                    if (napiItalokIsmerlodesNelkul[i] == arlista[x, 0])
                        ar = int.Parse(arlista[x, 1]);
                }
                vegosszeg += ar * dbSzamok[i];
                Console.WriteLine("\n\t{0} : {1} db ({2}.-)", napiItalokIsmerlodesNelkul[i], dbSzamok[i], ar*dbSzamok[i]);
            }
            Console.WriteLine("\n_____________________________");
            Console.WriteLine("\t\t\t"+vegosszeg+".-");
        }

        // = = = = 2.)
        // napok számának bekérése
        static int BekerNapokSzama()
        {
            KiirSzines("Add meg a napok számát: \t", false);
            return int.Parse(Console.ReadLine());
        }

        // = = = = 3.)
        // eladott italok bekérése, mátrix feltöltése
        static string[,] BekerEladottItalok(int napokSzama)
        {
            string[,] tablazat = new string[napokSzama, 10];
            // sorok = napok
            // oszlopok = eladott italok

            for (int i = 0; i < napokSzama; i++)
            {
                KiirSzines((i + 1).ToString() + ". napi ital(ok):", true); // melyik nap italjai

                int italSzamlalo = 0;
                bool italokVege = false;
                while (!(italokVege || italSzamlalo == 10)) // italok bekérése
                {
                    string bekertItal = Console.ReadLine();
                    if (bekertItal == "")
                    {
                        italokVege = true;
                    }
                    else
                    {
                        tablazat[i, italSzamlalo] = bekertItal;
                        italSzamlalo++;
                    }
                }
            }

            return tablazat;
        }

        // = = = = 7.)
        // egy adott nap italjait rendezi
        static void RendezNapiItalLista(string[] adottNapItaljai)
        {

            for (int i = 0; i < adottNapItaljai.Length-1; i++)
            {
                int min = i;
                for (int j = (i+1); j < adottNapItaljai.Length; j++)
                {
                    //if (adottNapItaljai[min] > adottNapItaljai[j])
                    if(StringKisebbE(adottNapItaljai[j] , adottNapItaljai[min])) // a < b forma!!!
                        min = j;
                }
                string seged = adottNapItaljai[i];
                adottNapItaljai[i] = adottNapItaljai[min];
                adottNapItaljai[min] = seged;
            }


        }


        // a string kisebb-e mint b string
        static bool StringKisebbE(string a , string b)
        {

            // CompareTo-ról fogunk tanulni
            // egyelőre elfogadott ha ELSŐ karakter alapján történik az összehasonlítás
            // pl. a[0] < b[0]

            if (a.CompareTo(b) <= 0)
                return true;
            else
                return false;
        }

        // = = = = 5.)
        // italok össz darabszáma / adott nap
        static int ItalokDarabszamaPerNap(string[,] eladottItalok, int melyikNap)
        {
            int szamlalo = 0;
            for (int i = 0; i < eladottItalok.GetLength(1); i++)
            {
                if (eladottItalok[melyikNap,i] != null)
                {
                    szamlalo++;
                }
            }
            return szamlalo;
        }


        // = = = = 6.)
        // italok listája / adott nap
        static string[] ItalokListajaPerNap(string[,] eladottItalok, int melyikNap)
        {
            string[] tomb = new string[eladottItalok.GetLength(1)];
            for (int i = 0; i < eladottItalok.GetLength(1); i++)
            {
                tomb[i] = eladottItalok[melyikNap, i];
            }
            
            // mielőtt visszaadnánk, vegyük ki a null értékeket

            string[] nullmentesTomb = NullokElhagy(tomb);

            return nullmentesTomb;
        }
        
        // bemeneti tömbből elhagyja a null elemeket
        static string[] NullokElhagy(string[] tomb)
        {
            int db = 0;
            for (int i = 0; i < tomb.Length; i++)
                if (tomb[i] != null)
                    db++;

            string[] tombNullokNelkul = new string[db];
            db = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] != null)
                {
                    tombNullokNelkul[db++] = tomb[i];
                }
            }

            return tombNullokNelkul;
        }


        // = = = = 8.)
        // egy nap italjai közül az ismétlődéseket eltávolítjuk
        static string[] IsmetlodoItalokKiszurese(string[] italokAdottNapra, ref int db)
        {
            // !!! halmaz létrehozás tétel
            // a bemeneti tömb már rendezett!
            // egy nap italjait megkapja, majd azokból az ismétlődő elemeket kiszűri
            

            string[] kivalogatottak = new string[italokAdottNapra.Length]; // lehet mindegyik különböző

            db = 0;
            kivalogatottak[db] = italokAdottNapra[0];

            for (int i = 1; i < italokAdottNapra.Length; i++)
            {
                if (italokAdottNapra[i] != kivalogatottak[db])
                {
                    // van új elem
                    db++;
                    kivalogatottak[db] = italokAdottNapra[i];
                }
            }
            // db az értékes darabszám!
            return kivalogatottak;
        }


        // = = = = 9.)
        // egyes italok darabszáma / adott nap
        static int[] EgyesItalokDarabszamaPerNap(string[] italokIsmNelkul , string[] italokIsm)
        {

            int[] italokDbSzama = new int[ italokIsmNelkul.Length ];

            for (int i = 0; i < italokIsmNelkul.Length; i++) // a már kiválogatott italokhoz hozzánézzük az...
            {
                for (int j = 0; j < italokIsm.Length; j++) // összes italt amit eladtunk
                {
                    if (italokIsmNelkul[i] == italokIsm[j])
                    {
                        italokDbSzama[i]++; // az adott itallal megegyező indexű helyre növelem a darabszámot
                    }
                }
            }

            return italokDbSzama;

        }

        
         
        


        // ------------------------------------------------------------------------------------------------
        

        static void Main(string[] args)
        {
            // = = = = 1.)
            // árlistát bekérjük
            string[,] arlista = BekerArlista();


            // = = = = 2-3.)
            // eladott italok bekérése, mátrix feltöltése
            string[,] eladottItalok = BekerEladottItalok(BekerNapokSzama());


            // = = = = 4-5.)
            // adott napon hány db ital volt
            int melyikNap = MelyikNap();
            int adottNapiDbSzam = ItalokDarabszamaPerNap(eladottItalok, melyikNap);
            Console.WriteLine("A(z) {0}. napon {1} db italt adtak el." , melyikNap+1 , adottNapiDbSzam);


            // = = = = 6.)
            // kivesszük a mátrix egy sorát, az lesz a x. napi italok listája (tömbje)
            string[] napiItalok = ItalokListajaPerNap(eladottItalok, melyikNap);
            

            // = = = = 7.)
            // rendezzük az italokat
            RendezNapiItalLista(napiItalok); // referencia
            

            // = = = = 8.)
            // szűrjük ki azokat, amelyek ismétlődnek
            int limitDb = 0;
            string[] napiItalokIsmerlodesNelkul = IsmetlodoItalokKiszurese( napiItalok , ref limitDb );


            // = = = = 9.)
            // adott napon megvett italok darabszáma
            int[] dbSzamok = EgyesItalokDarabszamaPerNap(napiItalokIsmerlodesNelkul, napiItalok);


            // = = = = 10.)
            // végeredmény kijelzése
            KiirEredmeny(arlista, limitDb, napiItalokIsmerlodesNelkul, dbSzamok);


            Console.WriteLine("\n\n\n\n\n");
        }
    }
}
