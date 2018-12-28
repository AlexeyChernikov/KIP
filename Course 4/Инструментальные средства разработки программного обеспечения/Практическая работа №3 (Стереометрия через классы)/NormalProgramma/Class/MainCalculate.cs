using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalProgramma.Class
{
    class MainCalculate
    {

    }
    public class SharCLass
    {
        private double r { get; set; }
        public SharCLass(double r)
        {
            this.r = r;
        }
        public double Volume()
        {
            return Math.Round(4.0 / 3.0 * Math.PI * Math.Pow(r, 3), 3);
        }
        public double Squre()
        {
            return Math.Round(4 * Math.PI * r * r, 3);
        }
    }
    public class Konus
    {
        private double r { get; set; }
        private double h { get; set; }
        double l = 0;
        public Konus(double r, double h)
        {
            this.r = r;
            this.h = h;
            l = Math.Sqrt(r * r + h * h);
        }
        public double SqureOsnova()
        {
            return Math.Round(Math.PI * r * r, 3);
        }
        public double Volume()
        {
            return Math.Round(h * 1 / 3 * Math.PI * Math.Pow(r, 2), 3);
        }
        public double SqureMain()
        {
            return Math.Round(Math.PI * r * (r + l), 3);
        }
        public double SqureBock()
        {
            return Math.Round(Math.PI * r * l, 3);
        }
    }
    public class Barrel
    {
        private double r { get; set; }
        private double h { get; set; }
        public Barrel(double r, double h)
        {
            this.h = h;
            this.r = r;
        }
        public double Volume()
        {
            return Math.Round(h * Math.PI * Math.Round(r, 2), 3);
        }
        public double SqrBock()
        {
            return (Math.Round(2 * Math.PI * r * h, 3));
        }
        public double SqrMain()
        {
            return Math.Round(2 * Math.PI + 2 * Math.PI * Math.Round(r, 2), 3);
        }
    }
    public class Ykonus
    {
        private double r { get; set; }
        private double R { get; set; }
        private double h { get; set; }
        private double l { get; set; }
        public Ykonus()
        {

        }
        public Ykonus(double R)
        {
            this.R = R;
        }
        public Ykonus(double r, string sd)
        {
            this.r = r;
        }

        public Ykonus(double r, double R, double h)
        {
            this.r = r;
            this.R = R;
            this.h = h;
        }
        public Ykonus(double l, double r, double R, string ss)
        {
            this.r = r;
            this.R = R;
            this.l = l;
        }
        public double BigSOsn()
        {
            return Math.Round(Math.PI * R * R, 3);
        }
        public double SmalOsn()
        {
            return Math.Round(Math.PI * r * r, 3);
        }
        public double Volume()
        {
            return Math.Round(h * 1 / 3 * Math.PI * (Math.Pow(r, 2) + Math.Pow(R, 2) + r * R), 3);
        }
        public double SqrALL()
        {
            return Math.Round(Math.PI * l * (r + R) + Math.PI * Math.Pow(R, 2) + Math.PI * Math.Pow(r, 2), 3);
        }
        public double SqrBock()
        {
            return Math.Round(Math.PI * l * (r + R), 3);
        }
    }
}
