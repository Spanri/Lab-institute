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
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace AntiV
{
    public partial class Form1Other
    {

        /// <summary>
        /// Указать путь к файлу
        /// </summary>
        /// <returns>Путь к файлу</returns>
        public string pathScan()
        {
            String line = "";
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter("path.txt");
                    sw.WriteLine(FBD.SelectedPath);
                    sw.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Exception: " + err.Message);
                }

                line = FBD.SelectedPath;
            }
            return line;
        }

        /// <summary>
        /// Получить список сигнатур
        /// </summary>
        /// <returns>Список сигнатур</returns>
        public List<Virus> getVirusDB()
        {
            Form1 f1 = new Form1();
            BinaryFormatter binForm = new BinaryFormatter();

            // узнать путь к файлу
            StreamReader sr = new StreamReader("sign.txt");
            string line = sr.ReadLine();
            sr.Close();

            FileStream virusDataBase = new FileStream(line, FileMode.Open);
            List<Virus> dataBase = new List<Virus>();
            while (virusDataBase.Position < virusDataBase.Length)
            {
                dataBase.Add((Virus)binForm.Deserialize(virusDataBase));
            }
            virusDataBase.Close();
            return dataBase;
        }
        
        /// <summary>
        /// Сканировать директорию
        /// </summary>
        /// <param name="path">Путь к директории</param>
        /// <param name="sign">База сигнатур</param>
        public List<string> scan(string path)
        {
            // создаем АВЛ дерево
            List<Virus> sign = getVirusDB();
            AVL tree = new AVL();
            // создаем АВЛ дерево из сигнатур
            for (int i = 0; i < sign.Count; i++)
            {
                tree.Add(sign[i]);
            }
            
            addSign aS = new addSign();
            List<string> str = new List<string>();

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (string f in Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories).Union(Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories)))
            {
                Virus? virus;
                string signHash, signHash2;

                // Открываем файл
                FileStream file = new FileStream(f, FileMode.Open);
                // узнаем, где у него исп секция
                int[] data = aS.exeSect(file);
                // смещаем его на начало исп секции
                file.Seek(data[1], SeekOrigin.Begin);

                // прогоняем для всей исп области, смещаясь
                // каждый раз на 1 байт и беря 8 байт как длину
                // возможного вируса
                while (file.Position + 8 < data[1] + data[0])
                {
                    // получаем блок кода из сканируемого файла
                    // на месте возможного вируса длиной 8 байт
                    signHash = aS.read(file, 8);
                    // хешируем его
                    signHash = aS.hash(signHash);
                    // сравниваем с помощью АВЛ по хешу
                    // если возвращаемое значение не null, то
                    // это, возможно, зараженный файл и нужно
                    // проверить полный хеш
                    virus = tree.Find(signHash);
                    if (virus != null)
                    {
                        // возвращаемся назад на 8 байт
                        file.Seek(-8, SeekOrigin.Current);
                        // читаем длину сигнатуры
                        signHash2 = aS.read(file, ((Virus)virus).length);
                        signHash2 = aS.hash(signHash2);
                        // если полные хеши равны, то это точно зараженный файл
                        if (signHash2 == ((Virus)virus).hash)
                        {
                            // добавляем в str путь к файлу
                            str.Add(f);
                            // ищем сигнатуру - источник заражения и
                            // прибавляем ей число обнаружений
                            for(int i = 0; i < sign.Count; i++)
                            {
                                if(sign[i].hash == ((Virus)virus).hash)
                                {
                                    //так делается, ибо это ошибка компилятора
                                    Virus vir = sign[i];
                                    vir.detect++;
                                    sign[i] = vir;
                                }
                            }
                            break;
                        }
                        // отменяем смещения
                        file.Seek(8 - ((Virus)virus).length, SeekOrigin.Current);
                    }
                    // идем назад на 8 байт и смещаем на 1 байт
                    file.Seek(-8 + 1, SeekOrigin.Current);
                }
                file.Close();
            }

            // Путь к файлу базы сигнатур
            StreamReader sr = new StreamReader("sign.txt");
            string line = sr.ReadLine();
            sr.Close();

            // сериализуем структуру (превращаем в бинарную форму)
            FileStream VDB = new FileStream(line, FileMode.Create, FileAccess.Write);
            BinaryFormatter binForm = new BinaryFormatter();
            // добавляем в VDB (файл базы сигнатур) объект sign
            // оно добавится туда в 2ой форме и сложно будет что-то понять
            // чтобы что-то понять, надо будет десериализовывать
            for(int i = 0; i < sign.Count; i++)
            {
                binForm.Serialize(VDB, sign[i]);
            }
            VDB.Close();

            return str;
        }
    }
}
