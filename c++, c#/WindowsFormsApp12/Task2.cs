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
    public partial class Task2 : Form
    {
        [Serializable]
        public struct Train : IComparable<Train>
        {
            public string dest, date;
            public int numTr;
            //присваивание
            public Train(string dest, int numTr, string date)
            {
                this.dest = dest;
                this.numTr = numTr;
                this.date = date;
            }
            //переопределнный compare
            public int CompareTo(Train train)
            {
                return String.Compare(this.dest, train.dest);
            }

            public static bool operator ==(Task2.Train a, Task2.Train b)
            {
                if ((Object)a == null || (Object)a == null) return false;
                if (b.dest == "" && b.date == "" && b.numTr == -1) return false;
                if ((b.dest.Equals("") || b.dest.Equals(a.dest))
                    && (b.date.Equals("") || b.date.Equals(a.date))
                    && (b.numTr == -1 || b.numTr == a.numTr)) return true;
                else return false;
            }

            public static bool operator !=(Task2.Train a, Task2.Train b)
            {
                if ((Object)a == null || (Object)a == null) return true;
                if (b.dest == "" && b.date == "" && b.numTr == -1) return true;
                if ((b.dest.Equals("") || b.dest.Equals(a.dest))
                    && (b.date.Equals("") || b.date.Equals(a.date))
                    && (b.numTr == -1 || b.numTr == a.numTr)) return false;
                else return true;
            }
        }

        public List<Train> train = new List<Train>();

        public Task2()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2Add add = new Form2Add();
            add.Owner = this;
            add.ShowDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2File file = new Form2File();
            file.Owner = this;
            file.ShowDialog();
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2Sort sort = new Form2Sort();
            sort.Owner = this;
            sort.ShowDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2Find find = new Form2Find();
            find.Owner = this;
            find.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int ind = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(ind);
            }
            else MessageBox.Show("Not selected");
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2Output outp = new Form2Output();
            outp.Owner = this;
            outp.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Task1About outp = new Task1About();
            outp.Owner = this;
            outp.ShowDialog();
        }
    }
}
