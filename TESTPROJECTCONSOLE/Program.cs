using System;
using System.IO;

namespace TESTPROJECTCONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckDirectory();
            View();

            Console.WriteLine("Hello! You wanna create [1], edit[2], delete[3] or view [4] notes?");
            var number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Create(); ///Метод должен получать переменную в виде номера заметки
                    break;
                case 2:
                    Edit();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    View();
                    break;
                default:
                    Console.WriteLine("Not found :( ");
                    break;
            }
            Console.ReadLine();
        }
        static void CheckDirectory()
        {
            if (Directory.Exists("Notes") == false)
            {
                Directory.CreateDirectory("Notes");
            }

            if (Directory.GetFiles("Notes") == null)
            {
                File.WriteAllText(@"Notes\0.txt", "My first notes");
            }
        }
        static void Create()
        {
            Console.WriteLine("You choice create. Let's started!");
            var text = Console.ReadLine();
            Console.WriteLine("Do you wanna save notes? Yes/No");
            var ask = Console.ReadLine();
            if (ask == "Yes")
            {
                var place = new DirectoryInfo(@"Notes");
                var files = place.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name != i.ToString() + ".txt")
                    {
                        File.WriteAllText(@"Notes\" + i + ".txt", text);
                        Console.WriteLine("Saved!");
                        break;
                    }
                }
            }
            else if (ask == "No")
            {
                Console.WriteLine("You choiсe No. Goodbye!");
                Console.ReadKey();
            }
        }
        static void Edit()
        {
            Console.WriteLine("You choice edit!");
            const string direc = @"Notes\";
            var files = Directory.GetFiles(direc);
            for (var i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{ i}) {Path.GetFileName(files[i])}");
            }

            while (true)
            {
                Console.WriteLine("Enter the number of the file you would like to see or 987 to exit");
                var choice = Console.ReadLine();
                
                if (int.TryParse(choice, out var index) && index > -2 && index < files.Length)
                {
                    if (index == 987)
                    return;
                    string[] chosenFiles = File.ReadAllLines(files[index]);
                    foreach (string file in chosenFiles)
                    {
                        Console.WriteLine("You choice file " + files[index]);
                        var text = Console.ReadLine();
                        File.WriteAllText(files[index], text);
                        Console.WriteLine("Saved!");
                    }
                }
                else
                    Console.WriteLine("Wrong. Try again, please.");
            }
        }
        static void View()
        {
            Console.WriteLine("You choice see notes!");
            var place = new DirectoryInfo(@"Notes\");
            var files = place.GetFiles();
            Console.WriteLine("Files are:");
            int i = 0;
            foreach (var fil in files)
            {
                var stringFile = File.ReadAllLines(place + fil.Name);
                Console.WriteLine(fil.Name.Remove(fil.Name.IndexOf(".")) + ") " + stringFile[0]);
                i++;
            }
        }
        static void Delete()
        {
            Console.WriteLine("You choice delete. Choose the note you need!");
            DirectoryInfo DI = new DirectoryInfo(@"Notes");
            DI.Delete(true);
        }
    }
}
