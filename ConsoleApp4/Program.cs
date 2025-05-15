namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            t.Priority = ThreadPriority.Highest;

            Console.WriteLine(t.Name);
            Console.WriteLine(t.Priority);
            Console.WriteLine(t.IsAlive);
            Console.WriteLine(t.ManagedThreadId);
            Console.WriteLine(Thread.GetDomain());
        }
    }
}
