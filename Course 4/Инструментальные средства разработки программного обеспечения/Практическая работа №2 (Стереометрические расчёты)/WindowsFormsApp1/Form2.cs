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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double R, V, S;
            try
            {
                if (textBox1.Text != "" && Single.Parse(textBox1.Text) > 0){
                R = Single.Parse(textBox1.Text);
                V = (4 * Math.PI * Math.Pow(R, 3)) / 3;
                textBox2.Text = Convert.ToString(Math.Round(V, 3));
                S = 4 * Math.PI * Math.Pow(R, 2);
                textBox3.Text = Convert.ToString(Math.Round(S, 3));
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /*private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(308, 284);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }*/
    }
}
