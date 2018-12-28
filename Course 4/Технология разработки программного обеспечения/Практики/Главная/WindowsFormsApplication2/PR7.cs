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
    public partial class PR7 : Form
    {

        private int _centr_x = 470 / 2;
        private int _centr_y = 435 / 2;
        private int _hypotenuse = 0;
        private int _leftPointx = 0;
        private int _leftPointy = 0;

        public PR7()
        {
            InitializeComponent();
        }

        private void MyDraw(Graphics g, int N, int x, int y)
        {

            if (N == 0)
                return;
            else
            {
                _hypotenuse = Convert.ToInt32(Math.Round(x * (Math.Pow(2, 1 / 2)) / 2, 0).ToString());
                _leftPointx = _centr_x - _hypotenuse;
                _leftPointy = _centr_y - _hypotenuse;
                g.DrawRectangle(new Pen(Brushes.Blue, 2), _leftPointx, _leftPointy, x, y);
                x += 50;
                y += 50;
                N--;
                MyDraw(g, N, x, y);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MyDraw(g, 7, 50, 50);
        }

    }
}
