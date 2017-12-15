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
    public partial class Form2Output : Form
    {
        public Form2Output()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task2 t2 = this.Owner as Task2;

            if (t2 != null)
            {
                int num;
                if (numTr.Text == "") num = -1;
                else num = Convert.ToInt32(numTr.Text);
                Task2.Train train = new Task2.Train(dest.Text, num, date.Text);
                for (int i = 0; i < t2.train.Count; i++)
                    if (t2.train[i] == train)
                    {
                        MessageBox.Show(t2.train[i].dest + " " + t2.train[i].date + " " + t2.train[i].numTr);
                        return;
                    }
                MessageBox.Show("Not found");
            }
            this.Close();
        }
    }
}
