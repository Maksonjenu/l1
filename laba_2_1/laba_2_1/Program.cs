using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2_1
{

    class Program
    {
        struct SStudent
        {
            public string fio;
            public int math;
            public int phys;
        }

        
        static void student(ref SStudent[] studd)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.Clear();
                string[] st_1 = new string[4] { "1) Все студенты ", "2) Только отличники ", "3) Не отличники ", "Enter) Выйти " };
                for (int i = 0; i < 4; i++)
                    Console.WriteLine(st_1[i]);
                ConsoleKeyInfo key = Console.ReadKey();
                char c = key.KeyChar;
                int sw_1 = Convert.ToInt32(key.KeyChar);
                switch (sw_1)
                {
                    case 49:
                        {
                            Console.Clear();
                            Console.WriteLine("Имя              Матеша      Физика");
                            for (int i = 0; i < 10; i++)
                            {

                                Console.WriteLine("{0}      {1}          {2}", studd[i].fio, studd[i].math, studd[i].phys);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 50:
                        {
                            Console.Clear();
                            Console.WriteLine("Имя              Матеша      Физика");
                            for (int i = 0; i < 10; i++)
                            {
                                if ((studd[i].math == 5) && (studd[i].phys == 5))
                                    Console.WriteLine("{0}      {1}          {2}", studd[i].fio, studd[i].math, studd[i].phys);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 51:
                        {
                            Console.Clear();
                            Console.WriteLine("Имя              Матеша      Физика");
                            for (int i = 0; i < 10; i++)
                            {
                                if ((studd[i].math <= 3) || (studd[i].phys <= 3))
                                    Console.WriteLine("{0}      {1}          {2}", studd[i].fio, studd[i].math, studd[i].phys);
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 13:
                        {
                            exit = true;
                            break;
                        }
                }
            }
        }
        static void month()
        {
            bool exit = false;
            while (exit == false)
            {
                int mon = int.Parse(Console.ReadLine());
                switch (mon)
                {
                    case 1:
                        Console.WriteLine("Январь");
                        break;
                    case 2:
                        Console.WriteLine("Февраль");
                        break;
                    case 3:
                        Console.WriteLine("Март");
                        break;
                    case 4:
                        Console.WriteLine("Апрель");
                        break;
                    case 5:
                        Console.WriteLine("Май");
                        break;
                    case 6:
                        Console.WriteLine("Июнь");
                        break;
                    case 7:
                        Console.WriteLine("Июль");
                        break;
                    case 8:
                        Console.WriteLine("Август");
                        break;
                    case 9:
                        Console.WriteLine("Сентябрь");
                        break;
                    case 10:
                        Console.WriteLine("Октябрь");
                        break;
                    case 11:
                        Console.WriteLine("Ноябрь");
                        break;
                    case 12:
                        Console.WriteLine("Декабрь");
                        break;
                    default:
                        break;
                }
            }
        }
        static void prostoe ()
        {
            int count=0;
            int suspect = int.Parse(Console.ReadLine());
            for (int i = 2; i <= suspect; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0) count = count + 1;
                }
                if (count <= 2) Console.WriteLine("{0} - простое ", i);
                if ((count > 2) && (i == suspect)) Console.WriteLine("{0} - не простое ", i);
                count = 0;
            }
        }
        static void randmass(int min, int max)
        {
            
            Random rnd = new Random();
            int[] mass = new int[10];
            for (int i = 0; i < 10; i++)
            {
                mass[i] = rnd.Next(min, max+1);
                Console.WriteLine("mass[{0}] = {1}", i, mass[i]);
            }
            Console.ReadKey();
        }
        static void tablica()
        {
            int i, j;
            for (i = 1; i < 11; i++)
            {
                Console.WriteLine("Таблица на {0}", i);
                for (j = 1; j < 11; j++)
                {
                    Console.WriteLine("{0} x {1} = {2} ", i, j, (i * j));
                }
            }
            Console.ReadKey();
        }
        static void simvol()
        {
            Console.Clear();
            bool exit = false;
            while (exit == false)
            {
                
                ConsoleKeyInfo key_1 = Console.ReadKey();
                char c_1 = key_1.KeyChar;
                int sw_1 = Convert.ToInt32(key_1.KeyChar);
                if ((sw_1 == 49) || (sw_1 == 50) || (sw_1 == 51) || (sw_1 == 52) || (sw_1 == 53) || (sw_1 == 54) || (sw_1 == 55) || (sw_1 == 56) || (sw_1 == 57) || (sw_1 == 58) || (sw_1 == 59))
                {   
                    Console.WriteLine(" - {0} - цифра ", sw_1);
                }
                else                
                Console.WriteLine(" - {0} - не цифра ",sw_1);
                if (sw_1 == 13)
                    exit = true;
            }
        }
        static void swap (ref double a, ref double b)
        {
            double heh;
            heh = a;
            a = b;
            b = heh;
        }

        static void Main(string[] args)
        {


            SStudent[] stud = new SStudent[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                

                stud[i].fio = ("Имя_студента_" + i);
                stud[i].math = rnd.Next(2, 6);
                stud[i].phys = rnd.Next(2, 6);
            }

            string[] st = new string[8] { "1)Таблица умножения ", "2)Цифра или нет ", "3)Поменять double ", "4)Массив из случайных чисел ", "5)Простое число ", "6)Месяца ", "7)Студенты ","Enter) Выход" };
            int menuIndex = 0;
            while (menuIndex != 8)
            {
                Console.Clear();
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine("{0}", st[i]);
                }
                    ConsoleKeyInfo key = Console.ReadKey();
                    char c = key.KeyChar;
                    int sw = Convert.ToInt32(key.KeyChar);
                    switch (sw)
                    {
                        case 49:
                        {
                            tablica();
                            break;
                        }
                        case 50:
                        {
                            simvol();
                            break;
                        }
                        case 51:
                        {
                            Console.Clear();
                            double a1 = double.Parse(Console.ReadLine());
                            double b1 = double.Parse(Console.ReadLine());
                            Console.WriteLine("a1 = {0}, b1 = {1} ", a1, b1);
                            swap(ref a1, ref b1);
                            Console.WriteLine("a1 = {0}, b1 = {1} ", a1, b1);
                            Console.ReadKey();
                            break;
                        }
                        case 52:
                        {
                            Console.Clear();
                            Console.Write("Минимальное значение - ");
                            int min = int.Parse(Console.ReadLine());
                            Console.Write("Максимальное значение - ");
                            int max = int.Parse(Console.ReadLine());
                            randmass(min, max);
                            break;
                        }
                        case 53:
                        {
                            Console.Clear();
                            prostoe();
                            Console.ReadKey();
                            break;
                        }
                        case 54:
                        {
                            Console.Clear();
                            month();
                            Console.ReadKey();
                            break;
                        }
                        case 55:
                        student(ref stud);
                        break;
                        case 13: menuIndex = 8;
                        break;

                    }




                }


            }
        }
    }


    

