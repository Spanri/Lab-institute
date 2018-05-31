using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Element
    {
        private string name;
        private int input, output;
        //конструкторы
        public Element()
        {
            name = "";
            input = 0;
            output = 0;
        }
        public Element(string name)
        {
            this.name = name;
            input = 1;
            output = 1;
        }
        public Element(string name, int input, int output)
        {
            this.name = name;
            this.input = input;
            this.output = output;
        }
        //свойства
        public string Name
        {
            get { return name; }
        }
        public int Input
        {
            get { return input; }
            set { input = value; }
        }
        public int Output
        {
            get { return output; }
            set { output = value; }
        }
    }
    //ИЛИ-НЕ: логическое сложение и отрицание результата
    class Combine : Element
    {
        bool[] numInput = new bool[5];
        //констуктор по умолчанию
        public Combine() : base("ИЛИ-НЕ",5,1)
        {
            for (int i = 0; i < 5; i++) setInput(i + 1, false);
        }
        //конструктор с параметрами
        public Combine(bool[] numInput) : base("ИЛИ-НЕ",5,1)
        {
            setNumInput(numInput);
        }
        //входы
        public void setNumInput(bool[] numInput)
        {
            try
            {
                for (int i = 0; i < 5; i++) this.numInput[i] = numInput[i];
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //отдельный вход
        public void setInput(int i, bool Input)
        {
            try
            {
                numInput[i - 1] = Input;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //значение выхода
        public bool getOutput()
        {
            try
            {
                return numInput[0] ^ numInput[1] ^ numInput[2] ^ numInput[3] ^ numInput[4];
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
    //регистр - совокупность триггеров (тут 11 триггеров)
    class Register
    {
        //триггер
        class Memory : Element
        {
            private bool[] memIn;
            private bool outDir, outInv;
            //свойства
            public bool OutDir
            {
                get { return outDir; }
                set { outDir = value; }
            }
            public bool OutInv
            {
                get { return outInv; }
                set { outInv = value; }
            }
            //конструктор по умолчанию
            public Memory()
            {
                outDir = false;
                outInv = false;
                Input = 2;
                Output = 1;
                memIn = new bool[Input];
                for (int i = 0; i < Input; i++) memIn[i] = false;
            }
            //конструктор c параметрами
            public Memory(bool memOutDir, bool memOutInv, bool[] memIn)
            {
                try
                {
                    this.outDir = memOutDir;
                    this.outInv = memOutInv;
                    this.memIn = new bool[2];
                    for (int i = 0; i < 2; i++) this.memIn[i] = memIn[i];
                }
                catch (FormatException e) { Console.WriteLine(e.Message); }
            }
            //конструктор копирования
            public Memory(Memory mem)
            {
                outDir = mem.outDir;
                outInv = mem.outInv;
                for (int i = 0; i < Input; i++) memIn[i] = mem.memIn[i];
            }
            //входы
            public void MemIn(bool[] memIn)
            {
                try
                {
                    for (int i = 0; i < Input; i++) this.memIn[i] = memIn[i];
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            //отдельный вход
            public void setMemIn(int i, bool memIn)
            {
                try
                {
                    this.memIn[i - 1] = memIn;
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //состояние экземпляра
            public void Cond(bool m1, bool m2)
            {
                try
                {
                    memIn[0] = m1;
                    memIn[1] = m2;
                    if (m1 == false && m2 == true && OutDir == true) OutDir = false; //011
                    else if (m1 == true && m2 == false && OutDir == false) OutDir = true; //100
                    else if (m1 == true && m2 == true && OutDir == false) OutDir = true; //110
                    else if (m1 == true && m2 == true && OutDir == true) OutDir = false; //111
                    Console.Write(OutDir);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            //переопределение ==
            public static bool operator ==(Memory a, Memory b)
            {
                if (System.Object.ReferenceEquals(a, b)) return true;
                if (((object)a == null) || ((object)b == null)) return false;
                return a.outDir == b.outDir && a.outInv == b.outInv;
            }
            //переопределение !=
            public static bool operator !=(Memory a, Memory b)
            {
                return !(a == b);
            }
        }
        private bool r, s;
        private Memory[] trig = new Memory[11];
        private bool[] InJ = new bool[11];
        private bool[] InK = new bool[11];

        //свойства
        public bool R
        {
            get { return r; }
            set { r = value; }
        }
        public bool S
        {
            get { return s; }
            set { s = value; }
        }
        //конструктор по умолчанию
        public Register()
        {
            r = false;
            s = false;
            for (int i = 0; i < 11; i++)
            {
                InJ[i] = false;
                InK[i] = false;
                trig[i] = new Memory();
            }
        }
        //конструктор c параметрами
        public Register(bool R, bool S, bool[] InJ, bool[] InK)
        {
            try
            {
                this.r = R;
                this.s = S;
                for (int i = 0; i < 11; i++)
                {
                    this.InJ[i] = InJ[i];
                    this.InK[i] = InK[i];
                }
            }
            catch (FormatException e) { Console.WriteLine(e.Message); }
        }
        //входы на триггерах
        public void MemIn(bool[] j, bool[] k)
        {
            try
            {
                for (int i = 0; i < 11; i++)
                {
                    InJ[i] = j[i];
                    InK[i] = k[i];
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //выход на отдельном триггере
        public void MemOut(bool J,bool K, int n)
        {
            try
            {
                trig[n].Cond(J, K);
                Console.WriteLine("\n");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
}
        //новое состояние
        public void RegCond()
        {
            try
            {
                trig[0].Cond(r, s);
                Console.Write(" " + trig[0].OutInv + "\n");
                for (int i = 1; i < 11; i++)
                {
                    trig[i].Cond(trig[i - 1].OutDir, trig[i - 1].OutInv);
                    Console.Write(" " + trig[0].OutInv + "\n");
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
        static void Main(string[] args)
        {
            Combine C = new Combine();
            Register R = new Register();
            int n = 0, m = 0, h;
            bool[] input = new bool[5];
            bool[] j = new bool[11];
            bool[] k = new bool[11];
            bool inp;
            Random r = new Random();

            string c;
            do
            {
                Console.WriteLine("Комбинационный элемент:\nОпределить входы - 1,\nОпределить отдельный вход - 2\nРассчитать выход - 3\n" +
                    "Регистр:\nОпределить входы - 4\nРассчитать выходы на отдельном триггере - 5\nНовое состояние - 6\nвыйти - 0");
                c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        try
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                input[i] = Convert.ToBoolean(r.Next(0, 2));
                                Console.Write(input[i]+" ");
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        C.setNumInput(input);
                        Console.Write("\nСв-ва элемента:\nИмя " + C.Name + "\nВходы " + C.Input + "\nВыходы " + C.Output + "\n");
                        break;
                    case "2":
                        m = 1;
                        try
                        {
                            while (m == 1)
                            {
                                Console.Write("Какой вход задать? ");
                                n = Convert.ToInt32(Console.ReadLine());
                                if (n < 5 && n > 0) m = 0;
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        m = 1;
                        try
                        {
                            while (m == 1)
                            {
                                Console.Write("Значение:(0/1) ");
                                h = Convert.ToInt32(Console.ReadLine());
                                if (h == 0) { C.setInput(n, false); m = 0; }
                                else if (h == 1)
                                {
                                    C.setInput(n, true);
                                    m = 0;
                                }
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        break;
                    case "3":
                        inp = C.getOutput();
                        Console.Write(inp + "\n");
                        break;
                    case "4":
                        for (int i = 0; i < 11; i++)
                        {
                            j[i] = Convert.ToBoolean(r.Next(0, 2));
                            k[i] = Convert.ToBoolean(r.Next(0, 2));
                            Console.Write(j[i] + "," + k[i] + "\t");
                        }
                        Console.Write("\n");
                        R.MemIn(j,k);
                        break;
                    case "5":
                        m = 1;
                        try
                        {
                            while (m == 1)
                            {
                                Console.Write("Номер триггера? ");
                                n = Convert.ToInt32(Console.ReadLine());
                                if (n < 11 && n > 0) m = 0;
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        m = 1;
                        try
                        {
                            while (m == 1)
                            {
                                Console.Write("Значение j:(0/1) ");
                                h = Convert.ToInt32(Console.ReadLine());
                                if (h == 0) { j[0] = false; m = 0; }
                                else if (h == 1) { j[0] = true; m = 0; }
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        m = 1;
                        try
                        {
                            while (m == 1)
                            {
                                Console.Write("Значение k:(0/1) ");
                                h = Convert.ToInt32(Console.ReadLine());
                                if (h == 0) { k[0] = false; m = 0; }
                                else if (h == 1) { k[0] = true; m = 0; }
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); break; }
                        R.MemOut(j[0], k[0], n);
                        break;
                    case "6":
                        R.RegCond();
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
