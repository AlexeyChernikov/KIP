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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R1, R2, V, S1, S2, Sb, H;
            try
            {
                if (textBox1.Text != "" && Single.Parse(textBox1.Text) > 0
                    && textBox2.Text != "" && Single.Parse(textBox2.Text) > 0
                    && textBox3.Text != "" && Single.Parse(textBox3.Text) > 0)
                {
                    R1 = Single.Parse(textBox1.Text);
                    R2 = Single.Parse(textBox2.Text);
                    H = Single.Parse(textBox3.Text);
                    S1 = Math.PI * Math.Pow(R1, 2);
                    textBox4.Text = Convert.ToString(Math.Round(S1, 3));
                    S2 = Math.PI * Math.Pow(R2, 2);
                    textBox5.Text = Convert.ToString(Math.Round(S2, 3));
                    Sb = Math.PI * (R1 + R2) * Math.Sqrt(Math.Pow(H, 2) + Math.Pow(R1 - R2, 2));
                    textBox6.Text = Convert.ToString(Math.Round(Sb, 3));
                    V = Math.PI * H * (Math.Pow(R2, 2) + R1 * R2 + Math.Pow(R1, 2)) / 3;
                    textBox7.Text = Convert.ToString(Math.Round(V, 3));
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
                textBox2.Text = "";
                textBox1.Focus();
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Исправьте число!");
                textBox1.Text = "";
                textBox2.Text = "";
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

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
