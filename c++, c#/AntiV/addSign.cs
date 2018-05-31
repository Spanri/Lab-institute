using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace AntiV
{
    public partial class addSign : Form
    {
        public addSign()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private void changeSignPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog OBD = new OpenFileDialog();
            if (OBD.ShowDialog() == DialogResult.OK)
            {
                path.Text = OBD.FileName;
            }

            // читаем файл
            FileStream fs = new FileStream(path.Text, FileMode.Open, FileAccess.Read);

            // узнаем смещение от начала исп секции и длину секции,
            // чтобы пользователь знал, какую длину ему можно 
            // максимально задать
            int[] data = exeSect(fs);

            // идем на исполняемую секцию
            fs.Seek(data[1], SeekOrigin.Begin);
            // узнаем ее длину
            if (data[0] == 0) MessageBox.Show("Кажется, это неисполняемый файл... Учтите это.");
            exeSection.Text = Convert.ToString(data[0]);
             
            // закрываем файл
            fs.Close();
        }
        
        /// <summary>
        /// Считывание сигнатуры из файла
        /// </summary>
        /// <param name="file">файл</param>
        /// <param name="len">длина</param>
        /// <returns>строка байтов</returns>
        public string read(FileStream file, int len)
        {
            byte[] bytes = new byte[len];
            // пишем в bytes от смещения файла до смещения + длина
            file.Read(bytes, 0, len);

            // конвертируем байты в строковый тип
            string str = "";
            foreach (byte symb in bytes)
            {
                // перевод из массива байтов в строку
                // Х2 - 16ричный формат
                str += symb.ToString("X2");
            }

            return str;
        }
 
        /// <summary>
        /// Хэширование (контрольная сумма сигнатуры)
        /// </summary>
        /// <param name="sign">что хешировать</param>
        /// <returns>хеш</returns>
        public string hash(string sign)
        {
            uint crc = 0;
            byte[] data;
            using (MD5 hash = MD5.Create())
            {
                data = hash.ComputeHash(Encoding.ASCII.GetBytes(sign));
                for(int i = 0; i < data.Length; i++)
                {
                    crc += data[i];
                }
            }
            if (crc == 0)
            {
                MessageBox.Show("Ошибка хеширования");
                return null;
            }
            // конвертируем байты в строковый тип
            string str = "";
            foreach (byte symb in data)
            {
                // перевод из массива байтов в строку
                // Х2 - 16ричный формат
                str += symb.ToString("X2");
            }
            return str;
        }

        /// <summary>
        /// Получить длину исп секции файла и смещение исп секции от начала
        /// </summary>
        /// <param name="f">поток файла</param>
        /// <returns>0 - длина исп секции, 1 - смещение от начала исп файла</returns>
        public int[] exeSect(FileStream f)
        {
            int[] data = new int[2];

            // читаем смещение заголовка, 
            // идем к e_lfanew
            f.Seek(60, SeekOrigin.Begin);
            int offset = f.ReadByte();
            // смещаем на offset и встаем
            // перед PE-заголовком
            f.Seek(offset, SeekOrigin.Begin);

            // количество секций, пропускаем
            // сигнатуру (4 байта) и архитектуру
            // процессора (2 байта)
            f.Seek(6, SeekOrigin.Current);
            int numOfSections = f.ReadByte();

            // размер дополнительного заголовка
            f.Seek(13, SeekOrigin.Current);
            int addition = f.ReadByte();
            // прыгаем к заголовкам секций
            f.Seek(3 + addition, SeekOrigin.Current);
            
            // проверяем все секции
            while (numOfSections > 0)
            {
                // тип секции
                f.Seek(36, SeekOrigin.Current);
                int temp = f.ReadByte();
                // если исполняемая, заходим
                if (temp == 32)
                {

                    // считываем длину секции
                    // надо считать 4 байта
                    f.Seek(-21, SeekOrigin.Current);
                    // байты расположены наоборот
                    byte[] tempArray = new byte[4];
                    for (int i = 3; i >= 0; i--)
                    {
                        tempArray[i] = (byte)f.ReadByte();
                    }
                    // заносим байты в строку
                    string tempBytes = "";
                    for (int i = 0; i < 4; i++)
                    {
                        // перевод из массива байтов в строку
                        // Х2 - 16ричный формат
                        tempBytes += tempArray[i].ToString("X2");
                    }
                    data[0] = Convert.ToInt32(tempBytes, 16);

                    // считываем смещение секции
                    // от начала файла
                    // переворачиваем и заносим в строку
                    for (int i = 3; i >= 0; i--)
                    {
                        tempArray[i] = (byte)f.ReadByte();
                    }
                    tempBytes = "";
                    for (int i = 0; i < 4; i++)
                    {
                        tempBytes += tempArray[i].ToString("X2");
                    }
                    data[1] = Convert.ToInt32(tempBytes, 16);

                    break;
                }
                else
                {
                    //если секция не исполняемая
                    f.Seek(3, SeekOrigin.Current);
                    numOfSections--;
                }
            }
            return data;
        }

        /// <summary>
        /// Добавить сигнатуру
        /// </summary>
        private void add_Click(object sender, EventArgs e)
        {
            if(path.Text == "")
            {
                MessageBox.Show("Вы не выбрали путь.");
                return;
            }
            
            if (name.Text != "" && offset.Text != "" && length.Text != "")
            {
                // заполняем структуру
                Virus sign;
                // открываем файл, чтобы считать код и захешировать
                FileStream file = new FileStream(path.Text, FileMode.Open, FileAccess.ReadWrite);
                // узнаем длину исп секции и смещение исп секции от начала файла
                int[] data = exeSect(file);
                // смещаем файл на начало исп секции + смещение от нее
                file.Seek(data[1] + Convert.ToInt32(offset.Text), SeekOrigin.Begin);
                // считываем сигнатуру из файла от смещения до смещения + длина
                string virusText = read(file, Convert.ToInt32(length.Text));
                // хэшируем
                sign.hash = hash(virusText);
                // смещаем файл на начало исп секции + смещение от нее
                file.Seek(data[1] + Convert.ToInt32(offset.Text), SeekOrigin.Begin);
                // считываем сигнатуру из файла от смещения до смещения + длина
                string virusText8 = read(file, 8);
                // хэшируем
                sign.hash8 = hash(virusText8);
                // имя вируса
                sign.name = name.Text;
                // длина вируса
                sign.length = Convert.ToInt32(length.Text);
                // кол-во обнаружений
                sign.detect = 0;

                file.Close();

                // Путь к файлу базы сигнатур
                StreamReader sr = new StreamReader("sign.txt");
                string line = sr.ReadLine();
                sr.Close();

                // сериализуем структуру (превращаем в бинарную форму)
                FileStream VDB = new FileStream(line, FileMode.Append, FileAccess.Write);
                BinaryFormatter binForm = new BinaryFormatter();
                // добавляем в VDB (файл базы сигнатур) объект sign
                // оно добавится туда в 2ой форме и сложно будет что-то понять
                // чтобы что-то понять, надо будет десериализовывать
                binForm.Serialize(VDB, sign);
                VDB.Close();

                this.Close();
            }
            else
                MessageBox.Show("Вы что-то не заполнили.");
        }

        #region Other

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addSign_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        #endregion Other
    }
}