using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace ParallelProgrammingExamples
{
    public class Ch1
    {
        static void Main1(string[] args)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += SimulateServiceCall;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
            Console.WriteLine("To Cancel Worker Thread Press C.");
            while (backgroundWorker.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'C')
                {
                    backgroundWorker.CancelAsync();
                }
            }

            //Console.WriteLine("Start Execution!!!");
            //CreateThreadUsingThreadClassWithoutParametr2();
            //Console.WriteLine("Finish Execution");
        }

        private static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else
            {
                Console.WriteLine($"Result from service call is {e.Result}");
            }
        }

        private static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.ProgressPercentage}% completed");
        }

        private static void SimulateServiceCall(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var data = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                if (!worker.CancellationPending)
                {
                    data.Append(i);
                    worker.ReportProgress(i);
                    Thread.Sleep(100);
                    throw new Exception("Some Error has occured");
                }
                else
                {
                    worker.CancelAsync();
                }
            }
            e.Result = data;
        }


        //private static void PrintNumberNTimes(object times)
        //{
        //    var n = Convert.ToInt32(times);
        //    for (int i = 0; i < n; i++)
        //    {
        //        Console.Write(1);
        //    }
        //    Console.WriteLine();
        //}

        //private static void CreateThreadUsingThreadClassWithoutParametr()
        //{
        //    var thread = new Thread(new ThreadStart(PrintNumberNTimes));
        //    thread.Start();
        //}

        //private static void CreateThreadUsingThreadClassWithoutParametr2()
        //{
        //    var thread = new Thread(new ParameterizedThreadStart(PrintNumberNTimes));
        //    thread.Start(10);
        //}
    }
}
