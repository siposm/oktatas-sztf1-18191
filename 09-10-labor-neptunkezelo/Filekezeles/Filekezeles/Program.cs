using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filekezeles
{

    class FileKezelo
    {
        StreamReader sr;
        StreamWriter sw;

        public FileKezelo()
        {
        }

        public void Kiolvas(string fileNev)
        {
            sr = new StreamReader(fileNev);
            int sorindex = 0;
            while (!sr.EndOfStream)
            {
                Console.WriteLine("[{0}].: {1}", sorindex++, sr.ReadLine());
            }
            sr.Close();
        }

        public void FilebaKiirEgysort(string tartalom)
        {
            sw = new StreamWriter("ujFile0.txt");
            sw.WriteLine(tartalom);
            sw.Close();
        }

        public void FilebaKiirTobbsort(string tartalom)
        {
            sw = new StreamWriter("ujFile1.txt");
            string[] tartalomSoronkent = tartalom.Split('|');
            for (int i = 0; i < tartalomSoronkent.Length; i++)
            {
                sw.WriteLine(tartalomSoronkent[i]);
            }
            sw.Close();
        }

        public void Hozzafuzes(string tartalom)
        {
            sw = new StreamWriter("ujFile1.txt" , true);
            sw.WriteLine(tartalom);
            sw.Close();
        }
        
    }

    class Program
    {

        static void Main(string[] args)
        {
            FileKezelo fk = new FileKezelo();
            fk.Kiolvas("data.txt");

            fk.FilebaKiirEgysort("Ez egy új szöveg amit most itt a kódból adtunk meg.");

            fk.FilebaKiirTobbsort("Random sor #1|Random sor #2");

            fk.Hozzafuzes("xxxxxx-utolso-sor-xxxxx");
        }
    }
}
