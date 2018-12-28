using System;

namespace Delegate4
{
    class Program
    {
        private static void Show_Message(GetMessage _del) { _del.Invoke(); }

        private static void GoodMorning() { Console.WriteLine("Сейчас: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute); Console.WriteLine("Доброе утро!"); }

        private static void GoodEvening() { Console.WriteLine("Сейчас: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute); Console.WriteLine("Добрый вечер"); }

        delegate void GetMessage();

        static void Main(string[] args)
        {
            if (DateTime.Now.Hour < 12)
            {
                GetMessage mes = new GetMessage(GoodMorning);
                Show_Message(mes);
            }
            else
            {

                GetMessage mes = new GetMessage(GoodEvening);
                Show_Message(mes);
            }
            Console.ReadLine();
        }
    }

}
