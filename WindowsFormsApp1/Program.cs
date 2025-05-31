using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_KEYDOWN = 0x0100;

        private static int count = 10;
        
        private static HookProc proc = HookCallback;
        private static IntPtr hook = IntPtr.Zero;

        [STAThread]
        public static void Main()
        {
            hook = SetHook(proc);
            Application.Run();
            UnhookWindowsHookEx(hook);
        }
        private static IntPtr SetHook(HookProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (wParam == (IntPtr)WM_KEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Keys.Escape)
                {
                    count--;    
                }

                
                
                if(count > 0)
                {
                    return (IntPtr)1;
                }

                //string sym = ((Keys)(vkCode)).ToString();
                //Stream stream = File.Open("log.txt", FileMode.Append);
                //byte[] buffer = Encoding.Unicode.GetBytes(sym);
                //stream.Write(buffer, 0, buffer.Length);
                //stream.Close();

                //if (((Keys)vkCode == Keys.LWin) || ((Keys)vkCode == Keys.RWin))
                //{
                //    Console.WriteLine("{0} blocked!", (Keys)vkCode);
                //    return (IntPtr)1;
                //}

                
            }
            return CallNextHookEx(hook, nCode, wParam, lParam);

            //if ((nCode >= 0) && (wParam == (IntPtr)WM_MOUSEMOVE))
            //{
            //    int X = Marshal.ReadInt32(lParam);
            //    if (X < 400) return (IntPtr)1;
            //}
            //return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
