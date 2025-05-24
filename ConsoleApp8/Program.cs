namespace ConsoleApp8
{
    internal class Program
    {


        static void Main(string[] args)
        {
            //Task task = new Task(()=>  { Console.WriteLine("Hello 1"); });
            //task.RunSynchronously();

            //Task task1 = Task.Run(()=> { Console.WriteLine("Hello 2"); }); 

            //Task task2 = Task.Factory.StartNew(() =>  Console.WriteLine("Hello 3") );

            //task.Wait();
            //task1.Wait();
            //task2.Wait();


            //Task task = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Task started");
            //    Task task1 = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Start Inner task");
            //        Thread.Sleep(2000);
            //        Console.WriteLine("End Inner task");
            //    }, TaskCreationOptions.AttachedToParent);
            //    //task1.Wait();
            //});
            //task.Wait();

            //Console.WriteLine("End main");



            //Task[] tasks = new Task[3]
            //{
            //    new Task(()=> Console.WriteLine("Hello 1")), 
            //    new Task(()=> Console.WriteLine("Hello 2")), 
            //    new Task(()=> Console.WriteLine("Hello 3")) 
            //};

            //foreach (var task in tasks)
            //{
            //    task.Start();   
            //}

            //Task.WaitAll(tasks);



            //int a = 5, b = 4;

            //Task<int> task = new Task<int>(() => Mult(a, b)); 
            //task.Start();

            //int res = task.Result;

            //Console.WriteLine(res);


            #region MyRegion

            #endregion

            //Task task1 = new Task(() => Console.WriteLine("Main Task"));

            //Task task2 = task1.ContinueWith(Print); 

            //task1.Start();

            //task2.Wait();

            //Console.WriteLine("End Main");


            //Task<int> task = new Task<int>(() => Mult(4, 6));
            //Task print = task.ContinueWith(task => PrintResult(task.Result));
            //task.Start();
            //print.Wait();

            //Console.WriteLine(DateTime.Today.ToShortDateString());

            //Task.Run(() => Clock());


            //Timer timer = new Timer(Clock, null, 0, 1000);
            //timer.Change(0, 1000);

            //Console.SetCursorPosition(0, 3);
            //string s = Console.ReadLine();

            int[] arr = new int[3] { 1, 2, 3 }; 

            Task<int> t = new Task<int>(() => Sum(arr));
            Task tp = t.ContinueWith(t => PrintResult(t.Result));   
            t.Start();

            tp.Wait();


            int Sum(int[] arr)
            {
                return arr.Sum();
            }



            void Clock(object obj)
            {
                (int l, int t) = Console.GetCursorPosition();
                Console.SetCursorPosition(80, 0);
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Console.SetCursorPosition(l, t);
                Thread.Sleep(1000);
            }

            void Print(Task t, int val)
            {
                Console.WriteLine("Start Print task");
                Thread.Sleep(2000);
                Console.WriteLine("End Print task");
            }

            int Mult(int a, int b)
            {
                //Thread.Sleep(3000);
                return a * b;
            }

            void PrintResult(int param)
            {
                Console.WriteLine($"Mult = {param}");
            }

        }
    }
}
