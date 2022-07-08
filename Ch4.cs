using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParallelProgrammingExamples
{
    public class Ch4
    {


        private static void A()
        {
            var range = ParallelEnumerable.Range(1, 20);

            var query = range.Select(i => i / (i - 10)).WithDegreeOfParallelism(2);

            try
            {
                query.ForAll(i => Console.WriteLine(i));
            }
            catch (AggregateException aEx)
            {
                foreach (var ex in aEx.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                    if (ex is DivideByZeroException)
                        Console.WriteLine("Attempt to divide by zero. Query stopped");
                }
            }
        }
    }
}
