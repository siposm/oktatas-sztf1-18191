using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunKezelo
{
    class Iskola
    {
        string nev;
        string cim;

        public Iskola(string nev, string cim)
        {
            this.nev = nev;
            this.cim = cim;
        }

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
        public string Cim
        {
            get { return cim; }
            set { cim = value; }
        }
    }
}
