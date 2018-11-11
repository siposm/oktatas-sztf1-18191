using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunKezelo
{
    class Program
    {
        // SEGÉDEK
        static void Elvalaszto()
        {
            Console.WriteLine("\n------------------------------------\n");
        }

        static Hallgato[] HallgatokLetrehozasaFilebol() // fileból beolvasva
        {
            int sorokSzama = 0;
            StreamReader sr = new StreamReader("hallgatokDB.txt");
            while (!sr.EndOfStream)
            {
                sorokSzama++;
                sr.ReadLine(); // különben végtelen ciklus !
            }
            sr.Close();

            // tudjuk mekkora tömb kell (=sorok száma)
            Hallgato[] hallgatok = new Hallgato[sorokSzama];
            int index = 0;
            sr = new StreamReader("hallgatokDB.txt");
            while (!sr.EndOfStream)
            {
                
                // adott pillanatban adott hallgató adatait szétszedem

                string[] adatok = sr.ReadLine().Split('|');
                
                // hallgató objektumot létrehozom
                hallgatok[index] =
                    new Hallgato(
                        adatok[0],
                        adatok[1],
                        DateTime.Parse(adatok[2])
                        );

                // beiratkoztatom
                hallgatok[index].BeiratkozasIdeje = DateTime.Parse(adatok[3]);
                
                if (Tagozatok.Nappli.ToString() == adatok[4])
                    hallgatok[index].Beiratkozas(Tagozatok.Nappli);
                else if (Tagozatok.Esti.ToString() == adatok[4])
                    hallgatok[index].Beiratkozas(Tagozatok.Esti);
                else if (Tagozatok.Levelező.ToString() == adatok[4])
                    hallgatok[index].Beiratkozas(Tagozatok.Levelező);
                
                // tárgyakat létrehozom
                hallgatok[index].Targyak = new Targy[6];
                TargyakFelvetele(hallgatok[index].Targyak);

                // iskola megadása
                hallgatok[index].Iskola = new Iskola("Óbudai Egyetem Neumann János Informatikai Kar", "Bécsi út 96/b");

                // hallgatók tömb indexét növelem
                index++;
            }
            sr.Close();

            return hallgatok;
        }

        static void TargyakFelvetele(Targy[] targyak)
        {
            StreamReader sr = new StreamReader("targyakDB.txt");
            int targyIndex = 0;

            // mivel pont annyi sor van a file-ban, ahány elemű tömböt létrehoztunk (6, hiszen ennyi az első féléves tárgyak száma)
            // ezért nem fog kiakadni. ha módosítunk a tárgyak listáján figyeljünk erre!
            while (!sr.EndOfStream)
            {
                string[] targyAdatok = sr.ReadLine().Split('|');

                bool vizsgas;
                if (int.Parse(targyAdatok[2]) == 1) // vizsgás-e
                    vizsgas = true;
                else
                    vizsgas = false;

                targyak[targyIndex++] = new Targy(
                    targyAdatok[0],                 // név
                    int.Parse(targyAdatok[1]),      // kredit
                    vizsgas,                        // vizsgás
                    DateTime.Parse(targyAdatok[3])  // időpont
                    );
            }
            sr.Close();
        }

        static void HallgatokFeldolgozasa(Hallgato[] hallgatok)
        {
            for (int i = 0; i < hallgatok.Length; i++)
                hallgatok[i].Adatok();
        }


        // FELADATOK
        // 1.
        static void LegregebbiHallgato(Hallgato[] hallgatok)
        {
            // ha több van akkor az elsőt
            int min = 0;
            for (int i = 1; i < hallgatok.Length; i++)
            {
                if (hallgatok[min].BeiratkozasIdeje > hallgatok[i].BeiratkozasIdeje)
                {
                    min = i;
                }
            }
            //return min;
            Console.WriteLine("A legrégebbi hallgató: {0} ({1})" , hallgatok[min].Nev , hallgatok[min].NeptunKod);
        }
        // 2.
        static void LegregebbiHallgatok(Hallgato[] hallgatok)
        {
            int[] legregebbiek = new int[hallgatok.Length];
            DateTime minertek = hallgatok[0].BeiratkozasIdeje;
            int db = 0;
            legregebbiek[db] = 0;

            for (int i = 1; i < hallgatok.Length; i++)
            {
                if (minertek > hallgatok[i].BeiratkozasIdeje)
                {
                    // van új minimális érték
                    minertek = hallgatok[i].BeiratkozasIdeje;
                    db = 0;
                    legregebbiek[db] = i;
                }
                else
                {
                    if (minertek == hallgatok[i].BeiratkozasIdeje)
                    {
                        // találtunk megegyező minimális elemet
                        db++;
                        legregebbiek[db] = i;
                    }
                }
            }

            // return ...

            Console.WriteLine("A legrégebbi hallgatók:\n");
            for (int i = 0; i <= db; i++)
            {
                Console.WriteLine("[{0}]. - {1} - ({2})" ,
                    legregebbiek[i],
                    hallgatok[legregebbiek[i]].Nev,
                    hallgatok[legregebbiek[i]].NeptunKod
                    );
            }
        }
        // 3.
        static void HallgatoTargyai(Hallgato[] hallgatok)
        {
            Console.Write("Hallgató tárgyai:\t");
            int melyik = int.Parse(Console.ReadLine());
            hallgatok[melyik].TargyakListazasa();
        }
        // 4.
        static void HallgatoTargyai(Hallgato[] hallgatok, bool vizsgas)
        {
            Console.Write("Hallgató (vizsgás/nemvizsgás) tárgyai:\t");
            int melyik = int.Parse(Console.ReadLine());
            hallgatok[melyik].TargyakListazasa(vizsgas);
        }
        
        // === SZÜNET 
        // 5.
        static void HallgatoVizsgazas(Hallgato[] hallgatok, string neptunkod, int jegy)
        {
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i].NeptunKod == neptunkod)
                {
                    hallgatok[i].Vizsgazas(
                        jegy,                      // érdemjegy
                        new Targy("Programozás I.",// tárgy neve alapján megy a keresés majd
                            0,                  // nem fontos
                            false,              // nem fontos
                            new DateTime()      // nem fontos
                            )
                        );
                }
            }
        }
        // 6.
        static void VizsgazottHallgatokLekerese(Hallgato[] hallgatok, string targyNev)
        {
            Console.WriteLine("Hallgatók, akik teljesítették a {0} tárgyat:\n", targyNev);

            for (int i = 0; i < hallgatok.Length; i++)
            {
                // i = hallgató kijelölése

                for (int j = 0; j < hallgatok[i].Targyak.Length; j++)
                {
                    // j = hallgató tárgyainak kijelölése

                    if (hallgatok[i].Targyak[j].Jegy > 0)
                    {
                        // kigyűjteni az indexeket...
                        // de most csak kiírjuk
                        Console.WriteLine("- {0} ({1}) : {2}",
                            hallgatok[i].Nev,
                            hallgatok[i].NeptunKod,
                            hallgatok[i].Targyak[j].Jegy);
                    }

                }
            }
        }
        // 7.
        static void HallgatokTagozaton(Hallgato[] hallgatok, Tagozatok tagozat, int limit)
        {
            Console.WriteLine("{0} tagozatra járó hallgatók:\n", tagozat);
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i].Tagozat == tagozat) // enum == enum működik
                {
                    Console.WriteLine("{0} ({1})",
                        hallgatok[i].Nev,
                        hallgatok[i].NeptunKod);
                }
            }
        }
        // 8.
        static void HallgatokTagozatonPassziv(Hallgato[] hallgatok, Tagozatok tagozat, Iskola iskola)
        {
            Console.WriteLine("{0}, {1} tagozatra járó hallgatók:\n", iskola.Nev,tagozat);
            for (int i = 0; i < hallgatok.Length; i++)
            {
                if (hallgatok[i].Tagozat == tagozat)
                {
                    if (hallgatok[i].Iskola.Nev == iskola.Nev)
                    {
                        Console.WriteLine("{0} ({1})",
                        hallgatok[i].Nev,
                        hallgatok[i].NeptunKod);
                    }
                }
            }
        }








        static void Main(string[] args)
        {
            
            Elvalaszto();

            // Feltöltés & kiírás
            Hallgato[] hallgatok = HallgatokLetrehozasaFilebol();
            HallgatokFeldolgozasa(hallgatok);
            
            Elvalaszto();

            /*Console.WriteLine("****");
            hallgatokFilebol[0].PasszivFelevekSzama = 3;
            Console.WriteLine(hallgatokFilebol[0].AktivFelevekSzama());*/


            // FELADATOK

            // 1. legrégebb óta ittlévő hallgató (beiratkozás tekintetében)
            LegregebbiHallgato(hallgatok);
            Elvalaszto();

            // 2. legrégebb óta ittlévő hallgatóK (beiratkozás tekintetében)
            LegregebbiHallgatok(hallgatok);
            Elvalaszto();

            // 3. Adott hallgató tárgyainak kilistázása
            HallgatoTargyai(hallgatok);
            Elvalaszto();

            // 4. Adott hallgató tárgyainak kilistázása ha az vizsgás
            HallgatoTargyai(hallgatok, true);
            Elvalaszto();

            // == SZÜNET

            // 5. Adott hallgató vizsgázik
            Random r = new Random();
            HallgatoVizsgazas(hallgatok, "IRNMAN", r.Next(1,6));
            HallgatoVizsgazas(hallgatok, "LOO921", r.Next(1, 6));
            HallgatoVizsgazas(hallgatok, "1L4HJ5", r.Next(1, 6));
            //Valaszto();

            // 6. Azokat a hallgatókat kérjük le, akik adott tárgyból vizsgáztak már
            VizsgazottHallgatokLekerese(hallgatok,"Programozás I.");
            Elvalaszto();

            // 7. Nappali tagozatos hallgatók listázása, akik 1990 előtt születtek
            HallgatokTagozaton(hallgatok, Tagozatok.Nappli, 1990);
            Elvalaszto();

            // 8. Esti tagozatos hallgatók, akik a NIK-re járnak ÉS nem volt passzív félévük még
            HallgatokTagozatonPassziv(
                hallgatok,
                Tagozatok.Esti,
                new Iskola("Óbudai Egyetem Neumann János Informatikai Kar","Bécsi út 96/b"));
            Elvalaszto();

            // tesztelés céljából megnézni, hogy egyik hallgató iskoláját Keleti karra átállítjuk
            // és más eredmény fog születni
            // ...







            Console.ReadLine();
        }
    }
}
