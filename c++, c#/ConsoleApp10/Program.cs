using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    struct Train: IComparable <Train>
    {
        public string dest, date;
        public int numTr;
        //присваивание
        public Train(string dest, int numTr, string date){
            this.dest = dest;
            this.numTr = numTr;
            this.date = date;
        }
        //переопределнный compare
        public int CompareTo(Train train)
        {
            return String.Compare(this.dest, train.dest);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Train[] train = new Train[8];
            int k = 0;
            //массивы для заранее заданных
            string[] mas = { "hghf", "sdfgs", "aaasdf", "bfgsdfg", "kljgdfg", "lkjdfg", "dsfgsdf", "kaqex" };
            int[] mas2 = { 2, 45, 12, 46, 14, 1, 65, 30 };
            string[] mas3 = { "14-25", "11-15", "18-15", "15-36", "21-16", "23-00", "14-30", "09-09" };
            //ввод с клавиатуры
            int c;
            do
            {
                Console.WriteLine("Ввести данные - 1, заданные заранее - 2");
                c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                    for (int i = 0; i < 8; i++)
                    {
                        try
                        {
                            Console.Write("пункт назначения: ");
                            train[i].dest = Console.ReadLine();
                            Console.Write("номер поезда: ");
                            train[i].numTr = Convert.ToInt32(Console.ReadLine());
                            Console.Write("время отправления: ");
                            train[i].date = Console.ReadLine();
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); c = 0; break; }
                    }
                else if (c == 2)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        train[i].dest = mas[i];
                        train[i].numTr = mas2[i];
                        train[i].date = mas3[i];
                    }
                }
                else Console.WriteLine("Не туда тыкнул!");
            } while (c != 1 && c != 2);
            //сортировка
            Array.Sort(train);
            //вывести поезда
            for (int i = 0; i < 8; i++)
                Console.WriteLine($"{train[i].dest}\t{train[i].numTr}\t{train[i].date}\t");
            //вывод поездов с датой после введенного времени
            Console.Write("Время: ");
            string time = Console.ReadLine();
            for (int i = 0; i < 8; i++)
            {
                if (String.Compare(train[i].date, time) == 1)
                    Console.WriteLine($"{train[i].dest}\t{train[i].numTr}\t{train[i].date}\t");
                k++;
            }
            if (k == 0) Console.Write("Все поезда ушли!");
        }
    }
}
