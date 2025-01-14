using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleM9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;
            while (isContinue) 
            {
                try
                {
                    TaskSelection();
                    isContinue = false;
                }
                catch (IncorrectChoiceException)
                {
                    Console.WriteLine("Вы сделали неверный выбор. Только 1 или 2");
                }
            }
            Console.WriteLine("\n Задание выполнено.");
            Console.ReadKey();
        }

        static void TaskSelection()
        {
            Console.WriteLine("\nВыберете номер задачи для выполнения: 1 или 2");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice != 1 && choice != 2) throw new IncorrectChoiceException();

            switch (choice) {
                case 1: 
                    DisplayTask("Task1.txt");
                    ExceptionHandler excHandler = new ExceptionHandler();
                    excHandler.RunHandler();
                    break;
                case 2:
                    DisplayTask("Task2.txt");
                    break;
            }
        }

        static void DisplayTask(string fileName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(executableLocation, fileName);

            if (File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }

        }
    }

}
