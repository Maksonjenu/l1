# l1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication111111111
{

   
    class Program
    {
        
        static void vihod_mass(ref int[] mass)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{1}ый - {0} ",mass[i],i+1);
            }
        }
        static void rand_mass(ref int[] mass)
        {
                Random rnd = new Random();
                int min = (1);
                int max = (100);
                for (int i = 0; i < 10; i++)
                {
                    mass[i] = rnd.Next(min, max + 1);
                }
        }
        static void sort(ref int[] mass)
        {
            for (int j =0; j<10;j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (mass[i]>mass[j])
                    {
                        int heh = mass[i];
                        mass[i] = mass[j];
                        mass[j] = heh;
                    }
                    
                }
            }
        }
        static void Main(string[] args)
        {
            int[] masif = new int[10];
            rand_mass(ref masif);
            vihod_mass(ref masif);
            Console.WriteLine("------------");
            sort(ref masif);
            vihod_mass(ref masif);
            Console.ReadKey();
        }
        
    }
}
