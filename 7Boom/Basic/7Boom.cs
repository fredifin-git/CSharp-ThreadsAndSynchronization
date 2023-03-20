using System;

namespace Basic
{
    public class SevenBoom
    {
        //static int variable = 0;
        static Pocket pocket = new Pocket();
        static readonly object lockObj = new object();
        public static void SevenBoomFourThreads()
        {
            Thread thread1 = new Thread(SBoom);
            Thread thread2 = new Thread(SBoom);
            Thread thread3 = new Thread(SBoom);
            Thread thread4 = new Thread(SBoom);

            thread1.Start(pocket);
            thread2.Start(pocket);
            thread3.Start(pocket);
            thread4.Start(pocket);

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            //Console.WriteLine(pocket.variable);
        }
        public static void SBoom(object obj)
        {
            Pocket pocket = obj as Pocket;
            while (pocket.variable < 200)
            {
                //Interlocked.Increment(ref variable);
                lock (lockObj)
                {
                    if (pocket.variable < 200)
                    {
                        pocket.variable++;
                        //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is incrementing the variable.");
                        //Console.WriteLine(variable);
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
