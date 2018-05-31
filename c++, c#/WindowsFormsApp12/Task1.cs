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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //окно с информацией о разработчике
            Task1About about = new Task1About();
            about.ShowDialog();
        }

        private void beginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //окно begin
            Task1Begin begin = new Task1Begin();
            begin.ShowDialog();
        }

        private void Task1_Load(object sender, EventArgs e)
        {

        }
    }
}
