using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 123;

            Task<int> t = Task.Factory.StartNew<int>(() =>
            {
                Thread.Sleep(2000);
                x += 4;
                return x;
            });

            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
