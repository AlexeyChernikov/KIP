using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PR5 Pr = new PR5();
            Pr.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PR6 Pr = new PR6();
            Pr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PR1 Pr = new PR1();
            Pr.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PR4 Pr = new PR4();
            Pr.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           
           int h = DateTime.Now.Hour;
           int m = DateTime.Now.Minute;
           int s = DateTime.Now.Second;

           string time = "";

           if (h < 10)
           {
               time += "0" + h;
           }
           else
           {
               time += h;
           }

           time += ":";

           if (m < 10)
           {
               time += "0" + m;
           }
           else
           {
               time += m;
           }

           time += ":";

           if (s < 10)
           {
               time += "0" + s;
           }
           else
           {
               time += s;
           }
           toolStripStatusLabel2.Text = "Время: " + time;

           string data = "";

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 10)
            {
                data += "0" + day;
            }
            else
            {
                data += day;
            }
            data += ".";
            if(month<10)
            {
                data += "0" + month;
            }
            else
            {
                data += month;
            }
            data += ".";
            data += year;
            toolStripStatusLabel1.Text = "Дата: " + data;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel2.BackColor = Color.White;
        }

        private void зелёныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel2.BackColor = Color.White;
        }

        private void жёлтыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel2.BackColor = Color.White;
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel2.BackColor = Color.White;
        }

        private void стандартныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            toolStripStatusLabel1.BackColor = Color.White;
            toolStripStatusLabel2.BackColor = Color.White;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(100, 100);
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(567, 514);
        }

        private void bigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 700);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PR3 Pr = new PR3();
            Pr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ничего
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PR7 Pr = new PR7();
            Pr.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PR8 Pr = new PR8();
            Pr.ShowDialog();
        }
    }
}
