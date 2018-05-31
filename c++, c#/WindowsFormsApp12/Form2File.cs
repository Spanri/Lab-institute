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

namespace WindowsFormsApp12
{
    public partial class Form2File : Form
    {
        public Form2File()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("file.txt", true);

            string s = f.ReadToEnd();
            String[] xy = s.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Task2 t2 = this.Owner as Task2;

            if (t2 != null)
            {
                string[] split;
                int l;

                try
                {
                    t2.train.Clear();
                    t2.listBox1.Items.Clear();
                    for (int i = 0; i < xy.Length; i++)
                    {
                        l = t2.train.Count;
                        split = xy[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        t2.train.Add(new Task2.Train());
                        var tr = t2.train[l];
                        tr.dest = split[0];
                        tr.date = split[1];
                        tr.numTr = Convert.ToInt32(split[2]);
                        t2.train[l] = tr;
                        string str = tr.dest + "\t" + tr.date + "\t" + tr.numTr;
                        t2.listBox1.Items.Add(str);
                    }
                }
                catch (FormatException er) { Console.WriteLine(er.Message); }
            }
            this.Close();
            f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter("file.txt", true);

            f.WriteLine($"{dest.Text} {date.Text} {numTr.Text}");

            f.Close();
        }
    }
}
