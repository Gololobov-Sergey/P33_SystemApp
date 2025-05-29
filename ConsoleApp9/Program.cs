using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Student 
    {
        public string Name { get; set; }

        public event EventHandler<string> Exam;

        public void SetExam(string date)
        {
            Exam?.Invoke(this, date);
        }
    }


    internal class Program
    {
        static async Task Main(string[] args)
        {

            // #1

            //await PrintAsync();
            //Console.WriteLine("Main ....");


            //void Print()
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Print Func");
            //}


            //async Task PrintAsync()
            //{
            //    Console.WriteLine("PrintAsync Start");
            //    await Task.Run(Print);
            //    Console.WriteLine("PrintAsync End");
            //}


            // #2

            //Task t1 = Print("SQL");
            //Task t2 = Print("C#");
            //Task t3 = Print("C++");

            //await t1;
            //await t2;
            //await t3;

            //async Task Print(string message)
            //{
            //    await Task.Delay(3000); 
            //    Console.WriteLine(message);
            //}


            //#3

            //Student student = new Student { Name = "Vasya" };
            //student.Exam += PrintExam;

            //student.SetExam("29.05.2025");

            //await Task.Delay(2000);

            //async void PrintExam(object obj, string date)
            //{
            //    await Task.Delay(1000); 
            //    Console.WriteLine($"Inform Exam for {(obj as Student)!.Name} on Email to {date}");
            //}


            //#4

            var a = FactAsync(15);
            var b = FactAsync(18);

            //
            //

            await a;
            
            Console.WriteLine($"Fa = {a.Result}");

            await b;
            Console.WriteLine($"Fb = {b.Result}");


            async Task<Int64> FactAsync(int n)
            {
                await Task.Delay(0);
                Int64 f = 1;
                for (int i = 1; i <= n; i++)
                {
                    f *= i;
                }
                return f;
            }
        }
    }
}
