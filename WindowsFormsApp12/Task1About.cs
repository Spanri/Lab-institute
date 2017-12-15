using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp12
{
    public partial class Task1About : Form
    {
        public Task1About()
        {
            InitializeComponent();
        }

        private void Task1About_Load(object sender, EventArgs e)
        {
            if (File.Exists("train.dat"))
                using (FileStream fs = new FileStream("train.dat", FileMode.OpenOrCreate))
                {
                    Task2 t2 = this.Owner as Task2;

                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Task2.Train> newTrain = (List<Task2.Train>)formatter.Deserialize(fs);

                    label1.Text = label1.Text + "\nLastDest:" + newTrain[t2.train.Count-1].dest + ",\nLastDate:" + newTrain[t2.train.Count-1].date;

                    Console.ReadLine();
                }
        }
    }
}
