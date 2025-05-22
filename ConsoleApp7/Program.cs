namespace ConsoleApp7
{
    internal class Program
    {
        static Mutex mutex = new Mutex();
        //static Semaphore mutex = new Semaphore(2, 2);

        static void Main(string[] args)
        {


            Thread t1 =  new Thread(F1);
            t1.Start(); 
            Thread t2 = new Thread(F2);
            t2.Start();

            t1.Join();
            t2.Join();

            for (int i = 0; i < args.Length; i++)
            {

            }

            
            
        }

        static void F1()
        {
            mutex.WaitOne();    
            for (int i = 1; i <= 20; i++)
            {
                Console.Write(i + " ");
                //Thread.Sleep(50);
            }
            Console.WriteLine();
            mutex.ReleaseMutex();
        }

        static void F2()
        {
            mutex.WaitOne();
            for (int i = 10; i> 0; i--)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            mutex.ReleaseMutex();
        }
    }
}
