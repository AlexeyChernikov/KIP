using System;

namespace Delegate6
{
    using System;
    using My;

    class Program
    {
        public static void Main(string[] args)
        {
            string S = "#######################";
            First Ob = new First(S);

            Del Od = new Del(Ob.fun1);
            Od();

            Od = new Del(Ob.Report);
            Od();

            S = "****************************";

            First Ob1 = new First(S);


            Od = new Del(Ob1.fun2);
            Od(); 

            Od = new Del(Ob1.Report);
            Od();

            Od = new Del(Ob1.fun3);
            Od();

            Od = new Del(Ob1.Report);
            Od();

            Del OdS = new Del(First.funStatic);
            OdS();

            Console.WriteLine();

            S = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            Second ObSecond = new Second(S);

            Del OdSecond = new Del(ObSecond.fun5);
            OdSecond();

            OdSecond = new Del(ObSecond.Report);
            OdSecond();

            OdSecond = new Del(ObSecond.fun1);
            OdSecond();

            OdSecond = new Del(ObSecond.Report);
            OdSecond();

            Console.ReadLine();
        }
    }


}

namespace My
{
    public delegate void Del();
    class First
    {
        protected string str = "";

        public First(string s) { this.str = s; }

        public void fun1()
        {
            Console.Write("работает fun1\n"); str += '1';
        }
        public void fun2()
        {
            Console.Write("работает fun2\n"); str += '2' + str;
        }
        public void fun3()
        {
            Console.Write("работает fun3\n"); str += '3';
        }
        public static void funStatic()
        {
            Console.Write("работает статическая функция\n");
        }
        public void Report()
        {
            Console.Write("работает функция Report. Итоговое значение str = " + str + "\n");
        }

    }

    class Second : First
    {
        public Second(string str) : base(str) { }
        public void fun5()
        {
            Console.Write("работает fun5 класса Second\n"); str += '5';
        }
    }
}