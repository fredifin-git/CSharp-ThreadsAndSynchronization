using System;


namespace ThreadPoolEx
{
    public class SevenBoomPool
    {
        static Pocket pocket = new Pocket();
        static readonly object lockObj = new object();
        private const int maxThreadNum = 4;
        public static void SevenBoomPoolMethod()
        {
            ThreadPool.SetMaxThreads(4, 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SBoom), 1);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SBoom), 2);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SBoom), 3);
            ThreadPool.QueueUserWorkItem(new WaitCallback(SBoom), 4);
           
        }
        
        public static void SBoom(object threadNum)
        {
            //Pocket pocket = obj as Pocket;
            while (pocket.variable < 200)
            {
                //Interlocked.Increment(ref variable);
                lock (pocket)
                {
                    if (pocket.variable >= 200)
                    {
                        break;
                    }
                    if (pocket.variable % maxThreadNum + 1 == (int)threadNum)
                    {
                        pocket.variable++;
                        //Console.WriteLine($"Thread {Thread.CurrentThread.Name} is incrementing the variable.");
                        //Console.WriteLine($"Thread: {(int)threadNum}");
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
        public class Pocket
        {
            public int variable = 0;
        }
    }
}
