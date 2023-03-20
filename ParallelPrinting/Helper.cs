using System;

namespace ParallelPrinting
{
    public class Helper
    {
        public static void PrintNumTimes(int iter_num, char letter)
        {
            for (int i = 0; i < iter_num; i++)
            {
                Console.Write(letter);
            }
            //Thread.CurrentThread.Abort();
        }

        public static void Foo()
        {
            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}

