using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunKezelo
{
    class Targy
    {
        string nev;
        int kreditErtek;
        bool vizsgasE;
        int jegy;
        DateTime idopont;

        public Targy(string nev, int kreditErtek, bool vizsgasE, DateTime idopont)
        {
            this.nev = nev;
            this.kreditErtek = kreditErtek;
            this.vizsgasE = vizsgasE;
            this.jegy = 0; // elhagyható
            this.idopont = idopont;
        }

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
        public int KreditErtek
        {
            get { return kreditErtek; }
            set { kreditErtek = value; }
        }
        public bool VizsgasE
        {
            get { return vizsgasE; }
            set { vizsgasE = value; }
        }
        public int Jegy
        {
            get { return jegy; }
            set { jegy = value; }
        }
        public DateTime Idopont
        {
            get { return idopont; }
            set { idopont = value; }
        }

        
    }
}
