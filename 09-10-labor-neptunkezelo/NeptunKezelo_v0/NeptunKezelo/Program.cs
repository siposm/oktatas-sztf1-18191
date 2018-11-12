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
        static Hallgato[] HallgatokLetrehozasaFilebol() // fileból beolvasva
        {
            int sorokSzama = 0;
            string file = "hallgatokDB.txt";
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                sorokSzama++;
                sr.ReadLine(); // különben végtelen ciklus !
            }
            sr.Close();

            // tudjuk mekkora tömb kell (=sorok száma)
            Hallgato[] hallgatok = new Hallgato[sorokSzama];
            int index = 0;
            sr = new StreamReader(file);
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
                hallgatok[index].Targyak = new Targy[4];
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
            targyak[0] =
                    new Targy(
                        "Analízis I.", 5, true,
                        new DateTime(2016, 10, 13, 12, 00, 00));
            targyak[1] =
                   new Targy(
                       "Fizika", 3, true,
                       new DateTime(2016, 10, 13, 14, 00, 00));
            targyak[2] =
                   new Targy(
                       "Programozás I.", 6, true,
                       new DateTime(2016, 12, 6, 8, 00, 00));
            targyak[3] =
                    new Targy(
                        "Informatikai rendszerek alapjai", 2, false,
                        new DateTime(2016, 12, 6, 8, 00, 00));
        }

        static void HallgatokFeldolgozasa(Hallgato[] hallgatok)
        {
            for (int i = 0; i < hallgatok.Length; i++)
                hallgatok[i].Adatok();
        }


        // FELADATOK
        // folytatjuk innen :)







        static void Main(string[] args)
        {
            // Feltöltés & kiírás
            Hallgato[] hallgatok = HallgatokLetrehozasaFilebol();
            HallgatokFeldolgozasa(hallgatok);
            
            // gyakorlás
            // 1. egyes hallgatóknak a tulajdonságok használatával módosítani ezt-azt
            // 2. hallgatók közül megkeresni azt, aki a legrégebb óta itt van






            Console.ReadLine();
        }
    }
}
