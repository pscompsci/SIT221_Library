using System;
using SIT221_Library;
using System.Threading;

namespace Program
{
    class Program
    {
        const int Limit = 100000000;
        const int SleepTime = 60 * 1000;

        static void Main(string[] args)
        {
            OrderedLinkedList<int> iList = new OrderedLinkedList<int>();
            OrderedLinkedList<string> sList = new OrderedLinkedList<string>();

            for(int i = Limit; i > 0; i--)
            {
                iList.Add(i);
                if (i % 100000 == 0)
                    System.Console.WriteLine(i.ToString());
            }
            System.Console.WriteLine("Current list size: " + iList.Count.ToString());

            Thread.Sleep(SleepTime);

            iList.Clear();
            System.Console.WriteLine("Current list size: " + iList.Count.ToString());
            System.Console.WriteLine("\nPress Any Key to Exit...");
            Console.ReadLine();
        }
    }
}
