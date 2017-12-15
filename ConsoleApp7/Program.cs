using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader f0 = new StreamReader("str.txt");
                string str = f0.ReadToEnd();
                Console.WriteLine(str);
                f0.Close();

                //разбиваем на слова
                Char delimiter = ' ';
                String[] sub = str.Split(delimiter);

                //проверяем длину
                Console.WriteLine("Слова <= 4:");
                for (int i = 0; i < sub.Length; i++)
                    if (sub[i].Length <= 4) Console.Write(sub[i] + ", ");
                Console.Write("\n");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Файла не существует");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Каталога не существует");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Неверный режим открытия файла");
            }
            catch (IOException)
            {
                Console.WriteLine("Файл не открывается из-за ошибок ввода-вывода");
            }
            catch
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
    }
}
