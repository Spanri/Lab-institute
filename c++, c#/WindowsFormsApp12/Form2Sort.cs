using System;
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
    public partial class Form2Sort : Form
    {
        public Form2Sort()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task2 t2 = this.Owner as Task2;

            if (t2 != null)
            {
                t2.listBox1.Items.Clear();
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < t2.train.Count; i++)
                        for (int j = i; j < t2.train.Count; j++)
                            if (String.Compare(t2.train[i].dest, t2.train[j].dest) > 0)
                            {
                                var t = t2.train[j];
                                t2.train[j] = t2.train[i];
                                t2.train[i] = t;
                            }
                }
                else if (radioButton2.Checked)
                {
                    for (int i = 0; i < t2.train.Count; i++)
                        for (int j = i; j < t2.train.Count; j++)
                            if (String.Compare(t2.train[i].date, t2.train[j].date) > 0)
                            {
                                var t = t2.train[j];
                                t2.train[j] = t2.train[i];
                                t2.train[i] = t;
                            }
                }
                else if (radioButton3.Checked)
                {
                    for (int i = 0; i < t2.train.Count; i++)
                        for (int j = i; j < t2.train.Count; j++)
                            if (t2.train[i].numTr > t2.train[j].numTr)
                            {
                                var t = t2.train[j];
                                t2.train[j] = t2.train[i];
                                t2.train[i] = t;
                            }
                }
                else MessageBox.Show("Not selected");
                for (int i = 0; i < t2.train.Count; i++)
                    t2.listBox1.Items.Add(t2.train[i].dest + " " + t2.train[i].date + " " + t2.train[i].numTr);

                this.Close();
            }
        }
    }
}
