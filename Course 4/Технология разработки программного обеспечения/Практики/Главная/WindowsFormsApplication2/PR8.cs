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
    public partial class PR8 : Form
    {
        public PR8()
        {
            InitializeComponent();
        }

        private void PR8_Load(object sender, EventArgs e)
        {
            double Xmin = 5.3;
            double Xmax = 10.3;
            double Step = 0.25;
            double a = 1.35, b = -6.25;
            int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = Xmin + Step * i;
                y1[i] = a * Math.Pow(x[i], 3) + Math.Pow(Math.Cos(Math.Pow(x[i], 3) - b), 2);
            }
            // Настраиваем оси графика 
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;
            // Определяем шаг сетки 
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
            // Добавляем вычисленные значения в графики 
            chart1.Series[0].Points.DataBindXY(x, y1);
        }
    }
}
