using System;
using ParallelPrinting;
public class Solution
{
    public static void Assignment1Part1()
    {
        ThreadStart threadStart = () => Helper.PrintNumTimes(100, 'Y');
        Thread thread = new Thread(threadStart);
        thread.Start();
        Helper.PrintNumTimes(100, 'X');
    }

    public static void Assignment1Part2()
    {
        ThreadStart threadStart = () => Helper.PrintNumTimes(100, 'Y');
        Thread thread = new Thread(threadStart)
        {
            IsBackground = true
        };
        thread.Start();
        Helper.PrintNumTimes(100, 'X');
    }

    public static void Assignment2(string str)
    {
        ParameterizedThreadStart parameterizedThread = (str) =>
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(str);
            }
        };
        Thread thread = new Thread(parameterizedThread);
        thread.Start(str);
        for (int i = 0; i < 5; i++)
        {
            Console.Write(str);
        }
    }

    public static void Assignment3Part1(string str)
    {
        ThreadPool.SetMaxThreads(2, 2);

        ThreadPool.QueueUserWorkItem(new WaitCallback((str) => { Console.WriteLine(str); }), str);
        ThreadPool.QueueUserWorkItem(new WaitCallback((str) => { Console.WriteLine(str); }), str);
    }


    public static void Assignment3Part2(string str)
    {
        //Console.Write(Environment.ProcessorCount);
        int logicCores = Environment.ProcessorCount;
        const int maxThreadsPerCore = 25;
        ThreadPool.SetMaxThreads(maxThreadsPerCore * logicCores, maxThreadsPerCore * logicCores);
        for (int i = 0; i < maxThreadsPerCore; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((str) => { Console.WriteLine(str); }), str);
        }
    }

    public static void Assignment4Part1()
    {
        ThreadStart threadStart = () =>
        {
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(i);
            }

            Thread.Sleep(2000);
        };
        Thread thread = new Thread(threadStart);
        thread.Start();
        thread.Join();
        Console.WriteLine("Thread ended ");
    }

    public static void Assignment4Part2()
    {
        /*
        * Write code here
        */
    }
}
