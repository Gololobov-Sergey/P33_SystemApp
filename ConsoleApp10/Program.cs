using Microsoft.Win32;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey soft = currentUserKey.OpenSubKey("Software", true);
            RegistryKey myApp = soft.CreateSubKey("MyApp");
            myApp.SetValue("login", "admin");
            myApp.SetValue("password", "12345");
            myApp.Close();  
        }
    }
}
