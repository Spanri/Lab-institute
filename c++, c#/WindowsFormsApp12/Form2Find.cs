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
    public partial class Form2Find : Form
    {
        public Form2Find()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task2 t2 = this.Owner as Task2;

            if (t2 != null)
            {
                if (radioButton1.Checked)
                {
                    if (dest.Text == "") {
                        MessageBox.Show("Not input");
                        return;
                    }
                    for (int i = 0; i < t2.train.Count; i++)
                        if (dest.Text == t2.train[i].dest)
                        {
                            MessageBox.Show(t2.train[i].dest + " " + t2.train[i].date + " " + t2.train[i].numTr);
                            return;
                        }
                    MessageBox.Show("Not found");
                    return;
                }
                else if (radioButton2.Checked)
                {
                    if (date.Text == "")
                    {
                        MessageBox.Show("Not input");
                        return;
                    }
                    for (int i = 0; i < t2.train.Count; i++)
                        if (date.Text == t2.train[i].date)
                        {
                            MessageBox.Show(t2.train[i].dest + " " + t2.train[i].date + " " + t2.train[i].numTr);
                            return;
                        }
                    MessageBox.Show("Not found");
                    return;
                }
                else if (radioButton3.Checked)
                {
                    if (numTr.Text == "")
                    {
                        MessageBox.Show("Not input");
                        return;
                    }
                    int num = Convert.ToInt32(numTr.Text);
                    for (int i = 0; i < t2.train.Count; i++)
                        if (num == t2.train[i].numTr)
                        {
                            MessageBox.Show(t2.train[i].dest + " " + t2.train[i].date + " " + t2.train[i].numTr);
                            return;
                        }
                    MessageBox.Show("Not found");
                    return;
                }
                MessageBox.Show("Nothing choose");
            }
        }
    }
}
