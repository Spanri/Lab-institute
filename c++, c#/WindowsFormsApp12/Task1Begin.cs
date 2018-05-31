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
    public partial class Task1Begin : Form
    {
        public Task1Begin()
        {
            InitializeComponent();
        }

        private void str_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private int obrat(List<int> norm)
        {
            int[] s = new int[norm.Count];
            for (int i = norm.Count - 1; i >= 0; i--)
            {
                s[norm.Count - 1 - i] = norm[i];
            }
            return Convert.ToInt32(string.Join<int>("", s));
        }

        private int perevod2(int a)
        {
            int b = 0;
            List<int> s = new List<int>();
            while (a > 0)
            {
                b = a % 2;
                a = a / 2;
                s.Add(b);
            }
            return obrat(s);
        }

        private int perevod8(int a)
        {
            int b = 0;
            List<int> s = new List<int>();
            while (a > 0)
            {
                b = a % 8;
                a = a / 8;
                s.Add(b);
            }
            return obrat(s);
        }

        private string perevod16(int a)
        {
            int b = 0;
            List<string> s = new List<string>();
            while (a > 0)
            {
                b = a % 16;
                a = a / 16;
                if(b == 10) s.Add("A");
                else if (b == 11) s.Add("B");
                else if (b == 12) s.Add("C");
                else if (b == 13) s.Add("D");
                else if (b == 14) s.Add("E");
                else if (b == 15) s.Add("F");
                else s.Add(Convert.ToString(b));
            }
            string s2 = "";
            for (int i = 0; i < s.Count; i++)
                s2 = s2 + s[i];
            char[] arr = s2.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) res.Text = Convert.ToString(perevod2(Convert.ToInt32(str.Text)));
            else if (radioButton2.Checked) res.Text = Convert.ToString(perevod8(Convert.ToInt32(str.Text)));
            else if (radioButton3.Checked) res.Text = Convert.ToString(perevod16(Convert.ToInt32(str.Text)));
            //res.Text = str.Text;
        }

    }
}
