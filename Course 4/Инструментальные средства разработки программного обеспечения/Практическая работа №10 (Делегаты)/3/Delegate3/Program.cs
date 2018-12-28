using System;

namespace Delegate3
{
    class Program
    {
        private static void Hello() { Console.WriteLine("Hello"); }
        private static int Add(int x, int y) { return x + y; }

        delegate int Operation(int x, int y);
        delegate void Message();

        static void Main(string[] args)
        {
            Message mes = Hello;
            mes.Invoke();
            Operation op = Add;
            Console.WriteLine(op.Invoke(3, 2).ToString());
            Console.Read();
        }
    }

}
