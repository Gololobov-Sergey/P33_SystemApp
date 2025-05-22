namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Reader(i + 1);
            }

            Console.ReadLine(); 
        }
    }
}
