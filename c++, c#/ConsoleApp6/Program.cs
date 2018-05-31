using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[8, 8];
            Random rng = new Random();
            int k = 0, sum;

            //генерация элементов
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    arr[i,j] = rng.Next(-10,10);
                    //arr[i, j] = rng.Next(2);
            //вывод элементов
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(arr[i,j] + "\t");
                Console.Write("\n");
            }

            //проверка на соответствие
            Console.Write("Соответствие: ");
            for (int i = 0; i < 8; i++)
            {
                k = 0;
                for (int j = 0; j < 8; j++)
                {
                    //меняю j, не меняя строку/столбец
                    //то есть проверяю все элементы строки/столбца
                    if (arr[i, j] == arr[j, i]) k++;
                    else k = 0;
                }
                if (k == 8) Console.Write(i+1 + " ");
            }
            Console.Write("\n");

            //сумма, где есть отриц элементы
            Console.WriteLine("Сумма: ");
            for (int i = 0; i < 8; i++) {
                sum = k = 0;
                for (int j = 0; j < 8; j++) {
                    sum += arr[i, j];
                    if (arr[i, j] < 0) k = 1;
                }
                if (k == 1) Console.WriteLine(i + " " + sum); ;
            }

        }
    }
}
