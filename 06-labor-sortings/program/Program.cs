using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Program
    {

		// ---------------------------
		// EGYSZERŰ CSERÉS RENDEZÉS
		// ---------------------------

		static void Csere(int[] tomb, int indexEgy, int indexKetto)
		{
			int temp = tomb[indexEgy];
			tomb[indexEgy] = tomb[indexKetto];
			tomb[indexKetto] = temp;
		}


		static void EgyszeruCseresRendezes( int[] tomb )
		{
			for (int i = 0; i < tomb.Length-1; i++)
			{
				for (int j = (i+1); j < tomb.Length; j++)
				{
					if (tomb[i] > tomb[j])
						Csere(tomb, i, j); 
				}
			}
		}



		// ------------------------------
		// MINIMUMKIVÁLASZTÁSOS RENDEZÉS
		// ------------------------------

		static void MinKivRendezes(int[] tomb)
		{
			for (int i = 0; i < tomb.Length - 1; i++)
			{
				int min = i;
				for (int j = (i + 1); j < tomb.Length; j++)
				{
					if (tomb[min] > tomb[j])
						min = j;
				}
				Csere(tomb, min, i);
			}
		}

		// ------------------------------
		// MAXIMUMKIVÁLASZTÁSOS RENDEZÉS
		// ------------------------------

		static void MaxKivRendezes(int[] tomb)
		{
			for (int i = 0; i < tomb.Length - 1; i++)
			{
				int max = i;
				for (int j = (i + 1); j < tomb.Length; j++)
				{
					if (tomb[max] < tomb[j])
						max = j;
				}
				Csere(tomb, max, i);
			}
		}


		// ------------------------------
		// BUBORÉKRENDEZÉS
		// ------------------------------

		static void BuborekRendezes(int[] tomb)
		{
			for (int i = tomb.Length-1; i >= 1; i--)
			{
				for (int j = 0; j <= (i-1); j++)
				{
					if (tomb[j] > tomb[j + 1])
						Csere(tomb, j, j + 1); 
				} 
			}
		}


		// ----------------------------------------------------------------
		//			TÖMB KEZELŐ METÓDUSOK
		// ----------------------------------------------------------------

		static void TombFeltolt( int[] tomb )
		{
			Random r = new Random();
			for (int i = 0; i < tomb.Length; i++)
				tomb[i] = r.Next(10);
		}

		static void TombKiir( int[] tomb )
		{
			for (int i = 0; i < tomb.Length; i++)
				Console.WriteLine(tomb[i]);
		}

		static void FormazottStringKiir(string bemenet , int ujsor)
		{
			if(ujsor == 2)
				Console.WriteLine("\n\n {0} \n------------------------" , bemenet);
			else
				Console.WriteLine("\n» {0} \n" , bemenet);
		}





        static void Main(string[] args)
        {
			int[] tombom = new int[ 8 ];


			// egyszerű cserés rendezés
            	TombFeltolt(tombom);

				FormazottStringKiir("EGYSZERŰ CSERÉS RENDEZÉS" , 2);
				FormazottStringKiir("EREDETI" , 1);
				TombKiir(tombom);
	            
				FormazottStringKiir("RENDEZETT" , 1);
				EgyszeruCseresRendezes(tombom);
				TombKiir(tombom);


			// minimumkiválasztásos rendezés
	            TombFeltolt(tombom);

				FormazottStringKiir("MINIMUMKIVÁLASZTÁSOS RENDEZÉS" , 2);
				FormazottStringKiir("EREDETI" , 1);
				TombKiir(tombom);

				FormazottStringKiir("RENDEZETT" , 1);
				MinKivRendezes(tombom);
				TombKiir(tombom);


			// maximumkiválasztásos rendezés
				TombFeltolt(tombom);

				FormazottStringKiir("MINIMUMKIVÁLASZTÁSOS RENDEZÉS" , 2);
				FormazottStringKiir("EREDETI" , 1);
				TombKiir(tombom);

				FormazottStringKiir("RENDEZETT" , 1);
				MaxKivRendezes(tombom);
				TombKiir(tombom);


			// buborékrendezés
				TombFeltolt(tombom);

				FormazottStringKiir("MINIMUMKIVÁLASZTÁSOS RENDEZÉS" , 2);
				FormazottStringKiir("EREDETI" , 1);
				TombKiir(tombom);

				FormazottStringKiir("RENDEZETT" , 1);
				BuborekRendezes(tombom);
				TombKiir(tombom);



		}
    }
}
