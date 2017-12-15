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
    public partial class Task3 : Form
    {
        public int inf, k = 0;
        float[,] coord = new float[2, 200];

        public Task3()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("data.txt");
            string s = f.ReadLine();

            String[] xy = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string[] split;
            k = 0;

            try
            {
                for (int i = 0; i < xy.Length; i++)
                {
                    split = xy[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    coord[0, i] = Convert.ToSingle(split[0]);
                    coord[1, i] = Convert.ToSingle(split[1]);
                    k++;
                }
            }
            catch (FormatException er) { Console.WriteLine(er.Message); }

            f.Close();
        }

        private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task3Choose choose = new Task3Choose();
            choose.Owner = this;
            choose.ShowDialog();
        }

        private void line()
        {
            Pen Pen = new Pen(Color.Red, 1);

            if (inf == 0) Pen.Color = Color.Green;
            else if (inf == 1) Pen.Color = Color.Red;
            else if (inf == 2) Pen.Color = Color.Blue;
            else MessageBox.Show("Не выбран цвет, по умолчанию красный");
            
            for (int i = 1; i < k; i++)
            {
                float w = pictureBox1.Width;
                float h = pictureBox1.Height;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(Pen, w/2 + coord[0, i - 1], h/2 - coord[1, i - 1], w/2 + coord[0, i], h/2 - coord[1, i]);
            }
        }

        private void bar()
        {
            pictureBox1.Update();
            Pen Pen = new Pen(Color.Red, 1);

            if (inf == 0) Pen.Color = Color.Green;
            else if (inf == 1) Pen.Color = Color.Red;
            else if (inf == 2) Pen.Color = Color.Blue;
            else MessageBox.Show("Не выбран цвет, по умолчанию красный");

            for (int i = 0; i < k; i++)
            {
                float w = pictureBox1.Width;
                float h = pictureBox1.Height;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(Pen, w / 2 + coord[0, i], h / 2 - coord[1, i], w / 2 + coord[0, i], h / 2);
            }
        }

        private void axes()
        {
            String color = "Red";
            if (inf == 0) color = "Green";
            else if (inf == 1) color = "Red";
            else if (inf == 2) color = "Blue";
            if (lineToolStripMenuItem.Enabled) label1.Text = color + " line";
            else label1.Text = color + " bar";

            float w = pictureBox1.Width;
            float h = pictureBox1.Height;
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(Pens.Black, w / 2, 0, w / 2, h);
            g.DrawLine(Pens.Black, 0, h / 2, w, h / 2);

            Font f = new Font("Arial", 9);
            SolidBrush b = new SolidBrush(Color.Black);
            StringFormat strf = new StringFormat();
            StringFormat strf2 = new StringFormat();
            strf.FormatFlags = StringFormatFlags.DirectionVertical;
            strf2.Alignment = StringAlignment.Far;
            for (int i = 0; i < 500; i+=20)
            {
                PointF p1 = new PointF(w / 2 + i, h / 2);
                PointF p2 = new PointF(w / 2, h / 2 - i);
                PointF p3 = new PointF(w / 2 - i, h / 2);
                PointF p4 = new PointF(w / 2, h / 2 + i);
                g.DrawString(Convert.ToString(i), f, b, p1,strf);
                g.DrawString(Convert.ToString(i), f, b, p2, strf2);
                g.DrawString(Convert.ToString(i), f, b, p3,strf);
                g.DrawString(Convert.ToString(i), f, b, p4, strf2);
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            axes();
            line();
        }

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            axes();
            bar();
        }

        private void Task3_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void Task3_Resize(object sender, EventArgs e)
        {
            pictureBox1.Update();
            if (lineToolStripMenuItem.Enabled) { axes(); line(); }
            else { axes(); bar(); }
        }
    }
}
