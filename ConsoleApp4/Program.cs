namespace ConsoleApp4
{
    internal class Program
    {
        static void ThreadMethod()
        {
            Console.WriteLine("\t\t\tThread started");
            Thread.Sleep(2000);
            Console.WriteLine("\t\t\tThread finished");
        }

        static void ThreadMethod(object message)
        {
            Console.WriteLine("\t\t\tThread started");
            Console.WriteLine(message);
            Thread.Sleep(2000);
            Console.WriteLine("\t\t\tThread finished");
        }

        static void MultN(object n)
        {
            if (n is int)
            {
                int number = (int)n;    
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                Console.WriteLine(number * number);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished");
            }
        }

        public record Person(string FirstName, string LastName);

        static void PrintPerson(object person)
        {
            if (person is Person p)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
                Console.WriteLine($"{p.FirstName} {p.LastName}");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished");
            }
        }

        public record Range(int start, int end);
        public record Rec(List<int> start, int end);


        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");

            //Thread t = Thread.CurrentThread;
            //t.Priority = ThreadPriority.Highest;

            //Console.WriteLine(t.Name);
            //Console.WriteLine(t.Priority);
            //Console.WriteLine(t.IsAlive);
            //Console.WriteLine(t.ManagedThreadId);
            //Console.WriteLine(Thread.GetDomain());

           //ThreadMethod();

            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            //Thread t1 = new Thread(ThreadMethod);
            //t1.Start();

            //Thread t2 = new Thread(()=> Console.WriteLine("Thread 3"));
            //t2.Start();


            //Thread t1 = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //t1.Start("Hello from thread 1");

            //Thread t2 = new Thread(new ParameterizedThreadStart(MultN));
            //t2.Start(5);


            //Person p1 = new Person("John", "Doe");

            //Thread t3 = new Thread(new ParameterizedThreadStart(PrintPerson));
            //t3.Start(p1);

            //Range range = new Range(1, 10);
            //Thread t4 = new Thread(new ParameterizedThreadStart((object r) =>
            //{
            //    if (r is Range rg)
            //    {
            //        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
            //        for (int i = rg.start; i <= rg.end; i++)
            //        {
            //            Console.WriteLine(i);
            //            Thread.Sleep(100);
            //        }
            //        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished");
            //    }
            //}));
            //t4.Start(range);


            //List<int> list = [];



            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(random.Next(1, 100));  
            //}

            t.Join();
            Console.WriteLine("End Main");
        }
    }
}
