using Microsoft.Win32;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if (args[0] == "red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if(args[0] == "blue")
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                Console.Clear();
            }



            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey soft = currentUserKey.OpenSubKey("Software", true);
            //RegistryKey myApp = soft.CreateSubKey("MyApp");
            //myApp.SetValue("login", "admin");
            //myApp.SetValue("password", "12345666");
            //myApp.Close();  


            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey soft = currentUserKey.OpenSubKey("Software\\MyApp", true);
            //RegistryKey myApp = soft.CreateSubKey("Settings");
            //myApp.SetValue("Color", "Red");
            //soft.Close();
            //myApp.Close();


            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey soft = currentUserKey.OpenSubKey("Software\\MyApp\\Settings");
            //string color = soft.GetValue("Color").ToString();
            //if(color == "Red")
            //{
            //    Console.BackgroundColor = ConsoleColor.Red;
            //    Console.Clear();
            //}



            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey soft = currentUserKey.OpenSubKey("Software\\MyApp\\Settings", true);
            //soft.DeleteValue("Color");
            //soft.Close();


            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey soft = currentUserKey.OpenSubKey("Software\\MyApp", true);
            //soft.DeleteSubKey("Settings");
            //soft.Close();

            
        }
    }
}
