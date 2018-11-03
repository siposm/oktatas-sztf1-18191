using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_alapok
{

    class Szemely
    {
        // ADATTAGOK
        private bool hazas;
        int eletkor; // ha nem írunk elé semmit, az alapból private
        private string nev;


        // KONSTRUKTOR
        public Szemely(string nev, int eletkor)
        {
            this.nev = nev;
            this.eletkor = eletkor;
            // this = ez a példány
        }
        public Szemely(string nev, int eletkor, bool hazas)
        {
            this.nev = nev;
            this.eletkor = eletkor;
            this.hazas = hazas;
        }
        public Szemely(string nev)
        {
            this.nev = nev;
            eletkor = 5;
            hazas = false;
        }

        // GET és SET mint metódusok
        public int GetEletkor()
        {
            return eletkor;
        }
        public void SetEletkor(int eletkor)
        {
            this.eletkor = eletkor;
        }


        // GET és SET mint tulajdonság
        // beépített nyelvi elem
        public int Eletkor
        {
            get { return eletkor; }
            set { eletkor = value; }
        }
        public string Nev
        {
            get { return nev; }
            // get { return "*" + nev; }

            //set { nev = value; }
            // set { nev = "*" + value; }
        }


        // További metódusok...
        public void Szuletesnap()
        {
            eletkor++;
            ElmultHarminc();
        }
        private void ElmultHarminc()
        {
            if (eletkor > 30)
            {
                Console.WriteLine("Elmúlt már harminc éves.");
            }
            // else: nem csinálunk semmit.
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Szemely szemely = new Szemely("Baltazár",36);

            // szemely.Nev = "Baltazár2"; // --> Hibásnak jelzi, mert nem biztosítottuk a SET részt.
            szemely.Eletkor = 37;

            Console.WriteLine(szemely.Nev);
            
        }
    }
}
