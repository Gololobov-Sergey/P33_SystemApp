//using Student;

using System.Reflection;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student.Student st = new Student.Student { LastName = "Pupkin", FirstName = "Vasya", BirthDay = new DateTime(2000, 02, 22) };
            //st.Info();


            Assembly assembly = Assembly.LoadFrom("ClassLibrary.dll");
            Module? module = assembly.GetModule("ClassLibrary.dll");
            List<string> types = new List<string>();
            foreach (Type type in module!.GetTypes())
            {
                types.Add(type.FullName);
            }

            int indType = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, types.ToArray());

            Type? selectedType = module.GetType(types[indType]);

            //Console.WriteLine(selectedType.IsEnum);

            foreach (var field in selectedType.GetEnumValues())
            {
                Console.WriteLine(field);
            }

            var parameters = selectedType!.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            List<string> listParams = new List<string>();

            foreach (var param in parameters)
            {
                listParams.Add(param.Name + " - " + param.PropertyType);
            }

            listParams.Insert(0, "Exit");

            object[] propValues = new object[parameters.Count];

            while (true)
            {
                int indParam = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, listParams.ToArray());
                if (indParam == 0)
                    break;

                Type? paramType = parameters[indParam - 1].PropertyType;

                if (paramType == typeof(string))
                {
                    Console.WriteLine("Enter string value");
                    propValues[indParam - 1] = Console.ReadLine();
                }
                else if (paramType == typeof(int))
                {
                    Console.WriteLine("Enter int value");
                    propValues[indParam - 1] = Convert.ToInt32(Console.ReadLine());
                }
                else if (paramType == typeof(DateTime))
                {
                    Console.WriteLine("Enter DateTime value");
                    propValues[indParam - 1] = Convert.ToDateTime(Console.ReadLine());
                }
            }

            object? instance = Activator.CreateInstance(selectedType, propValues);

            List<string> listMethods = new List<string>();
            foreach (var method in selectedType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                listMethods.Add(method.Name);
            }

            int indMethod = ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, listMethods.ToArray());

            selectedType.GetMethod(listMethods[indMethod])?.Invoke(instance, null);

            assembly = null;


        }
    }
}
