using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingExamples
{
    public class Ch3
    {
        static void Main1(string[] args)
        {
            //try
            //{
            //    Parallel.Invoke(() => Console.WriteLine("Action 1"),
            //        new Action(() => Console.WriteLine("Action 2")));
            //}
            //catch (AggregateException exs)
            //{
            //    foreach (var ex in exs.InnerExceptions)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            //Console.WriteLine("Unblocked");
            B();
            Console.ReadLine();
        }

        private static void B()
        {
            var source = Enumerable.Range(1, 100).ToList();

            var orderablePartitioner = Partitioner.Create(1, 100);

            Parallel.ForEach(orderablePartitioner, (range, state) =>
            {
                var startIndex = range.Item1;
                var endIndex = range.Item2;
                Console.WriteLine($"Range execution finished on task {Task.CurrentId} with range {startIndex}-{endIndex}");
            });
        }

        private static string A()
        {
            var totalFiles = 0;
            var files = Directory.GetFiles("C:\\");

            Parallel.For(0, files.Length, (i) =>
            {
                var fileInfo = new FileInfo(files[i]);

                if (fileInfo.CreationTime.Day == DateTime.Now.Day)
                    Interlocked.Increment(ref totalFiles);
            });

            return $"Total number of files in C: drive are {files.Count()} and {totalFiles} files were  created today";
        }
    }
}
