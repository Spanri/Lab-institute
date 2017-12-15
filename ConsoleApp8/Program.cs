using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Notebook
    {
        //фамилия, дата рождения(02/12/1997), номер телефона
        private string surname, dateBirth, num;
        //конструкторы по умолчанию, с параметрами
        public Notebook()
        {
            surname = "";
            dateBirth = "";
            num = "";
        }
        public Notebook(string surname, string dateBirth, string num)
        {
            this.surname = surname;
            this.dateBirth = dateBirth;
            this.num = num;
        }
        //свойства
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        //перегрузка операций
        public static bool operator ==(Notebook a, Notebook b)
        {
            if (a.DateBirth == b.DateBirth && a.Surname == b.Surname && a.Num == b.Num) return true;
            else return false;
        }
        public static bool operator !=(Notebook a, Notebook b)
        {
            if (a.DateBirth != b.DateBirth || a.Surname != b.Surname || a.Num != b.Num) return true;
            else return false;
        }
    }
    class Record
    {
        private Notebook[] rec = new Notebook[1000];
        private int len;
        
        public Record()
        {
            len = 0;
        }
        public int Len
        {
            get { return len; }
            set { len = value; }
        }
        //индексатор
        public Notebook this[int i]
        {
            get
            {
                if (i >= 0 && i < len) return rec[i];
                else {
                    Console.WriteLine("Такой записи нет...");
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < len) rec[i] = value;
            }
        }
        public void data(int i)
        {
            try
            {
                Console.WriteLine(rec[i].Surname + " " + rec[i].DateBirth + " " + rec[i].Num);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //одинаковые записи
        public void equal()
        {
            try
            {
                for (int i = 0; i < len; i++)
                    for (int j = i + 1; j < len; j++)
                    {
                        if (this[i] == this[j])
                        {
                            Console.Write(i + " " + j + " ");
                            this.data(i);
                            break;
                        }
                    }
                Console.WriteLine("---------");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        //поиск
        public void search(int a, string b)
        {
            try
            {
                if (a == 1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (rec[i].Surname == b) { Console.Write("Запись: "); this.data(i); return; }
                    }
                    Console.WriteLine("Нет такой строки!");
                    return;
                }
                else if (a == 2)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (rec[i].DateBirth == b) { Console.Write("Запись: "); this.data(i); return; }
                    }
                    Console.WriteLine("Нет такой строки!");
                    return;
                }
                else if (a == 3)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (rec[i].Num == b) { Console.Write("Запись: "); this.data(i); return; }
                    }
                    Console.WriteLine("Нет такой строки!");
                    return;
                }
                else
                {
                    Console.WriteLine("Что-то не так введено!");
                    return;
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
        //добавление
        public void add(string surname, string dateBirth, string num)
        {
            try
            {
                rec[len] = new Notebook(surname, dateBirth, num);
                len++;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //удаление
        public void delete(int a)
        {
            try
            {
                //перезаписываем все записи с iой до конца на одну назад
                for (int i = a + 1; i < len; i++)
                {
                    //rec[i - 1].Surname = rec[i].Surname;
                    //rec[i - 1].DateBirth = rec[i].DateBirth;
                    //rec[i - 1].Num = rec[i].Num;
                    rec[i - 1] = rec[i];
                }
                rec[len] = null;
                len--;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //сортировка
        public void sort(int a)
        {
            try
            {
                string temp;
                for (int i = 0; i < len - 1; i++)
                    for (int j = i + 1; j < len; j++)
                        if (a == 1)
                        {
                            if (String.Compare(rec[i].Surname, rec[j].Surname) == 1)
                            {
                                temp = rec[i].Surname;
                                rec[i].Surname = rec[j].Surname;
                                rec[j].Surname = temp;
                            }
                        }
                        else if (a == 2)
                        {
                            if (String.Compare(rec[i].DateBirth, rec[j].DateBirth) == 1)
                            {
                                temp = rec[i].DateBirth;
                                rec[i].DateBirth = rec[j].DateBirth;
                                rec[j].DateBirth = temp;
                            }
                        }
                        else if (a == 3)
                        {
                            if (String.Compare(rec[i].Num, rec[j].Num) == 1)
                            {
                                temp = rec[i].Num;
                                rec[i].Num = rec[j].Num;
                                rec[j].Num = temp;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Что-то не то введено!");
                            return;
                        }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        //скрытые поля, констр с пар и без
        //св-ва, индексаторы, перегр операции
        //исключения, функции, мэин
        static void Main(string[] args)
        {
            Record R = new Record();
            int a, i;
            string b;
            string surname, dateBirth, num;

            //массивы для заранее заданных
            string[] mas = { "Иванов", "Шариков", "Козлова", "Омаров", "Иванникова" };
            string[] mas2 = { "2000/10/11", "1997/11/10", "1996/02/18", "2001/11/25", "1990/05/16" };
            string[] mas3 = { "1425", "1115", "1815", "1999", "2000" };

            string c;
            do
            {
                for (int j = 0; j < R.Len; j++) R.data(j);
                Console.WriteLine("Добавить - 1,\nНайти - 2\nУдалить - 3\n" +
                    "Сортировка - 4\nДоступ по номеру - 5\nОдинаковые записи - 6\nвыйти - 0");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        try
                        {
                            //Console.Write("Фамилия: ");
                            //surname = Console.ReadLine();
                            //Console.Write("Дата рождения(формат 01/01/2000): ");
                            //dateBirth = Console.ReadLine();
                            //Console.Write("Номер телефона: ");
                            //num = Console.ReadLine();
                            Random r = new Random();
                            surname = mas[r.Next(0,4)];
                            dateBirth = mas2[r.Next(0, 4)];
                            num = mas3[r.Next(0, 4)];
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        R.add(surname, dateBirth, num);
                        break;
                    case "2":
                        Console.Write("По какому полю искать?(фамилия - 1, дата рождения - 2, номер телефона - 3) ");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Значение, по которому искать: ");
                        b = Console.ReadLine();
                        R.search(a, b);
                        break;
                    case "3":
                        Console.Write("Номер записи для удаления: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        R.delete(i - 1);
                        break;
                    case "4":
                        Console.Write("По какому полю сортировать?(фамилия - 1, дата рождения - 2, номер телефона - 3) ");
                        a = Convert.ToInt32(Console.ReadLine());
                        R.sort(a);
                        break;
                    case "5":
                        Console.Write("Номер записи: ");
                        i = Convert.ToInt32(Console.ReadLine());
                        R.data(i - 1);
                        break;
                    case "6":
                        R.equal();
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
