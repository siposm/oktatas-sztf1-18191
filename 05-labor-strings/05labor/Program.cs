using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05labor
{
    class Program
    {
        static void Main(string[] args)
        {

            // ---------------------------------------
            //      STRINGEK
            // ---------------------------------------

            // String-ek is tömbként foghatóak fel.
            /*
             *      string a = "alma";
             *      
             *      megfeleltethető a következő formának/elképzelésnek:
             * 
             *      string aTomb = new string[4];
             *      aTomb[0] = "a";
             *      aTomb[1] = "l";
             *      aTomb[2] = "m";
             *      aTomb[3] = "a";
             *      
             * */


            // hossz lekérdezése
            string mondat = "indul a török aludni";
            int mondatHossza = mondat.Length;

            // elem lekérdezése
            char elsoKarakter = mondat[0];

            // értékadás NEM lehetséges
            // mondat[0] = "g";    // --> ez nem működik


            // konkatenáció azaz összefűzés
            // igazából ezért működött amikor Console.WriteLine-t használtunk és összefűztünk
            string valami1 = "ez egy mondat, befejezés nélkül";
            string valami2 = "ez pedig a mondat befejezése most";
            string osszefuzve = valami1 + valami2;

            
            // string-hez hozzáfűzhető karakter (char) is
            char x = 'X';
            string valami3 = "ide fűzöm hozzá: -->" + x;

            // char-nak vehetjük egy string egy elemét is
            string elemek = "ASD-ASD-ASD";
            valami3 += "| és még ezt is -->";
            valami3 = valami3 + elemek[2];


            // összefűzésnél néha konverzió kell, ha nem stringet vagy char-t szeretnénk hozzárakni
            int szam = 999;
            valami3 += szam.ToString(); // .ToString() !!!

        }
    }
}
