using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Ext
    {
        [DllImport("user32.dll")]
        static public extern SendOrPostCallback SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);



        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        static public extern IntPtr FindWindowByCaption(IntPtr hWnd, string WindowName);
    }
}
