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
            // neptun kódod úgy sem változtatunk
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
            Console.WriteLine("> {0} ({1}) - {2} - {3}", nev, neptunKod, beiratkozasIdeje.Year, tagozat);
        }



    }
}
