using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace AntiV
{
    // Вирусы, для базы вирусов
    [Serializable]
    public struct Virus
    {
        public int length;
        public string hash;
        public string hash8;
        public string name;
        public int detect;
    }

    public partial class Form1 : Form
    {
        Form1Other f1Other = new Form1Other();

        public Form1()
        {
            InitializeComponent();
            paths();
        }
       
        /// <summary>
        /// Вывод последних данных в окошки
        /// при загрузке окна
        /// </summary>
        public void paths()
        {
            String line;

            // Последнее сканирование
            try
            {
                StreamReader sr = new StreamReader("date.txt");
                line = sr.ReadLine();
                lastScan.Text = "Последнее сканирование: " + line;
                sr.Close();
            }
            catch (Exception e)
            {
                lastScan.Text = e.Message;
            }

            // Путь сканирования
            try
            {
                StreamReader sr = new StreamReader("path.txt");
                line = sr.ReadLine();
                scanPath.Text = "Путь сканирования: " + line;
                sr.Close();
            }
            catch (Exception e)
            {
                scanPath.Text = e.Message;
            }

            //Путь базы вирусов
            try
            {
                StreamReader sr = new StreamReader("sign.txt");
                line = sr.ReadLine();
                signPath.Text = "Путь к файлу базы вирусов: " + line;
                sr.Close();
            }
            catch (Exception e)
            {
                signPath.Text = e.Message;
            }
            // это не помогает
            Refresh();
        }

        #region Other

        private void Close2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var url = "https://www.facebook.com/profile.php?id=100004629041757&ref=bookmarks";
            System.Diagnostics.Process.Start(url);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var url = "https://twitter.com/spanri";
            System.Diagnostics.Process.Start(url);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var url = "https://vk.com/animeshny_kot";
            System.Diagnostics.Process.Start(url);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        #endregion Other

        #region Red buttons on center
        /// <summary>
        /// Путь сканирования
        /// </summary>
        private void label8_Click(object sender, EventArgs e)
        {
            deleteFile.Enabled = false;
            deleteInfFile.Enabled = false;

            // Путь сканирования
            String line = f1Other.pathScan();
            if (line == "") return;
            scanPath.Text = "Путь сканирования: " + line;

            // Вывести все pe файлы директории в listbox
            DirectoryInfo dir = new DirectoryInfo(line);
            listBox1.Items.Clear();
            files.Text = "PE файлы директории";
            foreach (string f in Directory.GetFiles(line, "*.exe", SearchOption.AllDirectories).Union(Directory.GetFiles(line, "*.dll", SearchOption.AllDirectories)))
            {
                string[] splitpath = f.Split('\\');
                string name = splitpath[splitpath.Length - 1];
                listBox1.Items.Add(name);
            }
        }

        /// <summary>
        /// Путь к файлу базы вирусов
        /// </summary>
        private void changeSignPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog OBD = new OpenFileDialog();
            if (OBD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("sign.txt");
                    sw.WriteLine(OBD.FileName);
                    sw.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Exception: " + err.Message);
                }
                signPath.Text = "Путь к файлу базы вирусов: " + OBD.FileName;
            }
        }
        
        /// <summary>
        /// Сканировать
        /// </summary>
        private void scan_Click(object sender, EventArgs e)
        {
            deleteFile.Enabled = false;
            deleteInfFile.Enabled = true;

            // Обновить последнее сканирование
            try
            {
                StreamWriter sw = new StreamWriter("date.txt");
                sw.WriteLine(DateTime.Now);
                sw.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Exception: " + err.Message);
            }
            lastScan.Text = "Последнее сканирование: " + DateTime.Now;
            
            // Считываем путь, по которому надо искать
            String line = "";
            StreamReader sr = new StreamReader("path.txt");
            line = sr.ReadLine();
            sr.Close();

            // вызываем функцию
            List<string> InfFile = f1Other.scan(line);

            // выводим в listbox  
            listBox1.Items.Clear();
            for (int j = 0; j < InfFile.Count; j++)
            {
                line = "Путь: " + InfFile[j];
                listBox1.Items.Add(line);
            }
        }
        #endregion Red buttons on center

        #region Pink buttons on bottom

        /// <summary>
        /// Добавить сигнатуру
        /// </summary>
        private void addSign_Click(object sender, EventArgs e)
        {
            addSign addSign = new addSign();
            addSign.Show();
        }

        /// <summary>
        /// вывести список сигнатур
        /// </summary>
        private void label2_Click(object sender, EventArgs e)
        {
            deleteFile.Enabled = true;
            deleteInfFile.Enabled = false;

            // Получить список сигнатур
            List<Virus> sign = f1Other.getVirusDB();

            string line;
            listBox1.Items.Clear();

            for (int i = 0; i < sign.Count; i++)
            {
                line = "Имя: " + sign[i].name + 
                    ", хеш: " + sign[i].hash + 
                    ", длина: " + sign[i].length +
                    ", кол-во заражений: " + sign[i].detect;
                listBox1.Items.Add(line);
            }
        }

        /// <summary>
        /// Удалить зараженный файл
        /// </summary>
        private void deleteFile_Click(object sender, EventArgs e)
        {
            // ищем, что было выделено в listbox1
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i] == listBox1.SelectedItem)
                {
                    // получаем путь к файлу через его структуру
                    string Path = Convert.ToString(listBox1.Items[i]);
                    Path = Path.Substring(6);
                    // удаляем файл
                    File.Delete(Path);

                    // после удаления файла надо удалить 
                    // запись о файле в listBox
                    listBox1.Items.RemoveAt(i);

                    break;
                }
            }
        }

        /// <summary>
        /// Удалить сигнатуру из файла
        /// </summary>
        private void deleteFile_Click_1(object sender, EventArgs e)
        {
            List<Virus> buffer = new List<Virus>();

            // ищем, что было выделено в listbox1
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i] == listBox1.SelectedItem)
                {
                    StreamReader sr = new StreamReader("sign.txt");
                    string line = sr.ReadLine();
                    sr.Close();

                    FileStream InfectedFilesDB = new FileStream(line, FileMode.Open, FileAccess.Read);
                    BinaryFormatter binForm = new BinaryFormatter();
                    
                    for (int k = 0; k < listBox1.Items.Count; k++)
                    {
                        Virus inf = (Virus)binForm.Deserialize(InfectedFilesDB);
                        if (k != i)
                        {
                            buffer.Add(inf);
                        }
                    }
                    InfectedFilesDB.Close();
                    
                    // сериализуем buffer
                    InfectedFilesDB = new FileStream(line, FileMode.Create);
                    for (int j = 0; j < buffer.Count; j++)
                    {
                        binForm.Serialize(InfectedFilesDB, buffer[j]);
                    }

                    // надо удалить запись о сигнатурев listBox
                    listBox1.Items.RemoveAt(i);

                    InfectedFilesDB.Close();
                    break;
                }
            }
        }
        #endregion Pink buttons on bottom
    }
}
