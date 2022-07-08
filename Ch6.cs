using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace ParallelProgrammingExamples
{
    public class Ch6
    {
        static ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

        private static void A()
        {
            var manualResetEvent = new ManualResetEventSlim(false);

            Task producerAndConsumerTask = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i <= 3; ++i)
                {
                    concurrentBag.Add(i);
                }
                //Allow second thread to add items
                manualResetEvent.Wait();

                while (concurrentBag.IsEmpty == false)
                {
                    int item;
                    if (concurrentBag.TryTake(out item))
                    {
                        Console.WriteLine($"Item is {item}");
                    }
                }
            });
        }
        private static void B()
        {
            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            Task producerTask1 = Task.Factory.StartNew(() => {
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(100);
                    concurrentDictionary.TryAdd(i, (i * i).ToString());
                }
            });
            Task producerTask2 = Task.Factory.StartNew(() => {
                for (int i = 10; i < 25; i++)
                {
                    Thread.Sleep(100);
                    concurrentDictionary.TryAdd(i, (i * i).ToString());
                }
            });
            Task producerTask3 = Task.Factory.StartNew(() => {
                for (int i = 15; i < 20; i++)
                {
                    Thread.Sleep(100);
                    concurrentDictionary.AddOrUpdate(i, (i * i).ToString(), (key, value) => (key * key).ToString());
                }
            });

            Task.WaitAll(producerTask1, producerTask2);

            Console.WriteLine($"Keys are {string.Join(", ", concurrentDictionary.Keys.Select(c => c.ToString()).ToArray())} ");
        }
    }
}
