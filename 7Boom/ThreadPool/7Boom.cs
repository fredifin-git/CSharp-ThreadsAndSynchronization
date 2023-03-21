using System;


namespace ThreadPoolEx
{
    public class SevenBoomPool
    {
        static Pocket pocket = new Pocket();
        //static readonly object lockObj = new object();
        public static void SevenBoomPoolMethod()
        {
            ThreadPool.SetMaxThreads(4, 1);
            string str = "Hello!";
            
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {SBoom(obj); }), new Pocket());
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {SBoom(obj); }), new Pocket());
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {SBoom(obj); }), new Pocket());
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {SBoom(obj); }), new Pocket());
            //Console.WriteLine(pocket.variable);
        }

        public static void SBoom(object obj)
        {
            Pocket pocket = obj as Pocket;
            while (pocket.variable < 200)
            {
                //Interlocked.Increment(ref variable);
                lock (pocket)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is incrementing the variable.");
                    if (pocket.variable < 200)
                    {
                        pocket.variable++;                        
                        if (pocket.variable % 7 == 0 || pocket.variable.ToString().Contains("7"))
                        {
                            Console.WriteLine("Boom");
                        }
                        else
                        {
                            Console.WriteLine(pocket.variable);
                        }
                    }

                    //Thread.Sleep(500);
                }
            }

        }

        public class Pocket
        {
            public int variable = 0;
        }
    }
}
