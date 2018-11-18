using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunKezelo
{

    enum Tagozatok
    {
        Nappli, Esti, Levelező
    }

    class Hallgato
    {
        // ADATTAGOK
        string nev;
        string neptunKod;
        DateTime beiratkozasIdeje;
        int passzivFelevekSzama;
        Tagozatok tagozat;
        DateTime szuletes;
        Iskola iskola;
        Targy[] targyak;

        // KONSTRUKTOR
        public Hallgato(string nev, string neptunKod, DateTime szuletes)
        {
            this.nev = nev;
            this.neptunKod = neptunKod;
            this.szuletes = szuletes;
        }

        // GETTER-SETTER
        public string Nev
        {
            get { return nev; }
            // nevet úgy sem változtatunk
        }
        public string NeptunKod
        {
            get { return neptunKod; }
            // neptun kódot úgy sem változtatunk
        }
        public DateTime BeiratkozasIdeje
        {
            get { return beiratkozasIdeje; }
            set { beiratkozasIdeje = value; }
        }
        public Tagozatok Tagozat
        {
            get { return tagozat; }
            set { tagozat = value; }
        }
        public Targy[] Targyak
        {
            get { return targyak; }
            set { targyak = value; }
        }
        public Iskola Iskola
        {
            get { return iskola; }
            set { iskola = value; }
        }
        public DateTime Szuletes
        {
            get { return szuletes; }
            set { szuletes = value; }
        }
        public int PasszivFelevekSzama
        {
            get { return passzivFelevekSzama; }
            set { passzivFelevekSzama = value; }
        }

        // EGYÉB METÓDUSOK
        public void Beiratkozas(Tagozatok tagozat)
        {
            this.tagozat = tagozat;
        }

        public void Adatok()
        {
            Console.WriteLine(" > {0}\t({1})\t{2}\t{3}", nev, neptunKod, beiratkozasIdeje.Year, tagozat);
        }

        public double AktivFelevekSzama()
        {
            double napok = (DateTime.Today - beiratkozasIdeje).TotalDays;
            return Math.Ceiling( ((napok / 365) * 2) - passzivFelevekSzama);
            // felfele kerekítünk, hiszen megkezdett a félév!
        }

        public void TargyakListazasa()
        {
            Console.WriteLine("{0} tárgyai:" , nev);
            for (int i = 0; i < targyak.Length; i++)
            {
                Console.WriteLine("- " + targyak[i].Nev);
            }
        }

        public void TargyakListazasa(bool vizsgas)
        {
            Console.WriteLine("{0} vizsgás tárgyai:", nev);
            for (int i = 0; i < targyak.Length; i++)
            {
                if (targyak[i].VizsgasE == vizsgas)
                {
                    Console.WriteLine("- " + targyak[i].Nev);
                }
            }
        }

        public void Vizsgazas(int jegy, Targy targy)
        {
            for (int i = 0; i < targyak.Length; i++)
            {
                if (targy.Nev == targyak[i].Nev)
                {
                    targyak[i].Jegy = jegy;
                }
            }
        }

        public bool NikesHallgato()
        {
            if (iskola.Nev == "ÓE NIK")
                return true;
            return
                false;
        }


    }
}
