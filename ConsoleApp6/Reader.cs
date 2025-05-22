using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Reader
    {
        static Semaphore semaphore = new Semaphore(2, 3);

        Thread thread;

        public Reader(int i)
        {
            thread = new Thread(Read);
            thread.IsBackground = true;
            thread.Name = $"Reader {i}";
            thread.Start();
        }

        void Read()
        {
            semaphore.WaitOne();
            Console.WriteLine($"{thread.Name} enter library");
            Console.WriteLine($"{thread.Name} read book");
            Thread.Sleep( 1000 );
            Console.WriteLine($"{thread.Name} exit library");
            semaphore.Release();
            Thread.Sleep( 1000 );
        }
    }
}
