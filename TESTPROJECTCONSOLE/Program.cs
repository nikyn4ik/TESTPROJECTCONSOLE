using System;
using System.IO;

namespace TESTPROJECTCONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! You wanna create [1], edit[2], delete[3] or see [4] notes?");
            var number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    Edit();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    See();
                    break;
                default:
                    Console.WriteLine("Not found :( ");
                    break;
            }
        }
        static void Create()
        {
            Console.WriteLine("You choice create. Let's started!");
            string Text;
            string Ask = null;
            Text = Console.ReadLine();
            Console.Write("Do you wanna save notes?");
            Ask = Console.ReadLine();
            if (Ask == "Yes")
            {
                File.WriteAllText("Create.txt", Text);
                Console.WriteLine("Saved!");
            }
            else
            {
                Console.WriteLine("You choiсe no. Goodbye!");
                Console.ReadKey();
            }
        }
        static void Edit()
        {
            Console.WriteLine("You choice edit. Choose the note you need!");
        }
        static void See()
        {
            Console.WriteLine("You choice see notes!");
            var place = new DirectoryInfo(@"C:\Users\nikab\source\repos\TESTPROJECTCONSOLE\TESTPROJECTCONSOLE\TEST");
            var Files = place.GetFiles();
            Console.WriteLine("Files are:");
            foreach (var fil in Files)
            {
                Console.WriteLine(fil.Name);
            }
        }
        static void Delete()
        {
            Console.WriteLine("You choice delete. Choose the note you need!");
            DirectoryInfo DI = new DirectoryInfo(@"C:\Users\nikab\source\repos\TESTPROJECTCONSOLE\TESTPROJECTCONSOLE\TEST");
            DI.Delete(true);
        }
    }
}
