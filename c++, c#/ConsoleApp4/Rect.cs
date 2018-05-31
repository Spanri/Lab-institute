using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //Составить описание класса прямоугольников со 
    //сторонами, параллельными осям координат. Предусмотреть
    //возможность перемещения прямоугольников на плоскости,
    //изменение размеров, построение наименьшего прямоугольника,
    //содержащего два заднных прямоугольника, и прямоугольника, являющегося
    //общей частью (пересечением) двух прямоугольников.
    class Rect
    {
        double xmin, xmax, ymin, ymax;
        public double Xmin
        {
            get { return xmin; }
            set { xmin = value; }
        }
        public double Xmax
        {
            get { return xmax; }
            set { xmax = value; }
        }
        public double Ymin
        {
            get { return ymin; }
            set { ymin = value; }
        }
        public double Ymax
        {
            get { return ymax; }
            set { ymax = value; }
        }
        public Rect()
        {
            xmin = xmax = ymin = ymax = 0;
        }
        public Rect(double xmin, double xmax, double ymin, double ymax)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.ymin = ymin;
            this.ymax = ymax;
        }
        public void move()
        {
            try
            {
                Console.Write("На сколько подвинуть высоту по координатной прямой? ");
                double h = Convert.ToDouble(Console.ReadLine());
                Console.Write("На сколько подвинуть ширину по координатной прямой ");
                double w = Convert.ToDouble(Console.ReadLine());
                xmin += w;
                xmax += w;
                ymin += h;
                ymax += h;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void scale()
        {
            try
            {
                Console.WriteLine("Размер меняется относительно нижней левой точки.");
                Console.Write("На сколько изменить высоту по координатной прямой? ");
                double h = Convert.ToDouble(Console.ReadLine());
                Console.Write("На сколько изменить ширину по координатной прямой ");
                double w = Convert.ToDouble(Console.ReadLine());
                xmax += w;
                ymax += h;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Fun
    {
        public static void data(Rect A, Rect B)
        {
            try
            {
                Console.Write("1 прямоугольник(xmin, xmax, ymin, ymax): ");
                Console.WriteLine($"{A.Xmin} {A.Xmax} {A.Ymin} {A.Ymax}");
                Console.Write("2 прямоугольник(xmin, xmax, ymin, ymax): ");
                Console.WriteLine($"{B.Xmin} {B.Xmax} {B.Ymin} {B.Ymax}");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void minRect(Rect A, Rect B)
        {
            try
            {
                double xmin, xmax, ymin, ymax;
                xmin = Math.Min(B.Xmin, A.Xmin);
                xmax = Math.Max(B.Xmax, A.Xmax);
                ymin = Math.Min(B.Ymin, A.Ymin);
                ymax = Math.Max(B.Ymax, A.Ymax);
                Rect C = new Rect(xmin, xmax, ymin, ymax);
                Console.WriteLine($"{C.Xmin} {C.Xmax} {C.Ymin} {C.Ymax}");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void comRect(Rect A, Rect B)
        {
            try
            {
                double xmin, xmax, ymin, ymax;
                xmin = Math.Max(B.Xmin, A.Xmin);
                xmax = Math.Min(B.Xmax, A.Xmax);
                ymin = Math.Max(B.Ymin, A.Ymin);
                ymax = Math.Min(B.Ymax, A.Ymax);
                Rect C = new Rect(xmin, xmax, ymin, ymax);
                Console.WriteLine($"{C.Xmin} {C.Xmax} {C.Ymin} {C.Ymax}");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double h, w;
            double xmin, xmax, ymin, ymax;

            //определение прямоугольников
            Console.WriteLine("1 прямоугольник");
            Console.WriteLine("Введите точки(через enter, xmin, xmax, ymin, ymax)");
            xmin = Convert.ToDouble(Console.ReadLine());
            xmax = Convert.ToDouble(Console.ReadLine());
            ymin = Convert.ToDouble(Console.ReadLine());
            ymax = Convert.ToDouble(Console.ReadLine());
            Rect A = new Rect(xmin, xmax, ymin, ymax);
            Console.WriteLine("2 прямоугольник");
            Console.WriteLine("Введите точки(через enter, xmin, xmax, ymin, ymax)");
            xmin = Convert.ToDouble(Console.ReadLine());
            xmax = Convert.ToDouble(Console.ReadLine());
            ymin = Convert.ToDouble(Console.ReadLine());
            ymax = Convert.ToDouble(Console.ReadLine());
            Rect B = new Rect(xmin, xmax, ymin, ymax);

            string c;
            do
            {
                Console.WriteLine("Передвинуть прямоугольник - 1\n" +
                "Изменить размеры прямоугольника - 2\nМинимальный общий прямоугольник - 3\n" +
                "Пересечение прямоугольников - 4\nВыйти - 0");
                Console.WriteLine("Что сделать?");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        Console.WriteLine("Какой прямоугольник передвинуть?(1 или 2)");
                        h = Convert.ToInt32(Console.ReadLine());
                        if (h == 1) A.move();
                        else B.move();
                        Fun.data(A, B);
                        break;
                    case "2":
                        Fun.data(A, B);
                        Console.WriteLine("Размеры какого прямоугольника изменить?(1 или 2)");
                        h = Convert.ToInt32(Console.ReadLine());
                        if (h == 1) A.scale();
                        else B.scale();
                        Fun.data(A, B);
                        break;
                    case "3":
                        Fun.data(A, B);
                        Fun.minRect(A, B);
                        break;
                    case "4":
                        Fun.data(A, B);
                        Fun.comRect(A, B);
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Не попал по клавише!");
                        break;
                }
            } while (c != "0");
        }
    }
}
