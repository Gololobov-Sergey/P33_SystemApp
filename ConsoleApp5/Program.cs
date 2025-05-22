namespace ConsoleApp5
{
    internal class Program
    {
        static Mutex mutex = new Mutex();   

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            Console.WriteLine("Start threads");
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Calculate);
                threads[i].Name = $"Thread #{i + 1}";
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Result X = {SharedResource.X}");
            Console.WriteLine($"Result Y = {SharedResource.Y}");

            Console.WriteLine("Press any key...");
            Console.ReadLine();
        }

        static object objLocker = new object();

        static void Calculate()
        {
            mutex.WaitOne();
            Console.WriteLine($"Start thread - {Thread.CurrentThread.Name}");
            for (int i = 0; i < 1000000; i++)
            {
                // InterLocked

                //Interlocked.Increment(ref SharedResource.X);
                //if (SharedResource.X % 4 == 0)
                //{
                //    Interlocked.Increment(ref SharedResource.Y);
                //}


                // lock

                //lock (objLocker)
                //{
                //    SharedResource.X++;
                //    if (SharedResource.X % 4 == 0)
                //    {
                //        SharedResource.Y++;
                //    }
                //}


                //Monitor

                //Monitor.Enter(objLocker);
                //SharedResource.X++;
                //if (SharedResource.X % 4 == 0)
                //{
                //    SharedResource.Y++;
                //}

                //Monitor.Exit(objLocker);    



                //Mutex

                SharedResource.X++;
                if (SharedResource.X % 4 == 0)
                {
                    SharedResource.Y++;
                }

               
            }
            mutex.ReleaseMutex();
        }
    }




    static public class SharedResource
    {
        public static int X = 0;
        public static int Y = 0;
    }
}
