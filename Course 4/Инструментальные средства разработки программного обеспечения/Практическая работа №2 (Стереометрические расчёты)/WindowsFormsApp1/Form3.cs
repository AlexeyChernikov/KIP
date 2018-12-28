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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R, V, So, Sb, Sob, H;
            try
            {
                if (textBox1.Text != "" && Single.Parse(textBox1.Text) > 0 
                    && textBox2.Text != "" && Single.Parse(textBox2.Text) > 0){
                R = Single.Parse(textBox1.Text);
                H = Single.Parse(textBox2.Text);
                So = Math.PI * Math.Pow(R, 2);
                textBox3.Text = Convert.ToString(Math.Round(So, 3));
                Sb = Math.PI * R * Math.Sqrt(Math.Pow(R, 2) + Math.Pow(H, 2));
                textBox4.Text = Convert.ToString(Math.Round(Sb, 3));
                Sob = So + Sb;
                textBox5.Text = Convert.ToString(Math.Round(Sob, 3));
                V = (So * H)/3;
                textBox6.Text = Convert.ToString(Math.Round(V, 3));
                }
                else{
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }
