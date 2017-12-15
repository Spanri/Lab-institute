using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int[] arr = new int[100];
            int max, c, k = 0, m1 = 0, m2 = 0;

            Console.Write("Сколько элементов в массиве(до 100)? ");
            int n = Convert.ToInt32(Console.ReadLine());

            //генерация элементов
            do
            {
                k = 0;
                for (int i = 0; i < n; i++)
                {
                    arr[i] = rng.Next(20);
                    if (arr[i] == 0)
                    {
                        k++;
                        if (k == 1) m1 = i + 1;
                        if (k == 2) m2 = i;
                    }
                }
            }
            while (k < 2);
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.Write("\n");

            //макс элемент массива
            max = arr[0];
            for (int i = 1; i < n; i++)
                max = Math.Max(max,arr[i]);
            Console.WriteLine("Максимум: " + max);

            //произведение элементов между 1 и 2 нулевым элементами
            c = arr[m1];
            for (int i = m1 + 1; i < m2; i++)
                c *= arr[i];
            Console.WriteLine("Произведение: " + c);
        }
    }
}
