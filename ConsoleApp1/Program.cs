using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //int res = Ext.MessageBox(IntPtr.Zero, "Hello, World!", "My Message Box", Ext.MB_OKCANCEL | Ext.MB_ICONINFORMATION);
            //Console.WriteLine(res);

            //string name = Console.ReadLine();
            //IntPtr hWnd = Ext.FindWindowByCaption(IntPtr.Zero, name);
            //if(hWnd == IntPtr.Zero)
            //{
            //    Console.WriteLine("Window not found");
            //}
            //else
            //{
            //    Console.WriteLine("Window found");
            //    // Show the window
            //    Ext.ShowWindow(hWnd, (int)ShowWindowCommands.Maximize); 
            //    Console.ReadLine();

            //    // Hide the window
            //    Ext.ShowWindow(hWnd, (int)ShowWindowCommands.Minimize); 
            //    Console.ReadLine();

            //    // Show the window
            //    Ext.ShowWindow(hWnd, (int)ShowWindowCommands.Restore);
            //    Console.ReadLine();

            //    // Hide the window
            //    Ext.ShowWindow(hWnd, (int)ShowWindowCommands.Hide);
            //    Console.ReadLine();

            //    // Show the window
            //    Ext.ShowWindow(hWnd, (int)ShowWindowCommands.Restore);
            //    Console.ReadLine();

            //    Thread.Sleep(1000);
            //}


            while (true)
            {
                IntPtr hWnd = Ext.FindWindowByCaption(IntPtr.Zero, "Калькулятор");
                if (hWnd != IntPtr.Zero)
                {
                    Ext.SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(3000);

            }

        }
    }
}
