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
    public partial class Task3Choose : Form
    {
        public Task3Choose()
        {
            InitializeComponent();
        }

        private void Task3Choose_Load(object sender, EventArgs e)
        {
            string[] buf = { "Зеленый", "Красный", "Синий" };
            for (int i = 0; i < buf.Length; i++)
                listBox1.Items.Add(buf[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task3 t3 = this.Owner as Task3;
            if (t3 != null)
            {
                //Line or bar
                if (radioButton1.Checked)
                {
                    t3.lineToolStripMenuItem.Enabled = true;
                    t3.barToolStripMenuItem.Enabled = false;
                }
                else
                {
                    t3.lineToolStripMenuItem.Enabled = false;
                    t3.barToolStripMenuItem.Enabled = true;
                }
            }
            t3.inf = listBox1.SelectedIndex;
            this.Close();
        }
    }
}
