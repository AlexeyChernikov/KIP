﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        Timer time = new Timer(); 
        public Form1() 
        { 
            InitializeComponent(); 
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            time.Interval = 250; 
            time.Tick += new EventHandler(IncreaseProgressBar); 
            time.Start(); 
        } 
        private void IncreaseProgressBar(object sender, EventArgs e) 
        { 
            progressBar1.Increment(1); 
            toolStripStatusLabel1.Text = progressBar1.Value.ToString() + "% Выполнено"; 
            if (progressBar1.Value == progressBar1.Maximum) 
            { 
                time.Stop();
                progressBar1.Value = 0; 
            }
        } 
        private void button2_Click(object sender, EventArgs e) 
        { 
            time.Stop(); 
        } 
        private void button3_Click(object sender, EventArgs e) 
        { 
            progressBar1.Value = 0; 
            toolStripStatusLabel1.Text = "0"; 
        } 
    } 
}
