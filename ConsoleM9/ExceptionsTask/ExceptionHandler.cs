using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleM9
{ 
    internal class ExceptionHandler
    {
        public List<Exception> exceptions { get; private set; }

        public void RunHandler()
        {
            CreateExceptions();
            foreach(Exception exp in exceptions)
            {
                Console.WriteLine();
                if (exp is ArgumentNullException)
                {
                    Console.WriteLine("Вызов исключения - ArgumentNullException");
                    try
                    {
                        ArgumentNullHandler(null);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                if (exp is DirectoryNotFoundException)
                {
                    Console.WriteLine("Вызов исключения - DirectoryNotFoundException");
                    try
                    {
                        DirectoryNotFoundHandler();
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                if (exp is DivideByZeroException)
                {
                    Console.WriteLine("Вызов исключения - DivideByZeroException");
                    try
                    {
                        int number1 = 5;
                        int number2 = 0;
                        double result = number1 / number2;
                        Console.WriteLine(result);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                if (exp is IndexOutOfRangeException)
                {
                    Console.WriteLine("Вызов исключения - IndexOutOfRangeException");
                    try
                    {
                        int[] numbers = { 1, 2, 3 };
                        int result = numbers[10];
                        Console.WriteLine(result);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                if (exp is IncorrectChoiceException)
                {
                    Console.WriteLine("Вызов исключения - IncorrectChoiceException");
                    try
                    {
                        IncorrectChoiceHandler();
                    }
                    catch (IncorrectChoiceException)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }

            }
        }

        private void ArgumentNullHandler(string argument)
        {
            if (argument == null) throw new ArgumentNullException();
        }

        private void DirectoryNotFoundHandler()
        {
            string wrongPath = "Wrong path";
            if (!Directory.Exists(wrongPath))
            {
                throw new DirectoryNotFoundException("Директория не найдена.");
            }
        }

        private void IncorrectChoiceHandler()
        {
            Console.WriteLine("Сделайте выбор 1 или 2");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice != 1 && choice != 2) throw new IncorrectChoiceException();
        }
        private void CreateExceptions()
        {
            exceptions = new List<Exception>();

            ArgumentNullException exception = new ArgumentNullException("Argument null exception");
            exceptions.Add(exception);

            DirectoryNotFoundException directoryNotFoundException = new DirectoryNotFoundException("Directory not found exception");
            exceptions.Add(directoryNotFoundException);

            DivideByZeroException divideByZeroException = new DivideByZeroException("Devided by zero exception");
            exceptions.Add(divideByZeroException);

            IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException("Index out of range exception");
            exceptions.Add(indexOutOfRangeException);

            IncorrectChoiceException incorrectChoiceException = new IncorrectChoiceException("Incorrect choice expetion");
            exceptions.Add(incorrectChoiceException);

        }
    }
}
