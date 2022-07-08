using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingExamples
{
    internal class Ch2
    {

        static void Main1(string[] args)
        {
            //var task = new Task(() => PrintNumber10Times());
            //task.Start();

            //var task2 = new Task(new Action(() => PrintNumber10Times()));
            //task2.Start();

            //var task3 = new Task(delegate
            //{
            //    PrintNumber10Times();
            //});
            //task3.Start();



            //Task.Factory.StartNew(() => PrintNumber10Times());

            //Task.Factory.StartNew(new Action(() => PrintNumber10Times()));

            //Task.Factory.StartNew(delegate
            //{
            //    PrintNumber10Times();
            //});



            //Task.Run(() => PrintNumber10Times());

            //Task.Run(new Action(() => PrintNumber10Times()));

            //Task.Run(delegate
            //{
            //    PrintNumber10Times();
            //});


            //Console.WriteLine("Каков результат 20/2. Мы покажем результат через 2 секунды");
            //await Task.Delay(100000);
            //Console.WriteLine("После задержки в 2 секунды");
            //Console.WriteLine("Выход составляет 10");

            //Delay();

            //var t = Task.Run(async delegate
            //{
            //    await Task.Delay(5000);
            //    return 42;
            //});
            //t.Wait();
            //Console.WriteLine("Task t Status: {0}, Result: {1}",
            //                  t.Status, t.Result);


            //Console.WriteLine(Sum(42).ToString());
            //StaticTaskFromResult();



            Console.ReadKey();
        }








        private static void GetResultFromTasks()
        {
            var sumTaskViaTaskOfInt = new Task<int>(() => Sum(5));
            sumTaskViaTaskOfInt.Start();
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskOfInt.Result}");

            var sumTaskViaFactory = Task.Factory.StartNew<int>(() => Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaFactory.Result}");

            var sumTaskViaTaskRun = Task.Run<int>(() => Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskRun.Result}");

            var sumTaskViaTaskResult = Task.FromResult<int>(Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskResult.Result}");
        }

        private static void StaticTaskFromResult()
        {
            Task<int> resultTask = Task.FromResult<int>(Sum(10));
            Console.WriteLine(resultTask.Result);
        }

        private static int Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }

        private static void PrintNumber10Times()
        {
            var n = 10;
            for (int i = 0; i < n; i++)
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }

        private async static void Delay()
        {
            Console.WriteLine("Каков результат 20/2. Мы покажем результат через 2 секунды");
            await Task.Delay(3000);
            Console.WriteLine("После задержки в 2 секунды");
            Console.WriteLine("Выход составляет 10");
        }
    }
}
