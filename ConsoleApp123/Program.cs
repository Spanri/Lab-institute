using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void fun1()
        {
            StreamWriter f = new StreamWriter("fun1.txt",true);

            double a, z1, z2;
            Console.Write("a = ");
            a = Convert.ToDouble(Console.ReadLine());

            z1 = Math.Pow(Math.Cos((3 / 8) * Math.PI - 0.25 * a), 2) - 
                Math.Pow(Math.Cos((11 / 8) * Math.PI + 0.25 * a), 2);
            z2 = (Math.Sqrt(2) / 2) * Math.Sin(a / 2);

            Console.WriteLine("z1 = " + z1);
            Console.WriteLine("z2 = " + z2);
            
            f.WriteLine($"{a}\t{z1}\t{z2}");
            f.Close();
        }

        static void fun2()
        {
            StreamWriter f = new StreamWriter("fun2.txt", true);

            double x, y = 999;
            do
            {
                Console.Write("x = ");
                x = Convert.ToDouble(Console.ReadLine());
                if (x < -7 || x > 11)
                    Console.Write("x должен быть от -7 до 11!");
            } while (x < -7 || x > 11);

            if (x < -3 && x >= -7) y = 3;
            else if (x >= -3 && x <= 3) y = Math.Abs(Math.Sqrt(9 - x * x) - 3);
            else if (x > 3 && x < 6) y = 9 - 2 * x;
            else if (x >= 6 && x < 11) y = x - 9;

            Console.WriteLine("y = " + y);

            f.WriteLine($"{x}\t{y}");
            f.Close();
        }

        static void fun22()
        {
            StreamWriter f = new StreamWriter("fun22.txt", true);

            double r, x, y;
            bool s = false;
            
            Console.Write("r = ");
            r = Convert.ToDouble(Console.ReadLine());
            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());


            if (( (x+r)*(x+r) + (y-r)*(y-r) <= r*r) || (y >= -r && y <= 0 && x>=0 && x<=2*r)) 
                s = true;

            Console.WriteLine("Входит? " + s);

            f.WriteLine($"{r}\t{x}\t{y}\t{s}");
            f.Close();
        }

        static void fun3()
        {
            StreamWriter f = new StreamWriter("fun3.txt");

            double x, y = 999, i = 1;

            f.WriteLine("i\tx\ty");
            for (x = -7; x <= 11; x++) {
                if (x < -3 && x >= -7) y = 3;
                else if (x >= -3 && x <= 3) y = Math.Abs(Math.Sqrt(9 - x * x) - 3);
                else if (x > 3 && x < 6) y = 9 - 2 * x;
                else if (x >= 6 && x < 11) y = x - 9;
                f.WriteLine($"{i}\t{x}\t{y}");
                i++;
            }
            f.Close();

            Console.WriteLine("\tТаблица 2-1");
            StreamReader f0 = new StreamReader("fun3.txt");
            string s = f0.ReadToEnd();
            Console.WriteLine(s);
            f0.Close();
        }

        static void fun32()
        {
            StreamWriter f = new StreamWriter("fun32.txt");

            double x, y, r;
            bool s;

            Console.Write("r = ");
            r = Convert.ToDouble(Console.ReadLine());

            //ввести 10 выстрелов и фор массив от 0 до 9
            f.WriteLine("i\tx\ty\ts");
            for (int i = 0; i < 10; i++)
            {
                s = false;
                Console.Write(i + 1 + "\nx = ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("y = ");
                y = Convert.ToDouble(Console.ReadLine());

                if (((x + r) * (x + r) + (y - r) * (y - r) <= r * r) || (y >= -r && y <= 0 && x >= 0 && x <= 2 * r))
                    s = true;
                f.WriteLine($"{i}\t{x}\t{y}\t{s}");
            }
            f.Close();

            Console.WriteLine("\tТаблица 2-2");
            StreamReader f0 = new StreamReader("fun32.txt");
            string c = f0.ReadToEnd();
            Console.WriteLine(c);
            f0.Close();
        }

        static void fun33()
        {
            StreamWriter f = new StreamWriter("fun33.txt");

            double x1, x2, h, t, y, y2, n;
            bool k;

            do
            {
                Console.Write("xнач(от -1 до 1) ");
                x1 = Convert.ToDouble(Console.ReadLine());
                if (x1 < -1 || x1 > 1)
                    Console.Write("x должен быть от -1 до 1!\n");
            } while (x1 < -1 || x1 > 1);
            do
            {
                Console.Write("xкон(от -1 до 1) ");
                x2 = Convert.ToDouble(Console.ReadLine());
                if (x2 < -1 || x2 > 1)
                    Console.Write("x должен быть от -1 до 1!\n");
            } while (x2 < -1 || x2 > 1);
            do
            {
                Console.Write("шаг(от 0 до 2) ");
                h = Convert.ToDouble(Console.ReadLine());
                if (h < 0 || h > 2)
                    Console.Write("шаг должен быть от 0 до 2!\n");
            } while (h < 0 || h > 2);
            Console.Write("Точность ");
            t = Convert.ToDouble(Console.ReadLine());

            f.WriteLine("x\ty\t\tn");
            for (double x = x1; x <= x2; x += h)
            {
                n = 0;
                k = false;
                y = Math.PI / 2;
                while (!k)
                {
                    y2 = y;
                    y += (Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n + 1)) / (2 * n + 1);
                    if (Math.Abs(y2 - y)<= t) k = true;
                    n++;
                }
                f.WriteLine($"{x}\t{y}\t\t{n}");
            }
            f.Close();

            Console.WriteLine("\tТаблица 2-3");
            StreamReader f0 = new StreamReader("fun33.txt");
            string s = f0.ReadToEnd();
            Console.WriteLine(s);
            f0.Close();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1 задание - 1,\n2 задание - 2\n2(2) задание" +
                " - 22\n3 задание - 3\n3(2) задание - 32\n3(3) задание - 33\n" +
                "файл с результатами - номер задания + 0 (10, 20, 220, " +
                "или 330)\nвыйти - 0");
            string c;
            do
            {
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        fun1();
                        break;
                    case "2":
                        fun2();
                        break;
                    case "22":
                        fun22();
                        break;
                    case "3":
                        fun3();
                        break;
                    case "32":
                        fun32();
                        break;
                    case "33":
                        fun33();
                        break;
                    case "10":
                        StreamReader f1 = new StreamReader("fun1.txt");
                        string s1 = f1.ReadToEnd();
                        Console.WriteLine(s1);
                        f1.Close();
                        break;
                    case "20":
                        StreamReader f2 = new StreamReader("fun2.txt");
                        string s2 = f2.ReadToEnd();
                        Console.WriteLine(s2);
                        f2.Close();
                        break;
                    case "220":
                        StreamReader f22 = new StreamReader("fun22.txt");
                        string s22 = f22.ReadToEnd();
                        Console.WriteLine(s22);
                        f22.Close();
                        break;
                    case "330":
                        StreamReader f33 = new StreamReader("fun33.txt");
                        string s33 = f33.ReadToEnd();
                        Console.WriteLine(s33);
                        f33.Close();
                        break;
                    case "0":
                        break; 
                    default:
                        Console.WriteLine("Не попал по клавише!");
                        break;
                }
            } while (c !="0");
        }
    }
}
