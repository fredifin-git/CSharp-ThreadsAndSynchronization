using System;

namespace ParallelPrinting
{
    public class Helper
    {
        public static void PrintNumTimes(int iter_nun, char letter)
        {
            for (int i = 0; i < iter_nun; i++)
            {
                Console.Write(letter);
            }

            //Thread.CurrentThread.Abort();
        }
    }
}

