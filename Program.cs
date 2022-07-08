using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(square);

            //Scenario2AsyncReturningTaskExample();

            //Scenario3CallAsyncWithAwaitFromOutsideTryCatch();

            Scenario4CallAsyncWithoutAwaitFromOutsideTryCatch();
            Console.WriteLine("In Main Method After calling method");
            Console.ReadLine();
        }

        private static async void Scenario4CallAsyncWithoutAwaitFromOutsideTryCatch()
        {
            Task task = DoSomethingFaulty();
            Console.WriteLine("This should not execute");
        }

        static Func<int, Task<int>> square = async (x) => { return x * x; };

        private static async Task Scenario2AsyncReturningTaskExample()
        {
            try
            {
                Task task = DoSomethingFaulty();
                Console.WriteLine("This should not execute");
                task.ContinueWith((s) =>
                {
                    Console.WriteLine(s);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static async Task Scenario3CallAsyncWithAwaitFromOutsideTryCatch()
        {
            await DoSomethingFaulty();
            Console.WriteLine("This should not execute");           
        }

        private static Task DoSomethingFaulty()
        {
            Task.Delay(2000);
            throw new Exception("This is custom exception.");
        }
    }
}
