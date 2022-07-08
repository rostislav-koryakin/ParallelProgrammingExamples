using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgrammingExamples
{
    public class Data
    {

    }

    public class Ch7
    {

        static int counter = 0;
        public Data CachedData { get; set; }
        static Data GetDataFromDatabase()
        {
            if (counter == 0)
            {
                Console.WriteLine("Throwing exception");
                throw new Exception("Some Error has occured");
            }
            else
            {
                return new Data();
            }
        }

        public static void Main1()
        {
            //Console.WriteLine("Creating Lazy object");
            //Func<Data> dataFetchLogic = new Func<Data>(() => GetDataFromDatabase());
            //Lazy<Data> lazyDataWrapper = new Lazy<Data>(dataFetchLogic, System.Threading.LazyThreadSafetyMode.PublicationOnly);

            //Console.WriteLine("Lazy Object Created");
            //Console.WriteLine("Now we want to access data");
            //Data data = null;
            //try
            //{
            //    data = lazyDataWrapper.Value;
            //    Console.WriteLine("Data Fetched on Attempt 1");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Exception 1");
            //}
            //try
            //{
            //    counter++;
            //    data = lazyDataWrapper.Value;
            //    Console.WriteLine("Data Fetched on Attempt 2");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Exception 2");
            //    //     throw;
            //}
            //Console.WriteLine("Finishing up");

            //Console.ReadLine();


            //Parallel.For(0, 10, (i) => Initializer());

            //Console.ReadLine();
        }
    }

    //class SimpleLazy
    //{
    //    Data _cachedData;

    //    public _2SimpleLazy()
    //    {
    //        Console.WriteLine("Constructor called");
    //    }

    //    public Data GetOrCreate()
    //    {
    //        if (_cachedData == null)
    //        {
    //            Console.WriteLine("Initializing object");
    //            _cachedData = GetDataFromDatabase();
    //        }
    //        Console.WriteLine("Data returned from cache");
    //        return _cachedData;
    //    }

    //    private Data GetDataFromDatabase()
    //    {
    //        //Dummy Delay
    //        Thread.Sleep(5000);
    //        return new Data();
    //    }
    //}
}
