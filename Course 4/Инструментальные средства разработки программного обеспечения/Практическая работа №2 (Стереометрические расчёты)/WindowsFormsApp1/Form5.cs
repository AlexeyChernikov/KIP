using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R, H, V, Sb, So, Sp;
            try
            {
                if (textBox1.Text != "" && Single.Parse(textBox1.Text) > 0
                    && textBox2.Text != "" && Single.Parse(textBox2.Text) > 0)
                {
                    R = Single.Parse(textBox1.Text);
                    H = Single.Parse(textBox2.Text);
                    Sb = 2 * Math.PI * R * H;
                    textBox3.Text = Convert.ToString(Math.Round(Sb, 3));
                    So = Math.Pow(R,2) * H;
                    textBox3.Text = Convert.ToString(Math.Round(Sb, 3));
                    Sp = Sb + 2 * So;
                    textBox3.Text = Convert.ToString(Math.Round(Sb, 3));
                    V = Math.Pow(R, 2) * H * Math.PI;
                    textBox2.Text = Convert.ToString(Math.Round(V, 3));
                }
                else
                {
                    MessageBox.Show("Число должно быть больше 0!");
                    textBox1.Focus();
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Исправьте число!");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Исправьте число!");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Form1 = new Form1();
            Form1.Show();
        }
    }
}
