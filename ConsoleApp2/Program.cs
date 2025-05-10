using System;
using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Process p = Process.Start("calc.exe");

            //Console.WriteLine(p.ProcessName);
            //Console.WriteLine(p.MachineName);
            //Console.WriteLine(p.MainModule);
            //Console.WriteLine(p.Handle);
            //Console.WriteLine(p.Id);

            //Thread.Sleep(3000);

            //Process[] pp = Process.GetProcessesByName(p.ProcessName);
            //foreach (var item in pp)
            //{
            //    if(item.MainWindowHandle == IntPtr.Zero)
            //    {
            //        item.Kill();
            //    }
            //}


            Process.Start("calc.exe");

            Thread.Sleep(3000);

            var processes = Process.GetProcessesByName("CalculatorApp");
            foreach (var process in processes)
            {
                Console.WriteLine($"   {process.ProcessName} (ID: {process.Id})");

                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    process.Kill();
                }
                else
                {
                    process.CloseMainWindow();
                    bool exited = process.WaitForExit(5000);
                    process.Kill();

                }
            }



            //ProcessStartInfo psi = new ProcessStartInfo();
            //psi.FileName = "c:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            //psi.Arguments = "www.rozetka.com.ua";

            //Process p = Process.Start(psi);

            //Thread.Sleep(5000);
            //p.Kill();



        }
    }
}
