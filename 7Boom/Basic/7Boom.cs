using System;
using System.Threading;

namespace Basic
{
    public class SevenBoom
    {
        static Pocket pocket = new Pocket();
        static readonly object lockObj = new object();
        private const int maxThreadNum = 4;
        public static void SevenBoomFourThreads()
        {
            Thread[] threads = new Thread[maxThreadNum];

            
            for (int i = 1; i <= maxThreadNum; i++)
            {
                Thread thread = new Thread(SBoom);
                thread.Name = i.ToString();
                threads[i - 1] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start(pocket);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            //Console.ReadLine();
        }

        public static void SBoom(object obj)
        {
            Pocket pocket = obj as Pocket;

            while (pocket.variable < 200)
            {
                lock (lockObj)
                {
                    if (pocket.variable < 200)
                    {
                        int threadNum = Int32.Parse(Thread.CurrentThread.Name);
                        if (pocket.variable % maxThreadNum + 1 == threadNum)
                        {
                            pocket.variable++;
                            //Console.WriteLine($"Thread {Thread.CurrentThread.Name} is incrementing the variable.");
                            if (pocket.variable % 7 == 0 || pocket.variable.ToString().Contains("7"))
                            {
                                Console.WriteLine("Boom");
                            }
                            else
                            {
                                Console.WriteLine(pocket.variable);
                            }
                        }
                    }
                }
            }
        }

        public class Pocket
        {
            public int variable = 0;
        }
    }
}
