using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Form2Add : Form
    {
        public Form2Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task2 t2 = this.Owner as Task2;

            int l = t2.train.Count;

            t2.train.Add(new Task2.Train());

            var tr = t2.train[l];
            tr.dest = dest.Text;
            tr.date = date.Text;
            tr.numTr = Convert.ToInt32(numTr.Text);

            t2.train[l] = tr;
            
            string str = tr.dest + "\t" + tr.date + "\t" + tr.numTr;
            t2.listBox1.Items.Add(str);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("train.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, t2.train);
            }

            this.Close();
        }
    }
}
