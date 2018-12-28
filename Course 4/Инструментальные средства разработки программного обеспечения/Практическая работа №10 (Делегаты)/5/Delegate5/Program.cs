using System;

namespace Delegate5
{
    class Program
    {
        private static void Hello() { Console.WriteLine("Привет"); }

        private static void HowAreYou() { Console.WriteLine("Как дела?"); }

        delegate void Message();
        delegate string Messa(string x, string y);

        static void Main(string[] args)
        {
            Messa mess = (x, y) => String.Concat(x, y);
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2;
            mes3();
            Console.WriteLine("-------------------------");
            Console.WriteLine(mess("Хорошо, ", "спасибо"));
            Console.WriteLine("-------------------------");
            mes3 -= mes2;
            mes3();
            Console.Read();
        }

    }
}


